using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private const float MinVolume = 0f;
    private const float MaxVolume = 1f;
    
    [SerializeField] private AlarmTrigger _zone;
    [SerializeField] private float _increaseSpeed = 1f;
    
    private AudioSource _audioSource;
    private Coroutine _fadeCoroutine;
    
    private int _currentEntryCount;
    
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
        if (_currentEntryCount == 0)
            StartFadeVolume(MaxVolume);
        
        _currentEntryCount++;
    }

    private void FadeOut(Collider other)
    {
        _currentEntryCount = Mathf.Max(0, _currentEntryCount - 1);

        if (_currentEntryCount == 0)
            StartFadeVolume(MinVolume);
    }

    private void StartFadeVolume(float targetVolume)
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        if (_fadeCoroutine != null)
            StopCoroutine(_fadeCoroutine);

        _fadeCoroutine = StartCoroutine(IncreaseRoutine(targetVolume));
    }

    private IEnumerator IncreaseRoutine(float targetVolume)
    {
        while (Mathf.Approximately(_audioSource.volume, targetVolume) == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _increaseSpeed * Time.deltaTime);

            yield return null;
        }

        if (Mathf.Approximately(targetVolume, 0f))
            _audioSource.Stop();
    }
}