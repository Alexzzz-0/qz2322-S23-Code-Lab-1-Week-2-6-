using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI roomNumber;
    public TextMeshProUGUI dustNumber;
    
    
    public void roomUIGenerate(int level, int dustLeft)
    {
        roomNumber.text = "-ROOM " + level.ToString() + " -";

        dustNumber.text = "Dust Solved: 0" + "\n" + "\n" + "Dust Left: " + dustLeft.ToString();
    }

    public void roomUIUpdate(int dustSolved, int dustLeft)
    {
        dustNumber.text = "Dust Solved: " + dustSolved.ToString() + "\n" + "\n" + "Dust Left: " + dustLeft;
    }
    
}
