using System.Collections.Generic;

namespace Chess {
    class Board {
        public static Tile[,] tiles = new Tile[8, 8];
        public static ChessColor CurrentPlayer = ChessColor.WHITE;
        public static Chess Window;
        public static List<PreviousBoardState> previousMoves = new List<PreviousBoardState>();
        public static ChessPiece GetPiece(int y, int x) => tiles[y, x].piece;
        public static List<Tile> GetAllPieceTiles(ChessColor color) {
            List<Tile> allpieces = new List<Tile>();
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                    if (GetPiece(y, x).color == color)
                        allpieces.Add(tiles[y, x]);
            return allpieces;
        }
        public static Tile GetTile(PieceKind piecekind, ChessColor color) {
            for (byte x = 0; x < 8; x++)
                for (byte y = 0; y < 8; y++) {
                    if (GetPiece(y, x).piecekind == piecekind && GetPiece(y, x).color == color)
                        return tiles[y, x];
                }
            return null;
        }
        public Board(Chess chess) {
            Window = chess;
            byte rows = 0;
            for (byte x = 0; x < 8; x++, rows++) {
                for (byte y = 0; y < 8; y++, rows++) {
                    Tile CorrectTile() => rows % 2 == 0 ? new Tile(y, x, ChessColor.WHITE) : new Tile(y, x, ChessColor.BLACK);
                    tiles[y, x] = CorrectTile();
                    chess.Controls.Add(tiles[y, x]);
                }
            }
            SetPieces(0, ChessColor.BLACK);
            SetPieces(7, ChessColor.WHITE);
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++) {
                    if (tiles[y, x].piece.piecekind != PieceKind.EMPTY)
                        tiles[y, x].PieceImage.BackgroundImage = Tile.PieceImages[tiles[y, x].piece.ImageName()];
                }
        }
        public static bool isAccessAble(int y, int x) => y < 8 && y >= 0 && x < 8 && x >= 0;
        private void SetPieces(int y, ChessColor color) {
            tiles[y, 0].piece = new ChessPiece(PieceKind.Rook, color);
            tiles[y, 1].piece = new ChessPiece(PieceKind.Knight, color);
            tiles[y, 2].piece = new ChessPiece(PieceKind.Bishop, color);
            tiles[y, 3].piece = new ChessPiece(PieceKind.Queen, color);
            tiles[y, 4].piece = new ChessPiece(PieceKind.King, color);
            tiles[y, 5].piece = new ChessPiece(PieceKind.Bishop, color);
            tiles[y, 6].piece = new ChessPiece(PieceKind.Knight, color);
            tiles[y, 7].piece = new ChessPiece(PieceKind.Rook, color);
            y += y == 0 ? 1 : -1;
            for (int x = 0; x < 8; x++)
                tiles[y, x].piece = new ChessPiece(PieceKind.Pawn, color);
        }
    }
    struct PreviousBoardState{
        public ChessPiece removedPiece { get; private set; }
        public PieceMove move { get; private set; }
        public ChessPiece piece { get; private set; }
        public Location previousLocation { get; private set; }
        public int moveIndex;
        public PreviousBoardState(ChessPiece piece,int moveIndex,Location previousLocation,PieceMove move){
            this.piece = piece;
            this.moveIndex = moveIndex;
            this.previousLocation = previousLocation;
            removedPiece = new ChessPiece(PieceKind.EMPTY);
            this.move = move;
        }
        public PreviousBoardState(ChessPiece piece,Location location,PieceMove move, ChessPiece removedPiece,int moveIndex):this(piece,moveIndex,location,move){
            this.removedPiece = removedPiece;
        }
    }
}