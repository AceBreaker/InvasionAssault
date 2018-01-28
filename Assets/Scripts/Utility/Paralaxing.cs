using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxing : MonoBehaviour {

    public Transform[] backgrounds; //Array of all the back and foregrounds to be paralaxed
    private float[] paralaxScales;  //The proportion of the camera's movement to move the backgrounds by
    public float smoothing = 1.0f;  //How smooth the parallax is going to be. Make sure to set this above 0.

    private Transform cam;  //reference to the main camera's transform
    private Vector3 previousCamPos; //The position of the camera in the previous frame

    void Awake()
    {
        cam = Camera.main.transform;
    }

	// Use this for initialization
	void Start () {
        previousCamPos = cam.position;

        paralaxScales = new float[backgrounds.Length];

        for(int i = 0; i < backgrounds.Length; i++)
        {
            paralaxScales[i] = backgrounds[i].position.z * -1.0f;
        }
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < backgrounds.Length; i++)
        {
            //the paralax is the opposite of the camera movement because the previous frame multiplied by the scale
            float paralax = (previousCamPos.x - cam.position.x) * paralaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + paralax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //fade between current position and the tarhet position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
	}
}
