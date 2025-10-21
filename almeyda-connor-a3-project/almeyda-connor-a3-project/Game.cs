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
            positionBall = new(Window.Width / 2, Window.Height / 8);
            // 
            Draw.LineSize = 1;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            // Run game logic
            BallGravity();
            BallToScreen();
            Window.ClearBackground(Color.OffWhite);
            // Draw Ball
            Draw.FillColor = colorBall;
            float angle = Time.SecondsElapsed * (MathF.Tau/4);
            float width = MathF.Cos(angle)*radiusBall;
            float height = MathF.Sin(angle)*radiusBall;
            Draw.Ellipse(positionBall.X, positionBall.Y, width, height);
        }
        void BallGravity()
        {
            // Apply gravity to velocity
            velocityBall += new Vector2(0,10)*Time.DeltaTime;
            // Apply velocity to velocity
            positionBall += velocityBall;
        }

        void BallToScreen()
        {
            if (positionBall.Y+radiusBall >= Window.Height)
            {
                velocityBall.Y = -velocityBall.Y;
                velocityBall *= 0.8f;
                // Place ball against bottom edge of screen
                positionBall.Y = Window.Height - radiusBall;
            }
           
        }
    }

}
