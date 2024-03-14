using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Resetting by reloading scene
public class ResetButton : MonoBehaviour
{
    void Awake()
    {
        Button btn = GetComponent<Button>();

        if (btn != null)
        {
            btn.onClick.AddListener(Reset);
        }
        else
        {
            Debug.LogWarning("ResetButton: Button component is missing.");
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
