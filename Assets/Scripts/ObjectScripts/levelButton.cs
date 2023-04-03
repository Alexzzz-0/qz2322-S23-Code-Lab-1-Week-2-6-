using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("loadLevel");
        SceneManager.LoadScene("Level0");

    }

}
