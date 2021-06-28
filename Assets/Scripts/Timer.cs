using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private float passedTimeAfterLoop = 0;
    public float maxWaitTime;

    public UnityEvent toDoEvent;

    void FixedUpdate()
    {
        passedTimeAfterLoop += Time.fixedDeltaTime;

        if (passedTimeAfterLoop >= maxWaitTime)
        {
            toDoEvent?.Invoke();

            passedTimeAfterLoop -= maxWaitTime;
        }
    }
}
