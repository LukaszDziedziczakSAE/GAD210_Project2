using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_ResourcesIndicator : MonoBehaviour
{
    [SerializeField] TMP_Text resourceText;

    public void UpdateResourceIndicator()
    {
        if (resourceText != null) resourceText.text = Game.Mothership.Resources.CurrentResources.ToString();
    }
}
