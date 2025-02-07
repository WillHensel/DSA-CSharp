namespace DSA;

public class DoublyLinkedList<T> where T : IComparable
{
    public int Length { get; private set; }
    public DoublyLinkedListNode<T>? Head { get; private set; }
    public DoublyLinkedListNode<T>? Tail { get; private set; }

    public void Prepend(T item)
    {
        var newNode = new DoublyLinkedListNode<T>(item);
        
        if (Length == 0)
        {
            Head = newNode;
            Tail = newNode;
            Length++;
            return;
        }

        newNode.Next = Head;
        Head!.Prev = newNode;
        Head = newNode;
        Length++;
    }

    public void Append(T item)
    {

        var newNode = new DoublyLinkedListNode<T>(item);

        if (Length == 0)
        {
            Head = newNode;
            Tail = newNode;
            Length++;
            return;
        }

        newNode.Prev = Tail;
        Tail!.Next = newNode;
        Tail = newNode;
        Length++;
    }

    public void Insert(int index, T item)
    {
        if (index > Length)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            Prepend(item);
            return;
        }

        if (index == Length)
        {
            Append(item);
            return;
        }

        var newNode = new DoublyLinkedListNode<T>(item);

        var curr = Head.Next;
        var idx = 1;
        while (idx != index)
        {
            curr = curr!.Next;
            idx++;
        }

        curr!.Prev!.Next = newNode;
        newNode.Prev = curr.Prev;
        curr.Prev = newNode;
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
            var temp = Head;
            Head = Head.Next;
            temp.Next = null;
            
            if (Head is not null)
                Head.Prev = null;

            Length--;
        }

        if (Head is null)
        {
            Tail = null;
            return;
        }

        var curr = Head;
        while (curr!.Next is not null)
        {
            while (curr.Next!.Data.Equals(item))
            {
                var temp = curr.Next;
                curr.Next = curr.Next.Next;
                if (curr.Next is not null)
                {
                    curr.Next.Prev = curr;
                }

                temp.Next = null;
                temp.Prev = null;

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
            curr = curr!.Next;
            idx++;
        }

        return curr!.Data;
    }

    public void RemoveAt(int index)
    {
        if (index > Length - 1 || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        var curr = Head;
        var idx = 0;
        while (idx != index)
        {
            curr = curr!.Next;
            idx++;
        }

        if (idx > 0 && idx < Length - 1)
        {
            curr!.Prev!.Next = curr.Next; 
            curr.Next!.Prev = curr.Prev;
        }
        else if (idx == 0)
        {
            Head = curr!.Next;
        }
        else if (idx == Length - 1)
        {
            Tail = curr!.Prev;
            Tail!.Next = null;
        }
        
        curr!.Next = null;
        curr.Prev = null;

        Length--;

        if (Head is null)
        {
            Tail = null;
        }
    }
}

public class DoublyLinkedListNode<T> where T : IComparable
{
    public T Data { get; }
    public DoublyLinkedListNode<T>? Next { get; internal set; }
    public DoublyLinkedListNode<T>? Prev { get; internal set; }

    public DoublyLinkedListNode(T data)
    {
        Data = data;
    }
}