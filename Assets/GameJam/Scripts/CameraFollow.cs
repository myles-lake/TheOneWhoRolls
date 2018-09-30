using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public float scale = 2f;
    public float x = 0f;
    public float y = -590f;

    private const float START = 1075f;
    private const float END = 9660f;
    private const float BOTTOM = -475f;
    private Transform t;

    private void Awake()
    {
        var cam = GetComponent<Camera>();
        cam.orthographicSize = (Screen.height / 2f) / scale;
    }

    // Use this for initialization
    void Start () {
        t = target.transform;
        x = START;
        y = BOTTOM;
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {

            if (t.position.x > START && t.position.x < END)
            {
                x = t.position.x;
            }
            if (t.position.y > BOTTOM) {
                y = t.position.y;
            }

            transform.position = new Vector3(x, y, transform.position.z);
        }
	}
}
