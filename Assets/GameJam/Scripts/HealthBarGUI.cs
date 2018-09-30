using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarGUI : MonoBehaviour {

    public GameObject target;
    public float xOff = 0f;
    public float yOff = 0f;

    private Transform t;

	// Use this for initialization
	void Start () {
        t = target.transform.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null)
        {
            transform.position = new Vector3(t.position.x + xOff, t.position.y + yOff, transform.position.z);
        }
	}
}
