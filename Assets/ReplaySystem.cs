using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class ReplaySystem : MonoBehaviour {

    private GameManager gameManager;

    private const int bufferFrames = 500;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private int frameReplayStarted;

    private Rigidbody rigidBody;


	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();


	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameManager.recording)
        {
            Record();

        } else { PlayBack(); }

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            frameReplayStarted = Time.frameCount % bufferFrames;
        }

        if (CrossPlatformInputManager.GetButtonUp("Fire1"))
        {
            transform.position = keyFrames[frameReplayStarted].position;
            transform.rotation = keyFrames[frameReplayStarted].rotation;
        }


    }

    void PlayBack()
    {
        rigidBody.isKinematic = true;

        int frame = Time.frameCount % bufferFrames;
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;

    }

    private void Record()
    {
        rigidBody.isKinematic = false;

        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;

        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

/// <summary>
/// A structure for storing time, rotation and position
/// </summary>
public struct MyKeyFrame  {

    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame (float time, Vector3 pos, Quaternion rot)
    {
        frameTime = time;
        position = pos;
        rotation = rot;
    }


}
