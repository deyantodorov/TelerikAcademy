(function (){
    var arr,
        min,
        less,
        i,
        j;

    arr = [2, 1, 1, 21, 3, 9, 3, 3, 2, 2, 2, 1];

    console.log("Unsorted: " + arr);

    for (i = 0; i < arr.length; i++) {

        min = arr[i];

        for (j = i + 1; j < arr.length; j++) {

            less = arr[j];

            if (min > less) {
                arr[i] = less;
                arr[j] = min;
                min = less;
            }
        }
    }

    console.log("Sorted: " + arr);
}());