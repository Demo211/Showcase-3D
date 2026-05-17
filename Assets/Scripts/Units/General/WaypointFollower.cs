using System.Collections;
using UnityEngine;
using static Utils;

public class WaypointFollower : Mover
{
    private Waypoint[] _route;
    private Vector3 _destinationPoint;
    private int _counter = 0;

    private void OnEnable()
    {
        StartCoroutine(ResetTarget());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _route[_counter].transform.position, Time.deltaTime * _speed);
    }

    private IEnumerator ResetTarget()
    {
        while (_counter < _route.Length)
        {
            yield return new WaitUntil(ReachedNextWaypoint);

            _counter++;
        }

        _counter--; // затычка, объект должен уже убиться об базу в этом моменте
        _speed = 0;
    }

    private bool ReachedNextWaypoint()
    {
        return (_route[_counter].transform.position - transform.position).magnitude < _route[_counter].Radius;
    }

    public void SetRoute(Waypoint[] route)
    {
        _route = route;
    }
}
