using UnityEngine;
using System.Collections;
using System.Collections.Generic;



/// <summary>
/// Still messy here...
/// </summary>
public class SteeringFlocking : SteeringBehaviour {

	private static List<SteeringFlocking> allPeers = new List<SteeringFlocking>();
	Globals.VectorField avoidForce  = Globals.CreatVectorFieldRadiant(
			r => 10f/(r*r*r + 0.1f));

	// Use this for initialization
	void Start () {
		allPeers.Add (this);
	}

	float desire;
	// Update is called once per frame
	Vector3 targetVelocity;
	void Update () {
		desire = 0;
		int n = allPeers.Count;
		if (n <= 1) 
						return;
		Vector3 ds = new Vector3();
		Vector3 dv = new Vector3();
		Vector3 av = new Vector3 ();
		foreach (var peer in allPeers) {
			if (peer == this) continue;
			float K = .00010f;
			Vector3 s = peer.rigidbody.position - rigidbody.position;
			//if (rigidbody.velocity.sqrMagnitude<.1f)
			float f = 1 / s.sqrMagnitude;
			//f-=0.05f;
			if (f < 0f)
					f = 0f;
			//float wi = (Vector3.Dot(rigidbody.velocity,s)+K)*f/(rigidbody.velocity.magnitude + K)
			//	+ rigidbody.velocity.magnitude/(rigidbody.velocity.magnitude + K);
			//float wi = (Vector3.Dot (rigidbody.velocity, s) / rigidbody.velocity.magnitude / s.magnitude +1)
			//	/ s.sqrMagnitude / s.sqrMagnitude * 1600;
			float vm = rigidbody.velocity.magnitude;
			float wi = (Vector3.Dot (rigidbody.velocity, s) / (vm+K)/s.magnitude
			            +1)/ s.sqrMagnitude/s.magnitude * 800;
			wi = 10*wi;
			ds += wi * s;
			dv += wi * peer.rigidbody.velocity;
			desire += wi;

			av +=	avoidForce (transform.position - peer.transform.position);
		}
		targetVelocity = 1f/desire*((1*(dv + 0.7f * (ds-transform.position))-rigidbody.velocity))
			+ rigidbody.velocity
			+ av;
		desire = desire*1f/( n - 1) + .1f;
	}
	public override float GetPriority ()
	{
		return desire/1;
	}
	public override Vector3 GetSteering ()
	{
		return targetVelocity;
	}
}
