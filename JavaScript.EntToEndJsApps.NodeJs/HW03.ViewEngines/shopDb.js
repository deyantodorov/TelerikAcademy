var PRODUCTS = 15;

function makeMenu() {
    return [
        {
            title: 'Home',
            url: 'home'
        }
        , {
            title: 'Smart phones',
            url: 'phones'
        }
        , {
            title: 'Tablets',
            url: 'tablets'
        }
        , {
            title: 'Wearables',
            url: 'wearables'
        }
    ];
}

function makePhones() {
    var phones = [];

    for (var i = 0; i < PRODUCTS; i += 1) {
        phones.push({
            model: 'Phone ' + (i + 1),
            screenSize: (i % 2) ? 4 : 5,
            price: (i % 2) ? 150 : 160
        });
    }

    return phones;
}

function makeTablets() {
    var tablets = [];

    for (var i = 0; i < PRODUCTS; i += 1) {
        tablets.push({
            model: 'Tablet ' + (i + 1),
            screenSize: (i % 2) ? 7 : 10,
            price: (i % 2) ? 350 : 460
        });
    }

    return tablets;
}

function makeWearables() {
    var wearables = [];

    for (var i = 0; i < PRODUCTS; i += 1) {
        wearables.push({
            model: 'Wearable ' + (i + 1),
            screenSize: (i % 2) ? 3 : 4,
            price: (i % 2) ? 550 : 660
        });
    }

    return wearables;
}

module.exports = {
    menu: makeMenu,
    phones: makePhones,
    tablets: makeTablets,
    wearables: makeWearables
};