using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    /*
        --Problem(ESAY): 
        1025. Divisor Game
        Alice and Bob take turns playing a game, with Alice starting first.
        Initially, there is a number N on the chalkboard.  On each player's turn, that player makes a move consisting of:

        Choosing any x with 0 < x < N and N % x == 0.
        Replacing the number N on the chalkboard with N - x.
        Also, if a player cannot make a move, they lose the game.

        Return True if and only if Alice wins the game, assuming both players play optimally. 

        --Thought:
        1. Classic dp, very similar to "Climbing Stairs (70)"
        2. Read more about how to determine whether a number is prime number: http://mathandmultimedia.com/2012/06/02/determining-primes-through-square-root/
     */
    class DivisorGame
    {
        public static bool Solution(int N)
        {
            // 1. Like fibonacci series, current game's result can be deduced from previous game's result -> use dp
            // 2. Since array starts at 0, do N + 1 to avoid worrying about it:)
            var rst = new bool[N + 1];
                
            // 3. Edge case: if 0 is on the board, and I start first and need to pick x > 0, I should lose 
            rst[0] = false; 

            // 4. When i = 5, it means when 5 is on the board, I start first, can I win? Calculate result all the way to N
            for (int i = 1; i <= N; i++)
            {
                // 5. My turn to pick (j). Rule No.1: 0 < j < current number on board (i)
                for (int j = 1; j < i; j++)
                {
                    // 6. Rule No.2: N % x == 0. Continue because it's illegal to pick.
                    if (i % j != 0) continue;

                    // 7. Rule No.3: After my pick, new number will be i - j (the other guy's turn).
                    if (!rst[i - j])
                    {
                        // If I know that's a checkmate move -> game over!
                        rst[i] = true;
                        continue;
                    }
                }
            }

            return rst[N];
        }
    }
}
