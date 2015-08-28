(function () {
    function findSmallAndLong(obj) {
        var i,
            arr = [''],
            index = 0;

        for (i in obj) {
            arr[index] = i;
            index++;
        }

        arr.sort();
        console.log('Lexicographically smallest = ' + arr[0]);
        console.log('Lexicographically largest = ' + arr[arr.length - 1]);
    }

    console.log('Result for document properties:');
    findSmallAndLong(document);
    console.log('');

    console.log('Result for window properties:');
    findSmallAndLong(window);
    console.log('');

    console.log('Result for navigator properties:');
    findSmallAndLong(navigator);
    console.log('');
}());