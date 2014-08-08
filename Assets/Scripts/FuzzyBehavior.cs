using UnityEngine;

public abstract class FuzzyBehavior : MonoBehaviour {

	/// <summary>
	/// Return a non-negative float to represent how desire it to act this behavior.
	/// </summary>
	public abstract float Desire();

	/// <summary>
	/// Return a desire velocity of the object.
	/// </summary>
	public abstract Vector3 Behavior();
}
