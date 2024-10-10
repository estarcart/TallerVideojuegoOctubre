using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Iniciar : MonoBehaviour
{
    public string sceneToLoad; // Nombre de la escena a cargar

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad); // Cambia a la escena especificada
    }
}
