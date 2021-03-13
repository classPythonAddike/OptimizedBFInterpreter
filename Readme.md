# An Optimized BrainF Interpreter Written in C#

In this project, I will list out the various optimizations I have tried, along with their time savings.
The code is based off my original [BrainF Interpreter](https://github.com/classPythonAddike/BFInterpreter)

## Optimizations

Note that all measurements are made off a computer with 4 GB of RAM,
and 1.6 GHz of CPU Clock Cycles.
The BrainF code used for testing can be found
[here](https://github.com/fabianishere/brainfuck/blob/master/examples/mandelbrot/mandelbrot-opt.bf)

The base for all time savings calculations are taken with the time taken
to execute when compiled with Debug Mode as the base.

- Initial Speed: 6:30 minutes
- Net Time Savings (as of now): 4:45 minutes

## Compiling in Release Mode - 1:45 Minutes

Release mode is much faster than Debug mode, but I only realised
that the former existed recently! So it came as a pleasant surprise when
I discovered that compiling my script in Release Mode sped up my program
by about 4:45 minutes!

Debug mode is usually slower than Release Mode because Debug mode provides
a lot of info to the debugger while executing. Everytime an instruction is
executed, the program pauses for a few minutes while it sends debug output
to the IDE.

## Using Dictionaries instead of Lists - 2:26 Minutes

If I thought that using a dictionary in place of a list would speed up the
execution time, I was sadly mistaken. Using a dictionary actually slowed
down the interpreter by 40 seconds, which was a huge increase. So I
reverted back to using lists.

## Condensing Instructions - 2:46 Minutes

I implemented an `Instruction` class which can be found in the `Instruction.cs` file. Basically,
it serves to condense code like `.++++++++++++++>>>>>>>>>>>----------......` into:
```
Instruction('.', 1)
Instruction('+', 14)
Instruction('>', 11)
Instruction('-', 10)
Instruction('.', 6)
```
Shortening it from 42 commands, to just 5! However, this did not reduce the execution time at all. But I
left it at that, because the next optimization would surely help it along.
