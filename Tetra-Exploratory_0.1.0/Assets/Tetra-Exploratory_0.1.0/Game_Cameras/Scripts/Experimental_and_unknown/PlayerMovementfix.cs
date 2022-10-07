using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementfix : MonoBehaviour
{
    private Rigidbody _body;
    public float speed = 10f;
    public float jumpHeight = 3f;
    public bool isGrounded;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
    }

    void Update()
    {

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _body.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Input.GetKey("left shift"))
        {
            speed = 20f;
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
           if  (isGrounded) Move();
        }
    }

    void Move()
    {
        Vector3 _fwd = new Vector3();
        _fwd.x = Input.GetAxis("Horizontal");
        _fwd.z = Input.GetAxis("Vertical");
        _fwd.y = 0;
        _body.AddRelativeForce(_fwd* speed * Time.deltaTime,ForceMode.VelocityChange);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("heh");
        if (collision.gameObject.tag.Contains("Ground")) isGrounded = true;
    }
}
