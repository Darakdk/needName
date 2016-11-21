using UnityEngine;
using System.Collections;

public class atackOneScr : MonoBehaviour {
    public Rigidbody myBody;
    public float gravity;
    public ParticleSystem explosion;
    public GameObject miniEnemy;
    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        myBody.velocity -= gravity * Vector3.up;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy") || collision.gameObject.layer == LayerMask.NameToLayer("Player") || collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            Destroy(this.gameObject);
            Instantiate(miniEnemy, transform.position - Vector3.forward * 2, transform.rotation);
            Instantiate(miniEnemy, transform.position - Vector3.forward * 1, transform.rotation);
            Instantiate(miniEnemy, transform.position + Vector3.forward * 2, transform.rotation);
            Instantiate(miniEnemy, transform.position + Vector3.forward * 1, transform.rotation);
        }
    }
}
