using UnityEngine;

[RequireComponent(typeof(Movement))]
public class SteeringController : MonoBehaviour
{
	public Transform Target;
	private SteeringBehaviour[] _steeringBehaviours;
	private Movement _movement;
	
	// Use this for initialization
	void Awake(){
		_steeringBehaviours = GetComponents<SteeringBehaviour>();
		_movement = GetComponent<Movement>();
	}
	
	protected void UpdateBehavior(){
		Vector3 desireVelocity = Vector3.zero;
		float sumWeight = 0f;
		foreach (var i in _steeringBehaviours) {
			float w = i.GetPriority();
			sumWeight += w;
			desireVelocity += w * i.GetSteering ();
		}
		sumWeight = Mathf.Max (sumWeight, 1f);
		Debug.Log (desireVelocity);
		_movement.Move (desireVelocity * (1f/sumWeight));
	}	
	// Update is called once per frame
	void Update () {
		UpdateBehavior ();
	}//*/
}
