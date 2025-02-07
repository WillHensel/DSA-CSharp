namespace DSA.Test;

public class DoublyDoublyLinkedListTest
{

    [Test]
    public void TestNew()
    {
        var list = new DoublyLinkedList<int>();

        Assert.That(list.Length, Is.EqualTo(0));
        Assert.That(list.Head, Is.Null);
        Assert.That(list.Tail, Is.Null);
    }
    
    [Test]
    public void TestPrepend()
    {
        var list = new DoublyLinkedList<int>();

        list.Prepend(1);

        Assert.That(list.Length, Is.EqualTo(1));
        Assert.That(list.Head, Is.Not.Null);
        Assert.That(list.Tail, Is.Not.Null);
        Assert.That(list.Head.Data, Is.EqualTo(1));
        Assert.That(list.Head, Is.EqualTo(list.Tail));

        list.Prepend(2);

        Assert.That(list.Length, Is.EqualTo(2));
        Assert.That(list.Head, Is.Not.Null);
        Assert.That(list.Tail, Is.Not.Null);
        Assert.That(list.Head, Is.Not.EqualTo(list.Tail));
        Assert.That(list.Head.Data, Is.EqualTo(2));
        Assert.That(list.Tail.Data, Is.EqualTo(1));
        
        list.Prepend(3);

        Assert.That(list.Length, Is.EqualTo(3));
        Assert.That(list.Head, Is.Not.Null);
        Assert.That(list.Tail, Is.Not.Null);
        Assert.That(list.Head, Is.Not.EqualTo(list.Tail));
        Assert.That(list.Head.Data, Is.EqualTo(3));
        Assert.That(list.Tail.Data, Is.EqualTo(1));
    }

    [Test]
    public void TestAppend()
    {
        var list = new DoublyLinkedList<int>();

        list.Append(1);

        Assert.That(list.Length, Is.EqualTo(1));
        Assert.That(list.Head, Is.Not.Null);
        Assert.That(list.Tail, Is.Not.Null);
        Assert.That(list.Head.Data, Is.EqualTo(1));
        Assert.That(list.Head, Is.EqualTo(list.Tail));

        list.Append(2);
        
        Assert.That(list.Length, Is.EqualTo(2));
        Assert.That(list.Head, Is.Not.Null);
        Assert.That(list.Tail, Is.Not.Null);
        Assert.That(list.Head, Is.Not.EqualTo(list.Tail));
        Assert.That(list.Head.Data, Is.EqualTo(1));
        Assert.That(list.Tail.Data, Is.EqualTo(2));
        
        list.Append(3);

        Assert.That(list.Length, Is.EqualTo(3));
        Assert.That(list.Head, Is.Not.Null);
        Assert.That(list.Tail, Is.Not.Null);
        Assert.That(list.Head, Is.Not.EqualTo(list.Tail));
        Assert.That(list.Head.Data, Is.EqualTo(1));
        Assert.That(list.Tail.Data, Is.EqualTo(3));
    }

    [Test]
    public void TestInsert()
    {

        var list = new DoublyLinkedList<int>();

        Assert.Throws<IndexOutOfRangeException>(() => list.Insert(1, 1));

        list.Insert(0, 1);

        Assert.That(list.Head, Is.Not.Null);
        Assert.That(list.Tail, Is.Not.Null);
        Assert.That(list.Head.Data, Is.EqualTo(1));
        Assert.That(list.Head, Is.EqualTo(list.Tail));

        list.Insert(1, 2);
        
        Assert.That(list.Length, Is.EqualTo(2));
        Assert.That(list.Head, Is.Not.Null);
        Assert.That(list.Tail, Is.Not.Null);
        Assert.That(list.Head, Is.Not.EqualTo(list.Tail));
        Assert.That(list.Head.Data, Is.EqualTo(1));
        Assert.That(list.Tail.Data, Is.EqualTo(2));
        
        list.Insert(1, 3);
        
        Assert.That(list.Length, Is.EqualTo(3));
        Assert.That(list.Head, Is.Not.Null);
        Assert.That(list.Tail, Is.Not.Null);
        Assert.That(list.Head, Is.Not.EqualTo(list.Tail));
        Assert.That(list.Head.Data, Is.EqualTo(1));
        Assert.That(list.Tail.Data, Is.EqualTo(2));
    }

    [Test]
    public void TestRemove()
    {
        var list = new DoublyLinkedList<int>();
        list.Append(1);
        list.Append(2);
        list.Append(2);
        list.Append(1);
        list.Append(3);
        list.Append(1);

        Assert.That(list.Length, Is.EqualTo(6));
        
        list.Remove(2);

        Assert.That(list.Length, Is.EqualTo(4));
        Assert.That(list.Get(1), Is.EqualTo(1));
        Assert.That(list.Get(2), Is.EqualTo(3));

        list.Remove(3);

        Assert.That(list.Length, Is.EqualTo(3));
        Assert.That(list.Get(2), Is.EqualTo(1));

        list.Remove(1);

        Assert.That(list.Length, Is.EqualTo(0));
    }

    [Test]
    public void TestGet()
    {
        var list = new DoublyLinkedList<int>();
        
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(0));
        
        list.Append(1);
        list.Append(2);
        list.Append(2);
        list.Append(1);
        list.Append(3);
        list.Append(1);

        Assert.Throws<IndexOutOfRangeException>(() => list.Get(6));

        Assert.That(list.Get(0), Is.EqualTo(1));
        Assert.That(list.Get(2), Is.EqualTo(2));
        Assert.That(list.Get(4), Is.EqualTo(3));


    }

    [Test]
    public void TestRemoveAt()
    {
        var list = new DoublyLinkedList<int>();
        
        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(0));
        
        list.Append(1);
        list.Append(2);
        list.Append(2);
        list.Append(1);
        list.Append(3);
        list.Append(1);
        
        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(6));

        list.RemoveAt(2);

        Assert.That(list.Length, Is.EqualTo(5));
        Assert.That(list.Get(2), Is.EqualTo(1));

        list.RemoveAt(2);

        Assert.That(list.Length, Is.EqualTo(4));
        Assert.That(list.Get(2), Is.EqualTo(3));

        list.RemoveAt(0);

        Assert.That(list.Length, Is.EqualTo(3));
        Assert.That(list.Get(0), Is.EqualTo(2));
    }
}
