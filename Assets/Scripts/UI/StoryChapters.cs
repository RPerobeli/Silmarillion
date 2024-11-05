using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryChapters : MonoBehaviour
{
    public static StoryChapters Instance { get; private set; }

    public List<MultiDialogueData> ListChapters;

    

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // Persistência entre cenas
    }

    public void Start()
    {
        ListChapters = new List<MultiDialogueData>();
        MultiDialogueData beforeMelkor = Resources.Load<MultiDialogueData>("Story/BeforeMelkor");
        ListChapters.Add(beforeMelkor);
    }

}
