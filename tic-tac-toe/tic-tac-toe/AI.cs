using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public class AI : Player
    {
       public AI(char sign) {
            this.signature = sign;
            this.opposite_signature = sign == 'X' ? 'O' : 'X';
        }

    public override Tuple<int, int> makeMove(char[,] field, int size) 
        {
            int bestMoveRow = -1;
            int bestMoveColumn = -1;
            int bestValue = int.MinValue;
            int currentValue;
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    if(field[row,column]=='_')
                    {
                        field[row, column] = signature;
                        currentValue = minimizer(field, size, 0, int.MinValue,int.MaxValue);
                        field[row, column] = '_';

                        if(currentValue > bestValue)
                        {
                            bestMoveRow = row;
                            bestMoveColumn = column;
                            bestValue = currentValue;
                        }

                    }
                    
                }
            }
                
            return new Tuple<int, int>(bestMoveRow, bestMoveColumn);
        }


        private int maximizer(char[,] field, int size, int depth, int alpha, int beta)
        {
            int score = Field.evaluate(field, size,this);

            if (score == 10)
                return score-depth;
            if (score == -10)
                return score+depth;

            if (Field.isMovesLeft(field, size) == false)
                return 0;

            int bestValue = int.MinValue;
            for(int row = 0; row < size; row++)
            {
                for(int column = 0; column < size; column++)
                {
                    if (field[row,column] == '_')
                    {
                        field[row, column] = signature; 
                        bestValue = Math.Max(bestValue, minimizer(field, size, depth + 1,alpha,beta));
                        field[row, column] = '_';
                        alpha = Math.Max(alpha, bestValue);
                        if (alpha >= beta)
                            break;
                    }
                }
            }
            return bestValue;

        }

        private int minimizer(char[,] field, int size, int depth,int alpha, int beta)
        {
            int score = Field.evaluate(field, size, this);

            if (score == 10)
                return score-depth;
            if (score == -10)
                return score+depth;

            if (Field.isMovesLeft(field, size) == false)
                return 0;

            int bestValue = int.MaxValue;
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    if (field[row, column] == '_')
                    {
                        field[row, column] = opposite_signature;
                        bestValue = Math.Min(bestValue, maximizer(field, size, depth + 1, alpha, beta));
                        field[row, column] = '_';
                        beta = Math.Min(beta, bestValue);
                        if (alpha >= beta)
                            break;
                    }
                }
            }
            return bestValue;

        }
    }
}
