using UnityEngine;
using System.Collections;

public class ResetOnCollide : MonoBehaviour {

	public Transform target;

	protected void OnCollisionEnter(Collision col)
	{
		if (col.collider == target.collider) {
			Application.LoadLevel(0);
		}
	}
}