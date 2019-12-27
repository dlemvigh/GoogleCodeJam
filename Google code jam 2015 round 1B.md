# Google Code Jam 2015 round 1B

## Counter Culture

for N <= 20 the answer is N

for N > 20 and N < 100 the answer is 10 + digit sum of N

done by counting till 10 and then till the least significant digit equals the most significant digit digit of N, flipping, and then counting until reaching N

for N >= 100 <= 100 
to 19, flip 91, to 100

is appears easiest to manipulate the outer digits

## Noisy Neighbors

if R*C < N *2

color each appartment like chessboard, wiht (0,0) always being white.

determine number of white squares
determine number of black corner squares (2 or 0)
determine number of black side squares
determine number of black center squares

optimal placement priority is

white, adding 0 unhappiness
black corner adding 2
black side adding 3
black center adding 4

## Hiking Deer

lots and lots of math