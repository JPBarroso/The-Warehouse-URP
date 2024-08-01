using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemGrabber : MonoBehaviour
{
    bool isGrabbing = false;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] float reach = 2.0f;
    [SerializeField] LayerMask mask;
    [SerializeField] Camera cam;
    [SerializeField] GameObject grabSlot;
    Object obj;
    GameObject grabbed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && !isGrabbing && obj != null)
        {
            Grab();
        }
        else if(Input.GetButtonDown("Fire1") && isGrabbing & grabbed != null)
        {
            Release();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, reach,mask) && isGrabbing == false)
        {
            obj = hit.transform.gameObject.GetComponent<Object>();
            infoText.text = "Hitting " + obj.type;
        }
        else
        {
            obj = null;
            infoText.text = null;
        }
    }
    void Grab()
    {
        isGrabbing = true;
        grabbed = obj.gameObject;
        grabbed.transform.SetParent(this.transform);
        grabbed.GetComponent<Rigidbody>().useGravity = false;
        grabbed.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        grabbed.transform.position = grabSlot.transform.position;
    }
    void Release()
    {
        isGrabbing = false;
        grabbed.transform.SetParent(null);
        grabbed.GetComponent<Rigidbody>().useGravity = true;
        grabbed.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        grabbed = null;
    }
}
