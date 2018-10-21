using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using Algorithms2.Algorithms;
using Algorithms2.Interfaces;

namespace Algorithms2.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            VisibleChessControls(false);
        }

        private void ChessJumperProblemBtn_Click(object sender, EventArgs e)
        {
            VisibleChessControls(true);
        }

        private async Task StartAlgorithm(IAlgorithm algorithm)
        {
            EnableButtons(false);

            await algorithm.Start();

            var time = algorithm.LastActionTime;

            algorithm.ShowResult();

            EnableButtons(true);
        }

        private void EnableButtons(bool enable)
        {
            ChessJumperProblemBtn.Enabled = enable;
        }

        private void VisibleChessControls(bool visible)
        {
            ChessBoardSizeLbl.Visible = visible;
            ChessStartFieldColumnLbl.Visible = visible;
            ChessStartFieldRowLbl.Visible = visible;
            StartFieldLbl.Visible = visible;

            ChessBoardSizeTb.Visible = visible;
            ChessStartFieldColumnTb.Visible = visible;
            ChessStartFieldRowTb.Visible = visible;

            StartChessJumperProblemBtn.Visible = visible;
        }

        private async void StartChessJumperProblemBtn_Click(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;

            int chessBoardSize, startFieldRow, startFieldColumn;

            if (!Int32.TryParse(ChessBoardSizeTb.Text, out chessBoardSize) || chessBoardSize < 1)
            {
                errorMessage += "Niepoprawna wartosc wielkosci tablicy\n";
            }
            if (!Int32.TryParse(ChessStartFieldColumnTb.Text, out startFieldColumn) 
                || startFieldColumn < 1 || startFieldColumn > chessBoardSize)
            {
                errorMessage += "Niepoprawna wartosc kolumny poczatkowego pola\n";
            }
            if (!Int32.TryParse(ChessStartFieldRowTb.Text, out startFieldRow) 
                || startFieldRow < 1 || startFieldRow > chessBoardSize)
            {
                errorMessage += "Niepoprawna wartosc wiersza poczatkowego pola\n";
            }

            if (String.IsNullOrEmpty(errorMessage))
            {
                VisibleChessControls(false);
                await StartAlgorithm(new ChessJumperProblem(chessBoardSize, new Point(startFieldRow, startFieldColumn)));
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }
    }
}