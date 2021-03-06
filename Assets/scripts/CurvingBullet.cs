﻿using UnityEngine;
using System.Collections;

public class CurvingBullet : MonoBehaviour {

    public float bulletSpeed = 3.0f;
    public float countDown;
    private bool keyPressed;
    public float rotationSpeed;
    private bool canCurve = true;
    public GameObject explosion;
    public Rigidbody myBody;
    private Vector3 player;
    [SerializeField]
    LayerMask groundMask;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        player = Character.playerPosition;
        //myBody.velocity = myBody.transform.forward * bulletSpeed;

        if(Physics.Raycast(transform.position+ (myBody.transform.forward*1), player - transform.position, Vector3.Distance(myBody.position, player), groundMask))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        //This is the countdown
        countDown = countDown - Time.deltaTime;
        if (countDown <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, myBody.transform.forward,bulletSpeed*Time.deltaTime*2, groundMask))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        //This is the bullet curving
        Plane playerPlane = new Plane(Vector3.right, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist) && (canCurve == true))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation((targetPoint - transform.position), Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            myBody.velocity = transform.forward * bulletSpeed;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
