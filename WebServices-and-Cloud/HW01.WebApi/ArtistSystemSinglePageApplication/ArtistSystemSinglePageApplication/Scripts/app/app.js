(function(){
    'use strict';

    var sammyApp = Sammy('#main', function () {
        this.get('#/', function(context) {
            context.redirect('#/songs');
        });
        this.get('#/songs', songController.getAll);
        this.get('#/songs/add', songController.add);
        this.get('#/songs/edit/:id', songController.edit);

        this.get('#/artists', artistController.getAll);
        this.get('#/artists/add', artistController.add);
        this.get('#/artists/edit/:id', artistController.edit);

        this.get('#/albums', albumController.getAll);
        this.get('#/albums/add', albumController.add);
        this.get('#/albums/edit/:id', albumController.edit);
    });

    $(function(){
        sammyApp.run('#/');
    });
}());