using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMovement : StraightMovement
{
    public float minY;
    public float maxY;

    public override int NewDirectionY()
    {
        int yDirection = Random.Range(-1, 2);
        float newPositionY = transform.position.y + yDirection;
        yDirection = newPositionY > minY && newPositionY < maxY ? yDirection : 0;

        return yDirection;
    }
}
