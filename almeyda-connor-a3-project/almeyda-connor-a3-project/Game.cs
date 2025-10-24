// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Player Specific Variables:
        Vector2 positionPlayer;
        float sizePlayer = 50;
        Color[] colorPlayer = { Color.White, Color.Yellow};
        bool isAlive = true;
        bool gameIsWon = false;
        // Rook Specific Variables
        Vector2 positionRook;
        float velocityRook;
        bool rookTouchLeftSide=true;
        float sizeRook = 50;
        Color colorRook = Color.Blue;
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(600, 800);
            Window.SetTitle("CoolMotionVector");
            // Set up variables once game is ready
            positionPlayer = new(Window.Width/2, Window.Height-sizePlayer);
            positionRook = new(10, Window.Height-100);
            // 
            Draw.LineSize = 1;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            if (isAlive==true && gameIsWon==false)
            {
                BoardSummon();
                // Run game logic
                PlayerHorizontalMovement();
                RookMovement();
                CheckIfWon();

                // Draw Player
                Draw.FillColor = colorPlayer[0];
                Draw.Square(positionPlayer, sizePlayer);
                // Draw Enemy Pieces
                Draw.FillColor = colorRook
                ;
                Draw.Square(positionRook, sizeRook);
            }
            if (gameIsWon==true)
            {
                BoardSummon();
                Draw.FillColor = colorPlayer[1]
                ;
                Draw.Square(positionPlayer, sizePlayer);
            }
            if (isAlive ==false && gameIsWon==false)
            {

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
            if (Input.IsKeyboardKeyPressed(KeyboardInput.S) && positionPlayer.Y <= Window.Height-2*sizePlayer)
            {
                positionPlayer += new Vector2(0, 50);
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
        void RookMovement()
        {
            if (positionRook.X >= Window.Width-50)
            {
                velocityRook = 0;
                rookTouchLeftSide = false;
            }
            if (positionRook.X <= 0)
            {
                velocityRook = 0;
                rookTouchLeftSide = true;
            }
            if (!rookTouchLeftSide)
            {
                velocityRook += 10;
                positionRook -= new Vector2(velocityRook * Time.DeltaTime, 0);
            }
            if (rookTouchLeftSide)
            {
                velocityRook += 10;
                positionRook += new Vector2(velocityRook * Time.DeltaTime, 0);
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
