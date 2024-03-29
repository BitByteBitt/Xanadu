﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileRed.png", UriKind.Relative)),
        };

        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-Z.png", UriKind.Relative))
        };

        private readonly Image[,] imageControls;

        private GameState gameState = new GameState();
        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameState.GameGrid);
        }

        private Image[,] SetupGameCanvas(GameGrid _grid)
        {
            Image[,] imageControls = new Image[_grid.Rows, _grid.Columns];
            int cellSize = 25;

            for (int r = 0; r < _grid.Rows; r++)
            {
                for (int c = 0; c < _grid.Columns; c++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };

                    Canvas.SetTop(imageControl, (r - 2) * cellSize);
                    Canvas.SetLeft(imageControl, c * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;
                }
            }

            return imageControls;
        }

        private void DrawGrid(GameGrid _grid)
        {
            for (int r = 0; r < _grid.Rows; r++)
            {
                for (int c = 0; c < _grid.Columns; c++)
                {
                    int id = _grid[r, c];
                    imageControls[r, c].Source = tileImages[id];
                }
            }
        }

        private void DrawBlock(Block _block)
        {
            foreach (Position p in _block.TilePositions())
            {
                imageControls[p.Row, p.Column].Source = tileImages[_block.Id];
            }
        }

        private void Draw(GameState _gamestate)
        {
            DrawGrid(_gamestate.GameGrid);
            DrawBlock(_gamestate.CurrentBlock);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            Draw(gameState);
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
