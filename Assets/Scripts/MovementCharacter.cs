using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    public float moveSpeed = 5f;            // Velocidad de movimiento
    public Rigidbody2D rb;                  // Referencia al Rigidbody2D
    public Animator animator;               // Referencia al Animator del jugador
    public AudioSource leftFootAudio;       // AudioSource para el sonido del pie izquierdo
    public AudioSource rightFootAudio;      // AudioSource para el sonido del pie derecho
    public float footstepInterval = 0.5f;   // Intervalo entre los pasos (ajústalo según el ritmo que prefieras)

    private Vector2 movement;
    private bool isFacingRight = true;      // Determina si el jugador está mirando a la derecha
    private float footstepTimer = 0f;       // Temporizador para el sonido de pasos
    private bool isLeftFoot = true;         // Alterna entre el pie izquierdo y derecho

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // Asigna el Rigidbody2D del jugador
        animator = GetComponent<Animator>(); // Asigna el Animator del jugador
    }

    void Update()
    {
        // Detecta la entrada del jugador (teclas A, D o flechas izquierda y derecha)
        float moveX = Input.GetAxisRaw("Horizontal");

        // Guardar el movimiento en el eje X
        movement = new Vector2(moveX, rb.velocity.y);

        // Controla la animación y el sonido del jugador
        HandleAnimationAndSound(moveX);

        // Voltea el sprite según la dirección del movimiento
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
        // Aplicar el movimiento en el Rigidbody2D para el control físico
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    // Método para controlar las animaciones y el sonido de pasos
    void HandleAnimationAndSound(float moveX)
    {
        if (moveX != 0)
        {
            // Si el jugador está caminando, reproduce la animación de caminar
            animator.Play("Walk");

            // Temporizador para reproducir los sonidos de pasos a intervalos regulares
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0)
            {
                PlayFootstepSound();  // Reproduce el sonido de pasos
                footstepTimer = footstepInterval; // Reinicia el temporizador
            }
        }
        else
        {
            // Si el jugador está quieto, reproduce la animación de estar parado (idle)
            animator.Play("Idle");

            // Reinicia el temporizador para evitar sonidos de pasos mientras está quieto
            footstepTimer = 0f;
        }
    }

    // Método para reproducir el sonido de pasos alternando entre pie izquierdo y derecho
    void PlayFootstepSound()
    {
        if (isLeftFoot && leftFootAudio != null)
        {
            leftFootAudio.Play();  // Reproduce el sonido del pie izquierdo
        }
        else if (!isLeftFoot && rightFootAudio != null)
        {
            rightFootAudio.Play(); // Reproduce el sonido del pie derecho
        }
        isLeftFoot = !isLeftFoot; // Alterna entre pie izquierdo y derecho
    }

    // Método para voltear el sprite del jugador
    void Flip()
    {
        isFacingRight = !isFacingRight;  // Cambia la dirección a la que mira el jugador
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;                // Invierte el eje X del sprite
        transform.localScale = theScale; // Aplica la escala invertida
    }
}