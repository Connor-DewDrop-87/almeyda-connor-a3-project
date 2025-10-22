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
        Vector2 positionBall;
        Vector2 velocityBall;
        Vector2[] platformPositions = { new Vector2 (300,700), new Vector2(100, 500) };
        Vector2[] platformSize = { new Vector2(30, 10), new Vector2(200, 30) };
        float radiusBall = 35;
        Color colorBall = Color.Red;
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(400, 800);
            Window.SetTitle("CoolMotionVector");
            // Set up variables once game is ready
            positionBall = new(Window.Width/2, Window.Height);
            // 
            Draw.LineSize = 1;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            // Run game logic
            BallHorizontalMovement();
            BallGravity();
            BallToScreen();
            
            // Draw Ball
            Draw.FillColor = colorBall;
            Draw.Circle(positionBall,radiusBall);
            // CreatePlateforms
            for (int i = 0; i < platformPositions.Length; i++)
            {
                CreatePlatform(i);
            }
        }
        void BallGravity()
        {
            // Check if can jump
            if (Input.IsKeyboardKeyDown(KeyboardInput.W) && positionBall.Y == Window.Height - radiusBall)
            {
                positionBall -= new Vector2(0, 50);
            }
            else
            {
                // Apply gravity to velocity
                velocityBall += new Vector2(0, 10) * (Time.DeltaTime/50);
                // Apply velocity to velocity
                positionBall += velocityBall;
            }
            
        }

        void BallHorizontalMovement()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.D) && positionBall.X + radiusBall <= Window.Width)
            {
                positionBall += new Vector2(10, 0);
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.A) && positionBall.X - radiusBall >= 0)
            {
                positionBall -= new Vector2(10, 0);
            }
            
        }

        void BallToScreen()
        {
            if (positionBall.Y+radiusBall >= Window.Height)
            {
                positionBall.Y = Window.Height - radiusBall;
            }
           
        }

        void CreatePlatform(int i)
        {
            Draw.Rectangle(platformPositions[i], platformSize[i]);
        }
    }

}
