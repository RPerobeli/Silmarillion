using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTirionBoundaries : MonoBehaviour
{
    public event Action OnTriggerLoadScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnTriggerLoadScene?.Invoke();
            Debug.Log("Jogador entrou na área de trigger!");
        }
    }
}
