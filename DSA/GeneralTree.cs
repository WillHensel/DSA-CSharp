namespace DSA;

public class GeneralTree<T> where T : IComparable<T>
{
    
}

public class GeneralTreeNode<T> where T : IComparable<T>
{
    public T Data { get; private set; }
    public List<T> Children { get; private set; } = new();

    public GeneralTreeNode(T data)
    {
        Data = data;
    }
    
}
