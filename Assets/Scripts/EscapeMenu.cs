using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    public static bool isActive = true;
    public GameObject InstructionsMenuUI;
     
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isActive)
            {
                ToggleOff();
            }
            else
            {
                ToggleOn();
            }
        }
    }

    public void ToggleOff()
    {
        InstructionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isActive = false;
    }

    void ToggleOn()
    {
        InstructionsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isActive = true;
    }
}
