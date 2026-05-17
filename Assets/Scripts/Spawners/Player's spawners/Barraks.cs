using System;
using System.Collections;
using UnityEngine;

public class Barraks : SpawnPoint<Infantry>
{
    [SerializeField] private int _maxUnitsPrepared = 3;
    [SerializeField] private int _maxUnitsOnField = 5;
    [SerializeField] private float _unitPreparationTime = 1;

    private int _unitsPrepared = 3;
    private int _activeUnitsOnField = 0;

    public bool HaveUnitsReady => _unitsPrepared > 0;
    public bool NeedMoreOnField => _activeUnitsOnField < _maxUnitsOnField;

    private void OnEnable()
    {
        StartCoroutine(PreparingInfantryUnit());
    }

    private void FixedUpdate()
    {
        Debug.Log($"On field: {_activeUnitsOnField}\n Prepared: {_unitsPrepared}");
    }

    private IEnumerator PreparingInfantryUnit()
    {
        while (this.enabled)
        {
            yield return new WaitUntil(HaveMoreSpace);
            yield return new WaitForSeconds(_unitPreparationTime);
            _unitsPrepared++;
        }
    }

    private bool HaveMoreSpace()
    {
        return _unitsPrepared < _maxUnitsPrepared;
    }

    private IEnumerator SpawnUnit()
    {
        while(HaveUnitsReady)
        {
            _spawner.Spawn(_possibleTypes[0]);
            _unitsPrepared--;
            _activeUnitsOnField++;
        }

        yield return null;
    }

    public void Spawn()
    {
        StartCoroutine(SpawnUnit());
    }
}
