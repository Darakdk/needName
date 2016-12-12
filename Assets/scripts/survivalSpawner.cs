using UnityEngine;
using System.Collections;

public class survivalSpawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject goal;
    public float spawnInterval = 1;
    public int enemyNumber = 10;
    public float offsetY;
    public float offsetZ;
    private float countDown;
    private Vector3 spawnPosition;


    void Start () {
        countDown = spawnInterval;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        countDown = countDown - Time.deltaTime;
        if (countDown <= 0) {
            countDown = spawnInterval;
            if (enemyNumber > 0) {
                Spawn();
                enemyNumber -= 1;
                if (enemyNumber == 0)
                {
                    Instantiate(goal, transform.position, transform.rotation);
                    Destroy(this.gameObject);
                }
            }

        }
	}
    void Spawn()
    {
        float spawnPointY = Random.Range(-offsetY, offsetY);
        float spawnPointZ = Random.Range(-offsetZ, offsetZ);
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + spawnPointY, transform.position.z + spawnPointZ);
        Instantiate(enemy, spawnPosition, transform.rotation);
    }
}
