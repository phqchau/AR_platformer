using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public Transform cam;
    public Vector3 cameraRelative;

    // Use this for initialization
    void Start () {
        cam = Camera.main.transform;
        Vector3 cameraRelative = cam.InverseTransformPoint(transform.position);

        if (cameraRelative.z > 0)
            print("The object is in front of the camera");
        else
            print("The object is behind the camera");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
