using System.Collections;
using UnityEngine;

public class CameraShakeTrigger : MonoBehaviour
{
    public CameraShake CameraShake;
    private void OnTriggerEnter(Collider other)
    {
        //StartCoroutine(CameraShake.Shake(1f,5f));
        CameraShake.ShakeCamera();
    }
}
