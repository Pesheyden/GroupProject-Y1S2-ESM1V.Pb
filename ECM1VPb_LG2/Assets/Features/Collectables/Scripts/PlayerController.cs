using System;
using System.Collections;
using System.Collections.Generic;
using BSOAP.Variables;
using SaintsField;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public enum PowerUpType
{
    Snowman,
    IceBucket,
    Ad,
}
public class PlayerController : MonoBehaviour
{
    [Header("Coins")][Space(10)]
    public IntVariable Coins;

    [SaintsDictionary("PowerUp", "Price")]
    [SerializeField] private SaintsDictionary<PowerUpType,int> _powerUpPrices;

    public Image SnowmanFillImage;
    public Image IceBucketFillImage;
    public Image AdFillImage;

    public UnityEvent OnSnowmanPowerUp;
    public UnityEvent OnIceBucketPowerUp;
    public UnityEvent OnAdPowerUp;

    private void Awake()
    {
        Coins.OnValueChanged += value =>
        {
            SnowmanFillImage.fillAmount = 1 - (float)value / _powerUpPrices[PowerUpType.Snowman];
            IceBucketFillImage.fillAmount = 1 - (float)value / _powerUpPrices[PowerUpType.IceBucket];
            AdFillImage.fillAmount = 1 - (float)value / _powerUpPrices[PowerUpType.Ad];
        };
    }

    public void Purchase(string powerUpType)
    {
        if (!Enum.TryParse<PowerUpType>(powerUpType, out var result))
            return;
        
        switch (result)
        {
            case PowerUpType.Snowman:
                if (Coins.Value - _powerUpPrices[PowerUpType.Snowman] >= 0)
                {
                    Coins.Value -= _powerUpPrices[PowerUpType.Snowman];
                    OnSnowmanPowerUp?.Invoke();
                }
                break;
            case PowerUpType.IceBucket:
                if (Coins.Value - _powerUpPrices[PowerUpType.IceBucket] >= 0)
                {
                    Coins.Value -= _powerUpPrices[PowerUpType.IceBucket];
                    OnIceBucketPowerUp?.Invoke();
                }
                break;
            case PowerUpType.Ad:
                if (Coins.Value - _powerUpPrices[PowerUpType.Ad] >= 0)
                {
                    Coins.Value -= _powerUpPrices[PowerUpType.Ad];
                    OnAdPowerUp?.Invoke();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(powerUpType), powerUpType, null);
        }
    }
}
