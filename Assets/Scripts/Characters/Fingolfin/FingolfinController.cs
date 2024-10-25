

using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FingolfinController : Assets.Scripts.Interfaces.CharacterController, IInteractable
{
    
    private string _charName = "Fingolfin";

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
