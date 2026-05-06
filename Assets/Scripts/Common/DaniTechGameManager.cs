using System.Collections.Generic;
using UnityEngine;

public class DaniTechGameManager : MonoBehaviour
{
    public static DaniTechGameManager Inst { get; set; }

    private void Awake()
    {
        Inst = this;
    }

    public void SaveAndEndGame()
    {
        Application.Quit();
    }
}
