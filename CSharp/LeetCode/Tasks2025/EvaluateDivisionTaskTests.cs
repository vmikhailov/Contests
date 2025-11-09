using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class EvaluateDivisionTaskTests
{
    private EvaluateDivisionTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new EvaluateDivisionTask();
    }

    [Test]
    public void CalcEquation_BasicDivisionChain_ReturnsCorrectResults()
    {
        // Arrange
        // a/b = 2.0, b/c = 3.0
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a", "b" },
            new List<string> { "b", "c" }
        };
        double[] values = [2.0, 3.0];
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a", "c" }, // a/c = (a/b)*(b/c) = 2.0*3.0 = 6.0
            new List<string> { "b", "a" }, // b/a = 1/(a/b) = 1/2.0 = 0.5
            new List<string> { "a", "e" }, // e not in equations = -1.0
            new List<string> { "a", "a" }, // a/a = 1.0
            new List<string> { "x", "x" }  // x not in equations = -1.0
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(5);
        result[0].Should().BeApproximately(6.0, 0.00001);
        result[1].Should().BeApproximately(0.5, 0.00001);
        result[2].Should().Be(-1.0);
        result[3].Should().BeApproximately(1.0, 0.00001);
        result[4].Should().Be(-1.0);
    }

    [Test]
    public void CalcEquation_SimpleExample_ReturnsCorrectResults()
    {
        // Arrange
        // a/b = 2.0
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a", "b" }
        };
        double[] values = [2.0];
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a", "b" }, // 2.0
            new List<string> { "b", "a" }, // 0.5
            new List<string> { "a", "c" }, // -1.0
            new List<string> { "x", "y" }  // -1.0
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(4);
        result[0].Should().BeApproximately(2.0, 0.00001);
        result[1].Should().BeApproximately(0.5, 0.00001);
        result[2].Should().Be(-1.0);
        result[3].Should().Be(-1.0);
    }

    [Test]
    public void CalcEquation_DisconnectedGraphs_ReturnsCorrectResults()
    {
        // Arrange
        // a/b = 2.0, c/d = 3.0 (two separate graphs)
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a", "b" },
            new List<string> { "c", "d" }
        };
        double[] values = [2.0, 3.0];
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a", "b" }, // 2.0
            new List<string> { "c", "d" }, // 3.0
            new List<string> { "a", "c" }, // disconnected = -1.0
            new List<string> { "b", "d" }  // disconnected = -1.0
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(4);
        result[0].Should().BeApproximately(2.0, 0.00001);
        result[1].Should().BeApproximately(3.0, 0.00001);
        result[2].Should().Be(-1.0);
        result[3].Should().Be(-1.0);
    }

    [Test]
    public void CalcEquation_LongerChain_ReturnsCorrectResults()
    {
        // Arrange
        // a/b = 2.0, b/c = 3.0, c/d = 4.0
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a", "b" },
            new List<string> { "b", "c" },
            new List<string> { "c", "d" }
        };
        double[] values = [2.0, 3.0, 4.0];
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a", "d" }, // a/d = 2.0*3.0*4.0 = 24.0
            new List<string> { "d", "a" }, // d/a = 1/24.0
            new List<string> { "b", "d" }, // b/d = 3.0*4.0 = 12.0
            new List<string> { "c", "a" }  // c/a = 1/(2.0*3.0) = 1/6.0
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(4);
        result[0].Should().BeApproximately(24.0, 0.00001);
        result[1].Should().BeApproximately(1.0/24.0, 0.00001);
        result[2].Should().BeApproximately(12.0, 0.00001);
        result[3].Should().BeApproximately(1.0/6.0, 0.00001);
    }

    [Test]
    public void CalcEquation_ComplexGraph_ReturnsCorrectResults()
    {
        // Arrange
        // a/b = 1.5, b/d = 2.0, a/c = 3.0, c/d = 4.0
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a", "b" },
            new List<string> { "b", "d" },
            new List<string> { "a", "c" },
            new List<string> { "c", "d" }
        };
        double[] values = [1.5, 2.0, 3.0, 4.0];
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a", "d" }, // can use multiple paths
            new List<string> { "b", "c" }
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().BeApproximately(3.0, 0.00001); // a/d via a->b->d = 1.5*2.0 = 3.0
        result[1].Should().BeApproximately(2.00, 0.00001); // b/c via b->a->c = (1/1.5)*3.0 = 2.0
    }

    [Test]
    public void CalcEquation_SelfQuery_ReturnsOne()
    {
        // Arrange
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a", "b" }
        };
        double[] values = [2.0];
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a", "a" },
            new List<string> { "b", "b" }
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().BeApproximately(1.0, 0.00001);
        result[1].Should().BeApproximately(1.0, 0.00001);
    }

    [Test]
    public void CalcEquation_CyclicGraph_ReturnsCorrectResults()
    {
        // Arrange
        // a/b = 2.0, b/c = 3.0, c/a = 1/6
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a", "b" },
            new List<string> { "b", "c" },
            new List<string> { "c", "a" }
        };
        double[] values = [2.0, 3.0, 1.0/6.0];
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a", "c" }, // 6.0
            new List<string> { "c", "b" }  // 1/3.0
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().BeApproximately(6.0, 0.00001);
        result[1].Should().BeApproximately(1.0/3.0, 0.00001);
    }

    [Test]
    public void CalcEquation_SingleVariable_UndefinedQuery_ReturnsMinusOne()
    {
        // Arrange
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a", "b" }
        };
        double[] values = [5.0];
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "c", "c" }  // c undefined
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Be(-1.0);
    }

    [Test]
    public void CalcEquation_ReverseEquations_ReturnsCorrectResults()
    {
        // Arrange
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "x", "y" },
            new List<string> { "y", "z" }
        };
        double[] values = [4.0, 5.0];
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "x", "z" }, // 4.0*5.0 = 20.0
            new List<string> { "z", "x" }, // 1/20.0 = 0.05
            new List<string> { "y", "x" }, // 1/4.0 = 0.25
            new List<string> { "z", "y" }  // 1/5.0 = 0.2
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(4);
        result[0].Should().BeApproximately(20.0, 0.00001);
        result[1].Should().BeApproximately(0.05, 0.00001);
        result[2].Should().BeApproximately(0.25, 0.00001);
        result[3].Should().BeApproximately(0.2, 0.00001);
    }

    [Test]
    public void CalcEquation_FractionalValues_ReturnsCorrectResults()
    {
        // Arrange
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a", "b" },
            new List<string> { "b", "c" }
        };
        double[] values = [0.5, 0.25];
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a", "c" }, // 0.5*0.25 = 0.125
            new List<string> { "c", "a" }  // 1/0.125 = 8.0
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().BeApproximately(0.125, 0.00001);
        result[1].Should().BeApproximately(8.0, 0.00001);
    }

    [Test]
    public void CalcEquation_ManyQueriesOnSameComponents_UnionFindOptimization()
    {
        // Arrange
        // Union-Find would optimize by pre-computing connected components
        // and avoiding repeated DFS for queries in disconnected graphs
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a", "b" },
            new List<string> { "b", "c" },
            new List<string> { "c", "d" },
            new List<string> { "x", "y" },
            new List<string> { "y", "z" },
            new List<string> { "m", "n" }
        };
        double[] values = [2.0, 3.0, 4.0, 5.0, 6.0, 7.0];
        
        // Many queries checking connectivity between different components
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a", "x" }, // different components = -1
            new List<string> { "b", "y" }, // different components = -1
            new List<string> { "c", "z" }, // different components = -1
            new List<string> { "a", "m" }, // different components = -1
            new List<string> { "x", "m" }, // different components = -1
            new List<string> { "d", "n" }, // different components = -1
            new List<string> { "a", "d" }, // same component = 24.0
            new List<string> { "x", "z" }, // same component = 30.0
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(8);
        result[0].Should().Be(-1.0);
        result[1].Should().Be(-1.0);
        result[2].Should().Be(-1.0);
        result[3].Should().Be(-1.0);
        result[4].Should().Be(-1.0);
        result[5].Should().Be(-1.0);
        result[6].Should().BeApproximately(24.0, 0.00001);
        result[7].Should().BeApproximately(30.0, 0.00001);
    }

    [Test]
    public void CalcEquation_LargeConnectedComponent_UnionFindForFastLookup()
    {
        // Arrange
        // Union-Find can quickly determine if two nodes are in the same component
        // without traversing the entire graph each time
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a", "b" },
            new List<string> { "b", "c" },
            new List<string> { "c", "d" },
            new List<string> { "d", "e" },
            new List<string> { "e", "f" },
            new List<string> { "f", "g" },
            new List<string> { "g", "h" },
            new List<string> { "h", "i" },
            new List<string> { "i", "j" }
        };
        double[] values = [2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0];
        
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a", "j" }, // long chain: 2^9 = 512
            new List<string> { "j", "a" }, // reverse: 1/512
            new List<string> { "e", "h" }, // mid-chain
            new List<string> { "a", "k" }  // k not in graph = -1
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(4);
        result[0].Should().BeApproximately(512.0, 0.00001);
        result[1].Should().BeApproximately(1.0/512.0, 0.00001);
        result[2].Should().BeApproximately(8.0, 0.00001);
        result[3].Should().Be(-1.0);
    }

    [Test]
    public void CalcEquation_MultipleDisconnectedPairs_UnionFindGrouping()
    {
        // Arrange
        // Union-Find efficiently groups disconnected components
        // Each pair forms its own component
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a", "b" },
            new List<string> { "c", "d" },
            new List<string> { "e", "f" },
            new List<string> { "g", "h" },
            new List<string> { "i", "j" }
        };
        double[] values = [1.5, 2.5, 3.5, 4.5, 5.5];
        
        // Queries across all different components
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a", "c" }, // -1
            new List<string> { "b", "d" }, // -1
            new List<string> { "e", "g" }, // -1
            new List<string> { "f", "h" }, // -1
            new List<string> { "i", "a" }, // -1
            new List<string> { "a", "b" }, // 1.5
            new List<string> { "c", "d" }, // 2.5
            new List<string> { "e", "f" }, // 3.5
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(8);
        result[0].Should().Be(-1.0);
        result[1].Should().Be(-1.0);
        result[2].Should().Be(-1.0);
        result[3].Should().Be(-1.0);
        result[4].Should().Be(-1.0);
        result[5].Should().BeApproximately(1.5, 0.00001);
        result[6].Should().BeApproximately(2.5, 0.00001);
        result[7].Should().BeApproximately(3.5, 0.00001);
    }

    [Test]
    public void CalcEquation_StarTopology_UnionFindSameRoot()
    {
        // Arrange
        // Star topology: all nodes connect to a central node
        // Union-Find would recognize all nodes share the same root
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "center", "a" },
            new List<string> { "center", "b" },
            new List<string> { "center", "c" },
            new List<string> { "center", "d" },
            new List<string> { "center", "e" }
        };
        double[] values = [2.0, 3.0, 4.0, 5.0, 6.0];
        
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a", "b" }, // a->center->b = (1/2)*3 = 1.5
            new List<string> { "b", "c" }, // b->center->c = (1/3)*4 = 4/3
            new List<string> { "d", "e" }, // d->center->e = (1/5)*6 = 1.2
            new List<string> { "a", "e" }, // a->center->e = (1/2)*6 = 3.0
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(4);
        result[0].Should().BeApproximately(1.5, 0.00001);
        result[1].Should().BeApproximately(4.0/3.0, 0.00001);
        result[2].Should().BeApproximately(1.2, 0.00001);
        result[3].Should().BeApproximately(3.0, 0.00001);
    }

    [Test]
    public void CalcEquation_ManyComponentsWithRepeatedConnectivityChecks_UnionFindBenefit()
    {
        // Arrange
        // Scenario with many components where Union-Find's O(α(n)) find operation
        // would be faster than DFS for checking connectivity
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a1", "a2" },
            new List<string> { "a2", "a3" },
            new List<string> { "b1", "b2" },
            new List<string> { "b2", "b3" },
            new List<string> { "c1", "c2" },
            new List<string> { "c2", "c3" },
            new List<string> { "d1", "d2" },
            new List<string> { "d2", "d3" }
        };
        double[] values = [1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0];
        
        // Many cross-component queries (all should return -1)
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a1", "b1" },
            new List<string> { "a1", "c1" },
            new List<string> { "a1", "d1" },
            new List<string> { "b1", "c1" },
            new List<string> { "b1", "d1" },
            new List<string> { "c1", "d1" },
            new List<string> { "a2", "b2" },
            new List<string> { "a3", "b3" },
            new List<string> { "c2", "d2" },
            new List<string> { "a3", "d3" },
            // Within component queries
            new List<string> { "a1", "a3" },
            new List<string> { "b1", "b3" },
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(12);
        for (var i = 0; i < 10; i++)
        {
            result[i].Should().Be(-1.0, $"query {i} should be -1 (disconnected)");
        }
        result[10].Should().BeApproximately(1.0, 0.00001);
        result[11].Should().BeApproximately(1.0, 0.00001);
    }

    [Test]
    public void CalcEquation_PathCompression_UnionFindOptimization()
    {
        // Arrange
        // Deep chain where Union-Find's path compression would optimize subsequent queries
        IList<IList<string>> equations = new List<IList<string>>
        {
            new List<string> { "a", "b" },
            new List<string> { "b", "c" },
            new List<string> { "c", "d" },
            new List<string> { "d", "e" },
            new List<string> { "e", "f" }
        };
        double[] values = [1.0, 1.0, 1.0, 1.0, 1.0];
        
        // Multiple queries from leaf to root - Union-Find would compress path after first query
        IList<IList<string>> queries = new List<IList<string>>
        {
            new List<string> { "a", "f" },
            new List<string> { "a", "f" }, // repeated
            new List<string> { "a", "f" }, // repeated
            new List<string> { "b", "f" },
            new List<string> { "b", "f" }, // repeated
            new List<string> { "c", "f" },
        };

        // Act
        var result = _task.CalcEquation(equations, values, queries);

        // Assert
        result.Should().HaveCount(6);
        result[0].Should().BeApproximately(1.0, 0.00001);
        result[1].Should().BeApproximately(1.0, 0.00001);
        result[2].Should().BeApproximately(1.0, 0.00001);
        result[3].Should().BeApproximately(1.0, 0.00001);
        result[4].Should().BeApproximately(1.0, 0.00001);
        result[5].Should().BeApproximately(1.0, 0.00001);
    }
}

