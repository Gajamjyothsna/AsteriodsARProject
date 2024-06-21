using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitialRotationTowardsTarget : MonoBehaviour
{
    [SerializeField] private string targetObjectName;
    [SerializeField] private Vector3 randomOffset;

    private void Start()
    {
        //Find the target with name of the object
        GameObject targetObject = GameObject.Find(targetObjectName);

        //If target object is not found, then its nothing
        if (targetObject == null) return;

        //Get the target's position to get the direction
        Vector3 direction = targetObject.transform.position - this.transform.position;

        //Randomize based on the offset and add to the direction
        direction += new Vector3(Random.Range(randomOffset.x, -randomOffset.x),
            Random.Range(randomOffset.y, -randomOffset.y), Random.Range(randomOffset.z, -randomOffset.z));

        //Rotating the object towards the target object
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
}
