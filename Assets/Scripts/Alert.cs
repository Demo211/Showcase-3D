using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alert : MonoBehaviour
{
    [SerializeField] private AlertTrigger[] _alertTriggers;

    [SerializeField] private float _maxVolume;
    [SerializeField] private float _volumeChangeStep;

    private float _volumeChangeRate = 0.1f;
    private AudioSource _audioSource;
    private float _targetVolume;

    private bool _isTryingDisable = false;

    private void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        foreach (AlertTrigger trigger in _alertTriggers)
        {
            trigger.ThiefCame += TurnOnAlert;
            trigger.ThiefLeft += TurnOffAlert;
        }

        StartCoroutine(ChangeVolume());
    }

    private void OnDisable()
    {
        foreach (AlertTrigger trigger in _alertTriggers)
        {
            trigger.ThiefCame -= TurnOnAlert;
            trigger.ThiefLeft -= TurnOffAlert;
        }
    }

    private void TurnOnAlert()
    {
        _audioSource.enabled = true;
        _targetVolume = _maxVolume;
    }

    private void TurnOffAlert()
    {
        _targetVolume = 0;

        if( _isTryingDisable == false) 
            StartCoroutine(DisableAudioSource());
    }

    private IEnumerator ChangeVolume()
    {
        while (enabled)
        {
            if (_audioSource.volume != _targetVolume)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeChangeStep * Time.deltaTime);
                
            }

            yield return new WaitForSeconds(_volumeChangeRate);
        }
    }

    private IEnumerator DisableAudioSource()
    {
        _isTryingDisable = true;

        yield return new WaitUntil(IsNoSound);
        _audioSource.enabled = false;

        _isTryingDisable = false;
    }

    private bool IsNoSound()
    {
        return _audioSource.volume == 0;
    }
}
