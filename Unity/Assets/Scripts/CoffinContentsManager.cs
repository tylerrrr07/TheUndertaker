using UnityEngine;
using System.Collections;

public class CoffinContentsManager : MonoBehaviour {

    public ObjectsIntersectingColliderTracker InBoundsCollider;
    public ObjectsIntersectingColliderTracker OutOfBoundsCollider;
    public int ItemsToSucceed = 5;
    public bool IsComplete = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (!IsComplete && OutOfBoundsCollider.NumberOfObjectsIntersecting == 0 && InBoundsCollider.NumberOfObjectsIntersecting == ItemsToSucceed)
        {
            Debug.Log("Great Success!");
            IsComplete = true;
        }

	}
}
