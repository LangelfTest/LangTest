using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    class Field
    {
        public char[,] field { get; set; }
        public int size { get; set; }

        public Field(int n)
        {
            this.field = new char[n, n];
            this.size = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    field[i, j] = '_';
                }
            }
        }

        public void move(Tuple<int, int> coords, Player player)
        {
            field[coords.Item1, coords.Item2] = player.signature;
        }

        public static bool isMovesLeft(char[,] field, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    if (field[row, column] == '_')
                        return true;
                }
            }
            return false;
        }

        public static int evaluate(char[,] field, int size, Player player)
        {
            for (int row = 0; row < size; row++)
            {
                if (field[row, 0] == field[row, 1] &&
                    field[row, 1] == field[row, 2])
                {
                    if (field[row, 0] == player.signature)
                        return +10;
                    else if (field[row, 0] != player.signature)
                        if (field[row, 0] != '_')
                            return -10;
                }
            }

            for (int column = 0; column < size; column++)
            {
                if (field[0, column] == field[1, column] &&
                    field[1, column] == field[2, column])
                {
                    if (field[0, column] == player.signature)
                        return +10;

                    else if (field[0, column] != player.signature)
                        if (field[0, column] != '_')
                            return -10;
                }
            }

            if (field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2])
            {
                if (field[0, 0] == player.signature)
                    return +10;
                else if (field[0, 0] != player.signature)
                    if (field[0, 0] != '_')
                        return -10;
            }

            if (field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0])
            {
                if (field[0, 2] == player.signature)
                    return +10;
                else if (field[0, 2] != player.signature)
                    if (field[0, 2] != '_')
                        return -10;
            }

            return 0;
        }

    }
}
