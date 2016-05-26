var binarySearch = function (sortedArray, searchValue, minPosition, maxPosition) {
    // Get middle value and boundaries.
    var max = maxPosition === undefined ? sortedArray.length - 1 : maxPosition;
    var min = minPosition === undefined ? 0 : minPosition;
    var midPosition = (max + min) / 2;
    var midValue = sortedArray[midPosition];
    
    if (midValue < searchValue) {
        // Search Right side.
        return binarySearch(sortedArray, searchValue, midPosition + 1, max);
    }
    else if (midValue > searchValue) {
        // Search Left side.
        return binarySearch(sortedArray, searchValue, min, midPosition - 1);
    }
    else if (midValue == searchValue) {
        return midPosition;
    }
    
    return -1;
};

var array = [2, 4, 5, 7, 24, 25, 55, 56, 66, 84, 96, 96, 100, 789, 855];
var valueIndex = binarySearch(array, 24);

console.log("BinarySearch "valueIndex);