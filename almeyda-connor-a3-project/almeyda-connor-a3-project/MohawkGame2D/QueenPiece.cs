using MohawkGame2D;
using System;
using System.Numerics;

namespace MohawkGame2D;

    public class QueenPiece
    {
    public Vector2 positionQueen = new(0, 0);
    public float velocityQueen;
    public float maxYQueen;
    public float minYQueen;
    // Determines whether or not vector is going up or down (Negative means up, Positive means down)
    public int upOrDown = -1;
    public bool QueenDoneWithLeftSide = true;
    public bool QueenTouchBottom = true;
    public bool QueenStillScooting = false;


    public QueenPiece(Vector2 positionBishop, float minY, float maxY)
    {
        this.positionQueen = positionBishop;
        this.minYQueen = minY;
        this.maxYQueen = maxY;
    }
    public void DrawQueen()
    {
        Draw.FillColor = Color.White;
        // Neck
        Draw.Rectangle(positionQueen + new Vector2(15, 15), new Vector2(20, 35));
        // Head
        Draw.Triangle(positionQueen + new Vector2(5, 10), positionQueen + new Vector2(45, 10), positionQueen + new Vector2(25, 20));
        // Crown 
        Draw.Circle(positionQueen + new Vector2(25,5), 10);
        for (int i = 0; i < 5; i++)
        {
            Draw.Circle(positionQueen + new Vector2(15 + i * 5, 10), 2.5f);
        }
        
        // Base
        Draw.Arc(positionQueen + new Vector2(25, 50), new Vector2(50, 25), 0, -180);
        // Movement
        if (positionQueen.X >= Window.Width - 50)
        {
            velocityQueen = 0;
            positionQueen.X = Window.Width - 50;
            QueenDoneWithLeftSide = false;
            if (positionQueen.Y < maxYQueen && positionQueen.Y > minYQueen)
            {
                QueenStillScooting = true;
            }
            else
            {
                QueenStillScooting = false;
            }
        }
        if (positionQueen.X <= 0)
        {
            velocityQueen = 0;
            positionQueen.X = 0;
            QueenDoneWithLeftSide = true;
            if (positionQueen.Y < maxYQueen && positionQueen.Y > minYQueen)
            {
                QueenStillScooting = true;
            }
            else
            {
                QueenStillScooting = false;
            }
        }
        if (positionQueen.Y > maxYQueen)
        {
            velocityQueen = 0;
            positionQueen.Y = maxYQueen;
            upOrDown *= -1;
            QueenTouchBottom = false;
        }
        if (positionQueen.Y < minYQueen)
        {
            velocityQueen = 0;
            positionQueen.Y = minYQueen;
            upOrDown *= -1;
            QueenTouchBottom = true;
        }
        if (QueenStillScooting)
        {
            positionQueen -= new Vector2(0, 100 * Time.DeltaTime * upOrDown);
        }
        if (QueenDoneWithLeftSide && !QueenStillScooting)
        {
                velocityQueen += 50;
                positionQueen += new Vector2(velocityQueen * Time.DeltaTime, velocityQueen * Time.DeltaTime * upOrDown);  
        }
        if (!QueenDoneWithLeftSide && !QueenStillScooting)
        {
                velocityQueen += 50;
                positionQueen -= new Vector2(velocityQueen * Time.DeltaTime, velocityQueen * Time.DeltaTime * upOrDown);
        }
    }
    // Get the positions for Collison Detection
    public float queenHitBoxX()
    {
        return positionQueen.X;
    }
    public float queenHitBoxY()
    {
        return positionQueen.Y;
    }

}

