module.exports = {
    getDate: function () {
        var today = new Date();
        var d = today.getDate();
        var m = today.getMonth() + 1;
        var y = today.getFullYear();

        if (d < 10) {
            d = '0' + d;
        }

        if (m < 10) {
            m = '0' + m;
        }

        var today = d + '-' + m + '-' + y;
        return today;
    }
};