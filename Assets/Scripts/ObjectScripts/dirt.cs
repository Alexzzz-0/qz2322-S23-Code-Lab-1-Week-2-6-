using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirt : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("swept!");
            GameManager.instance.dustNumLeft--;
            GameManager.instance.dustNumSolved++;
            GameManager.instance.RoomUIUpdate();
            Destroy(gameObject);
        }
    }
}
