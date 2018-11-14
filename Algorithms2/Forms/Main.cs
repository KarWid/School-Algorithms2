using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using Algorithms2.Algorithms;
using Algorithms2.Interfaces;
using Algorithms2.Enums;

namespace Algorithms2.Forms
{
    public partial class Main : Form
    {
        private AlgorithmType _lastAlgorithm;

        public Main()
        {
            InitializeComponent();

            VisibleChessControls(false, AlgorithmType.None);
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

        private void VisibleChessControls(bool visible, AlgorithmType algorithmType)
        {
            VisibleAllButtons(false);

            switch (algorithmType)
            {
                case AlgorithmType.ChessJumperProblem:
                    VisibleChessJumperButtons(visible);
                    break;
                case AlgorithmType.NQueenWithReturnsProblem:
                    VisibleNQueenWithReturnsButtons(visible);
                    break;
                case AlgorithmType.None:
                    VisibleAllButtons(visible);
                    break;
                default:
                    break;
            }
        }

        // buttons click
        // choose problem
        private void NQueenProblemWithReturnsBtn_Click(object sender, EventArgs e)
        {
            _lastAlgorithm = AlgorithmType.NQueenWithReturnsProblem;
            VisibleChessControls(true, AlgorithmType.NQueenWithReturnsProblem);
        }

        private void ChessJumperProblemBtn_Click(object sender, EventArgs e)
        {
            _lastAlgorithm = AlgorithmType.ChessJumperProblem;
            VisibleChessControls(true, AlgorithmType.ChessJumperProblem);
        }

        private void WandsdorffProblemBtn_Click(object sender, EventArgs e)
        {
            _lastAlgorithm = AlgorithmType.WarnsdorfProblem;
            VisibleChessControls(true, AlgorithmType.ChessJumperProblem);
        }

        // start algorithm
        private async void StartChessJumperProblemBtn_Click(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;

            int chessBoardSize, startFieldRow, startFieldColumn;

            if (!Int32.TryParse(ChessBoardSizeTb.Text, out chessBoardSize) || chessBoardSize < 5)
            {
                errorMessage += "Niepoprawna wartosc wielkosci tablicy\n";
            }

            if (!Int32.TryParse(ChessStartFieldColumnTb.Text, out startFieldColumn) 
                || startFieldColumn < 0 || startFieldColumn > chessBoardSize)
            {
                errorMessage += "Niepoprawna wartosc kolumny poczatkowego pola\n";
            }

            if (!Int32.TryParse(ChessStartFieldRowTb.Text, out startFieldRow) 
                || startFieldRow < 0 || startFieldRow > chessBoardSize)
            {
                errorMessage += "Niepoprawna wartosc wiersza poczatkowego pola\n";
            }

            if (String.IsNullOrEmpty(errorMessage))
            {
                VisibleChessControls(false, AlgorithmType.ChessJumperProblem);

                switch (_lastAlgorithm)
                {
                    case AlgorithmType.WarnsdorfProblem:
                        await StartAlgorithm(new WarnsdorfProblem(chessBoardSize, new Point(startFieldRow, startFieldColumn)));
                        break;
                    case AlgorithmType.ChessJumperProblem:
                        await StartAlgorithm(new ChessJumperProblem(chessBoardSize, new Point(startFieldRow, startFieldColumn)));
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private async void NQueenStartProblemBtn_Click(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;

            int chessBoardSize;

            if (!Int32.TryParse(ChessBoardSizeLbl.Text, out chessBoardSize) || chessBoardSize < 1)
            {
                errorMessage += "Niepoprawna wartosc wielkosci tablicy\n";
            }

            if (String.IsNullOrEmpty(errorMessage))
            {
                VisibleChessControls(false, AlgorithmType.NQueenWithReturnsProblem);
                await StartAlgorithm(new NQueenWithReturnsProblem(chessBoardSize));
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        // show buttons
        private void VisibleAllButtons(bool visible)
        {
            ChessBoardSizeLbl.Visible = visible;
            ChessStartFieldColumnLbl.Visible = visible;
            ChessStartFieldRowLbl.Visible = visible;
            StartFieldLbl.Visible = visible;
            ChessBoardSizeNQueenLbl.Visible = visible;

            ChessBoardSizeTb.Visible = visible;
            ChessStartFieldColumnTb.Visible = visible;
            ChessStartFieldRowTb.Visible = visible;
            ChessBoardSizeNQueenTb.Visible = visible;

            StartChessJumperProblemBtn.Visible = visible;
            NQueenStartProblemBtn.Visible = visible;
        }

        private void VisibleChessJumperButtons(bool visible)
        {
            StartChessJumperProblemBtn.Visible = visible;
            ChessBoardSizeLbl.Visible = visible;
            ChessStartFieldColumnLbl.Visible = visible;
            ChessStartFieldRowLbl.Visible = visible;
            StartFieldLbl.Visible = visible;

            ChessBoardSizeTb.Visible = visible;
            ChessStartFieldColumnTb.Visible = visible;
            ChessStartFieldRowTb.Visible = visible;
        }

        private void VisibleNQueenWithReturnsButtons(bool visible)
        {
            ChessBoardSizeNQueenLbl.Visible = visible;
            ChessBoardSizeNQueenTb.Visible = visible;

            NQueenStartProblemBtn.Visible = visible;
        }
    }
}