using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Resetting by reloading scene
public class ResetButton : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(Reset);
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
