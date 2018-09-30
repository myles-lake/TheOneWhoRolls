using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 225f;
    public Vector2 maxVelocity = new Vector2(60, 120);
    public float jumpSpeed = 300f;
    public bool standing;
    public float standingThreshold = 4f;
    public float airSpeedMultiplier = .3f;
    public bool jumping;
    public bool isFlipped = false;
    public AudioClip jumpSound;

    private SceneManager sceneManager;
    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    private PlayerController controller;
    private Animator animator;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        sceneManager = GetComponent<SceneManager>();
        audioSource = GetComponent<AudioSource>();

        Time.timeScale = 3f;
    }
	
	// Update is called once per frame
	void Update () {
        var absVelX = Mathf.Abs(body2D.velocity.x);
        var absVelY = Mathf.Abs(body2D.velocity.y);

        if (absVelY <= standingThreshold)
        {
            standing = true;
        }
        else
        {
            standing = false;
        }


        var force = new Vector2(0, 0);

        if (controller.moving.x != 0)
        {
            if (absVelX < maxVelocity.x)
            {
                var newSpeed = speed * controller.moving.x;
                force.x = standing ? newSpeed : (newSpeed * airSpeedMultiplier);
                renderer2D.flipX = force.x < 0;

                // dis is broken
                if (transform.rotation.eulerAngles.x < 0)
                    isFlipped = true;
                else
                    isFlipped = false;
            }
            animator.SetInteger("AnimState", 1);
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }


        if (controller.moving.y > 0)
        {
            if (absVelY < maxVelocity.y && !jumping)
            {
                body2D.velocity = new Vector2(body2D.velocity.x, jumpSpeed * controller.moving.y);
                audioSource.PlayOneShot(jumpSound);
            }
            jumping = true;
        }

        if (transform.position.y < -1000)
        {

            sceneManager.ChangeScene(2);

            Destroy(gameObject);
        }

        if (transform.position.x > 9720f)
        {
            sceneManager.ChangeScene(3);
        }

        if (jumping)
        {
            animator.SetInteger("AnimState", 2);
        }

        body2D.AddForce(force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            jumping = false;
        }
    }
}

