# Functional-and-ObjectOriented

Comparative examples showing how to solve the same problem using two different programming paradigms: **Functional Programming** (F#) and **Object-Oriented Programming** (C#).

## 📋 Description

This repository contains parallel implementations of classic algorithms, demonstrating how different approaches can solve the same problems. The goal is to highlight the conceptual differences, advantages, and disadvantages of each paradigm.

## 🏗️ Project Structure

```text
src/FunctionalVsObjectOriented/
├── FunctionalWay/          # Implementazione in F# (Paradigma Funzionale)
│   └── Maze/               # Problema del labirinto
│       ├── ListMonad.fs    # Implementazione della List Monad
│       ├── Maze.fs         # Algoritmo di ricerca percorsi
│       └── MazeTest.fs     # Test unitari
│
└── ObjectOrientedWay/      # Implementazione in C# (Paradigma OOP)
    └── Maze/               # Problema del labirinto
        ├── Maze.cs         # Algoritmo di ricerca percorsi
        └── MazeTest.cs     # Test unitari
```

## 🧩 Implemented Issues

### 1. Maze Solver

Finds all possible paths to exit a maze, avoiding walls and previously visited positions.

**Functional Approach (F#):**

- Uses the **List Monad** to handle non-deterministic computation
- Leverages **computation expressions** (`list { }`) for declarative syntax
- Recursive and immutable implementation
- Pattern matching to handle directions and validation

**Object-Oriented Approach (C#):**

- Uses mutable data structures (`List`, `HashSet`)
- Iterative approach with explicit state management
- Helper methods and local functions
- Record types to represent positions

**Comparison:**

```fsharp
// F# - Declarative approach with list monad
list {
    if current |> isExit then
        return List.rev path
    else
        let! nextDir = [Up; Down; Left; Right]
        let nextPos = movePos current nextDir
        if nextPos |> isValid && nextPos |> neverVisited then
            return! explore nextPos (nextDir :: path) newVisited
}
```

```csharp
// C# - Imperative approach with explicit management
var results = new List<List<Direction>>();
foreach (var direction in new[] { Direction.Up, Direction.Down, Direction.Left, Direction.Right })
{
    var nextPos = MovePos(current, direction);
    if (IsValid(nextPos) && !visited.Contains(nextPos))
    {
        results.AddRange(Explore(nextPos, newPath, newVisited));
    }
}
```

## 🛠️ Technologies

- **.NET 10.0**
- **F#** - Functional language for the functional version
- **C#** - Object-oriented language for the OOP version
- **xUnit** - Testing framework for both projects
- **Unquote** - Assertion library for F#

## 🚀 Getting Started

### Prerequisites

- .NET 10.0 SDK or higher

### Running Tests

```powershell
# Test the F# project (Functional)
dotnet test src/FunctionalVsObjectOriented/FunctionalWay/FunctionalWay.fsproj

# Test the C# project (Object-Oriented)
dotnet test src/FunctionalVsObjectOriented/ObjectOrientedWay/ObjectOrientedWay.csproj

# Run all tests
dotnet test src/FunctionalVsObjectOriented/
```

## 🎯 Learning Objectives

- Understand the differences between functional and object-oriented programming
- Explore the **List Monad** and computation expressions in F#
- Compare mutable vs immutable state management
- Analyze code readability and maintainability in both paradigms
- Evaluate declarative vs imperative approaches

## 📚 Key Concepts

### Functional Programming (F#)

- **Immutability**: all data structures are immutable
- **Recursion**: extensive use of recursion instead of loops
- **Pattern Matching**: powerful matching for deconstructing data
- **Computation Expressions**: syntax for monads and workflows
- **Composition**: functions as building blocks

### Object-Oriented Programming (C#)

- **Encapsulation**: data and behavior together
- **Controlled Mutability**: use of mutable collections
- **Iteration**: use of loops and iterators
- **Record Types**: immutable data structures (C# 9+)
- **Local Functions**: nested functions for organization

## 🔮 Future Developments

- [ ] Implementation of the **Knight's Tour Problem**
- [ ] Other backtracking algorithms
- [ ] Performance comparison
- [ ] Cyclomatic complexity analysis

## 📄 License

See the [LICENSE](LICENSE) file for details.

## 🤝 Contributing

Contributions are welcome! Feel free to open issues or pull requests to:

- Add new examples
- Improve existing implementations
- Fix bugs
- Improve documentation

