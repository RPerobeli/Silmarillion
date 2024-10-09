

using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;

public class FingolfinController : CharacterController, IInteractable
{

    public Dialog _dialog;
    public void Interact()
    {
        _dialog.Lines.Clear();
        StartCoroutine(DialogManager.Instance.ShowDialog(_dialog));
    }
}
