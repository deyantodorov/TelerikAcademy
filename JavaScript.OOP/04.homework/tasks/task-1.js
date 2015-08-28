/* Task Description */
/* 
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error 		
	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	*	all methods and properties must be attached to the prototype of the Person
	*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {
	var Person = (function() {

		function validateName(input) {
			var i,
				len,
				codeNum,
				name = input;

			if (name.length < 3) {
				throw new Error('Name is too short');
			} else if (name.length > 20) {
				throw new Error('Name is too long');
			}

			for (i = 0, len = input.length; i < len; i += 1) {
				codeNum = input.charCodeAt(i);

				if (codeNum < 65 || codeNum > 122) {
					throw new Error('Invalid symbol for name');
				}
			}


			return name;
		}

		function validateAge(age) {
			var newAge = +age;

			if (newAge === NaN) {
				throw new Error('Invalid age');
			} else if (newAge < 0) {
				throw new Error('You are impossible young');
			} else if (newAge > 150) {
				throw new Error('You are impossible old');
			}

			return newAge;
		}

		function Person(firstname, lastname, age) {
			this.firstname = validateName(firstname);
			this.lastname = validateName(lastname);
			this.age = validateAge(age);
		}

		Object.defineProperty(Person.prototype, 'fullname', {
			get: function() {
				return this.firstname + ' ' + this.lastname;
			},
			set: function(fullname) {
				var name = fullname.split(' '),
					fname = validateName(name[0]),
					lname = validateName(name[1]);

				this.firstname = fname;
				this.lastname = lname;
			}
		});

		Person.prototype.introduce = function() {
			return 'Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old';
		};

		return Person;
	}());
	return Person;
}
module.exports = solve;