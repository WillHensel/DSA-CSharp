namespace DSA.Test;

[TestFixture]
public class BinaryTreeTests
{
    public BinaryTree<int> Tree = new (1);
    
    //        1                                                             
    //      /  \                                                             
    //     2    3                                                           
    //    / \  / \                                                            
    //   4  5 6   7                                                           

    [OneTimeSetUp]
    public void SetUp()
    {
        Tree.Root.Left = new BinaryTreeNode<int>(2);
        Tree.Root.Right = new BinaryTreeNode<int>(3);
        
        Tree.Root.Left.Left = new BinaryTreeNode<int>(4);
        Tree.Root.Left.Right = new BinaryTreeNode<int>(5);
        
        Tree.Root.Right.Left = new BinaryTreeNode<int>(6);
        Tree.Root.Right.Right = new BinaryTreeNode<int>(7);
    }

    [Test]
    public void TestGetNodesPreOrder()
    {
        var nodes = Tree.GetNodesPreOrder();
        Assert.That(nodes.Count, Is.EqualTo(7));

        var expect = new List<int> {1, 2, 4, 5, 3, 6, 7};
        for (int i = 0; i < 7; i++)
        {
            Assert.That(nodes[i], Is.EqualTo(expect[i]));
        }
    }
    
    [Test]
    public void TestGetNodesInOrder()
    {
        var nodes = Tree.GetNodesInOrder();
        Assert.That(nodes.Count, Is.EqualTo(7));
        
        var expect = new List<int> {4, 2, 5, 1, 6, 3, 7};
        for (int i = 0; i < 7; i++)
        {
            Assert.That(nodes[i], Is.EqualTo(expect[i]));
        }
    }
    
    [Test]
    public void TestGetNodesPostOrder()
    {
        var nodes = Tree.GetNodesPostOrder();
        Assert.That(nodes.Count, Is.EqualTo(7));

        var expect = new List<int> {4, 5, 2, 6, 7, 3, 1};
        for (int i = 0; i < 7; i++)
        {
            Assert.That(nodes[i], Is.EqualTo(expect[i]));
        }
    }
}