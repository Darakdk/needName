using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public GameObject bullet;
    public GameObject curvingBullet;
    public float cooldown;
    public float recoil;
    private float canShoot = 1f;
	public ParticleSystem normalEffect;
	public ParticleSystem curvingEffect;
	public AudioSource audioEmitter;
	public AudioClip shot;
	public AudioClip shotHeavy;


    // Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
        //This is the shooting
        if (Input.GetMouseButtonDown(0))
        {
            //Left Click
            if (canShoot >= cooldown){
                Instantiate(bullet, transform.position, transform.rotation);
                canShoot = 0;
				normalEffect.Play();
				audioEmitter.PlayOneShot (shot);
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            {
                Instantiate(curvingBullet, transform.position, transform.rotation);
				curvingEffect.Play();
				audioEmitter.PlayOneShot (shotHeavy);
            }
        }
        //Right Click
        

        if (Input.GetMouseButtonDown(2)) { }
        //Middle Click

        if (canShoot < 1)
        {
            canShoot = canShoot + Time.deltaTime;
        }
    }
}
