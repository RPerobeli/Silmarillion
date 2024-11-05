using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsManager : MonoBehaviour
{
    public GoTirionBoundaries GoTirionBoundaries;
    private void Start()
    {
        if (GoTirionBoundaries is not null)
        {
            //GoTirionBoundaries.OnTriggerLoadScene += () => LoadScene("ArredoresTirionLeste");
            GoTirionBoundaries.OnTriggerLoadScene += () => LoadScene("ArredoresTirionLeste");

        }
    }

    private void LoadScene(string sceneTag)
    {
        SceneManager.LoadSceneAsync(sceneTag);
    }
}
