using UnityEngine;
using System.Collections;

public class SteerWander : SteeringBehaviour
{
    private Vector3 _randomSteering;
    
    public override Vector3 GetSteering()
    {
        _randomSteering += new Vector3(Random.Range(-.5f, .5f), 0, Random.Range(-.5f, .5f));
        _randomSteering.Normalize();

        return _randomSteering;
    }
}
