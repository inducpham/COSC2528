using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float Speed = 2f;
    public float Accel = 10f;

    protected void Reset()
    {
        rigidbody.useGravity = false;
    }

    public void Move(Vector3 targetVelocity)
    {
        if (targetVelocity.sqrMagnitude > 1)
        {
            targetVelocity.Normalize();
        }

        targetVelocity *= Speed;

        Vector3 acceleration = (targetVelocity - rigidbody.velocity)*Accel;

        if (acceleration.magnitude > Accel)
            acceleration = acceleration.normalized*Accel;

        rigidbody.velocity += acceleration * Time.deltaTime;

		//set the new orientation
		transform.rotation.SetFromToRotation (transform.position, new Vector3 (1f, 1f, 1f));
    }
}
