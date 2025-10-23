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
        float sizeCharacter = 50;
        Color colorBall = Color.Green;
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(600, 800);
            Window.SetTitle("CoolMotionVector");
            // Set up variables once game is ready
            positionCharacter = new(Window.Width/2, Window.Height-sizeCharacter);
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
            if (Input.IsKeyboardKeyPressed(KeyboardInput.D) && positionCharacter.X <= Window.Width-2*sizeCharacter)
            {
                positionCharacter += new Vector2(50, 0);
            }
            if (Input.IsKeyboardKeyPressed(KeyboardInput.A) && positionCharacter.X >= sizeCharacter)
            {
                positionCharacter -= new Vector2(50, 0);
            }
            if (Input.IsKeyboardKeyPressed(KeyboardInput.W) && positionCharacter.Y >= sizeCharacter)
            {
                positionCharacter -= new Vector2(0, 50);
            }
            if (Input.IsKeyboardKeyPressed(KeyboardInput.S) && positionCharacter.Y <= Window.Height-2*sizeCharacter)
            {
                positionCharacter += new Vector2(0, 50);
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
    }

}
