using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public string sceneToLoad; // Nombre de la escena a cargar
    public string targetTag = "Finish"; // Tag del objeto con el que colisionará para cambiar de escena

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto con el que colisiona tiene el tag específico
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Cambiar a la escena deseada
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
