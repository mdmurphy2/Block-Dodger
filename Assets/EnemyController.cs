using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float spawnRate = 3f;
    public float minX = -6;
    public float maxX = 6;
    private float timer;
    private float currentX;
    private bool spawnDecreased;
    private int score;


    public GameObject enemy;
	// Use this for initialization
	void Start () {
        timer = spawnRate;
	}
	
	// Update is called once per frame
	void Update () {
        

        if(PlayerController.instance.alive) {
            if (score != ScoreManager.score) {
                score = ScoreManager.score;
                spawnDecreased = false;
            }

            if (ScoreManager.score % 5 == 0 && ScoreManager.score != 0 && !spawnDecreased && spawnRate >= .4f) {
                spawnDecreased = true;
                spawnRate -= .1f;
            }

            timer -= Time.deltaTime;
            if (timer < 0 && PlayerController.instance.alive) {
                timer = spawnRate;
                currentX = Random.Range(minX, maxX);
                Object.Instantiate(enemy, new Vector3(currentX, 7f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            }
        }

        
	}
}
