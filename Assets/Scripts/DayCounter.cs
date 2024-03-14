using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script to show how long the simulation has been running as "days"
public class DayCounter : MonoBehaviour
{
    public int dayPerSeconds = 4;
    private Text txt;
    private int day = 1;

    void Awake()
    {
        txt = GetComponent<Text>();

        if (txt == null)
        {
            Debug.LogWarning("DayCounter: No Text component found.");
        }
        else
        {
            StartCoroutine(ChangeTextCoroutine());
        }
    }

    IEnumerator ChangeTextCoroutine()
    {
        if (txt != null)
        {
            while (true)
            {
                txt.text = "Day: " + day;
                day++;
                yield return new WaitForSeconds(dayPerSeconds);
            }
        }
    }
}
