using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rotation : MonoBehaviour {

    public Camera PlayerCamera;
    private bool isGrabbed = false;
	private Transform tr;
	private Rigidbody rb;
	private bool collision = false;
    private Vector2 centerOfScreen;
    public List<GameObject> GrabbableObjects;
    public List<GameObject> ColorableObjects;
    private Vector2 targetPosition;
    public GrabberController PlayerGrabberrController;
    public float ReachDistance = 5;
    public float ReachLength = 3.0f;

    public float GrabOffsetY = 1.0f;
    private float grabDistance = 0f;

    public Color DefaultColor = Color.yellow;
    public Color GrabbedColor = Color.green;
	// Use this for initialization
	void Start () {
        Physics.IgnoreLayerCollision(8, 9, true);
        ReachDistance = PlayerGrabberrController.Reach;
        centerOfScreen = new Vector2(Screen.width / 2, (float)((Screen.height / 2)));
        targetPosition = new Vector2(Screen.width / 2, (float)((Screen.height / 2) + (Screen.height * .2)));
		tr = transform;
		rb = rigidbody;
        TintGrabbables(DefaultColor);
		// set floor black
		//GameObject.Find("Floor").renderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {

		if ( !collision ){
			//tr.Rotate(90.0f*Time.deltaTime, 0.0f, 45.0f*Time.deltaTime);
		}

        
            if (Input.GetMouseButton(0) && !isGrabbed && !PlayerGrabberrController.IsGrabbing)
            {
                RaycastHit hitInfo;
                Ray ray = Camera.main.ScreenPointToRay(centerOfScreen);
                Debug.DrawRay(ray.origin, ray.direction * ReachDistance);
                if (Physics.Raycast(ray, out hitInfo, ReachDistance))
                {
                    Debug.Log("Raycast Hit - " + hitInfo.collider.transform.name);
                    foreach (var GrabbableObject in GrabbableObjects)
                    {
                        Debug.Log("Grabbable - " + GrabbableObject.transform.name);
                        if (hitInfo.collider.transform.name == GrabbableObject.transform.name)
                        {
                            Debug.Log("Grabbed!");
                            grabDistance = hitInfo.distance;
                            isGrabbed = true;
                            PlayerGrabberrController.IsGrabbing = true;
                            TintGrabbables(GrabbedColor);
                            rigidbody.isKinematic = true;
                            break;
                        }
                    }
                }
                //
                //			Debug.Log (temp);

            }
            else if (isGrabbed && Input.GetMouseButton(0))
            {
                HandleGrabbed();
            }
            else if (isGrabbed)
            {                
                TintGrabbables(DefaultColor);
                isGrabbed = false;
                //rb.useGravity = true;
                rigidbody.isKinematic = false;
                PlayerGrabberrController.IsGrabbing = false;
            }
        
	}

    void FixedUpdate()
    {
        if (isGrabbed && Input.GetMouseButton(0))
        {
            HandleGrabbed();
        }
    }

    private void TintGrabbables(Color color)
    {
        foreach(var objectToTint in ColorableObjects)
        {
            objectToTint.GetComponent<MeshRenderer>().material.color = color;
        }
    }

    private void HandleGrabbed()
    {
        
        Vector3 temp = PlayerCamera.transform.position + PlayerCamera.transform.forward * grabDistance;
        
        
        
        Debug.DrawLine(new Vector3(PlayerCamera.transform.position.x, targetPosition.y, PlayerCamera.transform.position.z), temp);

        //tr.Translate(Vector3.Normalize(tr.position + temp));
        //temp.y = targetPosition.y;
        tr.position = temp;
        //tr.rotation = new Quaternion(0.0f, PlayerCamera.transform.rotation.y, 0.0f, PlayerCamera.transform.rotation.w);
        //rb.useGravity = false;
        //rb.velocity = Vector3.zero;
    }

	void OnCollisionEnter() {
		collision = true;
	}

	void OnCollisionExit() {
		collision = false;	
	}




};