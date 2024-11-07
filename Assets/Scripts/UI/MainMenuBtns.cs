using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtns : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Playing App.");
        StartCoroutine(SceneTransition.Instance.LoadScene("Tirion"));
        
    }
    public void QuitGame()
    {
        Debug.Log("Quitting App.");
        Application.Quit();
    }
}
