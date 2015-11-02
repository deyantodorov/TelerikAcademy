var songController = (function () {
    'use strict';

    function getAll(context) {
        var songs;

        data.songs.getAll()
            .then(function (data) {
                //console.log(data);
                songs = data;
                return templates.get('song');
            })
            .then(function (template) {
                context.$element().html(template(songs));

                $('.edit-song').on('click', function () {
                    var $that = $(this);
                    var id = $that.parent().parent().attr("data-id");

                    context.redirect('#/songs/edit/' + id);
                });

                $('.delete-song').on('click', function () {
                    var $that = $(this);
                    var id = $that.parent().parent().attr("data-id");

                    remove(id);
                });
            });
    }

    function add(context) {
        templates.get('song-add')
            .then(function (template) {
                context.$element().html(template());

                $('#btn-add-song').on('click', function () {
                    var song = {
                        genre: $('#tb-genre').val(),
                        title: $('#tb-title').val(),
                        year: $('#tb-year').val()
                    }

                    //console.log(song);

                    if (!validator.length(song.title)) {
                        toastr.error('Title, must be length between 2 and 150.');
                        return;
                    }

                    if (!validator.length(song.year)) {
                        toastr.error('Year, must be length between 2 and 150.');
                        return;
                    }

                    if (!validator.length(song.genre)) {
                        toastr.error('Genre, must be length between 2 and 150.');
                        return;
                    }

                    data.songs.add(song)
                        .then(function () {
                            toastr.success('Song added!');
                            context.redirect('#/songs');
                        });
                });
            });
    }

    function edit(context) {
        var song,
            id = context.params.id;

        data.songs.edit(id)
            .then(function (data) {
                song = data;
                return templates.get('song-edit');
            })
            .then(function (template) {
                context.$element().html(template(song));

                $('#btn-update-song').on('click', function () {
                    var song = {
                        genre: $('#tb-genre').val(),
                        title: $('#tb-title').val(),
                        year: $('#tb-year').val()
                    }

                    //console.log(song);

                    if (!validator.length(song.title)) {
                        toastr.error('Title, must be length between 2 and 150.');
                        return;
                    }

                    if (!validator.length(song.year)) {
                        toastr.error('Year, must be length between 2 and 150.');
                        return;
                    }

                    if (!validator.length(song.genre)) {
                        toastr.error('Genre, must be length between 2 and 150.');
                        return;
                    }

                    data.songs.edit(id, song)
                        .then(function () {
                            toastr.success('Song updated!');
                            context.redirect('#/songs');
                        });
                });
            });
    }

    function remove(id) {
        //console.log(id);

        if (confirm("Are you sure?")) {
            data.songs.remove(id);
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