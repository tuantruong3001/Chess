using System;
using System.Windows.Forms;

namespace Chess
{
    public partial class PieceSelection : Form{
        private PieceSelection(){
            InitializeComponent();
            LeftArrow.Click += ButtonClick;
            RightArrow.Click += ButtonClick;
            ApplyButton.Click += ButtonClick;
        }
        Tile clickedTile;
        int position = 0;
        string[] keys = { "BQueen", "BBishop", "BRook", "BKnight" };
        ChessColor waitingPlayer;
        public static bool waiting { get; private set; } = false;
        public PieceSelection(Tile clickedTile):this() {
            waiting = true;
            waitingPlayer = Board.CurrentPlayer == ChessColor.WHITE ? ChessColor.BLACK : ChessColor.WHITE;
            Board.CurrentPlayer = ChessColor.NONE;
            this.clickedTile = clickedTile;
            if (clickedTile.GetY == 0)
                for (int i = 0; i < keys.Length; i++) {
                    keys[i] = keys[i].Remove(0, 1);
                    keys[i] = 'W' + keys[i];
                }
            Preview.Image = Tile.PieceImages[keys[position]];
        }
        public void ButtonClick(object sender , EventArgs e){
            switch (((Button)sender).Name){
                case "RightArrow" : position++; break;
                case "LeftArrow": position--; break;
                default: this.Close(); break;
            }
            if (position < 0) position = keys.Length-1;
            if (position > keys.Length-1) position = 0;
            Preview.Image = Tile.PieceImages[keys[position]];
        }
        protected override void OnClosed(EventArgs e){
            waiting = false;
            clickedTile.piece = new ChessPiece(keys[position], clickedTile);
            Board.CurrentPlayer = waitingPlayer;
            ChessPiece.UpdateAllAttacks();
            Movement Search = new Movement();
            if (Search.KingAttacked()){
                Board.Window.GameState.Text = "CHECK";
                Board.Window.GameState.ForeColor = System.Drawing.Color.Firebrick;
                Board.Window.GameState.Visible = true;
            }
            Search.CheckMate();
            base.OnClosed(e);
        }
    }
}