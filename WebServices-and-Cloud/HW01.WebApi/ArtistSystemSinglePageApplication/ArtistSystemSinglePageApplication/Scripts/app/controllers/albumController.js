var albumController = (function () {
    'use strict';

    function getAll(context) {
        var albums;

        data.albums.getAll()
            .then(function (data) {
                //console.log(data);
                albums = data;
                return templates.get('album');
            })
            .then(function (template) {
                context.$element().html(template(albums));

                $('.edit-album').on('click', function () {
                    var $that = $(this);
                    var id = $that.parent().parent().attr("data-id");

                    context.redirect('#/albums/edit/' + id);
                });

                $('.delete-album').on('click', function () {
                    var $that = $(this);
                    var id = $that.parent().parent().attr("data-id");

                    remove(id);
                });
            });
    }

    function add(context) {
        templates.get('album-add')
           .then(function (template) {
               context.$element().html(template());

               $('#btn-add-album').on('click', function () {
                   var album = {
                       title: $('#tb-title').val(),
                       releasedate: $('#tb-releasedate').val(),
                       producer: $('#tb-producer').val()
                   }

                   //console.log(album);

                   if (!validator.length(album.title)) {
                       toastr.error('title, must be length between 2 and 150.');
                       return;
                   }

                   if (!validator.length(album.producer)) {
                       toastr.error('producer, must be length between 2 and 150.');
                       return;
                   }

                   data.albums.add(album)
                       .then(function () {
                           toastr.success('Album added!');
                           context.redirect('#/albums');
                       });
               });
           });
    }

    function edit(context) {
        var album,
            id = context.params.id;

        data.albums.edit(id)
            .then(function (data) {
                album = data;
                return templates.get('album-edit');
            })
            .then(function (template) {
                context.$element().html(template(album));

                $('#btn-update-album').on('click', function () {
                    var album = {
                        title: $('#tb-title').val(),
                        releasedate: $('#tb-releasedate').val(),
                        producer: $('#tb-producer').val()
                    }

                    //console.log(artist);

                    if (!validator.length(album.title)) {
                        toastr.error('title, must be length between 2 and 150.');
                        return;
                    }

                    if (!validator.length(album.producer)) {
                        toastr.error('producer, must be length between 2 and 150.');
                        return;
                    }

                    data.albums.edit(id, album)
                        .then(function () {
                            toastr.success('Album updated!');
                            context.redirect('#/albums');
                        });
                });
            });
    }

    function remove(id) {
        if (confirm("Are you sure?")) {
            data.albums.remove(id);
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