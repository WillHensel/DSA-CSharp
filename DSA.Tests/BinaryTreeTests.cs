namespace DSA.Test;

[TestFixture]
public class BinaryTreeTests
{

    [Test]
    public void TestGetNodes()
    {
        var tree = new BinaryTree<int>(1);
        tree.Root.Left = new BinaryTreeNode<int>(2);
        tree.Root.Right = new BinaryTreeNode<int>(3);
        
        tree.Root.Left.Left = new BinaryTreeNode<int>(4);
        tree.Root.Left.Right = new BinaryTreeNode<int>(5);
        
        tree.Root.Right.Left = new BinaryTreeNode<int>(6);
        tree.Root.Right.Right = new BinaryTreeNode<int>(7);

        var nodes = tree.GetNodesPreOrder();
        Assert.That(nodes.Count, Is.EqualTo(7));

        var expect = new List<int> {1, 2, 4, 5, 3, 6, 7};
        for (int i = 0; i < 7; i++)
        {
            Assert.That(nodes[i], Is.EqualTo(expect[i]));
        }

        nodes = tree.GetNodesPostOrder();
        Assert.That(nodes.Count, Is.EqualTo(7));

        expect = new List<int> {4, 5, 2, 6, 7, 3, 1};
        for (int i = 0; i < 7; i++)
        {
            Assert.That(nodes[i], Is.EqualTo(expect[i]));
        }
        
        nodes = tree.GetNodesInOrder();
        Assert.That(nodes.Count, Is.EqualTo(7));
        
        expect = new List<int> {4, 2, 5, 1, 6, 3, 7};
        for (int i = 0; i < 7; i++)
        {
            Assert.That(nodes[i], Is.EqualTo(expect[i]));
        }
    }
}