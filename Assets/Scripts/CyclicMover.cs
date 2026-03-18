using UnityEngine;

public class CyclicMover : MonoBehaviour
{
    
    private Vector3 _movementSpeed = new Vector3(2f, 0 , 2f);

    private float _cycleTime = 0;
    private float _cycleTotalTime = 18;

    private float _middleOfTheCycle => _cycleTotalTime / 2;

    private void Update()
    {
        if (_cycleTime < _middleOfTheCycle)
            transform.Translate(_movementSpeed*Time.deltaTime);
        else
            transform.Translate(-_movementSpeed * Time.deltaTime);

        _cycleTime += Time.deltaTime;
        _cycleTime %= _cycleTotalTime;
    }
}
