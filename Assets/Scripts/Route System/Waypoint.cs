using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Waypoint _nextWaypoint;

    [SerializeField] private float _radius = 0.5f;

    public float Radius => _radius;
    public Waypoint NextWaypoint => _nextWaypoint;
}
