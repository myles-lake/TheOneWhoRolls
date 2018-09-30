using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float health = 3f;
    public GameObject healthBar;
    private SceneManager sceneManager;

    public AudioClip hit;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        sceneManager = GetComponent<SceneManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
        {
            var x = health * (health / 10);
            healthBar.transform.localScale = new Vector3(x, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
        if (health == 0)
        {
            sceneManager.ChangeScene(2);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
            audioSource.PlayOneShot(hit);
            Destroy(collision.gameObject);
        }
    }
}
