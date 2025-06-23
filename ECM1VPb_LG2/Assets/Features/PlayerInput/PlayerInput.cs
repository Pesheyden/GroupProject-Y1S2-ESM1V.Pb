using System;
using BSOAP.Variables;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum InputType
{
    ComputerType,
    Button,
    InvisibleButton,
    Joystick,
    FloatingJoystick,
    Slider
}
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private FloatVariable _moveInput;
    [SerializeField] private bool _reverseInput;
    [SerializeField] private InputType _inputType;
    
    [Header("Button Input")]
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    
    [Header("Invisible Button Input")]
    [SerializeField] private Button _invisibleLeftButton;
    [SerializeField] private Button _invisibleRightButton;

    [Header("Joystick")] 
    [SerializeField] private RectTransform _joyStick;
    [SerializeField] private RectTransform _joyStickKnob;
    [SerializeField] private Rect _joystickArea;
    [SerializeField] private RectTransform _joystickBlock;
    [SerializeField] private RectTransform _secondBlockAdjustment;



    private int _fingerId;
    private Vector2 _joyStickSize;
    
    private void Start()
    {
        switch (_inputType)
        {
            case InputType.ComputerType:
                break;
            case InputType.Button:
                Input.simulateMouseWithTouches = true;
                _leftButton.onClick.AddListener(() => _moveInput.Value = 1); 
                _rightButton.onClick.AddListener(() => _moveInput.Value = -1); 
                _leftButton.gameObject.SetActive(true);
                _rightButton.gameObject.SetActive(true);
                break;
            case InputType.InvisibleButton:
                Input.simulateMouseWithTouches = true;
                _invisibleLeftButton.onClick.AddListener(() => _moveInput.Value = 1); 
                _invisibleRightButton.onClick.AddListener(() => _moveInput.Value = -1); 
                _invisibleLeftButton.gameObject.SetActive(true);
                _invisibleRightButton.gameObject.SetActive(true);
                break;
            case InputType.Joystick:
                _fingerId = -1;
                Input.simulateMouseWithTouches = false;
                _joyStickSize = _joyStick.sizeDelta;
                _joyStick.gameObject.SetActive(true);
                _joystickArea = _joystickBlock.rect;

                break;
            case InputType.FloatingJoystick:
                _fingerId = -1;
                Input.simulateMouseWithTouches = true;
                _joyStickSize = _joyStick.sizeDelta;
                _joystickArea = _joystickBlock.rect;
                if(_secondBlockAdjustment)
                    _joystickArea = new Rect(_joystickBlock.rect.x, _joystickBlock.rect.y, _secondBlockAdjustment.rect.width + _joystickBlock.rect.width, _secondBlockAdjustment.rect.width + _joystickBlock.rect.width);
                break;
            case InputType.Slider:
                Input.simulateMouseWithTouches = true;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    void Update()
    {
        switch (_inputType)
        {
            case InputType.ComputerType:
                HandleComputerInput();
                break;
            case InputType.Button:
                return;
            case InputType.InvisibleButton:
                return;
                break;
            case InputType.Joystick:
                HandleJoystickInput();
                break;
            case InputType.FloatingJoystick:
                HandleFloatingJoystickInput();
                break;
            case InputType.Slider:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void HandleJoystickInput()
    {
        if (Input.touchCount == 0)
            return;
        
        var currentTouch = new Touch();
        bool found = false;
        if (_fingerId == -1)
        {
            foreach (var touch in Input.touches)
            {
                if (IsPositionInsideTheArea(touch.position, _joystickArea))
                {
                    currentTouch = touch;
                    _fingerId = currentTouch.fingerId;
                    found = true;
                    break;
                }
            }
            if(!found)
                return;
        }
        else
        {
            foreach (var touch in Input.touches)
            {
                if (touch.fingerId == _fingerId)
                {
                    currentTouch = touch;
                    found = true;
                    break;
                }
            }

            if(!found)
                return;
        }

        switch (currentTouch.phase)
        {
            case TouchPhase.Began:
                _fingerId = currentTouch.fingerId;
                break;
            case TouchPhase.Moved:
                HandleJoystickKnobMovement(currentTouch, _joyStick, _joyStickKnob);
                break;
            case TouchPhase.Stationary:
                break;
            case TouchPhase.Ended:
                _moveInput.Value = 0;
                break;
            case TouchPhase.Canceled:
                _moveInput.Value = 0;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private bool IsPositionInsideTheArea(Vector2 pos, Rect area)
    {
        if (pos.x >= area.x && pos.y >= area.y && pos.x <= area.x + area.width && pos.y <= area.y + area.height)
            return true;
        return false;
    }

    private void HandleFloatingJoystickInput()
    {
        if (Input.touchCount == 0)
            return;
        
        var currentTouch = new Touch();
        bool found = false;
        if (_fingerId == -1)
        {
            foreach (var touch in Input.touches)
            {
                if (IsPositionInsideTheArea(touch.position, _joystickArea))
                {
                    currentTouch = touch;
                    _fingerId = currentTouch.fingerId;
                    found = true;
                    break;
                }
            }
            if(!found)
                return;
        }
        else
        {
            foreach (var touch in Input.touches)
            {
                if (touch.fingerId == _fingerId)
                {
                    currentTouch = touch;
                    found = true;
                    break;
                }
            }

            if(!found)
                return;
        }
        
        switch (currentTouch.phase)
        {
            case TouchPhase.Began:
                _fingerId = currentTouch.fingerId;
                SpawnJoystick(currentTouch, _joyStick, _joyStickKnob);
                break;
            case TouchPhase.Moved:
                HandleJoystickKnobMovement(currentTouch, _joyStick, _joyStickKnob);
                break;
            case TouchPhase.Stationary:
                break;
            case TouchPhase.Ended:
                _moveInput.Value = 0;
                DespawnJoystick(currentTouch, _joyStick, _joyStickKnob);
                break;
            case TouchPhase.Canceled:
                _moveInput.Value = 0;
                DespawnJoystick(currentTouch, _joyStick, _joyStickKnob);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void SpawnJoystick(Touch touch, RectTransform joystick, RectTransform joystickKnob)
    {
        if(!IsPositionInsideTheArea(touch.position, _joystickArea))
            return;
        
        joystick.anchoredPosition = ClampJoystickPosition(touch.position);
        joystick.gameObject.SetActive(true);
    }

    private Vector2 ClampJoystickPosition(Vector2 position)
    {
        return new Vector2(
            Mathf.Clamp(position.x, _joyStickSize.x / 2 + _joystickArea.x, _joystickArea.x + _joystickArea.width - _joyStickSize.x / 2),
            Mathf.Clamp(position.y, _joyStickSize.y / 2 + _joystickArea.y, _joystickArea.y + _joystickArea.height - _joyStickSize.y / 2)
        );
    }

    private void DespawnJoystick(Touch touch, RectTransform joystick, RectTransform joystickKnob)
    {
        joystickKnob.anchoredPosition = Vector2.zero;
        joystick.gameObject.SetActive(false);
    }

    private void HandleJoystickKnobMovement(Touch touch, RectTransform joystick, RectTransform joystickKnob)
    {
        Vector2 knobPos;
        float maxMovement = _joyStickSize.x / 2;
        if (Vector2.Distance(touch.position, joystick.anchoredPosition) > maxMovement)
        {
            knobPos = (touch.position - joystick.anchoredPosition).normalized * maxMovement;
        }
        else
        {
            knobPos = touch.position - joystick.anchoredPosition;
        }

        knobPos = new Vector2(knobPos.x, 0);
        joystickKnob.anchoredPosition = knobPos;
        _moveInput.Value = knobPos.x / maxMovement;
        if (_reverseInput)
            _moveInput.Value *= -1;
    }

    private void HandleComputerInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _moveInput.Value = 1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _moveInput.Value = -1f;
        }
        else
        {
            _moveInput.Value = 0;
        }
    }
}
