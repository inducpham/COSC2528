using UnityEngine;
using UnityEditor;
using System.Collections;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(NavMeshAgent))]

public class MouseMovement : MonoBehaviour
{
	private Movement _movement;
	private NavMeshAgent _navAgent;
	private Plane _groundPlane;

    private Vector3 _targetPoint;

    protected void Awake ()
    {
        _movement = GetComponent<Movement>();
		_navAgent = GetComponent<NavMeshAgent> ();
		_groundPlane = new Plane (Vector3.up, Vector3.zero);
    }

    protected void Start()
    {
        _targetPoint = transform.position;
    }

    protected void Update ()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float distance = 0f;

			if (_groundPlane.Raycast(ray, out distance)) {
				Vector3 d = ray.GetPoint(distance);
				d.y = 0;

				_navAgent.SetDestination(d);
				_targetPoint = _navAgent.steeringTarget;
//				_targetPoint = d;
			}
        }

		//get the path
		if (_navAgent.hasPath) {
			NavMeshPath p = _navAgent.path;
			for (int i = 1; i < p.corners.Length; i++) {
				Debug.DrawLine (p.corners[i - 1], p.corners[i]);
			}
			_targetPoint = _navAgent.nextPosition;
			Vector3 targetDirection = _targetPoint - transform.position;
			_movement.Move (targetDirection);
		}
    }
}
