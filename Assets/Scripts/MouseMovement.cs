using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
public class MouseMovement : MonoBehaviour
{
    private Movement _movement;

    private Vector3 _targetPoint;

    protected void Awake ()
    {
        _movement = GetComponent<Movement>();
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
            _targetPoint = ray.GetPoint(Camera.main.transform.position.y);
            _targetPoint.y = 0;
        }

        Vector3 targetDirection = _targetPoint - transform.position;

        _movement.Move(targetDirection);

    }
}
