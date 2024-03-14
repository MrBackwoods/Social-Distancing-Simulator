using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script to show how long the simulation has been running as "days"
public class DayCounter : MonoBehaviour
{
    public int i = 1;

    void Start()
    {
        StartCoroutine(ChangeTextCoroutine());
    }

    IEnumerator ChangeTextCoroutine()
    {
        if (GetComponent<Text>() != null)
        {
            while (true)
            {

                GetComponent<Text>().text = "Day: " + i;
                i++;
                yield return new WaitForSeconds(4f);
            }
        }
    }
}
