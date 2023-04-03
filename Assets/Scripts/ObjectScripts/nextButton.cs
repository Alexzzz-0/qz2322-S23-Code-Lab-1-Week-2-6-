using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextButton : MonoBehaviour
{
    public void loadNextLevel()
    {
        GameManager.instance.level++;
        Debug.Log(GameManager.instance.level.ToString());
        GameManager.instance.gameMode = GameManager.GameType.Generate;
        GameManager.instance.fileIsEmpty = true;
        GameManager.instance.sceneIsEmpty = true;
    }
}
