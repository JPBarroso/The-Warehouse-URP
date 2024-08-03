using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    Renderer rend;
    public float speedX, speedY;
    public float movingForce;
    [SerializeField] Vector2 offset;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroller();

    }
    void Scroller()
    {
        offset = new Vector2(Time.time * speedX,Time.time * speedY);
        rend.material.SetTextureOffset("_BaseColorMap", offset);
        rend.material.SetTextureOffset("_NormalMap", offset);
        rend.material.SetTextureOffset("_MetallicMap", offset);
        rend.material.SetTextureOffset("_AmbientOcclusionMap", offset);
        rend.material.SetTextureOffset("_RoughnessMap", offset);
        rend.material.SetTextureOffset("_HeightMap", offset);
    }
    private void OnCollisionStay(Collision collision)
    {
        rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(movingForce,0,0);
    }
}
