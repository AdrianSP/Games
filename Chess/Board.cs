using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {

        private static Board _instance;
        private static BoardMode mode = BoardMode.Selection;

        Dictionary<string, Piece> livePieces = new Dictionary<string, Piece>
        {
            {"A8", new Piece(PieceName.Rook, Team.Black) },
            {"B8", new Piece(PieceName.Knight, Team.Black) },
            {"C8", new Piece(PieceName.Bishop, Team.Black) },
            {"D8", new Piece(PieceName.Queen, Team.Black) },
            {"E8", new Piece(PieceName.King, Team.Black) },
            {"F8", new Piece(PieceName.Bishop, Team.Black) },
            {"G8", new Piece(PieceName.Knight, Team.Black) },
            {"H8", new Piece(PieceName.Rook, Team.Black) },
            {"A7", new Piece(PieceName.Pawn, Team.Black) },
            {"B7", new Piece(PieceName.Pawn, Team.Black) },
            {"C7", new Piece(PieceName.Pawn, Team.Black) },
            {"D7", new Piece(PieceName.Pawn, Team.Black) },
            {"E7", new Piece(PieceName.Pawn, Team.Black) },
            {"F7", new Piece(PieceName.Pawn, Team.Black) },
            {"G7", new Piece(PieceName.Pawn, Team.Black) },
            {"H7", new Piece(PieceName.Pawn, Team.Black) },
            {"A2", new Piece(PieceName.Pawn, Team.White) },
            {"B2", new Piece(PieceName.Pawn, Team.White) },
            {"C2", new Piece(PieceName.Pawn, Team.White) },
            {"D2", new Piece(PieceName.Pawn, Team.White) },
            {"E2", new Piece(PieceName.Pawn, Team.White) },
            {"F2", new Piece(PieceName.Pawn, Team.White) },
            {"G2", new Piece(PieceName.Pawn, Team.White) },
            {"H2", new Piece(PieceName.Pawn, Team.White) },
            {"A1", new Piece(PieceName.Rook, Team.White) },
            {"B1", new Piece(PieceName.Knight, Team.White) },
            {"C1", new Piece(PieceName.Bishop, Team.White) },
            {"D1", new Piece(PieceName.Queen, Team.White) },
            {"E1", new Piece(PieceName.King, Team.White) },
            {"F1", new Piece(PieceName.Bishop, Team.White) },
            {"G1", new Piece(PieceName.Knight, Team.White) },
            {"H1", new Piece(PieceName.Rook, Team.White) }
        };

        protected Board()
        {
        }

        public static Board Instance()
        {
            if (_instance == null)
            {
                _instance = new Board();
            }

            return _instance;
        }

        public BoardMode getBoardMode()
        {
            return mode;
        }

        public void setBoardMode(BoardMode newMode)
        {
            mode = newMode;
        }

        public bool isPieceAtPosition(string position)
        {
            return livePieces.ContainsKey(position);
        }

        public Team getTeamAtPostion(string position)
        {
            return livePieces[position].getTeam();
        }

        public List<string> getOpenMoves(string position)
        {
            Piece piece = livePieces[position];

            switch(piece.getName())
            {
                case PieceName.Pawn:
                    return GetPawnMoves(position, piece);
                case PieceName.Rook:
                    return GetRookMoves(position, piece);
                case PieceName.Knight:
                    return GetKnightMoves(position, piece);
                case PieceName.Bishop:
                    return GetBishopMoves(position, piece);
                case PieceName.Queen:
                    return GetQueenMoves(position, piece);
                case PieceName.King:
                    return GetKingMoves(position, piece);
                default:
                    return null;

            }
        }

        public void MovePiece(string start, string end)
        {
            if (isPieceAtPosition(end))
                livePieces.Remove(end);

            livePieces.Add(end, livePieces[start]);

            livePieces.Remove(start);

            if (livePieces[end].getName() == PieceName.Pawn)
            {
                livePieces[end].setHasPawnMoved();
            }
        }

        private bool isPositionWithinBounds(string position)
        {
            byte[] asciiValues = Encoding.ASCII.GetBytes(position);

            return (asciiValues[0] >= 65 && asciiValues[0] <= 72 && asciiValues[1] >= 49 && asciiValues[1] <= 56);
        }

        private string TranslatePosition(string start, int vertical, int horizontal)
        {
            char[] coordinate = start.ToCharArray();
            coordinate[0] += (char)horizontal;
            coordinate[1] += (char)vertical;

            return new string(coordinate);
        }

        private List<string> GetKingMoves(string position, Piece piece)
        {
            List<string> possibleMoves = new List<string>();
            possibleMoves.Add(position);

            string possibleMove = TranslatePosition(position, 1, 0); //UP
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            possibleMove = TranslatePosition(position, -1, 0); //DOWN
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            possibleMove = TranslatePosition(position, 0, 1); //RIGHT
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            possibleMove = TranslatePosition(position, 0, -1); //LEFT
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            possibleMove = TranslatePosition(position, 1, 1); //UP RIGHT
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            possibleMove = TranslatePosition(position, 1, -1); //UP LEFT
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            possibleMove = TranslatePosition(position, -1, 1); //DOWN RIGHT
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            possibleMove = TranslatePosition(position, -1, -1); //DOWN LEFT
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            return possibleMoves;
        }

        private List<string> GetQueenMoves(string position, Piece piece)
        {
            List<string> queenMoves = GetRookMoves(position, piece);
            queenMoves.AddRange(GetBishopMoves(position, piece));
            return queenMoves;
        }

        private List<string> GetBishopMoves(string position, Piece piece)
        {
            List<string> possibleMoves = new List<string>();
            possibleMoves.Add(position);

            // Move Up/Right
            string possibleMove = position;
            while (true)
            {
                possibleMove = TranslatePosition(possibleMove, 1, 1);
                if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                {
                    possibleMoves.Add(possibleMove);
                }
                else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                {
                    possibleMoves.Add(possibleMove);
                    break;
                }
                else
                    break;
            }

            // Move Down/Right
            possibleMove = position;
            while (true)
            {
                possibleMove = TranslatePosition(possibleMove, -1, 1);
                if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                {
                    possibleMoves.Add(possibleMove);
                }
                else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                {
                    possibleMoves.Add(possibleMove);
                    break;
                }
                else
                    break;
            }

            // Move Up/Left
            possibleMove = position;
            while (true)
            {
                possibleMove = TranslatePosition(possibleMove, 1, -1);
                if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                {
                    possibleMoves.Add(possibleMove);
                }
                else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                {
                    possibleMoves.Add(possibleMove);
                    break;
                }
                else
                    break;
            }

            // Move Down/Left
            possibleMove = position;
            while (true)
            {
                possibleMove = TranslatePosition(possibleMove, -1, -1);
                if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                {
                    possibleMoves.Add(possibleMove);
                }
                else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                {
                    possibleMoves.Add(possibleMove);
                    break;
                }
                else
                    break;
            }

            return possibleMoves;
        }

        private List<string> GetKnightMoves(string position, Piece piece)
        {
            List<string> possibleMoves = new List<string>();
            possibleMoves.Add(position);

            // Move Up/Right
            string possibleMove = position;
            possibleMove = TranslatePosition(possibleMove, 2, 1);
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            // Move Up/Left
            possibleMove = position;
            possibleMove = TranslatePosition(possibleMove, 2, -1);
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            // Move Right/Up
            possibleMove = position;
            possibleMove = TranslatePosition(possibleMove, 1, 2);
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            // Move Right/Down
            possibleMove = position;
            possibleMove = TranslatePosition(possibleMove, -1, 2);
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            // Move Down/Right
            possibleMove = position;
            possibleMove = TranslatePosition(possibleMove, -2, 1);
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            // Move Down/Left
            possibleMove = position;
            possibleMove = TranslatePosition(possibleMove, -2, -1);
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            // Move Left/Up
            possibleMove = position;
            possibleMove = TranslatePosition(possibleMove, 1, -2);
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            // Move Left/Down
            possibleMove = position;
            possibleMove = TranslatePosition(possibleMove, -1, -2);
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                possibleMoves.Add(possibleMove);
            else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            return possibleMoves;
        }

        private List<string> GetRookMoves(string position, Piece piece)
        {
            List<string> possibleMoves = new List<string>();
            possibleMoves.Add(position);

            // Move Up
            string possibleMove = position;
            while (true)
            {
                possibleMove = TranslatePosition(possibleMove, 1, 0);
                if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                {
                    possibleMoves.Add(possibleMove);
                }
                else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                {
                    possibleMoves.Add(possibleMove);
                    break;
                }
                else
                    break;
            }

            // Move Down
            possibleMove = position;
            while (true)
            {
                possibleMove = TranslatePosition(possibleMove, -1, 0);
                if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                {
                    possibleMoves.Add(possibleMove);
                }
                else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                {
                    possibleMoves.Add(possibleMove);
                    break;
                }
                else
                    break;
            }

            // Move Right
            possibleMove = position;
            while (true)
            {
                possibleMove = TranslatePosition(possibleMove, 0, 1);
                if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                {
                    possibleMoves.Add(possibleMove);
                }
                else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                {
                    possibleMoves.Add(possibleMove);
                    break;
                }
                else
                    break;
            }

            // Move Left
            possibleMove = position;
            while (true)
            {
                possibleMove = TranslatePosition(possibleMove, 0, -1);
                if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
                {
                    possibleMoves.Add(possibleMove);
                }
                else if (isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                {
                    possibleMoves.Add(possibleMove);
                    break;
                }
                else
                    break;
            }

            return possibleMoves;
        }

        private List<string> GetPawnMoves(string position, Piece piece)
        {
            List<string> possibleMoves = new List<string>();
            possibleMoves.Add(position);
            int verticalMove = 1;
            bool FirstSpotValid = false;

            if (piece.getTeam() == Team.Black)
            {
                verticalMove = -1;
            }

            string possibleMove = TranslatePosition(position, verticalMove, 0);
            if (isPositionWithinBounds(possibleMove) && !isPieceAtPosition(possibleMove))
            {
                FirstSpotValid = true;
                possibleMoves.Add(possibleMove);
            }

            string possibleExtraMove = TranslatePosition(possibleMove, verticalMove, 0);
            if (FirstSpotValid && !piece.getHasPawnMoved() && isPositionWithinBounds(possibleExtraMove) && !isPieceAtPosition(possibleExtraMove))
                possibleMoves.Add(possibleExtraMove);

            possibleMove = TranslatePosition(position, verticalMove, 1);
            if (isPositionWithinBounds(possibleMove) && isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            possibleMove = TranslatePosition(position, verticalMove, -1);
            if (isPositionWithinBounds(possibleMove) && isPieceAtPosition(possibleMove) && getTeamAtPostion(possibleMove) != piece.getTeam())
                possibleMoves.Add(possibleMove);

            return possibleMoves;
        }


    }
}
