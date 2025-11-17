namespace LeetCode.Tasks2025;

using NUnit.Framework;
using FluentAssertions;

/// <summary>
/// Test to verify LinkedList node reuse behavior
/// </summary>
public class LinkedListNodeReuseTests
{
    [Test]
    public void LinkedList_RemoveAndReAddSameNode_Works()
    {
        // Test if the current implementation pattern actually works
        var list = new LinkedList<int>();
        var node1 = list.AddFirst(1);
        var node2 = list.AddFirst(2);

        // Current implementation does: Remove then AddFirst with same node
        list.Remove(node1);
        list.AddFirst(node1); // Does this work?

        list.First!.Value.Should().Be(1);
        list.Last!.Value.Should().Be(2);
    }

    [Test]
    public void LinkedList_NodeReuseAfterRemoval_ListProperty()
    {
        var list = new LinkedList<int>();
        var node = list.AddFirst(1);

        node.List.Should().BeSameAs(list);

        list.Remove(node);

        // After removal, node.List becomes null
        node.List.Should().BeNull();

        // Can we re-add it?
        list.AddFirst(node);

        node.List.Should().BeSameAs(list);
        list.First.Should().Be(node);
    }
}

