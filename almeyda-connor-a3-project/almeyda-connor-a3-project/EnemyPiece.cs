using MohawkGame2D;
using System;
using System.Numerics;

namespace MohawkGame2D;
    public class EnemyPiece
    {

    public Vector2 positionRook = new(10, 700);
    public float velocityRook;
    public bool rookTouchLeftSide = true;
    public float sizeRook = 50;

    public EnemyPiece(Vector2 positionRook)
    {
        this.positionRook = positionRook;
    }
    public void DrawMovement()
        {
        Draw.FillColor = Color.Blue;
        Draw.Square(positionRook, sizeRook);
        if (positionRook.X >= Window.Width - 50)
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




    }
