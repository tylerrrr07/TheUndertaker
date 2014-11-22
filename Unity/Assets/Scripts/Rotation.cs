using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	private Transform tr;
	private Rigidbody rb;
	private bool collision = false;


	// Use this for initialization
	void Start () {

		tr = transform;
		rb = rigidbody;

		// set floor black
		GameObject.Find("Floor").renderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {

		if ( !collision ){
			//tr.Rotate(90.0f*Time.deltaTime, 0.0f, 45.0f*Time.deltaTime);
		}


		if ( Input.GetMouseButton(0) ){

			Vector3 temp = Input.mousePosition;
			temp.z = 10.0f;
			tr.position = Camera.main.ScreenToWorldPoint(temp);
			rb.useGravity = false;
			rb.velocity = Vector3.zero;
//
//			Debug.Log (temp);

		} else {


//			Vector3 temp = new Vector3(-0.45f, 10f, -1.1f); 
//			tr.position = temp;
//			rb.useGravity = false;
//			rb.velocity = Vector3.zero;
		

			rb.useGravity = true;	

		}
	
	}

	void OnCollisionEnter() {
		collision = true;
	}

	void OnCollisionExit() {
		collision = false;	
	}




}