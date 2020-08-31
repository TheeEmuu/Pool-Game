using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CueStick : MonoBehaviour {
	public GameObject cueBall;
	Vector3 cueBallTransform;
	Rigidbody rb;

	float r;
	float v;
	float deltaDistance;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		r = Input.GetAxis("Mouse X");
		v = Input.GetAxis("Mouse Y");
		cueBallTransform = new Vector3(cueBall.transform.position.x, cueBall.transform.position.y, cueBall.transform.position.z);
		deltaDistance = Vector3.Distance(cueBallTransform, transform.position);
		float lerp = 3;

		transform.RotateAround (cueBallTransform, new Vector3(0,1,0), r);


		if(v < 0)
			v = Mathf.Lerp(-lerp,0,v);
		else
			v = Mathf.Lerp(0,lerp,v);
		if((deltaDistance < 3 && v > 0) || (deltaDistance > 5 && v < 0))
			transform.Translate (0,0,0);
		else{
			transform.Translate (0, v * Time.deltaTime * 2, 0);
		}	

		if(Input.GetMouseButtonDown(0)){
			Charge(deltaDistance);
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.rigidbody.name == "Cue Ball"){
			gameObject.SetActive(false);
		}	
	}

	void Charge(float distance){
		float thrust = Mathf.Pow(distance, 2);
		rb.AddForce(transform.up * thrust, ForceMode.Impulse);
	}
}
