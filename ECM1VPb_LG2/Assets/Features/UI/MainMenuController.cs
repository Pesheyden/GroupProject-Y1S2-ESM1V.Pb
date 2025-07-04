using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("GameStart")]
    public UnityEvent OnStartCampaign;
    public UnityEvent OnStartFreePlay;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private Vector2Int _freePlaySceneRange;
    
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

    [Header("FMODBuses")] 
    [SerializeField] private string _mainBusName;
    [SerializeField] private string _sfxBusName;
    [SerializeField] private string _musicBusName;

    private FMOD.Studio.Bus _mainBus;
    private FMOD.Studio.Bus _sfxBus;
    private FMOD.Studio.Bus _musicBus;

    private void Awake()
    {
        MasterVolumeSlider.onValueChanged.AddListener(OnMasterSliderChange);
        SfxVolumeSlider.onValueChanged.AddListener(OnSfxSliderChange);
        MusicVolumeSlider.onValueChanged.AddListener(OnMusicSliderChange);

        _mainBus = FMODUnity.RuntimeManager.GetBus(_mainBusName);
        _sfxBus = FMODUnity.RuntimeManager.GetBus(_sfxBusName);
        _musicBus = FMODUnity.RuntimeManager.GetBus(_musicBusName);
    }

    private void OnMasterSliderChange(float value)
    {
        _mainBus.setVolume(value);
    }
    
    private void OnSfxSliderChange(float value)
    {
        _sfxBus.setVolume(value);
    }
    
    private void OnMusicSliderChange(float value)
    {
        _musicBus.setVolume(value);
    }
    

    public void StartCampaign()
    {
        OnStartCampaign?.Invoke();
    }

    public void StartFreePlay()
    {
        OnStartFreePlay?.Invoke();
        _sceneLoader.StartRandomScene(_freePlaySceneRange);
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
