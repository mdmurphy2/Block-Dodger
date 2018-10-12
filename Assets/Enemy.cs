using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public PlayerController player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {

        if(!PlayerController.instance.alive) {
            //Do nothing just let it play out
        }
        else if(collision.gameObject.name == "Player") {
            PlayerController.instance.alive = false;
        }
        else if (collision.gameObject.name == "Ground") {
            Invoke("selfDestruct", .1f);
            ScoreManager.score++;
        }
    }

    public void selfDestruct() {
        Destroy(this.gameObject);
    }
}
