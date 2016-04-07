# shard


Shard is my implementation of Dijkstra's Shunting-yard algorithm.
The goal of this algorithm is to parse infix notation to produce its postfix counterpart (reverse polish notation).
The algorithm works, as the name suggests, like a train shunting yard by incorporating a list of tokens, a stack of operators, and a queue for outputs.
I could try to explain the algorithm right here, but much smarter minds explain the concept better else where on the internet.

Here are some good starting places:
+ [wiki](https://en.wikipedia.org/wiki/Shunting-yard_algorithm)
+ [Oxford's Math Centre](http://www.oxfordmathcenter.com/drupal7/node/628)

This algorithm is very helpful when trying to parse mathematical formulas as calculations using Reverse Polish Notation (RPN) is much more computer friendly.
I recently used this algorithm in my [K-map solver](http://github.com/tarellano/canoe) to parse boolean functions and determine their corresponding truth table/ K-map.

I'll leave you to find a suitable use for this algorithm.
