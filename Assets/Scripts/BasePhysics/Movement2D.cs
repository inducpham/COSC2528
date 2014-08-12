using UnityEngine;
using System.Collections;

public class Movement2D : Movement3D {

	public void SetTo2D(){
		rigidbody.velocity = new Vector3 (rigidbody.velocity.x, 0 , rigidbody.velocity.z);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
	}

	void Start(){
		Reset ();
	}

	public virtual void Reset(){
		base.Reset ();
		transform.position = new Vector3(transform.position.x, 0 , transform.position.z);
		SetTo2D ();
	}

	public override void Move (Vector3 targetVelocity)
	{
		base.Move (targetVelocity);
		SetTo2D ();
	}
}
