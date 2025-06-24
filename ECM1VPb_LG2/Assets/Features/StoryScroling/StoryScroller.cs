using System;
using System.Collections;
using UnityEngine;
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
    [SerializeField] private float _waitTime;
    [SerializeField] private StartType _startType;
    [SerializeField] private Button _skipButton;

    private int _nextBlockIndex;
    private Coroutine _waitCoroutine;
    private AudioSource _audioSource;

    private void OnEnable()
    {
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
        StopCoroutine(_waitCoroutine);
        NextStep();
    }

    private void NextStep()
    {
        _storyBlocks[_nextBlockIndex].SetActive(true);
        _storyBlocks[_nextBlockIndex].GetComponent<Animation>()?.Play();
        _audioSource.PlayOneShot(_storyAudioBlocks[_nextBlockIndex]);

        if (_nextBlockIndex == _storyBlocks.Length - 1)
        {
            return;
        }
        _nextBlockIndex++;

        _waitCoroutine = StartCoroutine(WaitCoroutine());
    }

    private IEnumerator WaitCoroutine()
    {
        if(_storyAudioBlocks[_nextBlockIndex - 1])
            yield return new WaitForSeconds(_storyAudioBlocks[_nextBlockIndex - 1].length);
        else
            yield return new WaitForSeconds(_waitTime);
        NextStep();
    }
}
