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
    private Vector2 targetPosition;
    public GrabberController PlayerGrabberrController;
    public float ReachDistance = 5;
    public float ReachLength = 3.0f;

    public float GrabOffsetY = 1.0f;
	// Use this for initialization
	void Start () {
        Physics.IgnoreLayerCollision(8, 9, true);
        ReachDistance = PlayerGrabberrController.Reach;
        centerOfScreen = new Vector2(Screen.width / 2, (float)((Screen.height / 2)));
        targetPosition = new Vector2(Screen.width / 2, (float)((Screen.height / 2) + (Screen.height * .2)));
		tr = transform;
		rb = rigidbody;

		// set floor black
		//GameObject.Find("Floor").renderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {

		if ( !collision ){
			//tr.Rotate(90.0f*Time.deltaTime, 0.0f, 45.0f*Time.deltaTime);
		}

		if ( Input.GetMouseButton(0) && !isGrabbed){
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(centerOfScreen);
            if (Physics.Raycast(ray, out hitInfo, ReachDistance))
            {
                foreach (var GrabbableObject in GrabbableObjects)
                {
                    if (hitInfo.transform == GrabbableObject.transform)
                    {                        
                        isGrabbed = true;
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
        else
        {
            isGrabbed = false;
            rb.useGravity = true;	
        }
	
	}

    private void HandleGrabbed()
    {
        Debug.DrawRay(PlayerCamera.transform.position, PlayerCamera.transform.forward);
        Vector3 temp = PlayerCamera.transform.position + PlayerCamera.transform.forward * ReachLength;
        temp.y = temp.y + GrabOffsetY;
        Debug.Log(PlayerCamera.transform.position.ToString());
        
        Debug.DrawLine(new Vector3(PlayerCamera.transform.position.x, targetPosition.y, PlayerCamera.transform.position.z), temp);

        tr.position = temp;
        tr.rotation = new Quaternion(0.0f, PlayerCamera.transform.rotation.y, 0.0f, PlayerCamera.transform.rotation.w);
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
    }

	void OnCollisionEnter() {
		collision = true;
	}

	void OnCollisionExit() {
		collision = false;	
	}




};