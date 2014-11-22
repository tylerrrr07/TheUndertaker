using UnityEngine;
using System.Collections;

public class CoffinContentsManager : MonoBehaviour {

    public ObjectsIntersectingColliderTracker InBoundsCollider;
    public ObjectsIntersectingColliderTracker OutOfBoundsCollider;

    public int TargetNumberOfArms = 2;
    public int TargetNumberOfLegs = 2;
    public int TargetNumberOfTorsos = 1;
    public int TargetNumberOfHeads = 1;
    
    public bool IsComplete = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (!IsComplete && OutOfBoundsCollider.NumberOfObjectsIntersecting == 0 && 
            InBoundsCollider.NumberOfArmsIntersecting == TargetNumberOfArms &&
            InBoundsCollider.NumberOfLegsIntersecting == TargetNumberOfLegs &&
            InBoundsCollider.NumberOfTorsosIntersecting == TargetNumberOfTorsos &&
            InBoundsCollider.NumberOfHeadsIntersecting == TargetNumberOfHeads)
        {
            Debug.Log("Great Success!");
            IsComplete = true;
        }
	}
}
