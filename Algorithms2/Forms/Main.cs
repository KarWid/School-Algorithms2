using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Algorithms2.Models;
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
                case AlgorithmType.HashFunction:
                    VisibleHashFunctionButtons(visible);
                    break;
                case AlgorithmType.Kruskal:
                    VisibleKruskalButtons(visible);
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

        private void NQueenProblemPermutationsBtn_Click(object sender, EventArgs e)
        {
            _lastAlgorithm = AlgorithmType.NQueenPermutationsProblem;
            VisibleChessControls(true, AlgorithmType.NQueenWithReturnsProblem);
        }

        private void HashFunctionBtn_Click(object sender, EventArgs e)
        {
            _lastAlgorithm = AlgorithmType.HashFunction;
            VisibleChessControls(true, AlgorithmType.HashFunction);
        }

        private void KruskalBtn_Click(object sender, EventArgs e)
        {
            _lastAlgorithm = AlgorithmType.Kruskal;
            VisibleChessControls(true, AlgorithmType.Kruskal);
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
                || startFieldColumn < 0 || startFieldColumn >= chessBoardSize)
            {
                errorMessage += $"Niepoprawna wartosc kolumny poczatkowego pola, wartość powinna być z przedziału [0-{chessBoardSize - 1}]\n";
            }

            if (!Int32.TryParse(ChessStartFieldRowTb.Text, out startFieldRow) 
                || startFieldRow < 0 || startFieldRow >= chessBoardSize)
            {
                errorMessage += $"Niepoprawna wartosc wiersza poczatkowego pola, wartość powinna być z przedziału [0-{chessBoardSize - 1}]\n";
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

            if (!Int32.TryParse(ChessBoardSizeNQueenTb.Text, out chessBoardSize) || chessBoardSize < 1)
            {
                errorMessage += "Niepoprawna wartosc wielkosci tablicy\n";
            }

            if (String.IsNullOrEmpty(errorMessage))
            {
                VisibleChessControls(false, AlgorithmType.NQueenWithReturnsProblem);

                switch (_lastAlgorithm)
                {
                    case AlgorithmType.NQueenWithReturnsProblem:
                        await StartAlgorithm(new NQueenWithReturnsProblem(chessBoardSize));
                        break;
                    case AlgorithmType.NQueenPermutationsProblem:
                        await StartAlgorithm(new NQueenPermutationsProblem(chessBoardSize));
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

        private async void HashFunctionStartBtn_Click(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;

            int tableSize;
            double ratio;

            if (!Int32.TryParse(TableSizeHashFunctionTb.Text, out tableSize) || tableSize < 1)
            {
                errorMessage += "Niepoprawna wartosc wielkosci tablicy\n";
            }

            if (!double.TryParse(HashFunctionRatioTb.Text, out ratio))
            {
                errorMessage += "Wspolczynnik nie jest wartoscia liczbowa\n";
            }
            else if (ratio < 0 || ratio > 1)
            {
                errorMessage += "Wspolczynnik powinien miec wartosc z przedzialu [0,1]\n";
            }

            if (string.IsNullOrEmpty(errorMessage))
            {
                await StartAlgorithm(new HashFunction(tableSize, ratio));
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private async void KruskalStartBtn_Click(object sender, EventArgs e)
        {
            var someException = false;
            var tree = new List<TreeNodeModel<int, int>>();

            var fileName = KruskalSourceFileTb.Text;

            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Brak pliku z którego mam pobrać dane");
                return;
            }

            try
            {
                var lines = File.ReadAllLines(fileName);

                for (int iLines = 0; iLines < lines.Length; iLines++)
                {
                    var values = lines[iLines].Split(';');

                    var node = Int32.Parse(values[0]);
                    var list = new List<TreeNeighbourNode<int, int>>();

                    for (int jValues=1; jValues < values.Length;)
                    {
                        var treeNeighourNode = new TreeNeighbourNode<int, int>
                        {
                            Name = Int32.Parse(values[jValues++]),
                            Weight = Int32.Parse(values[jValues++])
                        };

                        list.Add(treeNeighourNode);
                    }

                    var treeNodeModel = new TreeNodeModel<int, int>(node, list);
                    tree.Add(treeNodeModel);
                }
            }
            catch (Exception ex)
            {
                var content = ex.Message;

                content += "\nLinia w pliku powinna zawierać dane:\nWierzhołek;Sasiad;Waga;Sasiad;Waga;Sasiad;Waga;...";

                MessageBox.Show(content);

                someException = true;
            }

            if (!someException)
            {
                await StartAlgorithm(new KruskalProblem(tree));
            }

            KruskalSourceFileTb.Text = "";
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

            HashFunctionStartBtn.Visible = visible;
            TableSizeHashFunctionLbl.Visible = visible;
            TableSizeHashFunctionTb.Visible = visible;
            HashFunctionRatioLbl.Visible = visible;
            HashFunctionRatioTb.Visible = visible;

            KruskalFindSourceFileBtn.Visible = visible;
            KruskalSourceFileTb.Visible = visible;
            KruskalStartBtn.Visible = visible;
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

        private void VisibleHashFunctionButtons(bool visible)
        {
            HashFunctionStartBtn.Visible = visible;
            TableSizeHashFunctionLbl.Visible = visible;
            TableSizeHashFunctionTb.Visible = visible;
            HashFunctionRatioLbl.Visible = visible;
            HashFunctionRatioTb.Visible = visible;
        }

        private void VisibleKruskalButtons(bool visible)
        {
            KruskalFindSourceFileBtn.Visible = visible;
            KruskalSourceFileTb.Visible = visible;
            KruskalStartBtn.Visible = visible;
        }

        // other buttons
        private void KruskalFindSourceFileBtn_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            dialog.FileName = @"C:\Users\Karol\Desktop\KruskalTree.txt";
            dialog.Filter = "Pliki tekstowe (*.txt)|*.txt";

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                KruskalSourceFileTb.Text = dialog.FileName;
            }
        }
    }
}