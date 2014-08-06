using UnityEngine;
using System.Collections;

public class SteerTarget : SteeringBehaviour
{
    [System.Serializable]
    public class Properties
    {
        public Transform Target;

        public float MaxForce = 2;
    }

    public Properties DefinedProperties;

    public override Vector3 GetSteering()
    {
        if (Vector3.Distance(DefinedProperties.Target.position, transform.position) < 3)
            return Vector3.zero;
        return Vector3.ClampMagnitude(DefinedProperties.Target.position
            - transform.position, DefinedProperties.MaxForce);
    }
}
