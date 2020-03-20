using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Piece
    {

        private PieceName name;
        private Team team;
        private bool hasPieceMoved = false;


        public Piece(PieceName name, Team team)
        {
            this.name = name;
            this.team = team;
        }

        public PieceName getName()
        {
            return name;
        }

        public void promotePawn(PieceName promotion)
        {
            name = promotion;
        }

        public bool getHasPawnMoved()
        {
            return hasPieceMoved;
        }

        public void setHasPawnMoved()
        {
            hasPieceMoved = true;
        }

        public Team getTeam()
        {
            return team;
        }

    }
}
