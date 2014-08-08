using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(FuzzyBehavior))]
public class FuzzyController : MonoBehaviour {

	private FuzzyBehavior[] _behaviors;
	private Movement _movement;

	// Use this for initialization
	void Awake(){
		_behaviors = GetComponents<FuzzyBehavior>();
		_movement = GetComponent<Movement>();
	}

	protected void UpdateBehavior(){
		Vector3 desireVelocity = Vector3.zero;
		float sumWeigh = 0f;
		foreach (var i in _behaviors) {
			float w = i.Desire();
			sumWeigh += w;
			desireVelocity += w * i.Behavior ();
		}
		_movement.Move (1f/sumWeigh*desireVelocity);
	}	
	// Update is called once per frame
	void Update () {
		UpdateBehavior ();
	}//*/
}
