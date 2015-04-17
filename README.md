# Google Code Jam Sandbox

Sandbox repository for Google Code Jam, and other coding competitions 

## C# solver

The C# project attempts to build some structure for rapid prototyping of solutions for programming contests.
The solution contains an abstract solver, and two test runners.
The test runners are for running the solution on either a file IO, or a simple string input, while making the solvers indifferent to the implementation.
When implementing the solvers, one simply extends the abstract solver, and overrides the abstract solve method.
From there the abstract base class provides a textreader and textwriter for the implementing solver class.

A simple EchoSolver would look something like this

```csharp
public class EchoSolver : AbstractSolver
{
	public override string Solve()
	{
		var line = Reader.ReadLine();
		return line;
	}
}
```

the goal was to remove as much boilerplate from the implementing solver as possible.

## Python solver

The python solver is fairly simple.
each solver is expected to implement a single method

```python
def solve(buffer):
	line = buffer.readline()
	return line
```

## Project Euler

Added a project for project euler solutions.
These don't have as rigerous an input sample size. So this solution is just a simple C# project with a utility class, and a method (or more) for each problem.
