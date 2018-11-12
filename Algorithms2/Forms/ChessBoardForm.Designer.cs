using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Algorithms2.Forms
{
    partial class ChessBoardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private const string _hetman = "X";

        private Label[,] _chessBoardLabel;
        private const int _tileSize = 40;
        private Color _blackClr = Color.DarkGray;
        private Color _whiteClr = Color.White;

        public ChessBoardForm(List<int[,]> chessBoards, int chessBoardSize, TimeSpan algorithmTime)
        {
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

            for (int row=0; row < chessBoardSize; row++)
            {
                for (int column=0; column < chessBoardSize; column++)
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
        }

        public ChessBoardForm(int[] positionInColumns, int chessBoardSize, TimeSpan algorithmTime)
        {
            if (positionInColumns == null)
            {
                throw new Exception("Position in columns are null");
            }

            _chessBoardLabel = new Label[chessBoardSize, chessBoardSize];

            var size = chessBoardSize * _tileSize * 2;

            this.Size = new Size(size, size);

            for (int row=0; row < chessBoardSize; row++)
            {
                for (int column=0; column < chessBoardSize; column++)
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
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ChessBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "ChessBoardForm";
            this.Text = "ChessBoard";
            this.ResumeLayout(false);

        }

        #endregion
    }
}