# An Optimized BrainF Interpreter Written in C#

In this project, I will list out the various optimizations I have tried, along with their time savings.
The code is based off my original [BrainF Interpreter](https://github.com/classPythonAddike/BFInterpreter)

## Optimizations

Note that all measurements are made off a computer with 4 GB of RAM, and 1.6 GHz of CPU Clock Cycles.
The BrainF code used for testing can be found [here](https://github.com/fabianishere/brainfuck/blob/master/examples/mandelbrot/mandelbrot-opt.bf)

The base for all time savings calculations are taken with the time taken to execute when compiled with Debug Mode as the base.

Initial Speed: 6:30 minutes
Net Time Savings (as of now): 4:45 minutes

1) Compiled With Release Mode: 1:45 minutes