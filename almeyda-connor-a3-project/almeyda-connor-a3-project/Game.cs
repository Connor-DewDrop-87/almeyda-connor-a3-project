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
        // Enemy Piece Variables
        RookPiece[] Rooks = [
            new RookPiece(new Vector2(250,700)),
            new RookPiece(new Vector2(10,250)),
            ];
        BishopPiece[] Bishops = [
            new BishopPiece(new Vector2(50,650),600,650),
            new BishopPiece(new Vector2(550,600),600,650)
            ];
        // Player Specific Variables:
        Vector2 positionPlayer = new Vector2(300, 750);
        Color[] colorPlayer = { Color.White, Color.Blue, Color.Yellow };
        // Player Collison Variables 
        Vector2 playerCentre = new Vector2(325, 775);
        public float leftEdgePlayer = 305;
        public float rightEdgePlayer = 345;
        public float topEdgePlayer = 755;
        public float bottomEdgePlayer = 795;

        // Game State Variables (Determine what is happening in the game right now)
        bool isAlive = true;
        bool gameIsWon = false;
        bool wasTouchedByRook = false;
        

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(600, 800);
            Window.SetTitle("Pawngger");
            // Set up variables once game is ready
            
            Draw.LineSize = 1;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            Draw.LineColor = Color.Black;
            BoardSummon();
            // Check Game State
            if (positionPlayer.Y <= 0)
            {
                gameIsWon = true;
            }
            if (wasTouchedByRook)
            {
                isAlive = false;
            }
            //// Game States
            // Playable State
            if (isAlive==true && gameIsWon==false)
            {
                // Player Commands
                Draw.FillColor = colorPlayer[1];
                Player();
                // Draw Enemy Pieces
                for (int i = 0; i < Rooks.Length; i++)
                {
                    Rooks[i].DrawRook();
                    bool wasTouchedByRook = Rooks[i].CollisonRook();
                }
                for (int i = 0; i < Bishops.Length; i++)
                {
                    Bishops[i].DrawBishop();
                }
                

            }
            // Win State
            if (gameIsWon==true)
            {
                positionPlayer = new(Window.Width / 2, 450);
                Draw.FillColor = colorPlayer[2];
                Player();
                Text.Color = Color.Blue;
                Text.Size = 40;
                Text.Draw("YOU WIN", new Vector2 (75,300));
                Text.Draw("PRESS SPACE TO RESET", new Vector2(75, 400));
                if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
                {
                    positionPlayer = new(Window.Width / 2, Window.Height - 50);
                    isAlive = true;
                    gameIsWon = false;
                }
            }
            // Lose State
            if (isAlive ==false && gameIsWon==false)
            {
                
                Draw.FillColor = colorPlayer[1];
                Player();
                Text.Color = Color.White;
                Text.Size = 40;
                Text.Draw("YOU LOSE", new Vector2(75, 300));
                Text.Draw("PRESS SPACE TO RESET", new Vector2(75, 400));
                if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
                {
                    positionPlayer = new(Window.Width / 2, Window.Height - 50);
                    isAlive = true;
                }
            }
        }

        void Player()
        {
            
            // Neck
            Draw.Rectangle(positionPlayer + new Vector2(15, 20), new Vector2(20, 30));
            // Base
            Draw.Arc(positionPlayer + new Vector2(25, 50), new Vector2(50, 25), 0, -180);
            // Head
            if (isAlive==true)
            {
                Draw.Circle(positionPlayer + new Vector2(25, 10), 15);
            }
            else
            {

            }
            if (isAlive==true && gameIsWon==false)
            {
                if (Input.IsKeyboardKeyPressed(KeyboardInput.D) && positionPlayer.X <= Window.Width - 2 * 50)
                {
                    positionPlayer += new Vector2(50, -50);
                }
                if (Input.IsKeyboardKeyPressed(KeyboardInput.A) && positionPlayer.X >= 50)
                {
                    positionPlayer -= new Vector2(50, 50);
                }
                if (Input.IsKeyboardKeyPressed(KeyboardInput.W) && positionPlayer.Y >= 50)
                {
                    positionPlayer -= new Vector2(0, 50);
                }
            }
            // Update HitBox Positions
            Vector2 playerCentre = positionPlayer + new Vector2(25, 25);
            float leftEdgePlayer = playerCentre.X - 20;
            float rightEdgePlayer = playerCentre.X + 20;
            float topEdgePlayer = playerCentre.Y - 20;
            float bottomEdgePlayer = playerCentre.Y + 20;
        }
        public float getLeftEdge()
        {
            return leftEdgePlayer;
        }
        public float getTopEdge()
        {
            return topEdgePlayer;
        }
        public float getRightEdge()
        {
            return rightEdgePlayer;
        }
        public float getBottomEdge()
        {
            return bottomEdgePlayer;
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
        
        public bool canMove()
        {
            if (isAlive==false && gameIsWon==true)
            {
                return false;
            }
            return true;
        }
        public bool gameOver()
        {
            if (isAlive == false)
            {
                return true;
            }
            return false;
        }
        
    }

}
