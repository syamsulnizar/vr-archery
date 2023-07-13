using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddPoints : MonoBehaviour
{
    public int point = 0;
    public bool permitted = false;

    public UnityEvent onPermit;
    public UnityEvent onNotPermit;


    public void AddPoint()
    {
        point += 1;

        if (point == 5)
        {
            permitted = true;
        }
    }

    public void DecreasePoint()
    {
        point -= 1;
    }

    public void Permit()
    {
        if (!permitted)
        {
            onNotPermit?.Invoke();
        }
        else
        {
            onPermit?.Invoke();
        }
    }
}
