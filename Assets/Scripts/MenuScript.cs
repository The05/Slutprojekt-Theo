using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private int sceneID = 1;
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneID);
        Debug.Log("Spelar scene " + sceneID);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Slutar");
    }
}
