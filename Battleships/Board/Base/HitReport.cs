using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Pieces;

namespace Battleships.Board.Base
{
    public class HitReport
    {
        public bool bHit { get; set; }
        public char SymbolStruck { get; set; }
        public Ship Ship { get; set; }
    }
}
