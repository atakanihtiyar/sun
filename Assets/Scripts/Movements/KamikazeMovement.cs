using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeMovement : StraightMovement
{
    private int whichXWillIDie;
    public int minXToDie;
    public int maxXToDie;

    public override void OnCreate()
    {
        base.OnCreate();

        whichXWillIDie = transform.position.x > 0 ? Random.Range(minXToDie, maxXToDie) : -Random.Range(minXToDie, maxXToDie);
    }

    public override int NewDirectionY()
    {
        if ((whichXWillIDie - transform.position.x) < 0.2f)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            return (int)player.position.y;
        }

        return 0;
    }
}
