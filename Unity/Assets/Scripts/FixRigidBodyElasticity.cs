using UnityEngine;
using System.Collections;

public class FixRigidBodyElasticity : MonoBehaviour {

    private Vector3 startPosition;
	// Use this for initialization
	void Start () {
        startPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.localPosition = startPosition;
	}
}
