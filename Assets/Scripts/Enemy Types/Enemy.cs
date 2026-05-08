using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _lifetime = 5f;

    private void OnEnable()
    {
        StartCoroutine(LifetimeSountdown());
    }

    private IEnumerator LifetimeSountdown()
    {
        yield return new WaitForSeconds(_lifetime);
        gameObject.SetActive(false);
    }

}
