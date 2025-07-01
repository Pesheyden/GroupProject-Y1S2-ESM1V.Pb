using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform[] _layers;
    [SerializeField] private float[] _parallax;
    public Vector3 Move;

    void Start()
    {
        
    }
    
    void LateUpdate()
    {
        for (int i = 0; i < _layers.Length; i++)
        {
            _layers[i].position += Move * _parallax[i];
        }
    }
}
