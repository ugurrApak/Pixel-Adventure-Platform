using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    Right = 0,
    Left = 1,
    Top = 2,
    Bottom = 3
}
public class CollisionSide : MonoBehaviour
{
    public Side side;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var colPos in collision.contacts)
        {
            if (colPos.normal.y > 0)      //bottom
                side = Side.Bottom;
            else if (colPos.normal.y < 0) // top
                side = Side.Top;
            else if (colPos.normal.x > 0) // left
                side = Side.Left;
            else if (colPos.normal.x < 0) //right
                side = Side.Right;
        }
    }
}
