using UnityEngine;
using System.Collections;

public class rangedEnemyScr: MonoBehaviour {

    private float distanceToPlayer;
    private Enemy sn;
    public float shootRange;
    public GameObject bullet;
    public GameObject player;
    private Vector3 targetPoint;
    public float fireRate;
    private float fireRateR;
    public int nRate;
    private int nRateR;
    // Use this for initialization
    void Start () {
        sn = gameObject.GetComponent<Enemy>();
        fireRateR = 0;
        nRateR = nRate;
    }
	
    void FixedUpdate()
    {
        distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);

        if (distanceToPlayer< shootRange && fireRateR == 0)
        {
            //This is the Rotation
            Plane playerPlane = new Plane(Vector3.right, transform.position);
            targetPoint = player.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.right);
            Instantiate(bullet, transform.position, targetRotation);
            if (nRateR <= 0)
            {
                fireRateR = fireRate;
                nRateR = nRate;
            }
            nRateR -= 1;

        }

        if(fireRateR > 0)
            fireRateR -= 1;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
