using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieDie : MonoBehaviour
{
    public int dieCount = 0;
    public int zombieCount;
    public UnityEvent Win;

    private void Update()
    {
        if (dieCount == zombieCount)
        {
            Win.Invoke();
        }
    }

    public void DieCount()
    {
        dieCount += 1;
    }
}
