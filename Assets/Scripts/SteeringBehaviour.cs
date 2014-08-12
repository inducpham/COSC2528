using UnityEngine;

public abstract class SteeringBehaviour:MonoBehaviour
{
	public float piority=1f;
    public abstract Vector3 GetSteering();
	public virtual float GetPriority () {
		return 0f;
	}

}
