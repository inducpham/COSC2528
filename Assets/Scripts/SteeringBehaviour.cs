using UnityEngine;

public abstract class SteeringBehaviour : FuzzyBehavior
{
    public abstract Vector3 GetSteering();
	public override Vector3 Behavior (){
		return GetSteering ();
	}
	public override float Desire(){
				return 1f;
		}
}
