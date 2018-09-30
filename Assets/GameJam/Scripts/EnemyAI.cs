using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public GameObject player;
    public GameObject projectile;
    public float firerate = 0.75f;
    public AudioClip collisionSound;
    public AudioClip shootSound;

    private float lastShot;
    private Transform t;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        t = player.GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        lastShot = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (player != null)
        {
            if (Time.time > lastShot + firerate)
            {
                lastShot = Time.time;
                if (Vector2.Distance(t.position, transform.position) < 700)
                {
                    audioSource.PlayOneShot(shootSound);
                    Instantiate(projectile, transform.position, Quaternion.identity);
                }
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            audioSource.PlayOneShot(collisionSound);
            Destroy(gameObject);
        }
    }
}
