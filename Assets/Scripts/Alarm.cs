using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AlarmTrigger _zone;
    [SerializeField] private float _increaseSpeed = 1f;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _minVolume = 0f;

    private AudioSource _audioSource;
    private Coroutine _fadeCoroutine;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
    }
    
    private void OnEnable()
    {
        _zone.PlayerEntered += FadeIn;
        _zone.PlayerOut += FadeOut;
    }

    private void OnDisable()
    {
        _zone.PlayerEntered -= FadeIn;
        _zone.PlayerOut -= FadeOut;
    }

    private void FadeIn(Collider other)
    {
        StartIncrease(_maxVolume);
    }

    private void FadeOut(Collider other)
    {
        StartDecrease(_minVolume);
    }

    private void StartIncrease(float targetVolume)
    {
        if (_fadeCoroutine != null)
            StopCoroutine(_fadeCoroutine);

        _fadeCoroutine = StartCoroutine(IncreaseRoutine(targetVolume));
    }
    
    private void StartDecrease(float targetVolume)
    {
        if (_fadeCoroutine != null)
            StopCoroutine(_fadeCoroutine);

        _fadeCoroutine = StartCoroutine(DecreaseRoutine(targetVolume));
    }

    private IEnumerator IncreaseRoutine(float targetVolume)
    {
        while (_audioSource.volume < targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _increaseSpeed * Time.deltaTime);
            
            yield return null;
        }
    }
    
    private IEnumerator DecreaseRoutine(float targetVolume)
    {
        while (_audioSource.volume > targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards( targetVolume, _audioSource.volume,_increaseSpeed * Time.deltaTime);
            
            yield return null;
        }
    }
}