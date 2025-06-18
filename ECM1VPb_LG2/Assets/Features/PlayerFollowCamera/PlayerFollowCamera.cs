using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _offset;
    void Start()
    {
        _offset =  transform.position - _target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _target.position + _offset;
    }
}
