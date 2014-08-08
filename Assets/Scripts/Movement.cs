using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Globals))]
[RequireComponent(typeof(Rigidbody))]
public abstract class Movement : MonoBehaviour
{
	public abstract void Move (Vector3 targetVelocity);
}
