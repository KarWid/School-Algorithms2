using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Algorithms2.Models;
using Algorithms2.Algorithms;
using Algorithms2.Interfaces;
using Algorithms2.Enums;
using Algorithms2.Models.Tarjan;

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
            await algorithm.Start();

            var time = algorithm.LastActionTime;

            algorithm.ShowResult();
        }

        // buttons click
        // choose problem
        #region Choose problem
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

        private void CNF2Btn_Click(object sender, EventArgs e)
        {
            _lastAlgorithm = AlgorithmType.CNF2;
            VisibleChessControls(true, AlgorithmType.CNF2);
        }

        private void ArticulationBtn_Click(object sender, EventArgs e)
        {
            _lastAlgorithm = AlgorithmType.Articulation;
            VisibleChessControls(true, AlgorithmType.Articulation);
        }

        private void TarjanBtn_Click(object sender, EventArgs e)
        {
            _lastAlgorithm = AlgorithmType.Tarjan;
            VisibleChessControls(true, AlgorithmType.Tarjan);
        }

        private void KMPBtn_Click(object sender, EventArgs e)
        {
            _lastAlgorithm = AlgorithmType.KMP;
            VisibleChessControls(true, AlgorithmType.KMP);
        }
        #endregion

        // start algorithm
        #region Start algorithm
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

        private async void CNF2StartBtn_Click(object sender, EventArgs e)
        {
            var someException = false;
            var tree = new List<TreeNodeModel<int, int>>();

            var fileName = CNF2SourceFileTb.Text;

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

                    int nodeFrom, nodeTo;
                    int weight = 0;

                    Int32.TryParse(values[0], out nodeFrom);
                    Int32.TryParse(values[1], out nodeTo);

                    nodeFrom *= -1;

                    if (values.Length > 2)
                    {
                        Int32.TryParse(values[2], out weight);
                    }

                    var node = tree.Where(x => x.Name == nodeFrom).FirstOrDefault();

                    var neighbour = new TreeNeighbourNode<int, int>
                    {
                        Name = nodeTo,
                        Weight = weight
                    };

                    if (node == null)
                    {
                        var neighbours = new List<TreeNeighbourNode<int, int>>();
                        neighbours.Add(neighbour);
                        tree.Add(new TreeNodeModel<int, int>(nodeFrom, neighbours));
                    }
                    else
                    {
                        node.Neighbours.Add(neighbour);
                    }
                }
            }
            catch (Exception ex)
            {
                var content = ex.Message;

                content += "\nLinia w pliku powinna zawierać dane:\nWierzhołek;Wierzhołek;Waga (Waga opcjonalnie)";

                MessageBox.Show(content);

                someException = true;
            }

            if (!someException)
            {
                await StartAlgorithm(new CNF2Problem(tree));
            }

            CNF2SourceFileTb.Text = "";
        }

        private async void ArticulationStartBtn_Click(object sender, EventArgs e)
        {
            var someException = false;
            var tree = new List<TreeNodeModel<int, int>>();

            var fileName = ArticulationSourceFileTb.Text;

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

                    int nodeFrom, nodeTo;
                    int weight = 0;

                    Int32.TryParse(values[0], out nodeFrom);
                    Int32.TryParse(values[1], out nodeTo);

                    if (values.Length > 2)
                    {
                        Int32.TryParse(values[2], out weight);
                    }

                    var node = tree.Where(x => x.Name == nodeFrom).FirstOrDefault();

                    var neighbour = new TreeNeighbourNode<int, int>
                    {
                        Name = nodeTo,
                        Weight = weight
                    };

                    if (node == null)
                    {
                        var neighbours = new List<TreeNeighbourNode<int, int>>();
                        neighbours.Add(neighbour);
                        tree.Add(new TreeNodeModel<int, int>(nodeFrom, neighbours));
                    }
                    else
                    {
                        node.Neighbours.Add(neighbour);
                    }
                }
            }
            catch (Exception ex)
            {
                var content = ex.Message;

                content += "\nLinia w pliku powinna zawierać dane:\nWierzhołek;Wierzhołek;Waga (Waga opcjonalnie)";

                MessageBox.Show(content);

                someException = true;
            }

            if (!someException)
            {
                await StartAlgorithm(new ArticulationBridgeProblem(tree));
            }

            ArticulationSourceFileTb.Text = "";
        }

        private async void TarjanStartBtn_Click(object sender, EventArgs e)
        {
            var errorMessage = "\n1. Linia - lista wierzchołków oddzielona znakiem ';'\n" +
                               "2. Linia - numer wierzchołka dla którego rozpoczynamy szukanie\n" +
                               "3. Linia - lista par wierzchołków, dla których szukamy przodka, np. 1-2;3-4;4-5" +
                               "Kolejne linie w pliku powinny zawierać dane:\nWierzhołek;Dziecko;Dziecko...";

            var someException = false;

            var model = new TarjanModel();
            var tree = new TarjanTreeModel();
            var targetPairs = new List<TarjanVertexPairTarget>();

            var fileName = TarjanSourceFileTb.Text;

            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Brak pliku z którego mam pobrać dane");
                return;
            }

            try
            {
                var lines = File.ReadAllLines(fileName);

                if (lines.Length < 3)
                {
                    throw new Exception("Plik ma nie wystarczającą liczbę linii.\n" + errorMessage);
                }

                // all vertices, first line
                var verticesFromLines = lines[0].Split(';');
                foreach (var vertexFromLine in verticesFromLines)
                {
                    var vertexName = Int32.Parse(vertexFromLine);

                    tree.Vertices.Add(new TarjanNodeModel
                    {
                        Color = Color.White,
                        Count = 1,
                        Name = vertexName,
                    });
                }

                // second line, root
                tree.Root = tree.Vertices.Find(x => x.Name == Int32.Parse(lines[1]));

                // third line, target vertex pairs
                var pairsFromLines = lines[2].Split(';');
                foreach (var pairs in pairsFromLines)
                {
                    var pairVertices = pairs.Split('-');
                    var pairVertex1 = tree.Vertices.Find(v => v.Name == Int32.Parse(pairVertices[0]));
                    var pairVertex2 = tree.Vertices.Find(v => v.Name == Int32.Parse(pairVertices[1]));

                    targetPairs.Add(new TarjanVertexPairTarget
                    {
                        Vertex1 = pairVertex1,
                        Vertex2 = pairVertex2
                    });
                }

                // graph
                for (int iLines = 3; iLines < lines.Length; iLines++)
                {
                    var vertices = lines[iLines].Split(';');

                    var tarjanVertex = tree.Vertices.Where(x => x.Name == Int32.Parse(vertices[0])).FirstOrDefault();

                    if (tarjanVertex == default(TarjanNodeModel))
                    {
                        throw new Exception("Nie istnieje taki vertex w podanych wierzchołkach");
                    }
                    else
                    {
                        for (int iVertex = 1; iVertex < vertices.Length; iVertex++)
                        {
                            var neighVertexName = Int32.Parse(vertices[iVertex]);

                            var neighVertex = tree.Vertices.Where(x => x.Name == neighVertexName).FirstOrDefault();

                            if (neighVertex == default(TarjanNodeModel))
                            {
                                throw new Exception("Nie istnieje taki vertex jako sąsiad w podanych wierzchołkach");
                            }
                            else
                            {
                                tarjanVertex.Children.Add(neighVertex);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var content = ex.Message;

                content += errorMessage;

                MessageBox.Show(content);

                someException = true;
            }

            if (!someException)
            {
                model.Tree = tree;
                model.Target = targetPairs;

                await StartAlgorithm(new TarjanProblem(model));
            }

            TarjanSourceFileTb.Text = "";
        }

        private async void KMPStartBtn_Click(object sender, EventArgs e)
        {
            await StartAlgorithm(new KMPProblem());
        }
        #endregion

        // show buttons
        #region Show buttons
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
                case AlgorithmType.CNF2:
                    VisibleCNF2Buttons(visible);
                    break;
                case AlgorithmType.Articulation:
                    VisibleArticulationButtons(visible);
                    break;
                case AlgorithmType.Tarjan:
                    VisibleTarjanButtons(visible);
                    break;
                case AlgorithmType.KMP:
                    VisibleKMPButtons(visible);
                    break;
                case AlgorithmType.None:
                    VisibleAllButtons(visible);
                    break;
                default:
                    break;
            }
        }

        private void VisibleAllButtons(bool visible)
        {
            VisibleChessJumperButtons(visible);
            VisibleNQueenWithReturnsButtons(visible);
            VisibleHashFunctionButtons(visible);
            VisibleKruskalButtons(visible);
            VisibleCNF2Buttons(visible);
            VisibleArticulationButtons(visible);
            VisibleTarjanButtons(visible);
            VisibleKMPButtons(visible);
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

        private void VisibleCNF2Buttons(bool visible)
        {
            CNF2FindSourceFileBtn.Visible = visible;
            CNF2SourceFileTb.Visible = visible;
            CNF2StartBtn.Visible = visible;
        }

        private void VisibleArticulationButtons(bool visible)
        {
            ArticulationFindSourceFileBtn.Visible = visible;
            ArticulationSourceFileTb.Visible = visible;
            ArticulationStartBtn.Visible = visible;
        }

        private void VisibleTarjanButtons(bool visible)
        {
            TarjanFindSourceFileBtn.Visible = visible;
            TarjanSourceFileTb.Visible = visible;
            TarjanStartBtn.Visible = visible;
        }

        private void VisibleKMPButtons(bool visible)
        {
            KMPStartBtn.Visible = visible;
        }
        #endregion

        // other buttons
        #region Other functionalities
        private void KruskalFindSourceFileBtn_Click(object sender, EventArgs e)
        {
            GetFileNamePath(KruskalSourceFileTb, @"C:\Users\Karol\Desktop\KruskalTree.txt");
        }

        private void CNF2FindSourceFileBtn_Click(object sender, EventArgs e)
        {
            GetFileNamePath(CNF2SourceFileTb, @"C:\Users\Karol\Desktop\CNF2.txt");
        }

        private void ArticulationFindSourceFileBtn_Click(object sender, EventArgs e)
        {
            GetFileNamePath(ArticulationSourceFileTb, @"C:\Users\Karol\Desktop\Articulation.txt");
        }

        private void TarjanFindSourceFileBtn_Click(object sender, EventArgs e)
        {
            GetFileNamePath(TarjanSourceFileTb, @"C:\Users\Karol\Desktop\Tarjan.txt");
        }

        private void GetFileNamePath(TextBox setTextbox, string defaultFileName)
        {
            var dialog = new OpenFileDialog();

            dialog.FileName = defaultFileName;
            dialog.Filter = "Pliki tekstowe (*.txt)|*.txt";

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                setTextbox.Text = dialog.FileName;
            }
        }
        #endregion
    }
}