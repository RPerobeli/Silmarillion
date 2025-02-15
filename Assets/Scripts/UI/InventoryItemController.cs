using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Item _item;


    public void SetItem(Item item)
    {
        _item = item;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter: " + _item.Name);
        TooltipManager.OnShowTooltip(_item.Name);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.fullyExited)
        {
            Debug.Log("OnPointerExit: " + _item.Name);
            TooltipManager.OnHideTooltip();
        }
    }
}
