using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    int tiempo = 2400;
    
    void Start()
    {
        StartCoroutine(TimerCorutina());
    }

    IEnumerator TimerCorutina()
    {
        while (tiempo != 0)
        {
            tiempo--;
            yield return new WaitForSeconds(1);
        }

    }

    
}
