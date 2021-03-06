﻿namespace Algorithms2.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.ChessJumperProblemBtn = new System.Windows.Forms.Button();
            this.ChessBoardSizeLbl = new System.Windows.Forms.Label();
            this.ChessStartFieldRowLbl = new System.Windows.Forms.Label();
            this.ChessStartFieldColumnLbl = new System.Windows.Forms.Label();
            this.StartFieldLbl = new System.Windows.Forms.Label();
            this.ChessBoardSizeTb = new System.Windows.Forms.TextBox();
            this.ChessStartFieldRowTb = new System.Windows.Forms.TextBox();
            this.ChessStartFieldColumnTb = new System.Windows.Forms.TextBox();
            this.StartChessJumperProblemBtn = new System.Windows.Forms.Button();
            this.NQueenProblemWithReturnsBtn = new System.Windows.Forms.Button();
            this.NQueenStartProblemBtn = new System.Windows.Forms.Button();
            this.ChessBoardSizeNQueenTb = new System.Windows.Forms.TextBox();
            this.ChessBoardSizeNQueenLbl = new System.Windows.Forms.Label();
            this.WandsdorffProblemBtn = new System.Windows.Forms.Button();
            this.NQueenProblemPermutationsBtn = new System.Windows.Forms.Button();
            this.HashFunctionBtn = new System.Windows.Forms.Button();
            this.TableSizeHashFunctionTb = new System.Windows.Forms.TextBox();
            this.TableSizeHashFunctionLbl = new System.Windows.Forms.Label();
            this.HashFunctionStartBtn = new System.Windows.Forms.Button();
            this.HashFunctionRatioTb = new System.Windows.Forms.TextBox();
            this.HashFunctionRatioLbl = new System.Windows.Forms.Label();
            this.KruskalBtn = new System.Windows.Forms.Button();
            this.KruskalSourceFileTb = new System.Windows.Forms.TextBox();
            this.KruskalFindSourceFileBtn = new System.Windows.Forms.Button();
            this.KruskalStartBtn = new System.Windows.Forms.Button();
            this.CNF2StartBtn = new System.Windows.Forms.Button();
            this.CNF2FindSourceFileBtn = new System.Windows.Forms.Button();
            this.CNF2SourceFileTb = new System.Windows.Forms.TextBox();
            this.CNF2Btn = new System.Windows.Forms.Button();
            this.ArticulationStartBtn = new System.Windows.Forms.Button();
            this.ArticulationFindSourceFileBtn = new System.Windows.Forms.Button();
            this.ArticulationSourceFileTb = new System.Windows.Forms.TextBox();
            this.ArticulationBtn = new System.Windows.Forms.Button();
            this.TarjanStartBtn = new System.Windows.Forms.Button();
            this.TarjanFindSourceFileBtn = new System.Windows.Forms.Button();
            this.TarjanSourceFileTb = new System.Windows.Forms.TextBox();
            this.TarjanBtn = new System.Windows.Forms.Button();
            this.KMPStartBtn = new System.Windows.Forms.Button();
            this.KMPBtn = new System.Windows.Forms.Button();
            this.FordFulkersonStartBtn = new System.Windows.Forms.Button();
            this.FordFulkersonFindSourceFileBtn = new System.Windows.Forms.Button();
            this.FordFulkersonSourceFileTb = new System.Windows.Forms.TextBox();
            this.FordFulkersonBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChessJumperProblemBtn
            // 
            this.ChessJumperProblemBtn.Location = new System.Drawing.Point(12, 12);
            this.ChessJumperProblemBtn.Name = "ChessJumperProblemBtn";
            this.ChessJumperProblemBtn.Size = new System.Drawing.Size(165, 41);
            this.ChessJumperProblemBtn.TabIndex = 0;
            this.ChessJumperProblemBtn.Text = "Problem skoczka szachowego";
            this.ChessJumperProblemBtn.UseVisualStyleBackColor = true;
            this.ChessJumperProblemBtn.Click += new System.EventHandler(this.ChessJumperProblemBtn_Click);
            // 
            // ChessBoardSizeLbl
            // 
            this.ChessBoardSizeLbl.AutoSize = true;
            this.ChessBoardSizeLbl.Location = new System.Drawing.Point(189, 12);
            this.ChessBoardSizeLbl.Name = "ChessBoardSizeLbl";
            this.ChessBoardSizeLbl.Size = new System.Drawing.Size(78, 13);
            this.ChessBoardSizeLbl.TabIndex = 2;
            this.ChessBoardSizeLbl.Text = "Rozmiar tablicy";
            // 
            // ChessStartFieldRowLbl
            // 
            this.ChessStartFieldRowLbl.AutoSize = true;
            this.ChessStartFieldRowLbl.Location = new System.Drawing.Point(189, 55);
            this.ChessStartFieldRowLbl.Name = "ChessStartFieldRowLbl";
            this.ChessStartFieldRowLbl.Size = new System.Drawing.Size(39, 13);
            this.ChessStartFieldRowLbl.TabIndex = 3;
            this.ChessStartFieldRowLbl.Text = "Wiersz";
            // 
            // ChessStartFieldColumnLbl
            // 
            this.ChessStartFieldColumnLbl.AutoSize = true;
            this.ChessStartFieldColumnLbl.Location = new System.Drawing.Point(189, 81);
            this.ChessStartFieldColumnLbl.Name = "ChessStartFieldColumnLbl";
            this.ChessStartFieldColumnLbl.Size = new System.Drawing.Size(48, 13);
            this.ChessStartFieldColumnLbl.TabIndex = 4;
            this.ChessStartFieldColumnLbl.Text = "Kolumna";
            // 
            // StartFieldLbl
            // 
            this.StartFieldLbl.AutoSize = true;
            this.StartFieldLbl.Location = new System.Drawing.Point(189, 40);
            this.StartFieldLbl.Name = "StartFieldLbl";
            this.StartFieldLbl.Size = new System.Drawing.Size(105, 13);
            this.StartFieldLbl.TabIndex = 5;
            this.StartFieldLbl.Text = "Pozycja początkowa";
            // 
            // ChessBoardSizeTb
            // 
            this.ChessBoardSizeTb.Location = new System.Drawing.Point(300, 12);
            this.ChessBoardSizeTb.Name = "ChessBoardSizeTb";
            this.ChessBoardSizeTb.Size = new System.Drawing.Size(35, 20);
            this.ChessBoardSizeTb.TabIndex = 6;
            // 
            // ChessStartFieldRowTb
            // 
            this.ChessStartFieldRowTb.Location = new System.Drawing.Point(300, 55);
            this.ChessStartFieldRowTb.Name = "ChessStartFieldRowTb";
            this.ChessStartFieldRowTb.Size = new System.Drawing.Size(35, 20);
            this.ChessStartFieldRowTb.TabIndex = 7;
            // 
            // ChessStartFieldColumnTb
            // 
            this.ChessStartFieldColumnTb.Location = new System.Drawing.Point(300, 81);
            this.ChessStartFieldColumnTb.Name = "ChessStartFieldColumnTb";
            this.ChessStartFieldColumnTb.Size = new System.Drawing.Size(35, 20);
            this.ChessStartFieldColumnTb.TabIndex = 8;
            // 
            // StartChessJumperProblemBtn
            // 
            this.StartChessJumperProblemBtn.Location = new System.Drawing.Point(356, 12);
            this.StartChessJumperProblemBtn.Name = "StartChessJumperProblemBtn";
            this.StartChessJumperProblemBtn.Size = new System.Drawing.Size(152, 20);
            this.StartChessJumperProblemBtn.TabIndex = 9;
            this.StartChessJumperProblemBtn.Text = "Uruchom skoczka";
            this.StartChessJumperProblemBtn.UseVisualStyleBackColor = true;
            this.StartChessJumperProblemBtn.Click += new System.EventHandler(this.StartChessJumperProblemBtn_Click);
            // 
            // NQueenProblemWithReturnsBtn
            // 
            this.NQueenProblemWithReturnsBtn.Location = new System.Drawing.Point(12, 122);
            this.NQueenProblemWithReturnsBtn.Name = "NQueenProblemWithReturnsBtn";
            this.NQueenProblemWithReturnsBtn.Size = new System.Drawing.Size(165, 41);
            this.NQueenProblemWithReturnsBtn.TabIndex = 10;
            this.NQueenProblemWithReturnsBtn.Text = "Problem N Hetmanow z powrotami";
            this.NQueenProblemWithReturnsBtn.UseVisualStyleBackColor = true;
            this.NQueenProblemWithReturnsBtn.Click += new System.EventHandler(this.NQueenProblemWithReturnsBtn_Click);
            // 
            // NQueenStartProblemBtn
            // 
            this.NQueenStartProblemBtn.Location = new System.Drawing.Point(356, 122);
            this.NQueenStartProblemBtn.Name = "NQueenStartProblemBtn";
            this.NQueenStartProblemBtn.Size = new System.Drawing.Size(152, 20);
            this.NQueenStartProblemBtn.TabIndex = 11;
            this.NQueenStartProblemBtn.Text = "Uruchom N Hetmanow";
            this.NQueenStartProblemBtn.UseVisualStyleBackColor = true;
            this.NQueenStartProblemBtn.Click += new System.EventHandler(this.NQueenStartProblemBtn_Click);
            // 
            // ChessBoardSizeNQueenTb
            // 
            this.ChessBoardSizeNQueenTb.Location = new System.Drawing.Point(300, 122);
            this.ChessBoardSizeNQueenTb.Name = "ChessBoardSizeNQueenTb";
            this.ChessBoardSizeNQueenTb.Size = new System.Drawing.Size(35, 20);
            this.ChessBoardSizeNQueenTb.TabIndex = 13;
            // 
            // ChessBoardSizeNQueenLbl
            // 
            this.ChessBoardSizeNQueenLbl.AutoSize = true;
            this.ChessBoardSizeNQueenLbl.Location = new System.Drawing.Point(189, 122);
            this.ChessBoardSizeNQueenLbl.Name = "ChessBoardSizeNQueenLbl";
            this.ChessBoardSizeNQueenLbl.Size = new System.Drawing.Size(78, 13);
            this.ChessBoardSizeNQueenLbl.TabIndex = 12;
            this.ChessBoardSizeNQueenLbl.Text = "Rozmiar tablicy";
            // 
            // WandsdorffProblemBtn
            // 
            this.WandsdorffProblemBtn.Location = new System.Drawing.Point(12, 60);
            this.WandsdorffProblemBtn.Name = "WandsdorffProblemBtn";
            this.WandsdorffProblemBtn.Size = new System.Drawing.Size(165, 41);
            this.WandsdorffProblemBtn.TabIndex = 14;
            this.WandsdorffProblemBtn.Text = "Reguła Warnsdorffa";
            this.WandsdorffProblemBtn.UseVisualStyleBackColor = true;
            this.WandsdorffProblemBtn.Click += new System.EventHandler(this.WandsdorffProblemBtn_Click);
            // 
            // NQueenProblemPermutationsBtn
            // 
            this.NQueenProblemPermutationsBtn.Location = new System.Drawing.Point(12, 169);
            this.NQueenProblemPermutationsBtn.Name = "NQueenProblemPermutationsBtn";
            this.NQueenProblemPermutationsBtn.Size = new System.Drawing.Size(165, 41);
            this.NQueenProblemPermutationsBtn.TabIndex = 15;
            this.NQueenProblemPermutationsBtn.Text = "Problem N Hetmanow z permutacjami";
            this.NQueenProblemPermutationsBtn.UseVisualStyleBackColor = true;
            this.NQueenProblemPermutationsBtn.Click += new System.EventHandler(this.NQueenProblemPermutationsBtn_Click);
            // 
            // HashFunctionBtn
            // 
            this.HashFunctionBtn.Location = new System.Drawing.Point(12, 225);
            this.HashFunctionBtn.Name = "HashFunctionBtn";
            this.HashFunctionBtn.Size = new System.Drawing.Size(165, 48);
            this.HashFunctionBtn.TabIndex = 16;
            this.HashFunctionBtn.Text = "Funkcja hashująca";
            this.HashFunctionBtn.UseVisualStyleBackColor = true;
            this.HashFunctionBtn.Click += new System.EventHandler(this.HashFunctionBtn_Click);
            // 
            // TableSizeHashFunctionTb
            // 
            this.TableSizeHashFunctionTb.Location = new System.Drawing.Point(300, 225);
            this.TableSizeHashFunctionTb.Name = "TableSizeHashFunctionTb";
            this.TableSizeHashFunctionTb.Size = new System.Drawing.Size(35, 20);
            this.TableSizeHashFunctionTb.TabIndex = 18;
            // 
            // TableSizeHashFunctionLbl
            // 
            this.TableSizeHashFunctionLbl.AutoSize = true;
            this.TableSizeHashFunctionLbl.Location = new System.Drawing.Point(189, 225);
            this.TableSizeHashFunctionLbl.Name = "TableSizeHashFunctionLbl";
            this.TableSizeHashFunctionLbl.Size = new System.Drawing.Size(78, 13);
            this.TableSizeHashFunctionLbl.TabIndex = 17;
            this.TableSizeHashFunctionLbl.Text = "Rozmiar tablicy";
            // 
            // HashFunctionStartBtn
            // 
            this.HashFunctionStartBtn.Location = new System.Drawing.Point(356, 224);
            this.HashFunctionStartBtn.Name = "HashFunctionStartBtn";
            this.HashFunctionStartBtn.Size = new System.Drawing.Size(152, 21);
            this.HashFunctionStartBtn.TabIndex = 19;
            this.HashFunctionStartBtn.Text = "Uruchom funkcję hashującą";
            this.HashFunctionStartBtn.UseVisualStyleBackColor = true;
            this.HashFunctionStartBtn.Click += new System.EventHandler(this.HashFunctionStartBtn_Click);
            // 
            // HashFunctionRatioTb
            // 
            this.HashFunctionRatioTb.Location = new System.Drawing.Point(300, 253);
            this.HashFunctionRatioTb.Name = "HashFunctionRatioTb";
            this.HashFunctionRatioTb.Size = new System.Drawing.Size(35, 20);
            this.HashFunctionRatioTb.TabIndex = 21;
            // 
            // HashFunctionRatioLbl
            // 
            this.HashFunctionRatioLbl.AutoSize = true;
            this.HashFunctionRatioLbl.Location = new System.Drawing.Point(189, 253);
            this.HashFunctionRatioLbl.Name = "HashFunctionRatioLbl";
            this.HashFunctionRatioLbl.Size = new System.Drawing.Size(75, 13);
            this.HashFunctionRatioLbl.TabIndex = 20;
            this.HashFunctionRatioLbl.Text = "Współczynnik";
            // 
            // KruskalBtn
            // 
            this.KruskalBtn.Location = new System.Drawing.Point(12, 279);
            this.KruskalBtn.Name = "KruskalBtn";
            this.KruskalBtn.Size = new System.Drawing.Size(165, 48);
            this.KruskalBtn.TabIndex = 22;
            this.KruskalBtn.Text = "Kruskal";
            this.KruskalBtn.UseVisualStyleBackColor = true;
            this.KruskalBtn.Click += new System.EventHandler(this.KruskalBtn_Click);
            // 
            // KruskalSourceFileTb
            // 
            this.KruskalSourceFileTb.Location = new System.Drawing.Point(192, 307);
            this.KruskalSourceFileTb.Name = "KruskalSourceFileTb";
            this.KruskalSourceFileTb.Size = new System.Drawing.Size(143, 20);
            this.KruskalSourceFileTb.TabIndex = 23;
            // 
            // KruskalFindSourceFileBtn
            // 
            this.KruskalFindSourceFileBtn.Location = new System.Drawing.Point(192, 279);
            this.KruskalFindSourceFileBtn.Name = "KruskalFindSourceFileBtn";
            this.KruskalFindSourceFileBtn.Size = new System.Drawing.Size(143, 22);
            this.KruskalFindSourceFileBtn.TabIndex = 24;
            this.KruskalFindSourceFileBtn.Text = "Wybierz plik";
            this.KruskalFindSourceFileBtn.UseVisualStyleBackColor = true;
            this.KruskalFindSourceFileBtn.Click += new System.EventHandler(this.KruskalFindSourceFileBtn_Click);
            // 
            // KruskalStartBtn
            // 
            this.KruskalStartBtn.Location = new System.Drawing.Point(356, 279);
            this.KruskalStartBtn.Name = "KruskalStartBtn";
            this.KruskalStartBtn.Size = new System.Drawing.Size(152, 21);
            this.KruskalStartBtn.TabIndex = 25;
            this.KruskalStartBtn.Text = "Uruchom Kruskala";
            this.KruskalStartBtn.UseVisualStyleBackColor = true;
            this.KruskalStartBtn.Click += new System.EventHandler(this.KruskalStartBtn_Click);
            // 
            // CNF2StartBtn
            // 
            this.CNF2StartBtn.Location = new System.Drawing.Point(882, 12);
            this.CNF2StartBtn.Name = "CNF2StartBtn";
            this.CNF2StartBtn.Size = new System.Drawing.Size(152, 21);
            this.CNF2StartBtn.TabIndex = 29;
            this.CNF2StartBtn.Text = "Uruchom 2-CNF";
            this.CNF2StartBtn.UseVisualStyleBackColor = true;
            this.CNF2StartBtn.Click += new System.EventHandler(this.CNF2StartBtn_Click);
            // 
            // CNF2FindSourceFileBtn
            // 
            this.CNF2FindSourceFileBtn.Location = new System.Drawing.Point(718, 12);
            this.CNF2FindSourceFileBtn.Name = "CNF2FindSourceFileBtn";
            this.CNF2FindSourceFileBtn.Size = new System.Drawing.Size(143, 22);
            this.CNF2FindSourceFileBtn.TabIndex = 28;
            this.CNF2FindSourceFileBtn.Text = "Wybierz plik";
            this.CNF2FindSourceFileBtn.UseVisualStyleBackColor = true;
            this.CNF2FindSourceFileBtn.Click += new System.EventHandler(this.CNF2FindSourceFileBtn_Click);
            // 
            // CNF2SourceFileTb
            // 
            this.CNF2SourceFileTb.Location = new System.Drawing.Point(718, 40);
            this.CNF2SourceFileTb.Name = "CNF2SourceFileTb";
            this.CNF2SourceFileTb.Size = new System.Drawing.Size(143, 20);
            this.CNF2SourceFileTb.TabIndex = 27;
            // 
            // CNF2Btn
            // 
            this.CNF2Btn.Location = new System.Drawing.Point(538, 12);
            this.CNF2Btn.Name = "CNF2Btn";
            this.CNF2Btn.Size = new System.Drawing.Size(165, 48);
            this.CNF2Btn.TabIndex = 26;
            this.CNF2Btn.Text = "2-CNF";
            this.CNF2Btn.UseVisualStyleBackColor = true;
            this.CNF2Btn.Click += new System.EventHandler(this.CNF2Btn_Click);
            // 
            // ArticulationStartBtn
            // 
            this.ArticulationStartBtn.Location = new System.Drawing.Point(882, 81);
            this.ArticulationStartBtn.Name = "ArticulationStartBtn";
            this.ArticulationStartBtn.Size = new System.Drawing.Size(152, 21);
            this.ArticulationStartBtn.TabIndex = 33;
            this.ArticulationStartBtn.Text = "Uruchom punkty artykulacji";
            this.ArticulationStartBtn.UseVisualStyleBackColor = true;
            this.ArticulationStartBtn.Click += new System.EventHandler(this.ArticulationStartBtn_Click);
            // 
            // ArticulationFindSourceFileBtn
            // 
            this.ArticulationFindSourceFileBtn.Location = new System.Drawing.Point(718, 81);
            this.ArticulationFindSourceFileBtn.Name = "ArticulationFindSourceFileBtn";
            this.ArticulationFindSourceFileBtn.Size = new System.Drawing.Size(143, 22);
            this.ArticulationFindSourceFileBtn.TabIndex = 32;
            this.ArticulationFindSourceFileBtn.Text = "Wybierz plik";
            this.ArticulationFindSourceFileBtn.UseVisualStyleBackColor = true;
            this.ArticulationFindSourceFileBtn.Click += new System.EventHandler(this.ArticulationFindSourceFileBtn_Click);
            // 
            // ArticulationSourceFileTb
            // 
            this.ArticulationSourceFileTb.Location = new System.Drawing.Point(718, 109);
            this.ArticulationSourceFileTb.Name = "ArticulationSourceFileTb";
            this.ArticulationSourceFileTb.Size = new System.Drawing.Size(143, 20);
            this.ArticulationSourceFileTb.TabIndex = 31;
            // 
            // ArticulationBtn
            // 
            this.ArticulationBtn.Location = new System.Drawing.Point(538, 81);
            this.ArticulationBtn.Name = "ArticulationBtn";
            this.ArticulationBtn.Size = new System.Drawing.Size(165, 48);
            this.ArticulationBtn.TabIndex = 30;
            this.ArticulationBtn.Text = "Punkty artykulacji i mosty";
            this.ArticulationBtn.UseVisualStyleBackColor = true;
            this.ArticulationBtn.Click += new System.EventHandler(this.ArticulationBtn_Click);
            // 
            // TarjanStartBtn
            // 
            this.TarjanStartBtn.Location = new System.Drawing.Point(882, 144);
            this.TarjanStartBtn.Name = "TarjanStartBtn";
            this.TarjanStartBtn.Size = new System.Drawing.Size(152, 21);
            this.TarjanStartBtn.TabIndex = 37;
            this.TarjanStartBtn.Text = "Uruchom Tarjana";
            this.TarjanStartBtn.UseVisualStyleBackColor = true;
            this.TarjanStartBtn.Click += new System.EventHandler(this.TarjanStartBtn_Click);
            // 
            // TarjanFindSourceFileBtn
            // 
            this.TarjanFindSourceFileBtn.Location = new System.Drawing.Point(718, 144);
            this.TarjanFindSourceFileBtn.Name = "TarjanFindSourceFileBtn";
            this.TarjanFindSourceFileBtn.Size = new System.Drawing.Size(143, 22);
            this.TarjanFindSourceFileBtn.TabIndex = 36;
            this.TarjanFindSourceFileBtn.Text = "Wybierz plik";
            this.TarjanFindSourceFileBtn.UseVisualStyleBackColor = true;
            this.TarjanFindSourceFileBtn.Click += new System.EventHandler(this.TarjanFindSourceFileBtn_Click);
            // 
            // TarjanSourceFileTb
            // 
            this.TarjanSourceFileTb.Location = new System.Drawing.Point(718, 172);
            this.TarjanSourceFileTb.Name = "TarjanSourceFileTb";
            this.TarjanSourceFileTb.Size = new System.Drawing.Size(143, 20);
            this.TarjanSourceFileTb.TabIndex = 35;
            // 
            // TarjanBtn
            // 
            this.TarjanBtn.Location = new System.Drawing.Point(538, 144);
            this.TarjanBtn.Name = "TarjanBtn";
            this.TarjanBtn.Size = new System.Drawing.Size(165, 48);
            this.TarjanBtn.TabIndex = 34;
            this.TarjanBtn.Text = "Algorytm Tarjana";
            this.TarjanBtn.UseVisualStyleBackColor = true;
            this.TarjanBtn.Click += new System.EventHandler(this.TarjanBtn_Click);
            // 
            // KMPStartBtn
            // 
            this.KMPStartBtn.Location = new System.Drawing.Point(718, 279);
            this.KMPStartBtn.Name = "KMPStartBtn";
            this.KMPStartBtn.Size = new System.Drawing.Size(152, 21);
            this.KMPStartBtn.TabIndex = 41;
            this.KMPStartBtn.Text = "Uruchom KMP";
            this.KMPStartBtn.UseVisualStyleBackColor = true;
            this.KMPStartBtn.Click += new System.EventHandler(this.KMPStartBtn_Click);
            // 
            // KMPBtn
            // 
            this.KMPBtn.Location = new System.Drawing.Point(538, 279);
            this.KMPBtn.Name = "KMPBtn";
            this.KMPBtn.Size = new System.Drawing.Size(165, 48);
            this.KMPBtn.TabIndex = 38;
            this.KMPBtn.Text = "Algorytm KMP";
            this.KMPBtn.UseVisualStyleBackColor = true;
            this.KMPBtn.Click += new System.EventHandler(this.KMPBtn_Click);
            // 
            // FordFulkersonStartBtn
            // 
            this.FordFulkersonStartBtn.Location = new System.Drawing.Point(882, 207);
            this.FordFulkersonStartBtn.Name = "FordFulkersonStartBtn";
            this.FordFulkersonStartBtn.Size = new System.Drawing.Size(152, 21);
            this.FordFulkersonStartBtn.TabIndex = 45;
            this.FordFulkersonStartBtn.Text = "Uruchom Forda Fulkersona";
            this.FordFulkersonStartBtn.UseVisualStyleBackColor = true;
            this.FordFulkersonStartBtn.Click += new System.EventHandler(this.FordFulkersonStartBtn_Click);
            // 
            // FordFulkersonFindSourceFileBtn
            // 
            this.FordFulkersonFindSourceFileBtn.Location = new System.Drawing.Point(718, 207);
            this.FordFulkersonFindSourceFileBtn.Name = "FordFulkersonFindSourceFileBtn";
            this.FordFulkersonFindSourceFileBtn.Size = new System.Drawing.Size(143, 22);
            this.FordFulkersonFindSourceFileBtn.TabIndex = 44;
            this.FordFulkersonFindSourceFileBtn.Text = "Wybierz plik";
            this.FordFulkersonFindSourceFileBtn.UseVisualStyleBackColor = true;
            this.FordFulkersonFindSourceFileBtn.Click += new System.EventHandler(this.FordFulkersonFindSourceFileBtn_Click);
            // 
            // FordFulkersonSourceFileTb
            // 
            this.FordFulkersonSourceFileTb.Location = new System.Drawing.Point(718, 235);
            this.FordFulkersonSourceFileTb.Name = "FordFulkersonSourceFileTb";
            this.FordFulkersonSourceFileTb.Size = new System.Drawing.Size(143, 20);
            this.FordFulkersonSourceFileTb.TabIndex = 43;
            // 
            // FordFulkersonBtn
            // 
            this.FordFulkersonBtn.Location = new System.Drawing.Point(538, 207);
            this.FordFulkersonBtn.Name = "FordFulkersonBtn";
            this.FordFulkersonBtn.Size = new System.Drawing.Size(165, 48);
            this.FordFulkersonBtn.TabIndex = 42;
            this.FordFulkersonBtn.Text = "Algorytm Ford-Fulkersona";
            this.FordFulkersonBtn.UseVisualStyleBackColor = true;
            this.FordFulkersonBtn.Click += new System.EventHandler(this.FordFulkersonBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 456);
            this.Controls.Add(this.FordFulkersonStartBtn);
            this.Controls.Add(this.FordFulkersonFindSourceFileBtn);
            this.Controls.Add(this.FordFulkersonSourceFileTb);
            this.Controls.Add(this.FordFulkersonBtn);
            this.Controls.Add(this.KMPStartBtn);
            this.Controls.Add(this.KMPBtn);
            this.Controls.Add(this.TarjanStartBtn);
            this.Controls.Add(this.TarjanFindSourceFileBtn);
            this.Controls.Add(this.TarjanSourceFileTb);
            this.Controls.Add(this.TarjanBtn);
            this.Controls.Add(this.ArticulationStartBtn);
            this.Controls.Add(this.ArticulationFindSourceFileBtn);
            this.Controls.Add(this.ArticulationSourceFileTb);
            this.Controls.Add(this.ArticulationBtn);
            this.Controls.Add(this.CNF2StartBtn);
            this.Controls.Add(this.CNF2FindSourceFileBtn);
            this.Controls.Add(this.CNF2SourceFileTb);
            this.Controls.Add(this.CNF2Btn);
            this.Controls.Add(this.KruskalStartBtn);
            this.Controls.Add(this.KruskalFindSourceFileBtn);
            this.Controls.Add(this.KruskalSourceFileTb);
            this.Controls.Add(this.KruskalBtn);
            this.Controls.Add(this.HashFunctionRatioTb);
            this.Controls.Add(this.HashFunctionRatioLbl);
            this.Controls.Add(this.HashFunctionStartBtn);
            this.Controls.Add(this.TableSizeHashFunctionTb);
            this.Controls.Add(this.TableSizeHashFunctionLbl);
            this.Controls.Add(this.HashFunctionBtn);
            this.Controls.Add(this.NQueenProblemPermutationsBtn);
            this.Controls.Add(this.WandsdorffProblemBtn);
            this.Controls.Add(this.ChessBoardSizeNQueenTb);
            this.Controls.Add(this.ChessBoardSizeNQueenLbl);
            this.Controls.Add(this.NQueenStartProblemBtn);
            this.Controls.Add(this.NQueenProblemWithReturnsBtn);
            this.Controls.Add(this.StartChessJumperProblemBtn);
            this.Controls.Add(this.ChessStartFieldColumnTb);
            this.Controls.Add(this.ChessStartFieldRowTb);
            this.Controls.Add(this.ChessBoardSizeTb);
            this.Controls.Add(this.StartFieldLbl);
            this.Controls.Add(this.ChessStartFieldColumnLbl);
            this.Controls.Add(this.ChessStartFieldRowLbl);
            this.Controls.Add(this.ChessBoardSizeLbl);
            this.Controls.Add(this.ChessJumperProblemBtn);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChessJumperProblemBtn;
        private System.Windows.Forms.Label ChessBoardSizeLbl;
        private System.Windows.Forms.Label ChessStartFieldRowLbl;
        private System.Windows.Forms.Label ChessStartFieldColumnLbl;
        private System.Windows.Forms.Label StartFieldLbl;
        private System.Windows.Forms.TextBox ChessBoardSizeTb;
        private System.Windows.Forms.TextBox ChessStartFieldRowTb;
        private System.Windows.Forms.TextBox ChessStartFieldColumnTb;
        private System.Windows.Forms.Button StartChessJumperProblemBtn;
        private System.Windows.Forms.Button NQueenProblemWithReturnsBtn;
        private System.Windows.Forms.Button NQueenStartProblemBtn;
        private System.Windows.Forms.TextBox ChessBoardSizeNQueenTb;
        private System.Windows.Forms.Label ChessBoardSizeNQueenLbl;
        private System.Windows.Forms.Button WandsdorffProblemBtn;
        private System.Windows.Forms.Button NQueenProblemPermutationsBtn;
        private System.Windows.Forms.Button HashFunctionBtn;
        private System.Windows.Forms.TextBox TableSizeHashFunctionTb;
        private System.Windows.Forms.Label TableSizeHashFunctionLbl;
        private System.Windows.Forms.Button HashFunctionStartBtn;
        private System.Windows.Forms.TextBox HashFunctionRatioTb;
        private System.Windows.Forms.Label HashFunctionRatioLbl;
        private System.Windows.Forms.Button KruskalBtn;
        private System.Windows.Forms.TextBox KruskalSourceFileTb;
        private System.Windows.Forms.Button KruskalFindSourceFileBtn;
        private System.Windows.Forms.Button KruskalStartBtn;
        private System.Windows.Forms.Button CNF2StartBtn;
        private System.Windows.Forms.Button CNF2FindSourceFileBtn;
        private System.Windows.Forms.TextBox CNF2SourceFileTb;
        private System.Windows.Forms.Button CNF2Btn;
        private System.Windows.Forms.Button ArticulationStartBtn;
        private System.Windows.Forms.Button ArticulationFindSourceFileBtn;
        private System.Windows.Forms.TextBox ArticulationSourceFileTb;
        private System.Windows.Forms.Button ArticulationBtn;
        private System.Windows.Forms.Button TarjanStartBtn;
        private System.Windows.Forms.Button TarjanFindSourceFileBtn;
        private System.Windows.Forms.TextBox TarjanSourceFileTb;
        private System.Windows.Forms.Button TarjanBtn;
        private System.Windows.Forms.Button KMPStartBtn;
        private System.Windows.Forms.Button KMPBtn;
        private System.Windows.Forms.Button FordFulkersonStartBtn;
        private System.Windows.Forms.Button FordFulkersonFindSourceFileBtn;
        private System.Windows.Forms.TextBox FordFulkersonSourceFileTb;
        private System.Windows.Forms.Button FordFulkersonBtn;
    }
}

