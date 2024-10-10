using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public AudioSource leftFootAudio;
    public AudioSource rightFootAudio;
    public float footstepInterval = 0.5f;
    public CameraShake cameraShake; // Referencia al script CameraShake

    private Vector2 movement;
    private bool isFacingRight = true;
    private float footstepTimer = 0f;
    private bool isLeftFoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        // Busca el script CameraShake en la cámara
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(moveX, rb.velocity.y);

        HandleAnimationAndSound(moveX);

        if (moveX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveX < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    void HandleAnimationAndSound(float moveX)
    {
        if (moveX != 0)
        {
            animator.Play("Walk");
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0)
            {
                PlayFootstepSound();
                footstepTimer = footstepInterval;

                // Llama al método para hacer temblar la cámara
                if (cameraShake != null)
                {
                    cameraShake.ShakeCamera(); // Llama al temblor de la cámara
                }
            }
        }
        else
        {
            animator.Play("Idle");
            footstepTimer = 0f;
        }
    }

    void PlayFootstepSound()
    {
        if (isLeftFoot && leftFootAudio != null)
        {
            leftFootAudio.Play();
        }
        else if (!isLeftFoot && rightFootAudio != null)
        {
            rightFootAudio.Play();
        }
        isLeftFoot = !isLeftFoot;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}