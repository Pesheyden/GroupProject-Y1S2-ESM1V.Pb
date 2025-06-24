using UnityEngine;
using UnityEngine.UI;

public class AdPowerupController : MonoBehaviour
{
    public RawImage AdImage;
    public GameObject CloseAdButtonGameObject;
    public GameObject AdditionalAdButtonGameObject;

    public GameObject FirstAdGameObject;
    public GameObject SecondAdGameObject;
    public GameObject ThirdAdGameObject;

    public void ActivateAnAd()
    {
        FirstAdGameObject.SetActive(true);
        
    }

    public void ActivateSecondAd()
    {
        if (FirstAdGameObject == true)
        {
            SecondAdGameObject.SetActive(true);
        }
    }

    public void ActivateThirdAd()
    {
        if (SecondAdGameObject == true)
        {
            ThirdAdGameObject.SetActive(true);
        }
    }

    public void DisableFirstAd()
    {
        FirstAdGameObject.SetActive(false);
    }

    public void DisableSecondAd() {
        SecondAdGameObject.SetActive(false);
    }

    public void DisableThirdAd()
    {
        ThirdAdGameObject.SetActive(false);
    }
}
