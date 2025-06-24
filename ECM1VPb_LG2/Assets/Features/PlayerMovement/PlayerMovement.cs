using System;
using BSOAP.Variables;
using UnityEngine;

public enum Axis
{
    x,
    y,
    z,
    rx,
    ry,
    rz
}
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Axis _forwardAxis;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private FloatVariable _moveInput;
    [SerializeField] private AnimationCurve _angleLinearDampingCurve;
    [SerializeField] private AnimationCurve _speedLinearDampingCurve;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _knockBackMultiplier;
    
    private bool _inverseForward;
    public bool _isCanMove;
    
    private Rigidbody _rigidbody;
    private Vector3 _forwardDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isCanMove = true;
    }

    public void FixedUpdate()
    {
        
        Rotate();
        CalculateLinearDamping();
        
        if(_isCanMove)
            Move();
    }
    
    private void Rotate()
    {
        transform.Rotate(new Vector3(0,1,0),_moveInput.Value * Time.fixedDeltaTime * _rotationSpeed);
        if (transform.eulerAngles.y > 180)
            _inverseForward = false;      
        else 
            _inverseForward = true;
    }
    
    private void CalculateLinearDamping()
    {
        var y = transform.eulerAngles.y;

        float t = 0;
        if (y >= 0 && y < 90 )
        {
            y -= 0;
            t = 1 - (y / 90);
        }
        else if (y >= 180 && y < 270)
        {
            y -= 180;
            t = 1 - (y / 90);
        }
        else if (y >= 90 && y < 180)
        {
            y -= 90;
            t = y / 90;
        }
        else if (y >= 270 && y < 360)
        {
            y -= 270;
            t = y / 90;
        }
        
        _rigidbody.linearDamping = _angleLinearDampingCurve.Evaluate(t) + _speedLinearDampingCurve.Evaluate(_rigidbody.linearVelocity.sqrMagnitude/_maxSpeed);
    }

    private void Move()
    {
        _forwardDirection = _forwardAxis switch
        {
            Axis.x => transform.right,
            Axis.y => transform.up,
            Axis.z => transform.forward,
            Axis.rx => -transform.right,
            Axis.ry => -transform.up,
            Axis.rz => -transform.forward,
            _ => throw new ArgumentOutOfRangeException()
        };
        _forwardDirection *= _inverseForward ? -1: 1;
        
        Debug.DrawRay(transform.position,_forwardDirection, Color.red);
        _rigidbody.AddForce(_forwardDirection * (_speed * Time.fixedDeltaTime));
        
        if (_rigidbody.linearVelocity.sqrMagnitude < 0.05f)
            _inverseForward = !_inverseForward;
    }

    public void Stop()
    {
        _rigidbody.linearVelocity = -_rigidbody.linearVelocity * _knockBackMultiplier;
        _isCanMove = false;
    }
    public void Stop(float duration)
    {
        Debug.Log("Stop");
        _rigidbody.linearVelocity = -_rigidbody.linearVelocity * _knockBackMultiplier ;
        _isCanMove = false;
        Invoke(nameof(ContinueMovement), duration);
    }

    public void ContinueMovement()
    {
        _isCanMove = true;
    }

    public void SpeedUp(float multiplier)
    {
        _rigidbody.linearVelocity *= multiplier;
    }

    public void StartSlowdown(float multiplier)
    {
        Debug.Log("Start");
        _speed *= multiplier;
    }

    public void StopSlowdown(float multiplier)
    {
        Debug.Log("stop");
        _speed /= multiplier;
    }
}
