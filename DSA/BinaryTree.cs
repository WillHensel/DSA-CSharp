namespace DSA;

public class BinaryTree<T> where T: IComparable<T>
{
    public BinaryTreeNode<T> Root { get; private set; }

    public BinaryTree(T rootData)
    {
        var newNode = new BinaryTreeNode<T>(rootData);
        Root = newNode;
    }

    public List<T> GetNodesPreOrder()
    {
        var result = new List<T>();
        RecurseNodesPreOrder(Root, result);

        return result;
    }

    private void RecurseNodesPreOrder(BinaryTreeNode<T> current, List<T> nodes)
    {
        nodes.Add(current.Data);

        if (current.Left is not null)
        {
            RecurseNodesPreOrder(current.Left, nodes);
        }

        if (current.Right is not null)
        {
            RecurseNodesPreOrder(current.Right, nodes);
        }
    }
    
    public List<T> GetNodesPostOrder()
    {
        var result = new List<T>();
        RecurseNodesPostOrder(Root, result);

        return result;
    }

    private void RecurseNodesPostOrder(BinaryTreeNode<T> current, List<T> nodes)
    {

        if (current.Left is not null)
        {
            RecurseNodesPostOrder(current.Left, nodes);
        }
        
        
        if (current.Right is not null)
        {
            RecurseNodesPostOrder(current.Right, nodes);
        }
        
        nodes.Add(current.Data);

    }
    
    public List<T> GetNodesInOrder()
    {
        var result = new List<T>();
        RecurseNodesInOrder(Root, result);

        return result;
    }

    private void RecurseNodesInOrder(BinaryTreeNode<T> current, List<T> nodes)
    {
        if (current.Left is not null)
        {
            RecurseNodesInOrder(current.Left, nodes);
        }
        
        nodes.Add(current.Data);

        if (current.Right is not null)
        {
            RecurseNodesInOrder(current.Right, nodes);
        }
        
        

    }
    
}

public class BinaryTreeNode<T> where T : IComparable<T>
{
    public T Data { get; private set; }
    public BinaryTreeNode<T>? Left { get; set; }
    public BinaryTreeNode<T>? Right { get; set; }

    public BinaryTreeNode(T data)
    {
        Data = data;
    }
}
