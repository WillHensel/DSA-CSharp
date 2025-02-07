namespace DSA;

public class DoublyLinkedList<T> where T : IComparable
{
    public int Length { get; private set; }
    public LinkedList<T>? Head { get; private set; }

    public void Prepend(T item)
    {
        
    }

    public void Append(T item)
    {
        
    }

    public void Insert(int index, T item)
    {
        
    }

    public void Remove(T item)
    {
        
    }

    public T Get(int index)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        
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