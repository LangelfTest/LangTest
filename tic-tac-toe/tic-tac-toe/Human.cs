using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
   public class Human : Player
    {
       public Human(char sign) {
            this.signature = sign;
            this.opposite_signature = sign == 'X' ? 'O' : 'X';
        }
        public override Tuple<int, int> makeMove(char[,] field, int size)
        {
            return new Tuple<int, int>(0, 0);
        }
    }
}
