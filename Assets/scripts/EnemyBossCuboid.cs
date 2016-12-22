using UnityEngine;
using System.Collections;

public class EnemyBossCuboid : MonoBehaviour {

    private Vector3 player;
    public Rigidbody myBody;
    public float movSpeed;
    public GameObject deathEffect;
    public ParticleSystem ragePart;
	public ParticleSystem atackOnePart;
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
    public int hp = 1;
    public float jumpDelay;
    private float jumpDelayR;
    private bool doJump;
	public float directVisionRange;
	private bool hasDirectVision;
    [SerializeField]
    LayerMask groundMask;
	[SerializeField]
	LayerMask playerMask;
	private RaycastHit hit;
	public static bool bossActive;
	public float atackOneRate;
	private float atackOneTimer;
    public GameObject atackOne;
    public float phase2Timer;
    public float phase2Dur;
    private float phase2TimerR;
    private float phase2DurR;
    private bool phase2;
    public GameObject BossDoor;
    public static int score;
    private int theHp;
    private Vector3 initPos;

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
		atackOneTimer = atackOneRate + Random.Range(0,100);
		bossActive = false;
        phase2 = false;
        phase2TimerR = phase2Timer;
        phase2DurR = phase2Dur;
        theHp = hp;
        initPos = myBody.transform.position;
}

    // Update is called once per frame
    void FixedUpdate()
    {
		if (alive && bossActive)
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

            if (this.transform.position.y < player.y-1 && grounded && distanceToPlayer < visionRange)
                doJump = true;   
			
            if (doJump && jumpDelayR == 0)
            {
                myBody.velocity = new Vector3(myBody.velocity.x, jumpSpeed, myBody.velocity.z);
                doJump = false;
                jumpDelayR = jumpDelay+Random.Range(0,3);
            }
            else if (doJump && jumpDelayR > 0)
                jumpDelayR -= 1;

            //BossHabilities
            //One
            if (!phase2)
            {
                atackOneTimer--;

                if (atackOneTimer <= 0) {

                    Instantiate(atackOnePart, player, transform.rotation);
                    Instantiate(atackOne, new Vector3(player.x, player.y + 40, player.z), transform.rotation);

                    atackOneTimer = atackOneRate + Random.Range(-100, 100);

                }
            }

            //Pahse2
            if (!phase2)
                phase2TimerR--;
            else
            {
                phase2DurR--;
                this.transform.position = new Vector3(this.transform.position.x, 14.8f, 226.8f);
            }

            if (phase2TimerR<=0)
            {
                phase2 = true;
                phase2TimerR = phase2Timer;
            }

            if(phase2DurR<=0)
            {
                phase2 = false;
                phase2DurR = phase2Dur;
            }


        }
    }


    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.layer == 9)
        {
            hp -= 1;
            if(phase2)
                hp -= 3;
            Instantiate(deathEffect, transform.position, transform.rotation);
            if (hp <= 0)
            {
                Destroy(col.gameObject);
                BossDoor.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }

    private void Update()
    {
        bool pressRestart = Input.GetKey(KeyCode.R);
        if (pressRestart)
        {
            bossActive = false;
            hp = theHp;
            myBody.transform.position = initPos;
            phase2 = false;
            phase2TimerR = phase2Timer;
            phase2DurR = phase2Dur;
            hasDirectVision = false;
            atackOneTimer = atackOneRate + Random.Range(0, 100);
            jumpDelayR = jumpDelay;
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