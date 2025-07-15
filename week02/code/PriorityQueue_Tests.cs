using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and priority: Bob (2), Tim (5), Sue (3) and
    // run until the queue is empty.
    // Expected Result: Tim, Sue, Bob
    // Defect(s) Found: Assert.AreEqual failed. Expected:<Sue>. Actual:<Tim>. The Dequeue functions seems to be
    // doubling the number of items removed.
    public void TestPriorityQueue_1()
    {
        var bob = ("Bob", 2);
        var tim = ("Tim", 5);
        var sue = ("Sue", 3);        

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Item1, bob.Item2);
        priorityQueue.Enqueue(tim.Item1, tim.Item2);
        priorityQueue.Enqueue(sue.Item1, sue.Item2);


        string[] expectedResult = new string[] {"Tim", "Sue", "Bob"};

        var result1 = priorityQueue.Dequeue();
        Assert.AreEqual("Tim", result1);

        var result2 = priorityQueue.Dequeue();
        Assert.AreEqual("Sue", result2);

        var result3 = priorityQueue.Dequeue();
        Assert.AreEqual("Bob", result3);
    }

/*
    [TestMethod]
    // Scenario: Create a queue with the following people and priority: Bob (5), Tim (4), Sue (5) and
    // run until the queue is empty.
    // Expected Result: Bob, Sue, Tim
    // Defect(s) Found: Assert.AreEqual failed. Expected:<Bob>. Actual:<Sue
    public void TestPriorityQueue_2()
    {
        var bob = new Person("Bob", 5);
        var tim = new Person("Tim", 4);
        var sue = new Person("Sue", 5);

        Person[] expectedResult = [bob, sue, tim];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Name, bob.Turns);
        priorityQueue.Enqueue(tim.Name, tim.Turns);
        priorityQueue.Enqueue(sue.Name, sue.Turns);
        
        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }
            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Name, person);
            i++;
        }
    }
*/

    [TestMethod]
    // Scenario: Try to get the next person from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: none
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new TakingTurnsQueue();
        try
        {
            priorityQueue.GetNextPerson();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("No one in the queue.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                            e.GetType(), e.Message)
            );
        }
    }
}