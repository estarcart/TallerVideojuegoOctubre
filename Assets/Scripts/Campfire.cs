using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public AudioSource audioSource; // Componente AudioSource
    public Transform player; // Transform del jugador
    public float maxDistance = 3f; // Distancia máxima para oír el sonido

    private void Start()
    {
        // Asegúrate de que el AudioSource esté asignado
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        
        // Reproduce el sonido en bucle
        audioSource.loop = true;
        audioSource.Play();
    }

    private void Update()
    {
        // Calcular la distancia entre el jugador y la fogata
        float distance = Vector3.Distance(transform.position, player.position);
        
        // Calcular el volumen en función de la distancia
        if (distance < maxDistance)
        {
            audioSource.volume = 1 - (distance / maxDistance); // Disminuye el volumen al alejarse
        }
        else
        {
            audioSource.volume = 0; // Silencio si está fuera de rango
        }
    }
}
