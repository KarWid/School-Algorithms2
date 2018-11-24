using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Algorithms2.Forms
{
    public partial class ChessBoardForm : Form
    {
        private const string _hetman = "X";

        private Label[,] _chessBoardLabel;
        private const int _tileSize = 40;
        private Color _blackClr = Color.DarkGray;
        private Color _whiteClr = Color.White;

        public ChessBoardForm(List<int[,]> chessBoards, int chessBoardSize, TimeSpan algorithmTime)
        {
            InitializeComponent();

            if (chessBoards == null)
            {
                throw new Exception();
            }

            if (chessBoards.Count == 0)
            {
                MessageBox.Show("Brak wyników");
                return;
            }

            _chessBoardLabel = new Label[chessBoardSize, chessBoardSize];

            var chessBoard = chessBoards.First();

            for (int row = 0; row < chessBoardSize; row++)
            {
                for (int column = 0; column < chessBoardSize; column++)
                {
                    var panel = new Label
                    {
                        Text = chessBoard[row, column].ToString(),
                        Location = new Point(_tileSize * row, _tileSize * column),
                        Width = _tileSize,
                        Height = _tileSize,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    Controls.Add(panel);

                    _chessBoardLabel[row, column] = panel;

                    if (row % 2 == 0)
                    {
                        panel.BackColor = column % 2 != 0 ? _blackClr : _whiteClr;
                    }
                    else
                    {
                        panel.BackColor = column % 2 != 0 ? _whiteClr : _blackClr;
                    }
                }
            }

            CreateAlgorithmTimeTextBox(algorithmTime, chessBoardSize);
        }

        public ChessBoardForm(int[] positionInColumns, int chessBoardSize, TimeSpan algorithmTime)
        {
            InitializeComponent();

            if (positionInColumns == null)
            {
                throw new Exception("Position in columns are null");
            }

            _chessBoardLabel = new Label[chessBoardSize, chessBoardSize];

            var size = chessBoardSize * _tileSize * 2;

            this.Size = new Size(size, size);

            for (int row = 0; row < chessBoardSize; row++)
            {
                for (int column = 0; column < chessBoardSize; column++)
                {
                    var panel = new Label
                    {
                        Location = new Point(_tileSize * row, _tileSize * column),
                        Width = _tileSize,
                        Height = _tileSize,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    Controls.Add(panel);

                    _chessBoardLabel[row, column] = panel;

                    if (row % 2 == 0)
                    {
                        panel.BackColor = column % 2 != 0 ? _blackClr : _whiteClr;
                    }
                    else
                    {
                        panel.BackColor = column % 2 != 0 ? _whiteClr : _blackClr;
                    }

                    if (positionInColumns[column] == row)
                    {
                        panel.Text = _hetman;
                    }
                }
            }

            CreateAlgorithmTimeTextBox(algorithmTime, chessBoardSize);
        }

        private void CreateAlgorithmTimeTextBox(TimeSpan algorithmTime, int chessBoardSize)
        {
            var timerPosition = (chessBoardSize + 1) * _tileSize;

            var algorithmTimeTextBox = new TextBox
            {
                Location = new Point(0, timerPosition),
                Text = $"{algorithmTime} s",
                Width = 150,
                Height = 100,
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right
            };

            Controls.Add(algorithmTimeTextBox);

            this.Height = (chessBoardSize + 3) * _tileSize;
        }
    }
}