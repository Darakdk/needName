using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{

    public float rotationSpeed;
    public Rigidbody myBody;
    public float movSpeed;
    public float gravity;
    public float jumpSpeed;
    public float recoil;
    public float maxSpeed;
    public GameObject playerRenderer;
	public GameObject cannonRenderer;
	public GameObject playerDeathEffect;
	public GameObject playerDeathScreen;
    public GameObject playerWinScreen;
    private bool keyRigth;
    private bool keyLeft;
    private bool grounded;
    private bool jumpPressed;
    private Vector3 targetPoint;
	public static bool isAlive = true;
    private int delayWorking;
    private bool dobleJump;
    public int fallDelay;
    public static Vector3 playerPosition;
    public static int playerScore = 0;
    public static Vector3 position;
    public Vector3 positionEdit;

    public static int myChekPoint=0;
    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        delayWorking = 0;
        dobleJump = false;
        playerPosition = transform.position;
        position = positionEdit;
    }

    void FixedUpdate()
    {

        //This is the Rotation
        if (isAlive)
        {
            Plane playerPlane = new Plane(Vector3.right, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;
            playerPosition = transform.position;
            if (playerPlane.Raycast(ray, out hitdist))
            {
                targetPoint = ray.GetPoint(hitdist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.right);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }

        checkGround();
		if (isAlive) {
            if (delayWorking > 0 && jumpPressed)
            {
                //Aado velocidad
                delayWorking = -15;
                myBody.velocity = new Vector3(myBody.velocity.x, jumpSpeed, myBody.velocity.z);
                //jumpParticle.Play();
            }
            else if (!grounded && jumpPressed && !dobleJump && delayWorking == 0)
            {
                dobleJump = true;
                myBody.velocity = new Vector3(myBody.velocity.x, jumpSpeed * 1.15f, myBody.velocity.z);
                //jumpParticle.Play();
            }

            if (keyRigth && !keyLeft) {
				myBody.velocity = new Vector3 (myBody.velocity.x, myBody.velocity.y, movSpeed);
			} else if (!keyRigth && keyLeft) {
				myBody.velocity = new Vector3 (myBody.velocity.x, myBody.velocity.y, -movSpeed);
			} else {
				myBody.velocity = new Vector3 (myBody.velocity.x, myBody.velocity.y, 0);
			}


            if (!grounded)
            {

                myBody.velocity -= gravity * Vector3.up;
                if (delayWorking > 0)
                    delayWorking -= 1;
                else if (delayWorking < 0)
                    delayWorking += 1;
                else
                    delayWorking = 0;
            }
        }
    }

    void Update()
	{
		keyRigth = Input.GetKey (KeyCode.D);
		keyLeft = Input.GetKey (KeyCode.A);
		jumpPressed = Input.GetKey (KeyCode.Space) || Input.GetKey(KeyCode.W);

		if (isAlive) {
			myBody.transform.position = new Vector3 (0, myBody.transform.position.y, myBody.transform.position.z);
		}
	}

    float groundSkin = 0.05f;
    [SerializeField]
    LayerMask groundMask;

    private void checkGround()
    {
        grounded = (Physics.Raycast(transform.position + Vector3.right * (transform.localScale.x / 2 - groundSkin),
                                    -Vector3.up,
                                    transform.localScale.y / 2 + groundSkin,
                                    groundMask)
                                    || Physics.Raycast(transform.position - Vector3.right * (transform.localScale.x / 2 - groundSkin),
                                    -Vector3.up,
                                    transform.localScale.y / 2 + groundSkin,
                                    groundMask)
                                    || Physics.Raycast(transform.position,
                                    -Vector3.up,
                                    transform.localScale.y / 2 + groundSkin,
                                    groundMask));

        if (grounded)
        {
            delayWorking = fallDelay;
            dobleJump = false;
        }


    }
    void OnCollisionEnter(Collision col) //Muerte al colisionar con un enemigo
    {
        if (col.gameObject.layer == 10 || col.gameObject.layer == LayerMask.NameToLayer("enemyBullet"))
        {
            isAlive = false;
            playerRenderer.SetActive(false);
            cannonRenderer.SetActive(false);
            Instantiate(playerDeathEffect, transform.position, transform.rotation);
            playerDeathScreen.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 13 || col.gameObject.layer == LayerMask.NameToLayer("goal")) // Colisión con el orbe dorado
        {
            playerWinScreen.SetActive(true);
            myBody.velocity = new Vector3(0, 0, 0);
            isAlive = false;
        }
    }


}