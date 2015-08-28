(function() {
	'use strict';

	String.prototype.bind = function(text, parameters) {
		var regexContent,
			regexHref,
			regexClass,
			prop,
			text = this;

		for (prop in parameters) {
			regexContent = new RegExp('(<.*?data-bind-content="' + prop + '".*?>)(.*?)(<\\s*/.*?>)', 'g');
			regexHref = new RegExp('(<.*?data-bind-href="' + prop + '".*?)>', 'g');
			regexClass = new RegExp('(<.*?data-bind-class="(' + prop + ')".*?)>', 'g');

			text = text.replace(regexContent, function(element, openingTag, content, closingTag) {
				return openingTag + parameters[prop] + closingTag;
			});

			text = text.replace(regexHref, function(tag, contentBeforeClosing) {
				return contentBeforeClosing + ' href="' + parameters[prop] + '">';
			});

			text = text.replace(regexClass, function(tag, contentBeforeClosing) {
				return contentBeforeClosing + ' class="' + parameters[prop] + '">';
			});
		}

		return text;
	};

	console.log('<div data-bind-content="name"></div>'.bind('', {
		name: 'Steven'
	}));

	console.log('<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>'.bind('', {
		name: 'Elena',
		link: 'http://telerikacademy.com'
	}));
}());