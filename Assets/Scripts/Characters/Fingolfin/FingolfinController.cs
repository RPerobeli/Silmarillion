

using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FingolfinController : Assets.Scripts.Interfaces.CharacterController, IInteractable
{

    public Dialog _dialog;
    private Transform PlayerTransform;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }
    public void Interact()
    {
        _dialog.Lines.Clear();
        LookAtPlayer();
        StartCoroutine(DialogManager.Instance.ShowDialog(_dialog));
    }



    private void LookAtPlayer()
    {
        AtualizarPositionMainChar();

        // Calcula a direção do jogador em relação ao NPC
        Vector3 direction =  PlayerTransform.position - transform.position;

        // Normaliza a direção para um vetor de unidade (magnitude = 1)
        direction.Normalize();

        // Verifica se o NPC deve virar para a esquerda ou para a direita
        Animator.SetFloat(nameof(direction.x), direction.x);
        Animator.SetFloat(nameof(direction.y), direction.y);
    }

    private void AtualizarPositionMainChar()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            PlayerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Feanor não encontrado na cena!");
        }
    }
}
