using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public bool alive = false;
    public static PlayerController instance;
    public Animator animator;

    void Awake() {
        instance = this;
        alive = false;
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(alive) {
            Movement();
        } 
        
	}

    


    private void Movement() {
        if (Input.GetKey(KeyCode.D)) {
            rb.AddForce(Vector3.right * Time.deltaTime * speed, ForceMode.VelocityChange);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        } else if (Input.GetKey(KeyCode.A)) {
            rb.AddForce(Vector3.left * Time.deltaTime * speed, ForceMode.VelocityChange);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
}
