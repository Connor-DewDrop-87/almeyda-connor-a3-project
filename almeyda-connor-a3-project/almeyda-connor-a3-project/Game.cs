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
        // Place your variables here:
        Vector2 positionCharacter;
        float sizeCharacter = 20;
        Vector2[] platformPositions = { new Vector2 (300,750), new Vector2(100, 500) };
        Vector2[] platformSize = { new Vector2(300, 10), new Vector2(200, 30) };
        Color colorBall = Color.Green;
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(600, 800);
            Window.SetTitle("CoolMotionVector");
            // Set up variables once game is ready
            positionCharacter = new(Window.Width/2, Window.Height/8);
            // 
            Draw.LineSize = 1;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            
            Window.ClearBackground(Color.OffWhite);
            BoardSummon();
            // Run game logic
            BallHorizontalMovement();
            
            // Draw Ball
            Draw.FillColor = colorBall;
            Draw.Square(positionCharacter, sizeCharacter);
        }
        

        void BallHorizontalMovement()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.D) && positionCharacter.X <= Window.Width-2*sizeCharacter)
            {
                positionCharacter += new Vector2(20, 0);
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.A) && positionCharacter.X >= sizeCharacter)
            {
                positionCharacter -= new Vector2(20, 0);
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.W) && positionCharacter.Y >= sizeCharacter)
            {
                positionCharacter -= new Vector2(0, 20);
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.S) && positionCharacter.Y <= Window.Height-2*sizeCharacter)
            {
                positionCharacter += new Vector2(0, 20);
            }
        }
        void BoardSummon()
        {
            for (int y = 0; y < 8; y++)
            {
                int yremainder = y % 2;
                for (int x = 0; x < 8; x++)
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
    }

}
