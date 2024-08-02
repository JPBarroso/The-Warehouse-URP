using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    Renderer rend;
    public float speed;
    public float movingForce;
    float offset;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        Debug.Log(rend.material);
    }

    // Update is called once per frame
    void Update()
    {
        Scroller();

    }
    void Scroller()
    {
        offset = Time.time * speed;
        rend.material.SetTextureOffset("_BaseColorMap", new Vector2(-offset, -offset));
        rend.material.SetTextureOffset("_NormalMap", new Vector2(-offset, -offset));
        rend.material.SetTextureOffset("_MetallicMap", new Vector2(-offset, -offset));
        rend.material.SetTextureOffset("_AmbientOcclusionMap", new Vector2(-offset, -offset));
        rend.material.SetTextureOffset("_RoughnessMap", new Vector2(-offset, -offset));
        rend.material.SetTextureOffset("_HeightMap", new Vector2(-offset, -offset));
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(movingForce,0,0);
    }
}
