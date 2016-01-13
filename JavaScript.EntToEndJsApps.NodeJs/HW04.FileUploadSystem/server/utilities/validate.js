module.exports = {
    passwordsNotMatch: function (pass, confPass) {
        return pass !== confPass;
    },
    userIsBlank: function (user) {
        if (!user) {
            return true;
        } else if (user.username === '' || user.password === '' || user.confirmPasswrod === '') {
            return true;
        } else {
            return false;
        }
    },
    range: function (min, max, val) {
        return val >= min && val <= max;
    }
};