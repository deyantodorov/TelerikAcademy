var data = (function () {
    'use strict';

    var SONGS_PATH = 'http://localhost:49274/api/songs/';
    var ARTISTS_PATH = 'http://localhost:49274/api/artists/';
    var ALBUMS_PATH = 'http://localhost:49274/api/albums/';

    /* SONGS */
    
    function getAllSongs() {
        return jsonRequester.get(SONGS_PATH)
            .then(function (data) {
                return data;
            });
    }

    function addSong(song) {
        var options = {
            data: song
        };

        return jsonRequester.post(SONGS_PATH, options)
            .then(function (resp) {
                return resp;
            });
    }

    function editSong(id, song) {
        if (song === undefined) {
            return jsonRequester.get(SONGS_PATH + id)
                .then(function(data) {
                    return data;
                });
        } else {
        var options = {
            data: song
        };

        return jsonRequester.put(SONGS_PATH + id, options)
            .then(function (resp) {
                return resp;
            });
        }
    }

    function removeSong(id) {
        jsonRequester.del(SONGS_PATH + id);
    }

    /* ARTISTS */

    function getAllArtists() {
        return jsonRequester.get(ARTISTS_PATH)
            .then(function (data) {
                return data;
            });
    }

    function addArtist(artist) {
        var options = {
            data: artist
        };

        return jsonRequester.post(ARTISTS_PATH, options)
            .then(function (resp) {
                return resp;
            });
    }

    function editArtist(id, artist) {
        if (artist === undefined) {
            return jsonRequester.get(ARTISTS_PATH + id)
                .then(function (data) {
                    return data;
                });
        } else {
            var options = {
                data: artist
            };

            return jsonRequester.put(ARTISTS_PATH + id, options)
                .then(function (resp) {
                    return resp;
                });
        }
    }

    function removeArtist(id) {
        jsonRequester.del(ARTISTS_PATH + id);
    }

    /* ALBUMS */

    function getAllAlbums() {
        return jsonRequester.get(ALBUMS_PATH)
            .then(function (data) {
                return data;
            });
    }

    function addAlbum(album) {
        var options = {
            data: album
        };

        return jsonRequester.post(ALBUMS_PATH, options)
            .then(function (resp) {
                return resp;
            });
    }

    function editAlbum(id, album) {
        if (album === undefined) {
            return jsonRequester.get(ALBUMS_PATH + id)
                .then(function (data) {
                    return data;
                });
        } else {
            var options = {
                data: album
            };

            return jsonRequester.put(ALBUMS_PATH + id, options)
                .then(function (resp) {
                    return resp;
                });
        }
    }

    function removeAlbum(id) {
        jsonRequester.del(ALBUMS_PATH + id);
    }

    return {
        songs: {
            getAll: getAllSongs,
            add: addSong,
            edit: editSong,
            remove: removeSong
        },
        artists: {
            getAll: getAllArtists,
            add: addArtist,
            edit: editArtist,
            remove: removeArtist
        },
        albums: {
            getAll: getAllAlbums,
            add: addAlbum,
            edit: editAlbum,
            remove: removeAlbum
        }
    }
}());