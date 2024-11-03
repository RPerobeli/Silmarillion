using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    [SerializeField] private GameObject _inventoryBox;

    public event Action OnShowInventory;
    public event Action OnHideInventory;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyUp(KeyCode.I))
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
