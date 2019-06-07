using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public Vector3 moveDir;
    public CharacterController charC;
    public float speed = 5f, gravity = 20f;

    void Start()
    {
        charC = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (charC.isGrounded)
        {
            moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed);
        }
        moveDir.y -= gravity * Time.deltaTime;
        charC.Move(moveDir * Time.deltaTime);
    }
}