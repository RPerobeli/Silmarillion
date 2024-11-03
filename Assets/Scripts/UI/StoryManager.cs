using Assets.Scripts.Helpers;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using System;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance { get; private set; }
    
    [SerializeField] private List<MultiDialogueData> _storyChapters;  // Array de capítulos
    private MultiDialogueData _currentChapter;  // Capítulo atual carregado

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // Persistência entre cenas
    }

    private void Start()
    {
        LoadStory();
    }

    public void LoadStory()
    {
        EStoryState storyState = GameStateHandler.Instance.CurrentStoryState;
        _currentChapter = _storyChapters[(int)storyState];
        Debug.Log("Capítulo " + storyState.ToString() + " carregado.");
    }

    public List<Dialog> LoadDialogue(string npcName)
    {
        if(_currentChapter is not null)
        {
            DialogueSet dialogueSet = _currentChapter.DialogueSets.Find(d => d.NpcName == npcName);
            if(dialogueSet != null) { return dialogueSet.Dialogs; }
            else {
                Debug.Log("Erro ao carregar o dialog set");
                return null; 
            }
        }else {
            Debug.Log("Erro em LoadDialogue - Não foi possível carregar o capítulo atual.");
            return null;
        }
    }
}
