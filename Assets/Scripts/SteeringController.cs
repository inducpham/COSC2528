using UnityEngine;

[RequireComponent(typeof(Movement))]
public class SteeringController : MonoBehaviour
{
	public Transform Target;
    private SteeringBehaviour[] _steeringBehaviours;
    private Movement _movement;

    protected void Awake()
    {
        _steeringBehaviours = GetComponents<SteeringBehaviour>();
        _movement = GetComponent<Movement>();
    }

	protected void Update ()
	{
	    Vector3 steering = Vector3.zero;

	    foreach (var steeringBehaviour in _steeringBehaviours)
	    {
	        steering += steeringBehaviour.GetSteering();
	    }

        _movement.Move(steering);
	}
}
