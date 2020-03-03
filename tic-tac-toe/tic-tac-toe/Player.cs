using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public abstract class Player
    { 
        public char signature { get; set; }
        public char opposite_signature { get; set; }
        public abstract Tuple<int, int> makeMove(char[,] field, int size);
    }


    

}
