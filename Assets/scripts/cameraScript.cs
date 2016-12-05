using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour
{

    public GameObject player;
    public Camera cameratron;
    public float topOffset;
    public float depthOffset;
    public float leftOffset;
    public float cameraFlow;
    private Vector3 positionCamera;
    public float velocity;


    // Use this for initialization
    void Start()
    {
        player.GetComponent<GameObject>();
        cameratron = GetComponent<Camera>();
        positionCamera = cameratron.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        positionCamera = Vector3.Lerp(positionCamera, player.transform.position + Vector3.up * topOffset + Vector3.right * depthOffset + Vector3.forward * leftOffset, cameraFlow * Time.deltaTime);
        cameratron.transform.position = positionCamera;
    }
}