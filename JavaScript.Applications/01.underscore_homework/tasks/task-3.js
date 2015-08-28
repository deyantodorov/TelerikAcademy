/* 
 Create a function that:
 *   Takes an array of students
 *   Each student has:
 *   `firstName`, `lastName` and `age` properties
 *   Array of decimal numbers representing the marks
 *   **finds** the student with highest average mark (there will be only one)
 *   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

function solve() {
    return function (students) {
        var _ = require('underscore');

        var topStudentByAverageMark = _.chain(students).map(function (student) {
            var currentAverageMark = 0;

            _.each(student.marks, function (mark) {
                currentAverageMark += mark;
            });

            student.averageMark = currentAverageMark / student.marks.length;
            student.fullName = student.firstName + ' ' + student.lastName;

            return student;
        }).sortBy('averageMark').last().value();

        console.log(topStudentByAverageMark.fullName + ' has an average score of ' + topStudentByAverageMark.averageMark);
    };
}

module.exports = solve;