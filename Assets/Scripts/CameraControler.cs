using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {

    [SerializeField]
    private Transform CameraPosition;
    private Transform PlayerPosition;

    // Use this for initialization
    void Start () {
        
        PlayerPosition = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(CameraPosition.position.x,0,CameraPosition.position.z);

    }
}
