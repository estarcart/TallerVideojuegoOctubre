using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad del enemigo
    public float detectionRange = 5f; // Rango de detección del jugador
    public Transform player; // Referencia al transform del jugador

    private void Update()
    {
        // Comprobar si el jugador está dentro del rango de detección
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            // Mover al enemigo hacia el jugador
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        // Calcular la dirección hacia el jugador
        Vector2 direction = (player.position - transform.position).normalized;
        
        // Mover al enemigo
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el enemigo colisiona con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cambiar de escena
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        // Cambiar a la escena deseada
        SceneManager.LoadScene("Menu"); // Reemplaza "NombreDeLaEscena" por el nombre real de la escena
    }
}