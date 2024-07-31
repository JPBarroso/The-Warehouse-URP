using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float x, z;
    Vector3 move;
    [SerializeField] CharacterController chara;
    public float speed = 12f;
    public float gravity = -9.1f;
    public float jumpPower = 3f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        chara.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpPower * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        chara.Move(velocity * Time.deltaTime);
    }
}
