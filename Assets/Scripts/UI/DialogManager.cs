using Assets.Scripts.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject _dialogBox;
    [SerializeField] private Text _dialogText;
    [SerializeField] private Text _dialogTitle;


    [SerializeField] private float LettersPerSecond;
    private Queue<Dialog> _dialogQueue;
    private List<Dialog> _dialog;
    private bool _isTyping;

    public event Action OnShowDialog;
    public event Action OnHideDialog;


    private void Start()
    {
        _dialogQueue= new Queue<Dialog>();
        LettersPerSecond = 0.1f;

    }
    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void HandleUpdate()
    {
        if(Input.GetKeyUp(KeyCode.Z) && !_isTyping)
        {
            DisplayNextSentence();
        }
    }

    public IEnumerator<WaitForEndOfFrame> ShowDialog(string npcName)
    {
        yield return new WaitForEndOfFrame();
        //Load text
        _dialog = StoryManager.Instance.LoadDialogue(npcName);
        OnShowDialog?.Invoke();
        
        _dialogQueue.Clear();
        foreach(Dialog line in _dialog)
        {
            _dialogQueue.Enqueue(line);
        }
        
        
    }

    private void DisplayNextSentence()
    {
        if(_dialogQueue.Count == 0)
        {
            EndDialog();
            return;
        }
        Dialog currentLine = _dialogQueue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeDialog(currentLine.Text, currentLine.ActorName));
    }

    private void EndDialog()
    {
        _dialogBox.SetActive(false);
        OnHideDialog?.Invoke();
    }

    public IEnumerator<WaitForSeconds> TypeDialog(string line, string actor)
    {
        _isTyping = true;
        _dialogBox.SetActive(true);
        _dialogText.text = string.Empty;
        _dialogTitle.text = actor;
        foreach (var letter in line.ToCharArray()) 
        {
            _dialogText.text += letter;
            if(Input.GetKeyDown(KeyCode.Z))
            {
                _dialogText.text = line.ToString();
            }
            yield return new WaitForSeconds(1 / LettersPerSecond * Time.deltaTime);
        }
        _isTyping = false;
    }
}
