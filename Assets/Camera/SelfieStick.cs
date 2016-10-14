using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

public class SelfieStick : MonoBehaviour {

    private GameObject player;
    private Vector3 armRotation;

    public float panSpeed = 2f;
    

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        armRotation.y += CrossPlatformInputManager.GetAxis("RHoriz") * panSpeed ;
        armRotation.x += CrossPlatformInputManager.GetAxis("RVert") * panSpeed;
        transform.position = player.transform.position;
        transform.eulerAngles = new Vector3 (armRotation.x,armRotation.y,0);


	}
}
