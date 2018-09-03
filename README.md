# FizzBuzzGame
The Fizz Buzz is a legend when talking about Software Engineers Interviews, the rules are pretty simple.

count from 1 and up (normally arround 100)

if number is Dividable by 3, say Fizz
and if number is Dividable by 5, say Buzz
extra and if number is Dividable by 7, say Woof
if nothing above is true then say the number


This example have 3 Solutions.

## Solution FizzBuzzStatic 
is a more non-flexible way to resolve this problem, as the parameters for this puzzle is kinda static, ther ewould be no need to make the algorithm dynamic, unless asked for.

## Solution FizzBuzzDynamic 
is a flexible way to add or change number or fizzbuzz words quickly, without having to refactor the code. this solution i kinda see as overkill, as much as it is an engineers wet dream to make code flexible, it is sometimes not needed.

## Solution FizzBuzzDynamicUsingDelegates
This solution is compleetly overkill, and a way to be able to change the rules of the game, if it is suddenly not division that is asked for, but maybe something compleetly diffrent.
for example if it needs to write additionally Woof, everytime there is a 7 present in the number.
