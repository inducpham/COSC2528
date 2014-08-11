using UnityEngine;
using System.Collections;

public class PrefabHost : MonoBehaviour {

	public GameObject prefab = null;
	public int initCount = 5;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < initCount; i++)
			this.spawnPrefab ();	
	}

	void spawnPrefab() {
		if (this.prefab != null) {
			GameObject o = (GameObject) Instantiate(prefab, transform.position + Helpers.GetRandom2DVector(2f),
			                                        Quaternion.identity);

			// if the prefab has a steer target settings, set it to be this object
			SteeringController t = o.GetComponent<SteeringController>();
			if (t != null)
				t.Target = transform;
		}
	}

}
