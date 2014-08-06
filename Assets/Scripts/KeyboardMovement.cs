using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
public class KeyboardMovement : MonoBehaviour
{
    private Movement _movement;

    void Start ()
	{
	    _movement = GetComponent<Movement>();
	}
	
	void Update ()
	{
	    var targetVelocity = new Vector3(Input.GetAxis("Horizontal"),
                    0, Input.GetAxis("Vertical"));

        _movement.Move(targetVelocity);
	}
}
