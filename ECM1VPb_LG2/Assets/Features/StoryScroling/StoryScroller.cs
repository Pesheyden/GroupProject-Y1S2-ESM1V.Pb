using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum StartType 
{
    None,
    Awake,
    Start,
    Enable,
}

[RequireComponent(typeof(AudioSource))]
public class StoryScroller : MonoBehaviour
{
    [SerializeField] private GameObject[] _storyBlocks;
    [SerializeField] private AudioClip[] _storyAudioBlocks;
    [SerializeField] private int _waitTime;
    [SerializeField] private StartType _startType;
    [SerializeField] private Button _skipButton;
    [SerializeField] private UnityEvent _onStoryEnd;

    private int _nextBlockIndex;
    private Coroutine _waitCoroutine;
    private CancellationTokenSource _source;
    private CancellationToken _cancellationToken;

    private AudioSource _audioSource;

    private void OnEnable()
    {
        _source = new CancellationTokenSource();
        _cancellationToken = _source.Token;
        if (_startType == StartType.Enable)
        {
            NextStep();
        }
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _skipButton.onClick.AddListener(Skip);
        
        if (_startType == StartType.Awake)
        {
            NextStep();
        }
    }

    private void Start()
    {
        if (_startType == StartType.Start)
        {
            NextStep();
        }
    }

    private void Skip()
    {
        _source.Cancel();
        if (_nextBlockIndex - 1 == _storyBlocks.Length - 1)
        {
            _onStoryEnd?.Invoke();
            return;
        }
        Debug.Log("Skip");
        NextStep();
    }

    private void NextStep()
    {
        _storyBlocks[_nextBlockIndex].SetActive(true);
        _storyBlocks[_nextBlockIndex].GetComponent<Animation>()?.Play();

        var action = new UnityEvent();
        action.AddListener(NextStep);
        
        if (_storyAudioBlocks[_nextBlockIndex])
            _audioSource.PlayOneShot(_storyAudioBlocks[_nextBlockIndex]);

        _nextBlockIndex++;
        if (_nextBlockIndex == _storyBlocks.Length - 1)
        {
            _ = WaitCoroutine(_onStoryEnd);
            return;
        }

        

        _ = WaitCoroutine(action);
    }

    private async Task WaitCoroutine(UnityEvent action)
    {
        if(_storyAudioBlocks[_nextBlockIndex - 1])
            await Task.Delay((int)(_storyAudioBlocks[_nextBlockIndex - 1].length * 1000), _cancellationToken);
        else
            await Task.Delay(_waitTime, _cancellationToken);
        action.Invoke();
    }
}
