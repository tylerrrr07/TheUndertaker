using UnityEngine;
using System.Collections;

public class ObjectsIntersectingColliderTracker : MonoBehaviour {

    public int NumberOfObjectsIntersecting = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        NumberOfObjectsIntersecting += 1;
    }

    void OnTriggerExit(Collider other)
    {
        NumberOfObjectsIntersecting -= 1;
    }
}
