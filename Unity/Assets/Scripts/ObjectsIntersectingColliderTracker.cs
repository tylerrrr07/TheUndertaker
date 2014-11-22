using UnityEngine;
using System.Collections;

public class ObjectsIntersectingColliderTracker : MonoBehaviour {

    public int NumberOfArmsIntersecting = 0;
    public int NumberOfLegsIntersecting = 0;
    public int NumberOfHeadsIntersecting = 0;
    public int NumberOfTorsosIntersecting = 0;

    public int NumberOfObjectsIntersecting
    {
        get { return NumberOfArmsIntersecting + NumberOfLegsIntersecting + NumberOfHeadsIntersecting + NumberOfTorsosIntersecting;  }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        BodyPartIdentifier bodyPart = other.gameObject.GetComponent<BodyPartIdentifier>();

        if (bodyPart != null)
        {
            switch(bodyPart.BodyPart)
            {
                case BodyParts.Arm:
                    NumberOfArmsIntersecting++;
                    break;
                case BodyParts.Leg:
                    NumberOfLegsIntersecting++;
                    break;
                case BodyParts.Head:
                    NumberOfHeadsIntersecting++;
                    break;
                case BodyParts.Torso:
                    NumberOfTorsosIntersecting++;
                    break;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        BodyPartIdentifier bodyPart = other.gameObject.GetComponent<BodyPartIdentifier>();

        if (bodyPart != null)
        {
            switch (bodyPart.BodyPart)
            {
                case BodyParts.Arm:
                    NumberOfArmsIntersecting--;
                    break;
                case BodyParts.Leg:
                    NumberOfLegsIntersecting--;
                    break;
                case BodyParts.Head:
                    NumberOfHeadsIntersecting--;
                    break;
                case BodyParts.Torso:
                    NumberOfTorsosIntersecting--;
                    break;
            }
        }
    }
}
