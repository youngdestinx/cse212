using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    /// 
    /// <plan>
    /// 1. create a new node(we will call it newNode)
    /// 2. Set the "prev" of the new node to the current tail
    /// 3. set the "next" of the current tail to the new node
    /// 4. set the tail equal to the new node
    /// </plan>
    public void InsertTail(int value)
    {
        // TODO Problem 1
        Node newNode = new(value);

        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }

        else
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }
        
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    /// 
    /// <plan>
    /// 1. if the list has only one item, then set the head and tail as null; this will remove it.
    /// 2. if the list has several items then do the following:
    ///     1. disconnect the second to the last node from the last node.
    ///     2. update the tail to be the second to the last node
    /// </plan>
    public void RemoveTail()
    {
        // TODO Problem 2
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }

        else
        {
            _tail.Next!.Prev = null;
            _tail = _tail.Next;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    /// 
    /// <plan>
    /// 1. Check if the list is empty. if the list is empty there is nothing to remove, so return.
    /// 2. Check if the head node contain the value
    /// 3. If the head node contain the value, update the head of the list to point to the next node.
    /// 4. Traverse the list. if the head does not contain the value, traverse the list until you find the node
    ///    that contains the value
    /// 5. Remove the node. When you find the node, update the next pointer of the previous node to point to the node
    ///    after the one you're removing.
    /// 6. Handle edge cases. Make sure to handle edge cases, such as when the node to be removed is the last node in
    ///    the list.
    /// </plan>
    public void Remove(int value)
    {
        // TODO Problem 3
        if (_head == null) return;
        
        if (_head.Data == value)
        {
            if (_head.Next == null)
            {
                _head = null;
                _tail = null;
            }

            else
            {
               _head = _head.Next; 
            }
        }

        Node current = _head;
        while (current.Next != null)
        {
            if (current.Next.Data == value)
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
        
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    /// 
    /// <plan>
    /// 1. start at the head of the list. Begin by pointing at the head of the list.
    /// 2. traverse the list. move through the list one after the other, checking each node's value
    /// 3. check for old value. if the current node value matches old value, replace it with new value
    /// 4. continue until end of list. Keep tranversing until we reach the end of the list, i.e until we
    ///    encounter a null node
    /// </plan>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        Node current = _head;
        while (current != null)
        {
            if (current.Data == oldValue)
            {
                current.Data = newValue;
            }
            current = current.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    /// 
    /// <plan>
    /// 1. Traverse the list and store nodes in a stack.
    /// 2. Pop nodes from the stack and process them
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        Stack<Node> stack = new Stack<Node>();
        Node current = _head;
        while (current != null)
        {
            stack.Push(current);
            current = current.Next;
        }

        while (stack.Count > 0)
        {
            Node node = stack.Pop();
            yield return node.Data;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}