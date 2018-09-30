using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float range;

    private GameObject player;
    private SpriteRenderer renderer;
    private bool isFlipped;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        renderer = player.GetComponent<SpriteRenderer>();
        if (renderer.flipX)
            speed *= -1;
        range = Time.time + 7f;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        transform.position = new Vector3(pos.x + speed, pos.y, pos.z);
        if (Time.time > range)
            Destroy(gameObject);
    }
}
