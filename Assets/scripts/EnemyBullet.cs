using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

    public float bulletSpeed = 3.0f;
    public float countDown;
    public GameObject explosion;

    void Update () {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        //This is the countdown
        countDown = countDown - Time.deltaTime;
        if (countDown <= 0) {
            Destroy(this.gameObject);
            }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("enemy"))
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

}
