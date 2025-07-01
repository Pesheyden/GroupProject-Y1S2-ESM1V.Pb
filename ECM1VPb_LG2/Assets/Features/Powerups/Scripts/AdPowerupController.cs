using UnityEngine;
using UnityEngine.UI;

public class AdPowerupController : MonoBehaviour
{
    public GameObject FirstAdGameObject;
    public GameObject SecondAdGameObject;
    public GameObject ThirdAdGameObject;
    public GameObject[] CheckPopUp;

    public string OpenParameter;
    public string CloseParameter;

    public void ActivateAnAd()
    {
        FirstAdGameObject.SetActive(true);
        if (OpenParameter != "")
            FMODUnity.RuntimeManager.CreateInstance(OpenParameter).start();
        
    }

    public void ActivateSecondAd()
    {
        if (FirstAdGameObject == true)
        {
            if (OpenParameter != "")
                FMODUnity.RuntimeManager.CreateInstance(OpenParameter).start();
            SecondAdGameObject.SetActive(true);
        }
    }

    public void ActivateThirdAd()
    {
        if (SecondAdGameObject == true)
        {
            if (OpenParameter != "")
                FMODUnity.RuntimeManager.CreateInstance(OpenParameter).start();
            ThirdAdGameObject.SetActive(true);
        }
    }

    public void DisableFirstAd()
    {
        FirstAdGameObject.SetActive(false);
        if (CloseParameter != "")
            FMODUnity.RuntimeManager.CreateInstance(CloseParameter).start();
        
        CheckPopUp[Random.Range(0,CheckPopUp.Length - 1)].SetActive(true);
    }

    public void DisableSecondAd() {
        SecondAdGameObject.SetActive(false);
        if (CloseParameter != "")
            FMODUnity.RuntimeManager.CreateInstance(CloseParameter).start();
    }

    public void DisableThirdAd()
    {
        ThirdAdGameObject.SetActive(false);
        if (CloseParameter != "")
            FMODUnity.RuntimeManager.CreateInstance(CloseParameter).start();
    }
}
