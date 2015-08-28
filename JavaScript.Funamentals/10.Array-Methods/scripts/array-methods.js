(function() {
	'use strict';

	var Person = function(firstname, lastname, age, gender) {
		this.firstname = firstname;
		this.lastname = lastname;
		this.age = age;
		this.gender = gender ? 'Female' : 'Male';

		Person.prototype.toString = function() {
			return 'Hello I am ' + this.firstname + ' ' + this.lastname + ', age: ' + this.age + ', sex: ' + this.sex;
		};
	};

	var random = function(min, max) {
		return Math.floor((Math.random() * max) + min);
	};

	// Tasks: https://github.com/TelerikAcademy/JavaScript-Fundamentals/tree/master/10.%20Array%20Methods
	var i,
		person,
		names = ['Jack', 'Thomas', 'Joshua', 'William', 'Daniel', 'Matthew', 'James', 'Joseph', 'Harry', 'Samuel', 'Emily', 'Chloe', 'Megan', 'Jessica', 'Emma', 'Sarah', 'Elizabeth', 'Sophie', 'Olivia', 'Lauren'],
		persons = [];

	// Problem 1. Make person
	for (i = 0; i < 10; i += 1) {
		// sort of random name generations
		person = new Person(names[random(0, names.length - 1)], names[random(0, names.length - 1)], random(10, 80), (i % 2) ? 0 : 1);
		persons[i] = person;
	}

	console.log('Problem 1:');
	console.log(persons);

	// Problem 2. People of age
	// Filter
	(function() {
		var above18 = persons.filter(function(p) {
			return p.age >= 18;
		});

		console.log('\n' + 'Problem 2 - filter:');
		console.log(above18);
	}());

	// forEach
	(function() {
		var above18 = [];

		persons.forEach(function(p) {
			if (p.age >= 18) {
				above18.push(p);
			}
		});

		console.log('\n' + 'Problem 2 - forEach:');
		console.log(above18);
	}());

	// Problem 3. Underage people
	(function() {
		var age = 40,
			underage = persons.filter(function(p) {
				return p.age <= age;
			});

		console.log('\n' + 'Problem 3 - filter:');
		console.log(underage);
	}());

	// forEach
	(function() {
		var age = 40,
			underage = [];

		persons.forEach(function(p) {
			if (p.age <= age) {
				underage.push(p);
			}
		});

		console.log('\n' + 'Problem 3 - forEach:');
		console.log(underage);
	}());

	// Problem 4. Average age of females
	(function() {
		var age = 0,
			count = 0,
			females = persons.filter(function(person) {
				if (person.gender === 'Female') {
					age += person.age;
					count += 1;
					return person;
				}
			});

		console.log('\n' + 'Problem 4. Average age of females');
		console.log(females);
		console.log('Average age is: ' + (age / count));
	}());

	// Problem 5. Youngest person
	(function() {
		if (!Array.prototype.find) {
			Array.prototype.find = function(callback) {
				var i, len = this.length;
				for (i = 0; i < len; i += 1) {
					if (callback(this[i], i, this)) {
						return this[i];
					}
				}
			}
		}

		var personIndex = 0,
			minAge = Number.MAX_VALUE,
			person = persons.find(function(item, index) {

				if (minAge >= item.age) {
					minAge = item.age;
					personIndex = index;
				}
			});

		console.log('\n' + 'Problem 5. Youngest person');
		console.log(persons[personIndex].firstname + ' ' + persons[personIndex].lastname + ', age: ' + persons[personIndex].age);
	}());

	// Problem 6. Group people
	(function() {
		var groups = persons.reduce(function(gr, person) {
			var letter = person.firstname[0].toLowerCase();

			if (!gr[letter]) {
				gr[letter] = [];
				gr[letter].push(person);
			} else {
				gr[letter].push(person);
			}

			return gr;
		});

		console.log('\n' + 'Problem 6. Group people');
		console.log(groups);
	}());
}());