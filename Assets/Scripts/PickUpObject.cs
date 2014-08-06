using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour
{
    protected void OnCollisionEnter(Collision col)
    {
        if (col.collider.GetComponent<Movement>()
            != null)
        {
            //a collision has occured
            Destroy(gameObject);
            ScoreDisplay.Score++;
        }
    }
}
