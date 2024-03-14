using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Handling changing of social distancing setting via a button
public class DistancingButton : MonoBehaviour
{
    public int distancingPercentage;
    public Text distancingText;
    Button button;
    GameObject[] objectsWithTag;

    void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(SetDistancing);
        }
    }

    public void SetDistancing()
    {
        objectsWithTag = GameObject.FindGameObjectsWithTag("Person");

        if (objectsWithTag != null && distancingText != null)
        {
            int numObjectsToActOn = (int)((float)distancingPercentage / 100f * objectsWithTag.Length);

            distancingText.text = $"Distancing at {distancingPercentage} percent";

            for (int i = 0; i < objectsWithTag.Length; i++)
            {
                if (i < numObjectsToActOn)
                {
                    objectsWithTag[i].GetComponent<PersonHandler>().SetSocialDistancing(true);
                }

                else
                {
                    objectsWithTag[i].GetComponent<PersonHandler>().SetSocialDistancing(false);
                }
            }
        }
    }
}

