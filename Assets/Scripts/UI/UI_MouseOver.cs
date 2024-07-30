using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        UI.SetMouseOverUI(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI.SetMouseOverUI(false);
    }
}
