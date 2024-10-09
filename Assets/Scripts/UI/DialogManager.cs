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
    public int LettersPerSecond = 2;
    private Queue<string> _linesQueue;
    private Dialog _dialog;
    private bool _isTyping;

    public event Action OnShowDialog;
    public event Action OnHideDialog;


    private void Start()
    {
        _linesQueue= new Queue<string>();
        
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

    public IEnumerator<WaitForEndOfFrame> ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();
        _dialog = dialog;
        _linesQueue.Clear();
        foreach(string line in _dialog.Lines)
        {
            _linesQueue.Enqueue(line);
        }
        
    }

    private void DisplayNextSentence()
    {
        if(_linesQueue.Count == 0)
        {
            EndDialog();
            return;
        }
        string line = _linesQueue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeDialog(line, _dialog.ActorName));
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
            yield return new WaitForSeconds(1 / LettersPerSecond);
        }
        _isTyping = false;
    }
}
