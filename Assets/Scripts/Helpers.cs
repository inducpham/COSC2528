using UnityEngine;
using System.Collections;

public class Helpers : MonoBehaviour {

	public static Vector3 GetRandom2DVector(float range) {
		return new Vector3(
			Random.Range(-range, range),
			0f,
			Random.Range(-range, range));
	}

}
