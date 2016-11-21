using UnityEngine;
using System.Collections;

public class FollowLogicObjectWRotation : MonoBehaviour {

    public Transform toFollow;

    public float interpolationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, toFollow.position, interpolationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, toFollow.rotation, interpolationSpeed * Time.deltaTime);
    }
}
