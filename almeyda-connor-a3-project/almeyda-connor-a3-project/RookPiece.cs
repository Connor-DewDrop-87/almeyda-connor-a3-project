using MohawkGame2D;
using System;
using System.Numerics;

namespace MohawkGame2D;
    public class RookPiece
    {

    public Vector2 positionRook = new(0, 0);
    public float velocityRook;
    public bool rookTouchLeftSide = true;
    public float sizeRook = 50;

    public RookPiece(Vector2 positionRook)
    {
        this.positionRook = positionRook;
    }
    public void DrawRook()
        {
        Draw.FillColor = Color.White;
        Draw.Square(positionRook, sizeRook);
        if (positionRook.X >= Window.Width - sizeRook)
        {
            velocityRook = 0;
            positionRook.X = Window.Width - sizeRook;
            rookTouchLeftSide = false;
        }
        if (positionRook.X <= 0)
        {
            velocityRook = 0;
            positionRook.X = 0;
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




    }
