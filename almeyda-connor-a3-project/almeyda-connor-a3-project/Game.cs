// Include the namespaces (code libraries) you need below.
using System;
using System.Drawing;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Enemy Pieces
        EnemyPiece[] Rooks = [
            new EnemyPiece(new Vector2(300,700)),
            new EnemyPiece(new Vector2(10,250)),
            ];
        // Player Specific Variables:
        Vector2 positionPlayer;
        float sizePlayer = 50;
        Color[] colorPlayer = { Color.White, Color.Yellow};
        bool isAlive = true;
        bool gameIsWon = false;
        // Rook Specific Variables
        

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(600, 800);
            Window.SetTitle("CoolMotionVector");
            // Set up variables once game is ready
            positionPlayer = new(Window.Width/2, Window.Height-sizePlayer);
            
            
            // 
            Draw.LineSize = 1;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            CheckIfWon();
            //// Game States
            // Playable State
            if (isAlive==true && gameIsWon==false)
            {
                BoardSummon();
                // Run game logic
                PlayerHorizontalMovement();
                

                // Draw Player
                Draw.FillColor = colorPlayer[0];
                Draw.Square(positionPlayer, sizePlayer);
                // Draw Rooks
                for (int i = 0; i < Rooks.Length; i++)
                {
                    Rooks[i].DrawMovement();
                }
                

            }
            // Win State
            if (gameIsWon==true)
            {
                BoardSummon();
                Draw.FillColor = colorPlayer[1]
                ;
                Draw.Square(positionPlayer, sizePlayer);
                Text.Color = Color.Blue;
                Text.Size = 120;
                Text.Draw("YOU WIN", 75, 300);
            }
            // Lose State
            if (isAlive ==false && gameIsWon==false)
            {
                BoardSummon();
                Text.Color = Color.Blue;
                Text.Size = 120;
                Text.Draw("YOU LOSE", 75, 300);
            }
        }
        

        void PlayerHorizontalMovement()
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.D) && positionPlayer.X <= Window.Width-2*sizePlayer)
            {
                positionPlayer += new Vector2(50, -50);
            }
            if (Input.IsKeyboardKeyPressed(KeyboardInput.A) && positionPlayer.X >= sizePlayer)
            {
                positionPlayer -= new Vector2(50, 50);
            }
            if (Input.IsKeyboardKeyPressed(KeyboardInput.W) && positionPlayer.Y >= sizePlayer)
            {
                positionPlayer -= new Vector2(0, 50);
            }
            
        }
        void BoardSummon()
        {
            for (int y = 0; y < 16; y++)
            {
                int yremainder = y % 2;
                for (int x = 0; x < 12; x++)
                {
                    int xremainder = x % 2;
                    if (xremainder == 0 ^ yremainder == 1)
                    {
                        Draw.FillColor = Color.Black;
                        Draw.Square(0 + 50 * x, 0 + 50 * y, 50);

                    }
                    if (xremainder == 1 ^ yremainder == 1)
                    {
                        Draw.FillColor = Color.Red;
                        Draw.Square(0 + 50 * x, 0 + 50 * y, 50);

                    }

                }

            }
        }
        
        void CheckIfWon()
        {
            if (positionPlayer.Y <= 0)
            {
                gameIsWon = true;
            }
            if (positionPlayer.X >= 550)
            {
                isAlive = false;
            }
        }
    }

}
