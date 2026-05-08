using System.Collections;
using UnityEngine;

public class Enemy : Spawnable
{
    [SerializeField] private float _lifetime = 5f;

    private void OnEnable()
    {
        StartCoroutine(LifetimeCountdown());
    }

    private IEnumerator LifetimeCountdown()
    {
        yield return new WaitForSeconds(_lifetime);
        gameObject.SetActive(false);
    }
}
