using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    private BoxCollider2D coll;
    public GameObject player;
    float player_coord, enemy_coord;
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        coll = GetComponent<BoxCollider2D>();
        var watch = new Stopwatch();
        watch.Start();

    }

    // Update is called once per frame
    void Update()
    {
        player_coord = player.transform.position.x;
        enemy_coord = this.transform.position.x;
        if (player_coord <= enemy_coord)
        {
            direction = -1;
            GetComponent<SpriteRenderer>().flipX = false;

        }
        else if (player_coord >= enemy_coord)
        {
            direction = +1;
            GetComponent<SpriteRenderer>().flipX = true;

        }
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

    }

}
