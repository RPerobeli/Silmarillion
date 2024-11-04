using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public GameObject InventoryBox;

    public event Action OnShowInventory;
    public event Action OnHideInventory;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OnHideInventory?.Invoke();   
        }
    }


    public IEnumerator<WaitForEndOfFrame> ShowInventory()
    {
        yield return new WaitForEndOfFrame();       
        OnShowInventory?.Invoke();
    }


}
