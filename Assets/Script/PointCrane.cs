using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointCrane : MonoBehaviour
{
    public int point = 0;
    public bool permitted = false;

    public UnityEvent onPermit;
    public UnityEvent onNotPermit;

    private void Update()
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
    public void AddPoint()
    {
        point += 1;

        if (point == 3)
        {
            permitted = true;
        }
    }

    public void DecreasePoint()
    {
        point -= 1;
    }

    //public void Permit()
    //{
    //    if (!permitted)
    //    {
    //        onNotPermit?.Invoke();
    //    }
    //    else
    //    {
    //        onPermit?.Invoke();
    //    }
    //}
}
