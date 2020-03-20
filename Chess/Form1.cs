using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Chess
{
    public partial class Form1 : Form
    {
        Board board;
        Button currentSelection;
        Team turn = Team.White;

        public Form1()
        {
            InitializeComponent();
            board = Board.Instance();
        }

        private void Position_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            
            if (board.getBoardMode() == BoardMode.Selection)
            {
                if (board.isPieceAtPosition(btn.Name) && board.getTeamAtPostion(btn.Name) == turn)
                {
                    currentSelection = btn;
                    List<string> availablePositions = board.getOpenMoves(btn.Name);
                    SetMovesEnabled(availablePositions);
                    board.setBoardMode(BoardMode.Movement);
                }
            }
            else
            {
                if(btn.Name != currentSelection.Name)
                {
                    board.MovePiece(currentSelection.Name, btn.Name);
                    EndTurn();
                    btn.Image = currentSelection.Image;
                    currentSelection.Image = null;
                }

                board.setBoardMode(BoardMode.Selection);
                SetAllEnabled();
            }
        }

        private void EndTurn()
        {
            if (turn == Team.White)
                turn = Team.Black;
            else
                turn = Team.White;
        }

        private void SetMovesEnabled(List<string> moves)
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                if (!moves.Contains(btn.Name))
                {
                    if (btn.BackColor == Color.NavajoWhite)
                        btn.BackColor = Color.LightGray;
                    if (btn.BackColor == Color.SaddleBrown)
                        btn.BackColor = Color.DimGray;

                    btn.Enabled = false;
                }
            }
        }

        private void SetAllEnabled()
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                if (btn.BackColor == Color.LightGray)
                    btn.BackColor = Color.NavajoWhite;
                if (btn.BackColor == Color.DimGray)
                    btn.BackColor = Color.SaddleBrown;

                btn.Enabled = true;
            }
        }
    }
}
