using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.2f; // Duración del temblor
    public float shakeMagnitude = 0.1f; // Magnitud del temblor
    private Vector3 originalPosition;    // Posición original de la cámara

    void Start()
    {
        originalPosition = transform.localPosition; // Guarda la posición original
    }

    public void ShakeCamera()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            // Genera un desplazamiento aleatorio
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            // Aplica el desplazamiento a la posición de la cámara
            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null; // Espera hasta el siguiente frame
        }

        // Restablece la posición original de la cámara
        transform.localPosition = originalPosition;
    }
}
