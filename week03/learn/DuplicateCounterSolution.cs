public class DuplicateCounterSolution
{
    //CSE 212 Lesson 5C Solved
    //Count how many duplicates are in a collection of data.

    public static void Run()
    {
        /* This is a fixed array of int */
        int[] data = [
            50, 9, 24, 100, 7, 75, 93, 24, 17, 16, 97, 6, 18, 81, 48, 37, 49, 33, 60, 3, 99, 32, 88, 29, 65, 20, 35, 33,
            15, 81, 31, 93, 17, 5, 5, 79, 12, 91, 18, 31, 12, 94, 39, 98, 10, 72, 20, 79, 100, 27, 46, 28, 50, 1, 7, 14,
            78, 100, 55, 26, 48, 33, 96, 77, 69, 8, 33, 36, 42, 98, 42, 32, 49, 65, 1, 82, 30, 74, 73, 89, 23, 76, 25,
            4, 76, 7, 72, 86, 71, 29, 18, 98, 84, 20, 24, 18, 11, 33, 39, 96, 1, 97, 65, 41, 62, 48, 59, 51, 17, 89, 6,
            29, 98, 49, 37, 72, 63, 49, 12, 79, 27, 23, 23, 13, 90, 47, 11, 66, 41, 97, 2, 60, 1, 21, 38, 100, 98, 2,
            18, 75, 86, 52, 63, 58, 26, 80, 62, 82, 63, 94, 33, 76, 7, 11, 49, 2, 34, 3, 10, 27, 71, 60, 4, 94, 100, 95,
            46, 15, 21, 40, 35, 98, 89, 25, 46, 54, 24, 75, 92, 69, 37, 63, 71, 70, 90, 91, 82, 81, 4, 10, 82, 1, 32, 8,
            13, 47, 8, 52, 30, 54, 4, 79, 7, 90, 81, 33, 65, 89, 84, 83, 46, 95, 82, 6, 93, 5, 22, 67, 8, 79, 3, 55, 79,
            6, 54, 10, 22, 16, 40, 67, 50, 58, 37, 35, 7, 44, 10, 31, 45, 93, 12, 55, 67, 48, 32, 43, 57, 58, 37, 76,
            85, 47, 80, 18, 32, 59, 98, 92, 53, 98, 29, 61, 82, 42, 78, 97, 23, 94, 38, 20, 73, 11, 99, 94, 92, 82, 82,
            65
        ];

        // Use data.Length to print out the size of a fixed array
        Console.WriteLine($"Number of items in the collection: {data.Length}");
        // Use the function CountDuplicates(data) to print out the number of duplicate in the int fixed array
        Console.WriteLine($"Number of duplicates: {CountDuplicates(data)}");
        // We get back to this as I dont know what it is.
        Console.WriteLine($"Number of duplicates (alternate): {CountDuplicatesAlternate(data)}");
    }

    /// <summary>
    /// Loop through the data, check for membership in the set.
    /// If yes, then increase the counter; otherwise, add it to the set.
    /// </summary>
    private static int CountDuplicates(int[] data)
    {
        // Add code here.
        // This is a class that represent the set data type
        var unique = new HashSet<int>();
        // a variable that contain a positive integar
        var duplicates = 0;

        // loop through each member of the input or parameter "data" of the method.
        foreach (var x in data)
        {
            // check if the set contain a data. if it does, update the duplicate variable by increasing it by one
            if (unique.Contains(x))
                duplicates++;
            // if the set does not contain the data, then add the data to the set.
            else
                unique.Add(x);
            // this loop has no output. It just does it work.
        }
        // The method returns the duplicate that is the output of this method when called is an int, variable duplicate
        return duplicates;
    }

    /// <summary>
    /// Add everything in the data to the set. Duplicates will be automatically ignored.
    /// Subtract the length of the set from the length of the data.
    /// </summary>
    private static int CountDuplicatesAlternate(int[] data)
    {
        var unique = new HashSet<int>(data);
        return data.Length - unique.Count;
    }
}

/************************What is a set**************************************************************************/
/* A set is a sparse array. It is an array whose data are not filled in the array from left to right but rather
based on a unique equation. The index is determined using an equation index(n) = n. so If n = 3; then the index
of the data is 3. If the digit is 5 then the index is 5.

We could now see that the data index is determined by an equation, this makes the index of a set to be the same as
a data, therefore, a set cannot contain duplicate and it is not filled orderly. Position is not relevant.

The most important task of a set is to find the membership of a data in a set, since ideally, there can only be 
one unique data at a unique index.

Finding the membership of a set is an O1 performance because the set only need to lookup once to get the data.

But what happens when we have to create a set of very large numbers and still maintian O1 performance in checking
for membership of data, the works become so laborious and memory destructive that is not good to use the above 
formula. With the above formula, to create a set with 999,999,999 members, I will need a spare set of size 1 billion.

To make the set size small and maintain O1 performance, we can change our formular for getting the member index to
index(n) = n % sparseArraySize. This simply appoint a unique index to a data by using this formular. Let say we want
to insert 4565 into the set, and it capacity or size is 10, the index of the data will be 5 and only this data can 
be in position 5 in the set.

But what if you want to store more than integars in the set, you will love to store other data type such as a string.
This is where the hashing function comes in play. It is the integar equivalent of other data type. You must convert 
other data type to an integar inother to give it a unique index in the set.

We can therefore more correctly write our formular for assigning indexes to data in a set as this:
index(data) = hash(data) % sparseArraySize. To get that hash(data) you can using a built in C# method called 
GetHashCode(). The value return in each run may vary, but it will be consistent throughout the program so it 
does not crash. 

Let look at some examples. Get the hash code for the following data type: positive int(3), negative int(-3)
string (cat), float/double (3.14), bool (true) and list/object (new List<string>{})

solutions:
C# code                             Hash Code
3.GethashCode();                    3
-3.GetHasCode();                    -3
"cat".GetHasCode();                 -1599535192
3.14.GetHasCode();                  -732117838
true.GetHasCode();                  1
new List<string>{}.GetHasCode();    27252167

However, there will be a conflict with this our new approach to getting index and creating set. Because we are 
using remainder, several data can have the same index number according to our formular in creating a set with a 
fixed size. This will lead to conflict as only one value can be in an index of a set.

DEALING WITH CONFLICT
..................................Open Addressing......................
The first option is called open addressing. If we use our index(n) hashing function and find that something
already occupies the space(or the item in that space is not what we are looking for), then open addressing 
strategy will tell us to move the data to next avaialable space, usually right. The danger with this approach
is that a conflict can result in the creation of more conflicts. This is because the new index will also generate
conflcit when a data is suppose to there too.

.....................................Chaining.................................................................
This is creating a long branch of list of values in an index rather than pushing it to the next avaialble index
This will prevent the adverse effect of creating more conflict. The general adverse effect of both method of 
controlling conflict is that it slows down performance and change it to O(n). We have to do more work to get an
index.
...............................................................................................................
The best solution, however is to increase the spray array size to accomodate more data and reposition all the data
by using the the index(n) function.

In C#, the class we use to represent this kind of set, I have described is HashSet. */

