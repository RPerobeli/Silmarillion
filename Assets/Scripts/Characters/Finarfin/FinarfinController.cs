using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinarfinController : Assets.Scripts.Interfaces.CharacterController, IInteractable
{
    private string _charName = "Finarfin";

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }
    public void Interact()
    {
        LookAtPlayer();
        StartCoroutine(DialogManager.Instance.ShowDialog(_charName));
    }
}
