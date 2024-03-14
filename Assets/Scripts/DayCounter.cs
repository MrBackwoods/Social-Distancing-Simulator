using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script to show how long the simulation has been running as "days"
public class DayCounter : MonoBehaviour
{
    public int dayPerSeconds = 4;
    private Text text;
    private int day = 1;

    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(ChangeTextCoroutine());
    }

    IEnumerator ChangeTextCoroutine()
    {
        if (text != null)
        {
            while (true)
            {

                text.text = "Day: " + day;
                day++;
                yield return new WaitForSeconds(dayPerSeconds);
            }
        }
        else
        {
            Debug.LogWarning("DayCounter: No Text component found.");
        }
    }
}
