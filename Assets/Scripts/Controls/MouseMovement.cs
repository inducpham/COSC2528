using UnityEngine;
using UnityEditor;
using System.Collections;

[RequireComponent(typeof(Movement))]
public class MouseMovement : MonoBehaviour
{
    private Movement _movement;
	private Plane _groundPlane;

    private Vector3 _targetPoint;

    protected void Awake ()
    {
        _movement = GetComponent<Movement>();
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
            	_targetPoint = ray.GetPoint(distance);
            	_targetPoint.y = 0;
			}
        }

        Vector3 targetDirection = _targetPoint - transform.position;
        _movement.Move(targetDirection);
    }
}
