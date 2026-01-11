using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private const float MinVolume = 0f;
    private const float MaxVolume = 1f;
    
    [SerializeField] private AlarmTrigger _zone;
    [SerializeField] private float _increaseSpeed = 1f;
    [SerializeField] private Crook _crook;

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
        StartFadeVolume(MaxVolume);
    }

    private void FadeOut(Collider other)
    {
        StartFadeVolume(MinVolume);
    }

    private void StartFadeVolume(float targetVolume)
    {
        if (_fadeCoroutine != null)
            StopCoroutine(_fadeCoroutine);

        _fadeCoroutine = StartCoroutine(IncreaseRoutine(targetVolume));
    }

    private IEnumerator IncreaseRoutine(float targetVolume)
    {
        while (_audioSource.volume > targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _increaseSpeed * Time.deltaTime);
            
            yield return null;
        }
    }
}