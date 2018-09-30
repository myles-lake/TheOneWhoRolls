using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject projectile;
    public AudioClip throwSound;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (projectile != null)
        {
            if (Input.GetKeyUp("space"))
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                audioSource.PlayOneShot(throwSound);    
            }
        }
	}
}
