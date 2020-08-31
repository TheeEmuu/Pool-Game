using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : MonoBehaviour {
	public GameObject cueStick;
	Rigidbody rb;
	Rigidbody cuerb;
	
	float speed;
	bool flip;
	Vector3 cueBallPosition;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		cuerb = cueStick.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		speed = rb.velocity.magnitude;

		if (speed == 0 && flip){
			// rb.velocity = Vector3.zero;
			cueBallPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 3);
			// flip = false;
			// cueStick.transform.position = cueBallPosition;
			// cueStick.transform.Translate (0,-3,0);
			// cueStick.SetActive(true);
			
			cuerb.velocity = Vector3.zero;
			flip = false;
			cueStick.transform.position = cueBallPosition;
			cueStick.transform.rotation = Quaternion.Euler(90,0,0);
			cueStick.SetActive(true);
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.rigidbody.name == "Cue Stick")
			flip = true;
	}
}
