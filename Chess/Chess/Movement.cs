using System.Collections.Generic;

namespace Chess
{
    public class Movement {
        Tile pieceTile;
        public PieceMove?[] availableMoves;
        public Movement() { previousMove = new PieceMove(1, 1); }
        public Movement(Tile pieceTile):this(){
            this.pieceTile = pieceTile;
            availableMoves = Moves();
        }
        public bool isAvailableMove(Tile clickedTile){
            MovesInterface(false);
            for (int move=0;move<availableMoves.Length; move++){
                if (availableMoves[move] == null) continue;
                if (availableMoves[move]?.x == clickedTile.location.x && availableMoves[move]?.y == clickedTile.location.y){
                    if (!CanPerformPieceAction(move,clickedTile)) continue;
                    Board.previousMoves.Add(new PreviousBoardState(pieceTile.piece, pieceTile.location, (PieceMove)availableMoves[move], clickedTile.piece,move));
                    pieceTile.piece.firstMove = false;
                    clickedTile.PieceAssign(pieceTile.piece);
                    pieceTile.PieceAssign(new ChessPiece(PieceKind.EMPTY));
                    if (!PieceSelection.waiting){
                        Board.CurrentPlayer = Board.CurrentPlayer == ChessColor.WHITE ? ChessColor.BLACK : ChessColor.WHITE;
                        ChessPiece.UpdateAllAttacks();
                        if (KingAttacked()){
                            Board.Window.GameState.Text = "Chiếu Tướng!";
                            Board.Window.GameState.ForeColor = System.Drawing.Color.Firebrick;
                            CheckMate();
                        }
                        else{
                            Board.Window.GameState.Text = "...!";
                            Board.Window.GameState.ForeColor = System.Drawing.Color.OliveDrab;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        public void MovesInterface(bool show){
            for (int i = 0; i < availableMoves.Length; i++){
                if (availableMoves[i] == null) continue;
                if (pieceTile.piece.piecekind == PieceKind.Pawn && (i == 2 && isNotOccupied(pieceTile.location.y + dir, pieceTile.location.x + 1)
                    || i == 3 && isNotOccupied(pieceTile.location.y + dir, pieceTile.location.x - 1))) continue;
                Board.tiles[(int)availableMoves[i]?.y, (int)availableMoves[i]?.x].PossibleMove(show);
            }
        }
        public bool KingAttacked() => Board.GetTile(PieceKind.King, Board.CurrentPlayer).tileAttack != ChessColor.NONE;
        public bool CheckMate(){
            List<Tile> pieceTiles = Board.GetAllPieceTiles(Board.CurrentPlayer);
            for (int j = 0; j < pieceTiles.Count; j++){
                pieceTile = pieceTiles[j];
                availableMoves = Moves();
                if (IsKingSafe()) 
                    return false;
            }
            Board.Window.GameState.Text = "CHECKMATE";
            Board.Window.GameState.ForeColor = System.Drawing.Color.Firebrick;
            Board.Window.StopTimer();
            return true;
        }
        public bool IsKingSafe(){
            for (int move = 0; move < availableMoves.Length; move++){
                if (availableMoves[move] == null) continue;
                if (!CanMakeMove((int)availableMoves[move]?.y, (int)availableMoves[move]?.x))
                    availableMoves[move] = null;
            }
            for (int i = 0; i < availableMoves.Length; i++)
                if (availableMoves[i].HasValue)
                    return true;//it means that there is a solution to prevent the checkmate.
            return false;
        }
        bool CanMakeMove(int y, int x){
            ChessPiece previousTilePiece = Board.tiles[y, x].piece;
            Board.tiles[y, x].piece = pieceTile.piece;
            pieceTile.piece = new ChessPiece(PieceKind.EMPTY);
            ChessPiece.UpdateAllAttacks();
            if (!KingAttacked()){
                pieceTile.piece = Board.tiles[y, x].piece;
                Board.tiles[y, x].piece = previousTilePiece;
            }
            else{
                pieceTile.piece = Board.tiles[y, x].piece;
                Board.tiles[y, x].piece = previousTilePiece;
                ChessPiece.UpdateAllAttacks();
                return false;
            }
            return true;
        }
        bool CanPerformPieceAction(int move,Tile clickedTile){
            switch (pieceTile.piece.piecekind){
                case PieceKind.Pawn:
                    pieceTile.piece.TwoTilesMove = move == 1 ? true : false;
                    if (move == 2 && isNotOccupied(pieceTile.location.y + dir, pieceTile.location.x + 1)) return false;
                    if (move == 3 && isNotOccupied(pieceTile.location.y + dir, pieceTile.location.x - 1)) return false;
                    if (move == 4 || move == 5){
                        int xdir = move == 4 ? 1 : -1;
                        Board.tiles[pieceTile.GetY, pieceTile.GetX + xdir].PieceAssign(new ChessPiece(PieceKind.EMPTY)); return true;
                    }
                    if ((pieceTile.GetY == 1 && pieceTile.piece.color == ChessColor.WHITE) || (pieceTile.GetY == 6 && pieceTile.piece.color == ChessColor.BLACK)){
                        PieceSelection pieceSelection = new PieceSelection(clickedTile);
                        pieceSelection.Show();
                    }
                    break;
                case PieceKind.King:
                    int ydir = Board.CurrentPlayer == ChessColor.WHITE ? 7 : 0;
                    void castle(int tilex, int piecex){
                        Board.tiles[ydir, tilex].PieceAssign(Board.GetPiece(ydir, piecex));
                        Board.tiles[ydir, piecex].PieceAssign(new ChessPiece(PieceKind.EMPTY));
                    }
                    if (move == 8) castle(5, 7);
                    if (move == 9) castle(3, 0);
                    break;
                default: break;
            }
            return true;
        }
        PieceMove? previousMove; 
        int move;
        PieceMove?[] Moves() {
            PieceMove?[] moves = new PieceMove?[8];
            move = 0;
            switch (pieceTile.piece.piecekind) {
                case PieceKind.Bishop:moves = new PieceMove?[32]; LineMove(moves,false); break;
                case PieceKind.Knight:
                    moves[0] = destination(2,-1);
                    moves[1] = destination(2, 1);
                    moves[2] = destination(-2, 1);
                    moves[3] = destination(-2, -1);
                    moves[4] = destination(1, -2);
                    moves[5] = destination(1, 2);
                    moves[6] = destination(-1, -2);
                    moves[7] = destination(-1, 2);
                    break;
                case PieceKind.Queen:
                    moves = new PieceMove?[64];
                    LineMove(moves,false);
                    previousMove = new PieceMove(1,1);
                    LineMove(moves,true);
                    break;
                case PieceKind.Rook: moves = new PieceMove?[32]; LineMove(moves, true); break;
                case PieceKind.King:
                    moves = new PieceMove?[10];
                    moves[0] = destination(1,-1);
                    moves[1] = destination(1,1);
                    moves[2] = destination(-1,1);
                    moves[3] = destination(-1, -1);
                    moves[4] = destination(1, 0);
                    moves[5] = destination(-1, 0);
                    moves[6] = destination(0, -1);
                    moves[7] = destination(0, 1);
                    bool CanCastle(int dir){
                        int range = dir == 1 ? 3 : 4; 
                        for (int i = 1; i < range; i++) { 
                            if (isOccupied(pieceTile.GetY, pieceTile.GetX + i * dir) ||
                                (Board.tiles[pieceTile.GetY, pieceTile.GetX + i * dir].tileAttack != ChessColor.NONE)) 
                                return false;
                        }
                        return true;
                    }
                    if (pieceTile.piece.firstMove && Board.GetPiece(pieceTile.GetY, pieceTile.GetX + 3).firstMove) //right castling
                        moves[8] = CanCastle(1) ? destination(0,2) : null;
                    if (pieceTile.piece.firstMove && Board.GetPiece(pieceTile.GetY, pieceTile.GetX - 4).firstMove) //left castling
                        moves[9] = CanCastle(-1) ? destination(0, -2) : null;
                    break;
                case PieceKind.Pawn:
                    moves = new PieceMove?[6];
                    moves[0] = isNotOccupied(pieceTile.location.y+1*dir,pieceTile.location.x) ? destination(1 * dir, 0) : previousMove = null;
                    if (previousMove != null) 
                        moves[1] = isNotOccupied(pieceTile.GetY + 2 * dir, pieceTile.GetX) && pieceTile.piece.firstMove ? destination(2 * dir, 0) : null;
                    moves[2] = destination(dir, 1);
                    moves[3] = destination(dir, -1);
                    moves[4] = isEnemyPawn(pieceTile.GetY, pieceTile.GetX+1) && !isOccupied(pieceTile.GetY+dir, pieceTile.GetX+1) ? destination(dir,1) : null;
                    moves[5] = isEnemyPawn(pieceTile.GetY, pieceTile.GetX - 1) && !isOccupied(pieceTile.GetY+dir, pieceTile.GetX-1) ? destination(dir,-1) : null;
                    break;
            }
            return moves;
        }
        int dir { get { return pieceTile.piece.color == ChessColor.BLACK ? 1 : -1; } }
        void LineMove(PieceMove?[] moves,bool straightLine){ // for pieces like Bishop, Queen and Rook 
            int rookDir = straightLine ? 0 : 1; int bishopDir = straightLine ? 1 : -1;
            for(int i = 1; i < 9; i++) moves[move] = LineDestination(-i,i*bishopDir*rookDir);
            previousMove = new PieceMove(1, 1); for (int i = 1; i < 9; i++) moves[move] = LineDestination(i, i*rookDir);
            previousMove = new PieceMove(1, 1); for (int i = 1; i < 9; i++) moves[move] = LineDestination(i*rookDir, -i);
            previousMove = new PieceMove(1, 1); for (int i = 1; i < 9; i++) moves[move] = LineDestination(i*bishopDir*rookDir, i);
        }
        PieceMove? LineDestination(int y, int x){
            if (previousMove == null)return null;
            return destination(y,x);
        }
        PieceMove? destination(int y, int x) { // for pieces like Knight and King
            int yLocation = pieceTile.location.y + y;
            int xLocation = pieceTile.location.x + x;
            move++;
            if (isAccessAble(yLocation, xLocation)){
                if (isOccupied(yLocation, xLocation) && pieceTile.piece.color != EnemyColor(yLocation, xLocation)){
                    previousMove = null;
                    return new PieceMove(yLocation,xLocation);
                }
                if (isOccupied(yLocation, xLocation)) return previousMove = null;
                return previousMove = new PieceMove(yLocation, xLocation);
            }
            else return previousMove = null;
        }
        bool isAccessAble(int y, int x) => Board.isAccessAble(y,x);
        bool isOccupied(int y, int x) => Board.tiles[y, x].isOccupied();
        bool isEnemyPawn(int y, int x){
            if (isAccessAble(y, x)) return isOccupied(y, x) && Board.GetPiece(y, x).TwoTilesMove && isEnemyColor(y, x);
            else return false;
        }
        bool isNotOccupied(int y, int x){
            if (isAccessAble(y, x)) return !isOccupied(y, x);
            return false;
        }
        bool isEnemyColor(int y, int x) => pieceTile.piece.color != EnemyColor(y, x) && EnemyColor(y, x) != ChessColor.NONE;
        ChessColor EnemyColor(int y, int x) => Board.tiles[y, x].piece.color;
    }
    public struct PieceMove{
        public int y, x;
        public PieceMove(int y,int x){ this.y = y; this.x = x;  }
    }
}