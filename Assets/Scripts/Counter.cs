using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _incrementDelay = 0.5f;
    [SerializeField] private KeyCode triggeringKey;

    private int _counter = 0;

    public float Count => _counter; 
    public event Action CounterChanged;

    private void Update()
    {
        if (Input.GetKeyDown(triggeringKey))
            StartCoroutine(Counting());
    }

    private IEnumerator Counting()
    {
        var wait = new WaitForSeconds(_incrementDelay);

        while (true)
        {

            yield return wait;

            if (Input.GetKey(triggeringKey) == false)
                yield break;

            _counter++;
            CounterChanged.Invoke();
        }
    }
}
