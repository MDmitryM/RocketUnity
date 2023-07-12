using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        QuitButtinCheck();
    }

    public void QuitButtinCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Debug.Log("ESC");
            Application.Quit();
        }
    }
}
