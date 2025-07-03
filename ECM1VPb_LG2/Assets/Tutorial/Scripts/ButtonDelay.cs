using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    public GameObject button;

    [SerializeField] private int waitAmount;

    [SerializeField] private GameObject textPopUp;

    private void OnEnable()
    {
        _ = buttonDelay();
    }

    async UniTask buttonDelay()
    {
        await UniTask.Delay(waitAmount);

        button.SetActive(true);

        textPopUp.SetActive(true);
    }
}
