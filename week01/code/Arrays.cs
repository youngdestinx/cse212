public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a double array with a size of "length" that will be passed into the function through the
        // parameter int length in the function constructor.

        // Step 2: Create the member of the array by using a loop to multiply each number lesser than "length" and
        // other than 0 with the "number" parameter of the function.
        
        // step 3: Return the created double array.
        var numbers = new double [length];
        for (int i = 0; i < length; i++)
        {
            var item = number * (i + 1);
            numbers[i] = item;
        }
        return numbers;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Store the numbers to be rotated from the right on the list in a temporary variable.
        // Step 2: Remove the numbers to be rotated from the list.
        // Step 3: Add the removed numbers to the end of the list.

        for (int i = 0; i < amount; i++)
        {
            int figure = data[data.Count -1];
            data.RemoveAt(data.Count -1);
            data.Insert(0, figure);
        }
        
    }
}
