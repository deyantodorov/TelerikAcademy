(function() {
	'use strict';

	String.prototype.format = function(options) {
		var prop,
			regex,
			param,
			text = this;

		for (prop in options) {
			param = prop;
			param = '#{' + param + '}';
			regex = new RegExp(param, 'gim');
			text = text.replace(regex, options[prop]);
		}

		return text;
	};

	var options = {
		name: 'John',
		age: 123,
	};
	var text = 'Hello, there! Are you #{name}?'.format(options);
	console.log(text);

	var options2 = {
		name: 'John',
		age: 13
	};
	var text2 = 'My name is #{name} and I am #{age}-years-old'.format(options2);
	console.log(text2);
}());