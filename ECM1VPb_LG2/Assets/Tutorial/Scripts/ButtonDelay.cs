using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    public GameObject button;

    [SerializeField] private int waitAmount;

    [SerializeField] private GameObject textPopUp;

    private void OnEnable()
    {
        buttonDelay();
    }

    async Task buttonDelay()
    {
        await Task.Delay(waitAmount);

        button.SetActive(true);

        textPopUp.SetActive(true);
    }
}
