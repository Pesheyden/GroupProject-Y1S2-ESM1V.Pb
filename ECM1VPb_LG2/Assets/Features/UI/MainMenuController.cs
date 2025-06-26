using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("GameStart")]
    public UnityEvent OnStartCampaign;
    public UnityEvent OnStartFreePlay;
    
    [Header("Settings")]
    public UnityEvent OnOpenSettings;
    public UnityEvent OnCloseSettings;
    public Slider MasterVolumeSlider;
    public Slider SfxVolumeSlider;
    public Slider MusicVolumeSlider;
    
    [Header("Other")]
    public UnityEvent OnOpenHowToPlay;
    public UnityEvent OnCloseHowToPlay;
    public UnityEvent OnOpenStoryRecap;
    public UnityEvent OnCloseStoryRecap;

    private void Awake()
    {
        MasterVolumeSlider.onValueChanged.AddListener(OnMasterSliderChange);
        SfxVolumeSlider.onValueChanged.AddListener(OnSfxSliderChange);
        MusicVolumeSlider.onValueChanged.AddListener(OnMusicSliderChange);
    }

    private void OnMasterSliderChange(float value)
    {
        //Write logic for volume change
    }
    
    private void OnSfxSliderChange(float value)
    {
        //Write logic for volume change
    }
    
    private void OnMusicSliderChange(float value)
    {
        //Write logic for volume change
    }
    

    public void StartCampaign()
    {
        OnStartCampaign?.Invoke();
    }

    public void StartFreePlay()
    {
        OnStartFreePlay?.Invoke();
    }

    public void OpenSettings()
    {
        OnOpenSettings?.Invoke();
    }

    public void CloseSettings()
    {
        OnCloseSettings?.Invoke();
    }

    public void OpenHowToPlayMenu()
    {
        OnOpenHowToPlay?.Invoke();
    }

    public void CloseHowToPlayMenu()
    {
        OnCloseHowToPlay?.Invoke();
    }

    public void OpenStoryRecap()
    {
        OnOpenStoryRecap?.Invoke();
    }

    public void CloseStoryRecap()
    {
        OnCloseStoryRecap?.Invoke();
    }
}
