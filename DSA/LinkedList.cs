namespace DSA;

public class LinkedList<T> where T : IComparable
{
    public int Length { get; private set; }
    public LinkedListNode<T>? Head { get; private set; }
    public LinkedListNode<T>? Tail { get; private set; }

    public void Prepend(T item)
    {
        var newNode = new LinkedListNode<T>(item);

        if (Head is not null)
        {
            newNode.Next = Head;
        }

        Head = newNode;

        if (Length == 0)
        {
            Tail = newNode;
        }

        Length++;
    }

    public void Append(T item)
    {
        var newNode = new LinkedListNode<T>(item);

        if (Tail is not null)
        {
            Tail.Next = newNode;
        }

        Tail = newNode;

        if (Length == 0)
        {
            Head = newNode;
        }

        Length++;
    }
    
    public void Insert(int index, T item)
    {
        if (index > Length || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        var newNode = new LinkedListNode<T>(item);

        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
            Head.Next = Tail;
        }
        else if (index == 0)
        {
            newNode.Next = Head;
            Head = newNode;
        }
        else if (index == Length)
        {
            Tail!.Next = newNode;
            Tail = newNode;
        }
        else
        {
            var curr = Head;
            var idx = 0;
            while (idx != index - 1)
            {
                curr = Head!.Next;
                idx++;
            }

            newNode.Next = curr!.Next;
            curr.Next = newNode;
        }

        Length++;
    }

    public void Remove(T item)
    {
        if (Length == 0)
        {
            return;
        }

        while (Head is not null && Head.Data.Equals(item))
        {
            var temp = Head.Next;
            Head.Next = null;
            Head = temp;
            Length--;
        }

        if (Head is null)
        {
            Tail = null;
            return;
        }
        
        var curr = Head;

        while (curr!.Next != null)
        {
            while (curr.Next?.Data.Equals(item) ?? false)
            {
                var temp = curr.Next;
                curr.Next = curr.Next.Next;
                temp.Next = null;
                Length--;
            }

            curr = curr.Next;
        }
    }

    public T Get(int index)
    {
        if (index > Length - 1 || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        var curr = Head;
        var idx = 0;
        while (idx != index)
        {
            idx++;
            curr = curr!.Next;
        }

        return curr!.Data;
    }

    public void RemoveAt(int index)
    {
        if (index > Length - 1 || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            Head = Head!.Next;
            Length--;
            return;
        }

        var curr = Head;
        var idx = 0;
        while (idx != index - 1)
        {
            idx++;
            curr = curr!.Next;
        }

        var temp = curr.Next.Next;
        curr.Next.Next = null;
        curr.Next = temp;

        Length--;
    }

    // This method was made as a challenge picked from a newsletter
    // which is the reason for the differing rules.
    // This is my solution. The optimal solution is below.
    public void RemoveMiddle()
    {
        // Assume we only have a head node
        // Assume we don't know the length

        if (Head is null)
        {
            return;
        }

        var curr = Head;
        var length = 1;
        while (curr.Next != null)
        {
            curr = curr.Next;
            length++;
        }

        var middleIdx = length / 2;

        curr = Head;
        var idx = 0;
        while (idx != middleIdx - 1)
        {
            curr = curr!.Next;
            idx++;
        }

        var temp = curr!.Next;
        curr.Next = curr.Next!.Next;
        temp!.Next = null;

        // Just to make this method in compliance with the rest of the datastructure
        Length--;
    }

    // Solution from the newsletter
    public void RemoveMiddleOptimal()
    {
        var tempHead = new LinkedListNode<T>(Head!.Data);
        tempHead.Next = Head;
        
        var slow = tempHead;
        var fast = Head!.Next;

        while (fast?.Next is not null)
        {
            slow = slow!.Next;
            fast = fast.Next?.Next;
        }

        var temp = slow!.Next;
        
        slow.Next = slow.Next?.Next;

        if (temp is not null)
        {
            temp.Next = null;
        }

        Length--;
    }
    
}

public class LinkedListNode<T> where T : IComparable
{
    public T Data { get; }
    public LinkedListNode<T>? Next { get; internal set; }
    
    public LinkedListNode(T data)
    {
        Data = data;
    }
}