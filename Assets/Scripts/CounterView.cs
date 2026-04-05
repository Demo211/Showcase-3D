using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshPro _showPlate;

    private int _number;
    private string _nameOfCountedItem = " crate(s)";

    private void Start()
    {
        _showPlate.text = "0" + _nameOfCountedItem;
    }
    private void OnEnable()
    {
        _counter.CounterChanged += UpdateInfo;
    }

    private void OnDisable()
    {
     _counter.CounterChanged -= UpdateInfo;   
    }

    private void UpdateInfo()
    {
        _showPlate.text = _counter.Count.ToString("") + _nameOfCountedItem;
    }
}
