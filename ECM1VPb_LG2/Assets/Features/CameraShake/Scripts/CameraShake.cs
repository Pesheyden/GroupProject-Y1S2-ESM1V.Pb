using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float Duration;
    public float Magnitude;
    public Vector3 rotationVector = new Vector3(0, 100, 0);
    public float RotationSpeed;

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;
        Vector3 originalRotation = transform.localEulerAngles;
        
        
        
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float xPosition = Random.Range(-1f * magnitude, 1f * magnitude);
            float yPosition = Random.Range(-1f * magnitude, 1f * magnitude);
            transform.localPosition = new Vector3(xPosition, yPosition, originalPosition.z);

            transform.Rotate(rotationVector * RotationSpeed);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
        transform.localEulerAngles = originalRotation;

    }

    public void ShakeCamera()
    {
        StartCoroutine(Shake(Duration, Magnitude));
    }
}
