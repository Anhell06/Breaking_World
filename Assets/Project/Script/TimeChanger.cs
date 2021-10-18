using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimeChanger 
{
    private bool pause = false;

    public void SetTime(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void Pause()
    {
        if (!pause)
        {
            Time.timeScale = 0;
            pause = true;
            Debug.Log("pause");
        }
        else
        {
            Time.timeScale = 1;
            pause = false;
            Debug.Log("nepause");
        }
    }
}
