/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and ISBN
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 *	Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
	var library = (function () {
		var books = [];
		var categories = [];

		function listBooks(args) {
			if (arguments.length > 0) {
				if (typeof args.category !== 'undefined') {
					return typeof categories[args.category] !== 'undefined' ? categories[args.category].books : [];
				}

				if (typeof args.author !== 'undefined') {
					var i,
						len,
						bookResult = [];

					for (i = 0, len = books.length; i < len; i += 1) {
						if (books[i].author === args.author) {
							bookResult.push(books[i]);
						}
					}
					
					return bookResult;
				}
			}

			return books;
		}

		function addBook(book) {
			book.ID = books.length + 1;

			if (categories.indexOf(book.category) < 0) {
				addNewCategory(book.category);
			}

			validateTitle(book);
			validateIsbn(book);
			validateAuthor(book);
			validateCategory(book);

			books.push(book);
			categories[book.category].books.push(book);

			return book;
		}

		function addNewCategory(category) {
			categories[category] = {
				books: [],
				ID: categories.length + 1
			};
		}
		
		// unique title
		// Book title name must be between 2 and 100 characters
		function validateTitle(book) {
			var title = book.title || '';

			if (title.length < 2 || title.length > 100) {
				throw new Error('Title is missing or too short');
			}

			books.forEach(function (item) {
				if (item.title === title) {
					throw new Error('Title already exist');
				}
			});
		}

		// Unique Book ISBN
		function validateIsbn(book) {
			var isbn = book.isbn;

			// Test length
			if (isbn.length < 10) {
				throw new Error('ISBN is too short');
			} else if (isbn.length > 13) {
				throw new Error('ISBN is too long');
			} else if (isNaN(parseInt(isbn + ''))) {
				throw new Error('ISBN is not a number')
			}

			books.forEach(function (item) {
				if (item.isbn === isbn) {
					throw new Error('ISBN already exist');
				}
			});
		}

		function validateAuthor(book) {
			var author = book.author || '';

			if (author.length === 0) {
				throw new Error('Invalid author');
			}
		}

		// Book category name must be between 2 and 100 characters
		function validateCategory(book) {
			var category = book.category || '';

			if (category.length < 2) {
				throw new Error('Category name is too short');
			} else if (category.length > 100) {
				throw new Error('Category name is too long');
			}
		}

		function listCategories() {
			var result = [];
			Array.prototype.push.apply(result, Object.keys(categories));
			return result;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());
	return library;
}

module.exports = solve;