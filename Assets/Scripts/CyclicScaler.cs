using UnityEngine;

public class CyclicScaler : MonoBehaviour
{    
    [SerializeField] private Vector3 _scalingFactor;

    private float _cycleTime = 0;
    private float _cycleTotalTime = 5;
    private float _middleOfTheCycle => _cycleTotalTime / 2;

    private void Update()
    {
        if (_cycleTime < _middleOfTheCycle)
            transform.localScale += _scalingFactor * Time.deltaTime;
        else
            transform.localScale -= _scalingFactor * Time.deltaTime;

        _cycleTime += Time.deltaTime;
        _cycleTime %= _cycleTotalTime;
    }
}
