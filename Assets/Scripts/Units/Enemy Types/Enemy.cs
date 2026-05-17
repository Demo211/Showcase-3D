using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, ISpawnable, IMoving
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided with " + collision.gameObject.name);
    }
}
