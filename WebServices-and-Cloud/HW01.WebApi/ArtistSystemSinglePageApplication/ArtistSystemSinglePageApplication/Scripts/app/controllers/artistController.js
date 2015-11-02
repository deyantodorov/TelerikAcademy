var artistController = (function () {
    'use strict';

    function getAll(context) {
        var artists;

        data.artists.getAll()
            .then(function (data) {
                //console.log(data);
                artists = data;
                return templates.get('artist');
            })
            .then(function (template) {
                context.$element().html(template(artists));

                $('.edit-artist').on('click', function () {
                    var $that = $(this);
                    var id = $that.parent().parent().attr("data-id");

                    context.redirect('#/artists/edit/' + id);
                });

                $('.delete-artist').on('click', function () {
                    var $that = $(this);
                    var id = $that.parent().parent().attr("data-id");

                    remove(id);
                });
            });
    }

    function add(context) {
        templates.get('artist-add')
           .then(function (template) {
               context.$element().html(template());

               $('#btn-add-artist').on('click', function () {
                   var artist = {
                       name: $('#tb-name').val(),
                       country: $('#tb-country').val(),
                       birthdate: $('#tb-birthdate').val()
                   }

                   //console.log(artist);

                   if (!validator.length(artist.name)) {
                       toastr.error('name, must be length between 2 and 150.');
                       return;
                   }

                   if (!validator.length(artist.country)) {
                       toastr.error('country, must be length between 2 and 150.');
                       return;
                   }

                   if (!validator.length(artist.birthdate)) {
                       toastr.error('birthdate, must be length between 2 and 150.');
                       return;
                   }

                   data.artists.add(artist)
                       .then(function () {
                           toastr.success('Artist added!');
                           context.redirect('#/artists');
                       });
               });
           });
    }

    function edit(context) {
        var artist,
            id = context.params.id;

        data.artists.edit(id)
            .then(function (data) {
                artist = data;
                return templates.get('artist-edit');
            })
            .then(function (template) {
                context.$element().html(template(artist));

                $('#btn-update-artist').on('click', function () {
                    var artist = {
                        name: $('#tb-name').val(),
                        country: $('#tb-country').val(),
                        birthdate: $('#tb-birthdate').val()
                    }

                    //console.log(artist);

                    if (!validator.length(artist.name)) {
                        toastr.error('name, must be length between 2 and 150.');
                        return;
                    }

                    if (!validator.length(artist.country)) {
                        toastr.error('country, must be length between 2 and 150.');
                        return;
                    }

                    if (!validator.length(artist.birthdate)) {
                        toastr.error('birthdate, must be length between 2 and 150.');
                        return;
                    }

                    data.artists.edit(id, artist)
                        .then(function () {
                            toastr.success('Artist updated!');
                            context.redirect('#/artists');
                        });
                });
            });
    }

    function remove(id) {
        if (confirm("Are you sure?")) {
            data.artists.remove(id);
            document.location.reload(true);
        }
    }

    return {
        getAll: getAll,
        add: add,
        edit: edit,
        remove: remove
    }
}());