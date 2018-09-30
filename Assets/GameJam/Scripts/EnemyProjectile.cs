using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    
    private GameObject player;
    private Transform t;
    private Vector2 direction;
    private Rigidbody2D body2D;

    // Use this for initialization
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        t = player.GetComponent<Transform>();
        body2D = GetComponent<Rigidbody2D>();
        direction = new Vector2(t.position.x - transform.position.x, t.position.y - transform.position.y).normalized;
        direction *= 100f;
        print(t.position.ToString());
        body2D.velocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
