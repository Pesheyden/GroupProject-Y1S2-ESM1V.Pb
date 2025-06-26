using UnityEngine;
using UnityEngine.UI;

public class AdPowerupController : MonoBehaviour
{
    public GameObject FirstAdGameObject;
    public GameObject SecondAdGameObject;
    public GameObject ThirdAdGameObject;

    public string OpenParameter;
    public string CloseParameter;

    public void ActivateAnAd()
    {
        FirstAdGameObject.SetActive(true);
        FMODUnity.RuntimeManager.CreateInstance(OpenParameter).start();
        
    }

    public void ActivateSecondAd()
    {
        if (FirstAdGameObject == true)
        {
            FMODUnity.RuntimeManager.CreateInstance(OpenParameter).start();
            SecondAdGameObject.SetActive(true);
        }
    }

    public void ActivateThirdAd()
    {
        if (SecondAdGameObject == true)
        {
            FMODUnity.RuntimeManager.CreateInstance(OpenParameter).start();
            ThirdAdGameObject.SetActive(true);
        }
    }

    public void DisableFirstAd()
    {
        FirstAdGameObject.SetActive(false);
        FMODUnity.RuntimeManager.CreateInstance(CloseParameter).start();
    }

    public void DisableSecondAd() {
        SecondAdGameObject.SetActive(false);
        FMODUnity.RuntimeManager.CreateInstance(CloseParameter).start();
    }

    public void DisableThirdAd()
    {
        ThirdAdGameObject.SetActive(false);
        FMODUnity.RuntimeManager.CreateInstance(CloseParameter).start();
    }
}
