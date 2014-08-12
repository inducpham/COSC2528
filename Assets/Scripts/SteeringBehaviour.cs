using UnityEngine;

public abstract class SteeringBehaviour:MonoBehaviour
{
    public abstract Vector3 GetSteering();
	public virtual float GetPriority () {
		return 0f;
	}

}
