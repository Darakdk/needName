using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private Vector3 player;
    public Rigidbody myBody;
    public float movSpeed;
    public GameObject deathEffect;
    public ParticleSystem ragePart;
    public float jumpSpeed;
    public float visionRange;
    public float rageRange;
    private bool grounded;
    private float groundSkin = 0.05f;
    public float gravity;
    private bool wallNear;
    private float baseSpeed;
    private float baseJump;
    private bool rage;
    private bool alive;
    protected float distanceToPlayer;
    public int enemyId;
    public int hp = 1;
    public float jumpDelay;
    private float jumpDelayR;
    private bool doJump;
    public GameObject miniEnemy;
	public float directVisionRange;
	private bool hasDirectVision;
    [SerializeField]
    LayerMask groundMask;
	[SerializeField]
	LayerMask playerMask;
	private RaycastHit hit;
    public GameObject cagonlaputa;
    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        baseSpeed = movSpeed;
        rage = false;
        baseJump = jumpSpeed;
        alive = true;
        jumpDelayR = jumpDelay;
        doJump = false;
        player = Character.playerPosition;
		hasDirectVision = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (alive)
        {
            wallNear = Physics.Raycast(transform.position + Vector3.forward * (transform.localScale.z / 2 - groundSkin), -Vector3.forward, transform.localScale.z / 2 + groundSkin, groundMask)
                    || Physics.Raycast(transform.position - Vector3.forward * (transform.localScale.z / 2 - groundSkin), Vector3.forward, transform.localScale.z / 2 + groundSkin, groundMask);

            distanceToPlayer = Vector3.Distance(this.transform.position, player);
            player = Character.playerPosition;

			hasDirectVision = false;
			if (Physics.Raycast (transform.position, player - transform.position, out hit, directVisionRange, playerMask)) {
				if (hit.transform.position == player) {
					hasDirectVision = true;
				}
			}

            if (enemyId == 0 || enemyId == 2)
            {
				if ((distanceToPlayer < visionRange || (hasDirectVision && distanceToPlayer<directVisionRange)) && this.transform.position.z > player.z + 0.5 && !wallNear)
                {
                    myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y, -movSpeed);
                }
				else if ((distanceToPlayer < visionRange || (hasDirectVision && distanceToPlayer<directVisionRange)) && this.transform.position.z + 0.5 < player.z && !wallNear)
                {
                    myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y, movSpeed);
                }
                else
                {
                    myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y, 0);
                }
            }
            checkGround();

            if (distanceToPlayer < rageRange)
            {

                if (!rage)
                {
                    ragePart.Play();
                    ragePart.GetComponent<ParticleSystem>().enableEmission = true;
                }
                movSpeed = baseSpeed * 1.3f;
                jumpSpeed = baseJump * 1.3f;
                rage = true;
            }
            else
            {
                movSpeed = baseSpeed;
                jumpSpeed = baseJump;
                if (rage)
                    ragePart.GetComponent<ParticleSystem>().enableEmission = false;
                rage = false;
            }

            if (!grounded)
            {
                myBody.velocity -= gravity * Vector3.up;
            }
            if (enemyId == 0 || enemyId == 2)
            {
                if (this.transform.position.y < player.y-1 && grounded && distanceToPlayer < visionRange)
                    doJump = true;   
            }
            if (doJump && jumpDelayR == 0)
            {
                myBody.velocity = new Vector3(myBody.velocity.x, jumpSpeed, myBody.velocity.z);
                doJump = false;
                jumpDelayR = jumpDelay+Random.Range(0,3);
            }
            else if (doJump && jumpDelayR > 0)
                jumpDelayR -= 1;
        }
    }
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.layer == 9)
        {
            hp -= 1;
            Instantiate(deathEffect, transform.position, transform.rotation);
            if (hp <= 0)
            {
                Destroy(col.gameObject);
                this.gameObject.SetActive(false);

                if(enemyId==2)
                {
                    Instantiate(miniEnemy, transform.position - Vector3.forward * 2, transform.rotation);
                    Instantiate(miniEnemy, transform.position - Vector3.forward * 1, transform.rotation);
                    Instantiate(miniEnemy, transform.position + Vector3.forward * 2, transform.rotation);
                    Instantiate(miniEnemy, transform.position + Vector3.forward * 1, transform.rotation);
                }
            }
        }
    }
    private void checkGround()
    {
        grounded = (Physics.Raycast(transform.position + Vector3.forward * (transform.localScale.z / 2 - groundSkin),
            -Vector3.up,
            transform.localScale.y / 2 + groundSkin,
            groundMask)
            || Physics.Raycast(transform.position - Vector3.forward * (transform.localScale.z / 2 - groundSkin),
                -Vector3.up,
                transform.localScale.y / 2 + groundSkin,
                groundMask)
            || Physics.Raycast(transform.position,
                -Vector3.up,
                transform.localScale.y / 2 + groundSkin,
                groundMask));


    }
}