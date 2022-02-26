using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Chess{
    public enum PieceKind { King, Queen, Pawn, Bishop, Knight, Rook,EMPTY }
    public struct ChessPiece{
        public bool firstMove { get; set; }
        public bool TwoTilesMove;
        public PieceKind piecekind { get; private set; }
        public ChessColor color;
        private Tile[] attackingTiles;
        void attack(Tile pieceTile){
            Movement movement = new Movement(pieceTile);
            attackingTiles = new Tile[movement.availableMoves.Length];
            for (int move = 0; move < movement.availableMoves.Length; move++) {
                if (movement.availableMoves[move] == null) continue;
                if (pieceTile.piece.piecekind == PieceKind.Pawn)
                    if (move == 0 || move == 1) continue;
                    Board.tiles[(int)movement.availableMoves[move]?.y, (int)movement.availableMoves[move]?.x].SetAttack(pieceTile.piece);
                    attackingTiles[move] = Board.tiles[(int)movement.availableMoves[move]?.y, (int)movement.availableMoves[move]?.x];
            }
        }
        public static void CleanPreviousAttack(){
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                    Board.tiles[y, x].RemoveAttack();
        }
        public static void UpdateAllAttacks(){
            CleanPreviousAttack();
            for(int x = 0; x < 8; x++) 
                for (int y = 0; y < 8; y++)
                    if (Board.tiles[y, x].isOccupied() && Board.tiles[y,x].piece.color != Board.CurrentPlayer)
                        Board.tiles[y, x].piece.attack(Board.tiles[y, x]);
        }
        public string ImageName(){
            string name = "";
            if (color != ChessColor.NONE)
                name = color == ChessColor.BLACK ? name = "B" : name = "W";
            return name + piecekind.ToString();
        }
        public ChessPiece(PieceKind piecekind = PieceKind.EMPTY,ChessColor color = ChessColor.NONE,bool TwoTilesMove = false,bool firstMove = false){
            attackingTiles = new Tile[32];
            this.firstMove = true;
            this.TwoTilesMove = TwoTilesMove;
            this.piecekind = piecekind;
            this.color = color;
            if (piecekind == PieceKind.EMPTY) this.firstMove = firstMove;
        }
        public ChessPiece(string key,Tile tile):this(PieceKind.Queen){
            color = key.First() == 'B' ? ChessColor.BLACK : ChessColor.WHITE;
            key = key.Remove(0, 1);
            switch (key){
                case "Bishop":piecekind = PieceKind.Bishop;  break;
                case "Rook": piecekind = PieceKind.Rook; break;
                case "Queen": piecekind = PieceKind.Queen; break;
                case "Knight": piecekind = PieceKind.Knight; break;
            }
            tile.PieceImage.BackgroundImage = Tile.PieceImages[ImageName()];
        }
       
    }
}