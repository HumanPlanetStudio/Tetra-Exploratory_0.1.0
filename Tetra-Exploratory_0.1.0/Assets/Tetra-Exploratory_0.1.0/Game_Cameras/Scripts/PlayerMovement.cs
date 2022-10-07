using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
// посмотреть подробнее про функции Vector3, Trasform, LayerMask
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // перемещение WASD

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // функция пока непонятна

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        // ускорение свободного падения
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
  
        // применяем формулу для прыжков
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        // приседание и ускорение, высота контроллера - вшитая функция, скорость тоже, но мы её задали в начале скрипта 
        
        if (Input.GetKey("c"))
        {
            controller.height = 0.9f;
        }
        else
        {
            controller.height = 1.8f;
        }
        if (Input.GetKey("left shift"))
        {
            speed = 10f;
        }
        else
        {
            speed = 5f;
        }
    }
}
