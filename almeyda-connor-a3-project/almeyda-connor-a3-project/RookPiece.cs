using MohawkGame2D;
using System;
using System.Numerics;

namespace MohawkGame2D;
    public class RookPiece
    {

    public Vector2 positionRook = new(0, 0);
    public float velocityRook;
    public bool rookTouchLeftSide = true;

    public RookPiece(Vector2 positionRook)
    {
        this.positionRook = positionRook;
    }
    public void DrawRook()
        {
        
        Draw.FillColor = Color.White;
        // Head
        Draw.Quad(positionRook + new Vector2(0, 0),
            positionRook + new Vector2(50, 0),
            positionRook + new Vector2(35, 10),
            positionRook + new Vector2(15, 10));
        // Base
        Draw.Quad(positionRook + new Vector2(35, 40),
            positionRook + new Vector2(15, 40),
            positionRook + new Vector2(0, 50),
            positionRook + new Vector2(50, 50));
        // Movement
        for (int i = 0; i < 5; i++)
        {
            Draw.Rectangle(positionRook + new Vector2(15+i*5, 10), new Vector2(20-i*5, 30));
        }
        if (positionRook.X >= Window.Width - 50)
        {
            velocityRook = 0;
            positionRook.X = Window.Width - 50;
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
    public float rookHitBoxX()
    {
        return positionRook.X;
    }
    public float rookHitBoxY()
    {
        return positionRook.Y;
    }




    }
