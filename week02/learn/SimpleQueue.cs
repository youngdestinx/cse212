public class SimpleQueue {
    public static void Run() {
        /***********REQUIREMENT***************************************************************************/
        /*  1. The enqueue method shall put a new item at the back of the queue
            2. The dequeue method shall remove an item from the front of the queue
            3. If the queue is empty, then the dequeue method shall throw an IndesxOutOfRangeException */

        // Test Cases

        // Test 1
        // Scenario: Enqueue one value and then Dequeue it.
        // Expected Result: It should display 100
        Console.WriteLine("Test 1");
        var queue = new SimpleQueue();
        queue.Enqueue(100);
        var value = queue.Dequeue();
        Console.WriteLine(value);
        // Defect(s) Found:

        Console.WriteLine("------------");

        // Test 2
        // Scenario: Enqueue multiple values and then Dequeue all of them
        // Expected Result: It should display 200, then 300, then 400 in that order
        Console.WriteLine("Test 2");
        queue = new SimpleQueue();
        queue.Enqueue(200);
        queue.Enqueue(300);
        queue.Enqueue(400);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);
        // Defect(s) Found: 

        Console.WriteLine("------------");

        // Test 3
        // Scenario: Dequeue from an empty Queue
        // Expected Result: An exception should be raised
        Console.WriteLine("Test 3");
        queue = new SimpleQueue();
        try {
            queue.Dequeue();
            Console.WriteLine("Oops ... This shouldn't have worked.");
        }
        catch (IndexOutOfRangeException) {
            Console.WriteLine("I got the exception as expected.");
        }
        // Defect(s) Found: 
    }

    private readonly List<int> _queue = new();

    /// <summary>
    /// Enqueue the value provided into the queue
    /// </summary>
    /// <param name="value">Integer value to add to the queue</param>
    private void Enqueue(int value) {
        _queue.Add(value);
    }

    /// <summary>
    /// Dequeue the next value and return it
    /// </summary>
    /// <exception cref="IndexOutOfRangeException">If queue is empty</exception>
    /// <returns>First integer in the queue</returns>
    private int Dequeue() {
        if (_queue.Count <= 0)
            throw new IndexOutOfRangeException();

        var value = _queue[0];
        _queue.RemoveAt(0);
        return value;
    }
}

/*******************************How To Write Test****************************************************************/
/* A test is an instance of a class. It is a test because you have the specific expected result or output
for this specific instance or scenerio. When you run the code and the result is false, you then know that the
class is faulty.

when testing, you want to see if the requirement works. I like to call these requirement the methods of a class.
Because most times, this requirement are the responsibilities of a class which is handle by a class. SO what you
are really doing when testing is to see if method of a class is running as expected. If they are producing the
expected result.

So if a test is wrong, all what you have to do is to check the class methods and ensure that they are producing the
right result.

For you to create the instance of a class, you must know how the class works. So it a good idea to know how a 
class method actually works. The input it receives and the output it returns, it responsibility and all that. */