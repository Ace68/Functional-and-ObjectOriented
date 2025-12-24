namespace StateMonad.Tests;

public class StateMonadTests
{
    [Fact]
    public void Return_ShouldReturnValueAndPreserveState()
    {
        // Arrange
        var initialState = 42;
        var expectedValue = "test";
        var stateComputation = State.Return<int, string>(expectedValue);

        // Act
        var (value, finalState) = stateComputation.Run(initialState);

        // Assert
        Assert.Equal(expectedValue, value);
        Assert.Equal(initialState, finalState);
    }

    [Fact]
    public void Get_ShouldReturnCurrentState()
    {
        // Arrange
        var initialState = 42;
        var stateComputation = State.Get<int>();

        // Act
        var (value, finalState) = stateComputation.Run(initialState);

        // Assert
        Assert.Equal(initialState, value);
        Assert.Equal(initialState, finalState);
    }

    [Fact]
    public void Put_ShouldReplaceState()
    {
        // Arrange
        var initialState = 42;
        var newState = 100;
        var stateComputation = State.Put(newState);

        // Act
        var (value, finalState) = stateComputation.Run(initialState);

        // Assert
        Assert.Equal(Unit.Value, value);
        Assert.Equal(newState, finalState);
    }

    [Fact]
    public void Modify_ShouldTransformState()
    {
        // Arrange
        var initialState = 10;
        var stateComputation = State.Modify<int>(x => x * 2);

        // Act
        var (value, finalState) = stateComputation.Run(initialState);

        // Assert
        Assert.Equal(Unit.Value, value);
        Assert.Equal(20, finalState);
    }

    [Fact]
    public void SelectMany_ShouldChainComputations()
    {
        // Arrange
        var initialState = 5;
        var stateComputation = State.Get<int>()
            .SelectMany(current => State.Put(current + 1));

        // Act
        var (value, finalState) = stateComputation.Run(initialState);

        // Assert
        Assert.Equal(Unit.Value, value);
        Assert.Equal(6, finalState);
    }

    [Fact]
    public void Select_ShouldMapValue()
    {
        // Arrange
        var initialState = 10;
        var stateComputation = State.Get<int>()
            .Select(x => x * 2);

        // Act
        var (value, finalState) = stateComputation.Run(initialState);

        // Assert
        Assert.Equal(20, value);
        Assert.Equal(initialState, finalState);
    }

    [Fact]
    public void LinqQuerySyntax_WithTwoFromClauses_ShouldWork()
    {
        // Arrange
        var initialState = 10;
        var increment =
            from current in State.Get<int>()
            from _ in State.Put(current + 1)
            select current;

        // Act
        var (value, finalState) = increment.Run(initialState);

        // Assert
        Assert.Equal(10, value);
        Assert.Equal(11, finalState);
    }

    [Fact]
    public void LinqQuerySyntax_WithMultipleFromClauses_ShouldChainCorrectly()
    {
        // Arrange
        var initialState = 0;
        var computation =
            from a in State.Get<int>()
            from _ in State.Put(a + 5)
            from b in State.Get<int>()
            from __ in State.Put(b * 2)
            from c in State.Get<int>()
            select (a, b, c);

        // Act
        var (value, finalState) = computation.Run(initialState);

        // Assert
        Assert.Equal((0, 5, 10), value);
        Assert.Equal(10, finalState);
    }

    [Fact]
    public void ComplexStatefulComputation_ShouldTrackStateChanges()
    {
        // Arrange
        var initialState = 1;
        var computation =
            from x in State.Get<int>()
            from _ in State.Modify<int>(s => s * 2)
            from y in State.Get<int>()
            from __ in State.Modify<int>(s => s + 3)
            from z in State.Get<int>()
            select (x, y, z);

        // Act
        var (value, finalState) = computation.Run(initialState);

        // Assert
        Assert.Equal((1, 2, 5), value);
        Assert.Equal(5, finalState);
    }

    [Fact]
    public void StateMonad_ShouldSupportStackOfOperations()
    {
        // Arrange: Simulate a stack with push/pop operations
        var initialStack = new List<int>();
        var computation =
            from _ in State.Modify<List<int>>(stack => { stack.Add(10); return stack; })
            from __ in State.Modify<List<int>>(stack => { stack.Add(20); return stack; })
            from ___ in State.Modify<List<int>>(stack => { stack.Add(30); return stack; })
            from result in State.Get<List<int>>()
            select result;

        // Act
        var (value, finalState) = computation.Run(initialStack);

        // Assert
        Assert.Equal(3, value.Count);
        Assert.Equal(new[] { 10, 20, 30 }, value);
        Assert.Same(value, finalState);
    }

    [Fact]
    public void StateMonad_WithStringState_ShouldConcatenate()
    {
        // Arrange
        var computation =
            from _ in State.Modify<string>(s => s + "Hello")
            from __ in State.Modify<string>(s => s + " ")
            from ___ in State.Modify<string>(s => s + "World")
            from result in State.Get<string>()
            select result;

        // Act
        var (value, finalState) = computation.Run("");

        // Assert
        Assert.Equal("Hello World", value);
        Assert.Equal("Hello World", finalState);
    }

    [Fact]
    public void StateMonad_ShouldSupportCounter()
    {
        // Arrange: A counter that increments and returns the previous value
        State<int, int> NextValue() =>
            from current in State.Get<int>()
            from _ in State.Put(current + 1)
            select current;

        var computation =
            from a in NextValue()
            from b in NextValue()
            from c in NextValue()
            select (a, b, c);

        // Act
        var (value, finalState) = computation.Run(0);

        // Assert
        Assert.Equal((0, 1, 2), value);
        Assert.Equal(3, finalState);
    }
}

