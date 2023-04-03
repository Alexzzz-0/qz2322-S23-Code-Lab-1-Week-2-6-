using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   private GameObject camera;

   private void Start()
   {
      camera = GameObject.FindWithTag("MainCamera");
   }


   public void CameraMove(Vector3 moveDis)
   {
      //Debug.Log("Camera MOve");
      camera.transform.position += moveDis;
   }

   public void CameraLoad(Vector3 moveToDis)
   {
      Debug.Log("Camera Initial Load");
      camera.transform.position = moveToDis;
   }
}
