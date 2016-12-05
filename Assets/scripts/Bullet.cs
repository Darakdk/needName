using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 3.0f;
    public float countDown;
    public GameObject explosion;
    public Rigidbody myBody;
    private RaycastHit hit;
    private Vector3 player;
    [SerializeField]
    LayerMask groundMask;
    void Update () {
        //transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        //This is the countdown
        
        countDown = countDown - Time.deltaTime;
        if (countDown <= 0) {
            Destroy(gameObject);
            }
    }

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        player = Character.playerPosition;
        myBody.velocity = myBody.transform.forward * bulletSpeed;

        if(Physics.Raycast(transform.position+myBody.transform.forward*2, player, Vector3.Distance(myBody.position, player), groundMask))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
