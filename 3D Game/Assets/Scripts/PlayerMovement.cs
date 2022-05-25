using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    float speed;
    public float gravity = -20f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    Vector3 movement;
    bool isGrounded;

    public float MaxStamina = 100f;
    float stamina = 100f;
    bool depletingStamina;
    public float staminaDepletionRate = 20f;
    public float staminaRegenRate = 10f;
    public float staminaDelay = 1f;
    AudioManager audioManager;
    bool isBreathing;

    void Start() 
    {
        audioManager = FindObjectOfType<AudioManager>();
        speed = walkSpeed;
        stamina = Mathf.Clamp(stamina, 0, MaxStamina);

    }
    
    void Update()
    {
        Movement();
        Jump();
        

        BreathingSound();
        StartCoroutine(DepleteStamina());
        StartCoroutine(RegenerateStamina());
    }

    void Movement() 
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movement = (transform.right * x + transform.forward * z).normalized;

        if(Input.GetButtonDown("Sprint"))
        {
            speed = sprintSpeed;
            depletingStamina = true;
        }
        if (Input.GetButtonUp("Sprint"))
        {
            speed = walkSpeed;
            depletingStamina = false;
        }
        if (stamina <= 0) {
            speed = walkSpeed;
        }

        controller.Move(movement * speed * Time.deltaTime);
    }

    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
                
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    
    IEnumerator DepleteStamina()
    {
        while (movement.magnitude > 0 && stamina > 0 && depletingStamina)
        {
            stamina -= staminaDepletionRate * Time.deltaTime;
            yield return new WaitForSeconds(staminaDelay);
        }
        yield return new WaitForSeconds(staminaDelay);
    }

    IEnumerator RegenerateStamina()
    {
        while (stamina < MaxStamina && (!depletingStamina || movement.magnitude <= 0))
        {
            stamina += staminaRegenRate * Time.deltaTime;
            yield return new WaitForSeconds(staminaDelay);
        }
        yield return new WaitForSeconds(staminaDelay);
    }

    void BreathingSound()
    {
        if (stamina < 50 && !isBreathing)
        {
            isBreathing = true;
            audioManager.Play("Breathing");
        }
    }
}