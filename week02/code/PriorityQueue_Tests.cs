using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: (June 3, May 2, April 1)
    // Expected Result: (June, May, April)
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("June", 3);
        priorityQueue.Enqueue("May", 2);
        priorityQueue.Enqueue("April", 1);

        var value1 = priorityQueue.Dequeue();
        var value2 = priorityQueue.Dequeue();
        var value3 = priorityQueue.Dequeue();


        Assert.AreEqual("June", value1);
        Assert.AreEqual("May", value2);
        Assert.AreEqual("April", value3);

    }

    [TestMethod]
    // Scenario: 
    // Expected Result: (June 3, May 3, April 1)
    // Defect(s) Found: (June, May, April)
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("June", 3);
        priorityQueue.Enqueue("May", 3);
        priorityQueue.Enqueue("April", 1);

        var value1 = priorityQueue.Dequeue();
        var value2 = priorityQueue.Dequeue();
        var value3 = priorityQueue.Dequeue();

        Assert.AreEqual("June", value1);
        Assert.AreEqual("May", value2);
        Assert.AreEqual("April", value3);
    }

    // Add more test cases as needed below.
}