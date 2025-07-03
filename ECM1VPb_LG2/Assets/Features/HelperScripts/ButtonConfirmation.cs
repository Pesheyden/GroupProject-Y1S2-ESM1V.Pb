using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonConfirmation : MonoBehaviour
{
    public Button ButtonOne;
    public Button ButtonTwo;

    public UnityEvent OnTwoButtonPress;

    private bool isButtonOnePressed = false;
    private bool isButtonTwoPressed = false;

    private void Start()
    {
        ButtonOne.onClick.AddListener(() => OnButtonPressed(1));
        ButtonTwo.onClick.AddListener(() => OnButtonPressed(2));
    }

    void OnButtonPressed(int buttonNumber)
    {
        if (buttonNumber == 1)
        {
            isButtonOnePressed = true;
        }
        else if (buttonNumber == 2)
        { 
            isButtonTwoPressed = true; 
        }

        CheckPressedButtons();
    }

    void CheckPressedButtons()
    {
        if (isButtonOnePressed && isButtonTwoPressed)
        {
            Debug.Log("Both buttons have been pressed, triggering the event");
            // Trigger your event here
            
            OnTwoButtonPress.Invoke();

            isButtonOnePressed = false;
            isButtonTwoPressed = false;
        }
    }
}
