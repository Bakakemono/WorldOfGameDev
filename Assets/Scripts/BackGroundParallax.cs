using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundParallax : MonoBehaviour {

    
    private Transform cameraTransform;
    [SerializeField]
    private float parallaxSpeed;
    private float lastCameraX;



	// Use this for initialization
	void Start () {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        float DeltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (DeltaX * parallaxSpeed);
        lastCameraX = cameraTransform.position.x;

    }
}
