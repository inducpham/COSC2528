﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteeringController))]
public class SteerTarget : SteeringBehaviour
{
//    [System.Serializable]
//    public class Properties
//    {
        private Transform _target;
        public float MaxForce = 2;
//    }

//    public Properties DefinedProperties;

	protected void Start()
	{
		_target = GetComponent<SteeringController>().Target;
	}

    public override Vector3 GetSteering()
    {
        if (Vector3.Distance(_target.position, transform.position) < 3)
            return Vector3.zero;
        return Vector3.ClampMagnitude(_target.position
            - transform.position, MaxForce);
    }
}
