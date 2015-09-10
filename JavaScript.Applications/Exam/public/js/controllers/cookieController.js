var cookieController = (function () {
    'use strict';

    function getAll(context) {
        var cookies;
        var category = context.params.category || null;
        var likes = context.params.likes || null;
        var shareDate = context.params.shareDate || null;

        data.cookies.getAll()
            .then(function (resCookies) {
                cookies = _.chain(resCookies)
                    .groupBy(controllerHelpers.groupByCategory)
                    .map(controllerHelpers.parseGroups).value();

                if (category) {
                    cookies = cookies.filter(controllerHelpers.filterByCategory(category));
                }

                if (likes) {
                    console.log(cookies);
                }

                if (shareDate) {
                    console.log(cookies);
                }

                //console.log(cookies);

                return templates.get('cookies');

            })
            .then(function (template) {
                context.$element().html(template(cookies));
            });
    }

    function add(context) {
        templates.get('add-cookie')
            .then(function (template) {
                context.$element().html(template());
                //return data.categories.get();

                if (!data.users.hasUser()) {
                    toastr.error('You must be logged in to share cookies');
                    context.redirect('#/login');
                    return;
                }

                $('#btn-share').on('click', function () {
                    var cookie = {
                        text: $('#tb-text').val(),
                        category: $('#tb-category').val(),
                        img: $('#tb-img').val()
                    };

                    if (!validator.length(cookie.text)) {
                        toastr.error('TEXT. Must be length between 6 and 30.');
                        return;
                    }

                    if (!validator.length(cookie.category)) {
                        toastr.error('CATEGORY. Must be length between 6 and 30.');
                        return;
                    }

                    if (cookie.img !== '' && !validator.url(cookie.img)) {
                        toastr.error('Invalid Image Source');
                        return;
                    }

                    //console.log(cookie);

                    data.cookies.add(cookie)
                        .then(function () {
                            toastr.success('Cookie shared!');
                            context.redirect('#/home');
                        })
                        .catch(function () {
                            toastr.error('You must be logged in to share cookies');
                            context.redirect('#/login');
                        })
                });
            });
    }

    function cookiesGetMyCookie(context) {
        var cookies;

        if (!data.users.hasUser()) {
            toastr.error('You must be logged in see your cookies');
            context.redirect('#/login');
            return;
        }

        data.cookies.getMyCookie()
            .then(function (res) {
                cookies = res;
                //console.log(cookies);
                return templates.get('my-cookie');
            })
            .then(function (template) {
                context.$element().html(template(cookies));
            })
            .catch(function (err) {
                toastr.error('You must be logged in to see Your Fortune Cookies');
                context.redirect('#/login');
            });
    }

    function like(context) {
        var id = context.params.id;
        //console.log('like ' + context.params.id);

        if (!data.users.hasUser()) {
            toastr.error('You must be logged in to like');
            context.redirect('#/login');
            return;
        }

        data.cookies.like(id);
        context.redirect('#/home');
    }

    function dislike(context) {
        var id = context.params.id;
        //console.log('like ' + context.params.id);

        if (!data.users.hasUser()) {
            toastr.error('You must be logged in to dislike');
            context.redirect('#/login');
            return;
        }

        data.cookies.dislike(id);
        context.redirect('#/home');
    }

    function reshare(context) {
        var id = context.params.id;
        //console.log('like ' + context.params.id);

        if (!data.users.hasUser()) {
            toastr.error('You must be logged in to reshare');
            context.redirect('#/login');
            return;
        }

        data.cookies.getAll()
            .then(function (res) {
                var searched,
                    i,
                    len;

                for (i = 0, len = res.length; i < len; i += 1) {
                    if (res[i].id === id) {
                        searched = res[i];
                    }
                }

                var cookie = {
                    text: searched.text,
                    category: searched.category,
                    img: searched.img
                };

                data.cookies.add(cookie)
                    .then(function () {
                        toastr.success('Cookie Re-Shared!');
                        context.redirect('#/home');
                    })
                    .catch(function () {
                        toastr.error('You must be logged in to Re-Shared cookies');
                        context.redirect('#/login');
                    });
            });

        data.cookies.reshare(id);
        context.redirect('#/home');
    }

    return {
        getAll: getAll,
        getMyCookie: cookiesGetMyCookie,
        add: add,
        like: like,
        dislike: dislike,
        reshare: reshare,
    };
}());
//
//this.get('#/cookie/like', cookieController.like);
//this.get('#/cookie/dislike', cookieController.dislike);
//this.get('#/cookie/reshare', cookieController.reshare);