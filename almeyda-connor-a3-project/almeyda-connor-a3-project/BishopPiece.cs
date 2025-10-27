using MohawkGame2D;
using System;
using System.Numerics;

namespace MohawkGame2D;
public class BishopPiece
{

    public Vector2 positionBishop = new(0, 0);
    public float velocityBishop;
    public float maxYBishop;
    public float minYBishop;
    // Determines whether or not vector is going up or down (Negative means up, Positive means down)
    public int upOrDown = -1;
    public bool bishopTouchLeftSide = true;
    public bool bishopTouchBottom = true;
    public float sizeBishop = 50;

    public BishopPiece(Vector2 positionBishop, float minY, float maxY)
    {
        this.positionBishop = positionBishop;
        this.minYBishop = minY;
        this.maxYBishop = maxY;
    }
    public void DrawBishop()
    {
        Draw.FillColor = Color.Green;
        Draw.Square(positionBishop, sizeBishop);
        if (positionBishop.X >= Window.Width - sizeBishop)
        {
            velocityBishop = 0;
            positionBishop.X = Window.Width - sizeBishop;
            bishopTouchLeftSide = false;
        }
        if (positionBishop.X <= 0)
        {
            velocityBishop = 0;
            positionBishop.X = 0;
            bishopTouchLeftSide = true;
        }
        if (positionBishop.Y > maxYBishop)
        {
            velocityBishop = 0;
            positionBishop.Y = maxYBishop;
            upOrDown *= -1;
            bishopTouchBottom = false;
        }
        if (positionBishop.Y < minYBishop)
        {
            velocityBishop = 0;
            positionBishop.Y = minYBishop;
            upOrDown *= -1;
            bishopTouchBottom = true;
        }
        if (bishopTouchLeftSide)
        {
            velocityBishop += 10;
            positionBishop += new Vector2(velocityBishop * Time.DeltaTime, velocityBishop * Time.DeltaTime * upOrDown);
        }
        if (!bishopTouchLeftSide)
        {
            velocityBishop += 10;
            positionBishop -= new Vector2(velocityBishop * Time.DeltaTime, velocityBishop * Time.DeltaTime * upOrDown);
        }
    }
}