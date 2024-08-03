using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    GameManager mgr;
    public Item._ItemType type;
    private void Start()
    {
        mgr = Camera.main.GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Deposit Trigger")
        {
            Debug.Log(type);
            mgr.DepositedItem(type);
            Destroy(this.gameObject);
        }
    }

}

