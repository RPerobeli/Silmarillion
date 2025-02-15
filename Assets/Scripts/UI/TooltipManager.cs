using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class TooltipManager : MonoBehaviour
{
    public static Action<string> OnShowTooltip;
    public static Action OnHideTooltip;

    private Text tooltipText;
    private RectTransform backgroundRectTransform;


    private void Awake()
    {

        backgroundRectTransform = transform.Find("Background").GetComponent<RectTransform>();
        tooltipText = transform.Find("TooltipText").GetComponent<Text>();
        OnShowTooltip += ShowTooltip;
        OnHideTooltip += HideTooltip;
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition,null,out localPoint);
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.FindWithTag("UI").GetComponent<RectTransform>(), Input.mousePosition,null,out localPoint);
        transform.localPosition = localPoint;
    }

    private void ShowTooltip(string tooltipString)
    {
        tooltipText.text = tooltipString;
        float textPaddingSize = 4f;

        Vector2 backgroundSize = new Vector2 (tooltipText.preferredWidth + textPaddingSize*2f, tooltipText.preferredHeight + textPaddingSize * 2f);
        backgroundRectTransform.sizeDelta = backgroundSize;
        this.gameObject.SetActive(true);
    }
    private void HideTooltip()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        OnShowTooltip -= ShowTooltip;
        OnHideTooltip -= HideTooltip;
    }
}
