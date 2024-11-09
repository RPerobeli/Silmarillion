using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public GameObject InventoryBox;
    private Animator Animator;

    public event Action OnShowInventory;
    public event Action OnHideInventory;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        Animator = InventoryBox.GetComponent<Animator>();
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(HideInventory());
        }
    }

    public IEnumerator<WaitForEndOfFrame> HideInventory()
    {
        yield return new WaitForEndOfFrame();
        OnHideInventory?.Invoke();
        Animator.SetBool("InventoryState", false);
    }

    public IEnumerator<WaitForEndOfFrame> ShowInventory()
    {
        yield return new WaitForEndOfFrame();
        ListItems();
        OnShowInventory?.Invoke();
        Animator.SetBool("InventoryState", true);
    }

    public void ListItems()
    {
        foreach(InventoryItem item in FeanorController.Instance.Inventory)
        {
            
        }
    }


}
