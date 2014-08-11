using UnityEngine;
using System.Collections;

public class SteerRandom : SteeringBehaviour {

	public Transform target = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override Vector3 GetSteering() {		
		return  new Vector3 (
			Random.Range (-1f, 1f),
			0,
			Random.Range (-1f, 1f)
				);
	}
}
