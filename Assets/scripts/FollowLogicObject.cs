using UnityEngine;
using System.Collections;

public class FollowLogicObject : MonoBehaviour {

    public Transform toFollow;

    public float interpolationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, toFollow.position, interpolationSpeed * Time.deltaTime);
    }
}
