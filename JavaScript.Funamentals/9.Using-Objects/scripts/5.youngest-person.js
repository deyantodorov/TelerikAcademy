(function (){
    'use strict';

    function Person(firstName, lastName, personAge) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = personAge;

        Person.prototype.toString = function () {
            return this.firstName + ' ' + this.lastName + ' ' + this.age;
        };
    }

    function groupByAge(obj, param) {
        var newObj = [];

        if (param === 'age') {

            newObj = obj.sort(function (a, b) {
                return a[param] > b[param] ? 1 : -1;
            });

        } else {

            return undefined;
        }

        return newObj;
    }

    var persons = [
        new Person('Gosho', 'Petrov', 32),
        new Person('Bay', 'Ivan', 81),
        new Person('Spaska', 'Paskova', 12),
        new Person('Spiro', 'Nikodimv', 18)
    ];

    console.log("List of persons: ");
    console.log(persons.join(' '));

    console.log("");

    console.log("Result: ");
    console.log("Youngest person is: " + groupByAge(persons, 'age')[0]);
}());