using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public GameObject InventoryBox;
    private Animator Animator;

    public event Action OnShowInventory;
    public event Action OnHideInventory;

    public Transform ItemContent;
    public GameObject InventoryItem;

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
        //Clear Inventory
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach(InventoryItem item in FeanorController.Instance.Inventory)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var controller = obj.GetComponent<InventoryItemController>();
            controller.SetItem(item.Item);

            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var itemQuantity = obj.transform.Find("QuantityPanel").Find("ItemQuantity").GetComponent<Text>();

            itemName.text = item.Item.Name;
            itemIcon.sprite = item.Item.Icon;
            itemQuantity.text = item.Quantity.ToString();
        }
    }


}
