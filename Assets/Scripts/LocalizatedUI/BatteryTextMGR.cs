using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.PersistentVariables;


public class BatteryTextMGR : MonoBehaviour
{
    LocalizeStringEvent ev;
    LocalizedString st;
    IntVariable power = null;
    // Start is called before the first frame update
    void Start()
    {
        ev = GetComponent<LocalizeStringEvent>();
        st = ev.StringReference;
        power = st["power"] as IntVariable;
    }
    public void PowerUpdate(float _power)
    {
        power.Value = (int)_power;
    }
    

}
