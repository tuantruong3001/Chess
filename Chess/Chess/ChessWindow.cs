using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Chess
{
    public partial class Chess : Form {
        //I could write a better code, but I wanted to sprint a little bit , so I can finally learn further OpenGL. So please don't judge me xD
        //So... the code for this project was written in one week.
        public Chess() { InitializeComponent(); }
        Board board;
        private void Chess_Load(object sender, EventArgs e) {
            board = new Board(this);
            Board.CurrentPlayer = ChessColor.NONE;
            TimeButton.MouseDown += click;
            Undo.MouseDown += click;
            Undo.MouseUp += ReleasedButton;
            RestartButton.MouseUp += click;
            
        }
        public ChessColor previousPlayer = ChessColor.WHITE;
        void click(object sender, EventArgs e) {
            if (sender.GetType() == typeof(Button))
                switch (((Button)sender).Name) {
                    case "TimeButton":
                        if (Board.CurrentPlayer == ChessColor.NONE && previousPlayer == ChessColor.NONE) { TimeButton.Enabled = false; return; }
                        TimeButton.Text = TimeButton.Text == "Chơi" ? "Tạm dừng" : "Chơi"; //Resume...
                        if (Board.CurrentPlayer == ChessColor.NONE) StartTimer();
                        else StopTimer();
                        break;
                    case "RestartButton":
                        int moves = Board.previousMoves.Count;
                        for (int i = 0; i < moves; i++)
                            ShowPreviousMove();
                        Board.previousMoves = new List<PreviousBoardState>();
                        Black = new PlayerTime(0,0);
                        White = new PlayerTime(0, 0);
                        if (timer != null) StopTimer();
                        TimeButton.Text = "Start";
                        Board.CurrentPlayer = ChessColor.NONE;
                        break;
                }
            if (sender.GetType() == typeof(PictureBox))
                switch (((PictureBox)sender).Name) {
                    case "Undo":
                        Undo.Image = Properties.Resources.undoArrrowClicked;
                        ShowPreviousMove();
                        break;
                }
        }
        void ShowPreviousMove(){
            if (Board.previousMoves.Count == 0) return;
            int dir = Board.CurrentPlayer == ChessColor.BLACK ? 1 : -1;
            ChessColor previousPlayer = Board.CurrentPlayer == ChessColor.BLACK ? ChessColor.WHITE : ChessColor.BLACK;
            if (previousMove.piece.piecekind == PieceKind.King){
                int ydir = previousPlayer == ChessColor.WHITE ? 7 : 0;
                if (previousMove.moveIndex == 8){
                    Board.tiles[ydir, 5].PieceAssign(new ChessPiece(PieceKind.EMPTY));
                    Board.tiles[ydir, 7].PieceAssign(new ChessPiece(PieceKind.Rook, previousPlayer));
                }
                if (previousMove.moveIndex == 9){
                    Board.tiles[ydir, 3].PieceAssign(new ChessPiece(PieceKind.EMPTY));
                    Board.tiles[ydir, 0].PieceAssign(new ChessPiece(PieceKind.Rook, previousPlayer));
                }
            }
            if (previousMove.piece.piecekind == PieceKind.Pawn){
                if (previousMove.moveIndex == 4)
                    Board.tiles[previousMove.move.y + dir, previousMove.move.x].PieceAssign(new ChessPiece(PieceKind.Pawn, Board.CurrentPlayer, true));
                if (previousMove.moveIndex == 5)
                    Board.tiles[previousMove.move.y + dir, previousMove.move.x].PieceAssign(new ChessPiece(PieceKind.Pawn, Board.CurrentPlayer, true));
            }
            Board.tiles[previousMove.move.y, previousMove.move.x].PieceAssign(previousMove.removedPiece);
            Board.tiles[previousMove.previousLocation.y, previousMove.previousLocation.x].PieceAssign(previousMove.piece);
            Board.previousMoves.RemoveAt(Board.previousMoves.Count - 1);
            Board.CurrentPlayer = previousPlayer;
            ChessPiece.UpdateAllAttacks();
            Movement movement = new Movement();
            if (movement.KingAttacked()){
                Board.Window.GameState.Text = "Chiếu Tướng!";
                Board.Window.GameState.ForeColor = System.Drawing.Color.Firebrick;
                movement.CheckMate();
            }
            else{
                Board.Window.GameState.Text = "...!";
                Board.Window.GameState.ForeColor = System.Drawing.Color.OliveDrab;
            }
        }
        void ReleasedButton(object sender, MouseEventArgs e) { 
            Undo.Image = Properties.Resources.undoArrrow;}
        PreviousBoardState previousMove { get { return Board.previousMoves.Last(); } }
        PlayerTime Black = new PlayerTime(0, 0);
        PlayerTime White = new PlayerTime(0, 0);
        public Timer timer;
        private void StartTimer() {
            Board.CurrentPlayer = previousPlayer;
            void ShowLabel(Label label, ref PlayerTime time){
                time.seconds += 1;
                label.Text = time.TimeFormat();
                if (time.seconds >= 59) { time.minutes += 1; }
            }
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (object sender, EventArgs e) => {
                string player = Board.CurrentPlayer.ToString();
                if (player == "BLACK")
                    ShowLabel(BlackTimer, ref Black);
                else ShowLabel(WhiteTimer, ref White);
            };
            timer.Start();
        }
        public void StopTimer() {
            timer.Stop();
            previousPlayer = Board.CurrentPlayer;
            Board.CurrentPlayer = ChessColor.NONE;
            BlackTimer.Text = Black.TimeFormat();
            WhiteTimer.Text = White.TimeFormat();
        }
        struct PlayerTime{
            public int seconds;
            public int minutes;
            public PlayerTime(int seconds, int minutes) { this.seconds = seconds; this.minutes = minutes; }
            public string TimeFormat(){
                string Format(string time) {
                    if (time.Length == 1) time = "0" + time;
                    return time;
                }
                if (seconds >= 60) seconds = 0;
                return Format(minutes.ToString())+":"+ Format(seconds.ToString());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Timer_Enter(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About dlg2 = new About();
            dlg2.ShowDialog();
        }
        
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("https://www.google.com.vn/?hl=vi");
        }
    }
}