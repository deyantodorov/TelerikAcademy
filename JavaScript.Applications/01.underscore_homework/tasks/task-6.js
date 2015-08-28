/* 
 Create a function that:
 *   **Takes** a collection of books
 *   Each book has propeties `title` and `author`
 **  `author` is an object that has properties `firstName` and `lastName`
 *   **finds** the most popular author (the author with biggest number of books)
 *   **prints** the author to the console
 *	if there is more than one author print them all sorted in ascending order by fullname
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

function solve() {
    return function (books) {
        var _ = require('underscore');

        function hasAuthor(array, authorFullName) {
            var i,
                len;

            for (i = 0, len = array.length; i < len; i += 1) {
                if (array[i].authorFullName === authorFullName) {
                    return i;
                }
            }

            return -1;
        }

        var i,
            len,
            currentBooks,
            nextBooks,
            topAuthors = [],
            authors = [];

        _.each(books, function (book) {
            var authorFullName = book.author.firstName + ' ' + book.author.lastName;
            var authorIndex = hasAuthor(authors, authorFullName);

            if (authorIndex !== -1) {
                authors[authorIndex].totalBooks += 1;
            } else {
                var obj = {
                    authorFullName: authorFullName,
                    totalBooks: 1
                };

                authors.push(obj);
            }
        });

        authors = _.chain(authors).sortBy('totalBooks').sortBy(authors, 'authorFullName').reverse().value();

        if (authors.length > 1) {

            for (i = 0, len = authors.length; i < len - 1; i += 1) {
                currentBooks = authors[i].totalBooks;
                nextBooks = authors[i + 1].totalBooks || 0;

                if (nextBooks < currentBooks) {
                    topAuthors.push(authors[i]);
                    break;
                }

                topAuthors.push(authors[i]);
            }
        } else {
            topAuthors = authors;
        }

        _.chain(topAuthors).sortBy('authorFullName').each(function (item) {
            console.log(item.authorFullName);
        });

    };
}

module.exports = solve;
