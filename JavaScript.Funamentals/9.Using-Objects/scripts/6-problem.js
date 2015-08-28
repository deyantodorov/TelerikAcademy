(function (){
    'use strict';

    function Person(firstName, lastName, personAge) {
        this.firstname = firstName;
        this.lastname = lastName;
        this.age = personAge;

        Person.prototype.toString = function () {
            return this.firstname + ' ' + this.lastname + ' ' + this.age;
        };
    }

    // Group implementation
    function group(obj, param) {

        var newObj = [];

        if (param === 'firstname' || param === 'lastname' || param === 'age') {

            newObj = obj.sort(function (a, b) {
                return a[param] > b[param] ? 1 : -1;
            });

        } else {

            return undefined;
        }

        return newObj;
    }

    // Test example:
    var persons = [
        new Person('Spaska', 'Paskova', 12),
        new Person('Gosho', 'Petrov', 32),
        new Person('Bay', 'Ivan', 81),
        new Person('Spiro', 'Nikodimv', 18)
    ];

    console.log("Default order:");
    console.log(persons.join(' '));
    console.log(' ');

    // Firstname test
    var groupedByFname = group(persons, "firstname");
    console.log("Grouped by 'firstname': ");
    console.log(groupedByFname.join(' '));
    console.log(' ');

    // Lastname test
    var groupedByLname = group(persons, "lastname");
    console.log("Grouped by 'lastname': ");
    console.log(groupedByLname.join(' '));
    console.log("");

    // Age test
    console.log("Grouped by 'age': ");
    var groupedByAge = group(persons, "age");
    console.log(groupedByAge.join(' '));
    console.log("");

    // Undefined test
    var groupedBySex = group(persons, "sex");
    console.log(groupedBySex);
}());