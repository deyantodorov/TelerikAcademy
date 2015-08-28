(function () {
    'use strict';

    function generateList(obj, template) {

        // Add UL and LI elements
        function createULandLI(template) {

            template = template.trim();
            var arr = template.match(/[^ ]+/g);

            for (var i = 0, len = arr.length; i < len; i++) {

                var visited = false;

                if (arr[i].indexOf("</") > -1) {

                    if (i === len - 1) {
                        arr[i] = arr[i] + "</li></ul>";
                        visited = true;
                    }
                    else {
                        arr[i] = arr[i] + "</li>";
                        visited = true;
                    }
                }

                if (!visited && arr[i].indexOf("<") > -1) {
                    if (i === 0) {
                        arr[i] = "<ul><li>" + arr[i];
                    }
                    else {
                        arr[i] = "<li>" + arr[i];
                    }
                }
            }

            return arr.join(" ");
        }

        var i, j, lenI, lenJ, keys, key, value, str, result = "", defaultTemp, endResult = "";

        // Generate ul li etc..
        template = createULandLI(template);

        defaultTemp = template;

        for (i = 0, lenI = obj.length; i < lenI; i++) {

            // fill property names
            keys = Object.getOwnPropertyNames(obj[i]);

            for (j = 0, lenJ = keys.length; j < lenJ; j++) {

                key = keys[j];
                value = obj[i][key];

                // Make search pattern
                str = "-{" + key + "}-";

                while (template.indexOf(str) > -1) {

                    result = template.replace(str, value);
                    template = result;

                    //alert(result);
                }
            }

            endResult += result;
            template = defaultTemp;
        }

        return endResult;
    }

    var temp = document.getElementById("list-item").innerHTML;

    var people = [
        {
            name: "Peter Petrov Ivanov Goshev",
            age: 14
        },
        {
            name: "Cakov Vakov",
            age: 86
        },
        {
            name: "Spirko Nikodimov Ostrev Surogvinov",
            age: 2
        }

    ];

    var peopleList = generateList(people, temp);
    document.getElementById("result").innerHTML = peopleList;
}());