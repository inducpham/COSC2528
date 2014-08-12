using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
public class InitVelocity : MonoBehaviour {

	public Vector3 targetVelocity = new Vector3(0, 0, 0);
	private Vector3 _targetPosition;
	private Movement _m;

	// Use this for initialization
	void Start () {
		_m = GetComponent<Movement> ();
		_targetPosition = transform.position + targetVelocity;
	}

	void Update () {
		Vector3 v = _targetPosition - transform.position;

		if (v.sqrMagnitude < 1f) {
			_m.Move (Vector3.zero);
			GetComponent<InitVelocity>().enabled = false;
		}
		_m.Move (v);
	}
}
