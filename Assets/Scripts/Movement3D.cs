using UnityEngine;
using System.Collections;

public class Movement3D : Movement {
	//public float Speed = 2f; //using drag (in rigid body) is better than setting a speed limit.
	
	/// <summary>
	/// The Reaction Speed to a given targetVelocity, the larger the faster to reach the given targetVelocity.
	/// </summary>
	public float ReactionSpeed = 10f;
	
	/// <summary>
	/// The maximum acceleration.
	/// </summary>
	public float MaximumAcc = 10f;
	/// <summary>
	/// To limit the movement in a perticular area.
	/// Take position as parameter.
	/// </summary>
	public Globals.VectorField Fence = Globals.CreatVectorFieldRadiant(r => -r/4f);


	//private Globals.Filter3 filter = Globals.CreateFilter3(50f,()=>Time.deltaTime);
	public override void Reset()
	{
		base.Reset ();
		//rigidbody.drag = .1f;
		rigidbody.useGravity = false;
	}

	public override void Move(Vector3 targetVelocity)
	{
		Vector3 acceleration = (targetVelocity - rigidbody.velocity)*ReactionSpeed;
		
		if (acceleration.magnitude > MaximumAcc)
			acceleration = acceleration.normalized*MaximumAcc;
		
		if (Fence != null)
			acceleration += Fence (transform.position);
		rigidbody.velocity += acceleration * Time.deltaTime;
		transform.eulerAngles = Globals.EulerAngles (rigidbody.velocity);
	}
}
