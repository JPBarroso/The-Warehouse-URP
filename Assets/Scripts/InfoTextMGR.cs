using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using TMPro;

public class InfoTextMGR : MonoBehaviour
{
    TextMeshProUGUI Tmpro;
    LocalizeStringEvent ev;
    LocalizedString st;
    IntVariable item = null;
    // Start is called before the first frame update
    void Start()
    {
        Tmpro = GetComponent<TextMeshProUGUI>();
        ev = GetComponent<LocalizeStringEvent>();
        st = ev.StringReference;
        item = st["itemInt"] as IntVariable;
    }

    public void GrabText(Item._ItemType type)
    {
        if (!Tmpro.enabled)
        {
            Tmpro.enabled = true;
        }
        switch (type)
        {
            case Item._ItemType.Doll:
                item.Value = 0;
                break;
            case Item._ItemType.Controller:
                item.Value = 1;
                break;
            case Item._ItemType.Book:
                item.Value = 2;
                break;
            case Item._ItemType.Food:
                item.Value = 3;
                break;
            case Item._ItemType.Ball:
                item.Value = 4;
                break;
            case Item._ItemType.Bottle:
                item.Value = 5;
                break;
            case Item._ItemType.Camera:
                item.Value = 6;
                break;
            default:
                item.Value = 7;
                break;

        }
    }
}
