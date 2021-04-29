using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

}
