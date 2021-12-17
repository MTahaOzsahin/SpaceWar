using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemy_pregame : MonoBehaviour
{
    [Header("Companent")]
    public GameObject impact_effect;
    public GameObject enemy_laser;
    public GameObject enemy_small;
    public gamemanager gamemanager;
   

    public Rigidbody2D enemysmallrigibody2d;
    public Collider2D enemysmallcollider2d;
    public SpriteRenderer enemysmallrenderer;

    

    [Header("Speed")]
    float movement_speed = 2.0f;
    float laser_speed = 200f;

    [Header("Fire Rate")]
    float fire_rate = 0.5f;
    float fire_time = 0f;


    public int enemyspawnercount;
    

    
      private void Awake()
      {
          enemysmallrigibody2d = GetComponent<Rigidbody2D>();
          enemysmallcollider2d = GetComponent<Collider2D>();
          enemysmallrenderer = GetComponent<SpriteRenderer>();
      }
    
    private void Start()
    {
        enemyspawner();
    }
    void enemy_smallmovement()
    {
        transform.Translate(Vector2.down *Time.deltaTime* movement_speed);
    }

    void enemyspawner()
    {
        for (int i = 0; i < enemyspawnercount; i++)
        {
            enemy_small = GameObject.Instantiate(enemy_small,
              new Vector3(transform.position.x + i, transform.position.y,
          transform.position.z), Quaternion.identity);

        }
        for (int i = 0; i < enemyspawnercount; i++)
        {
            enemy_small = GameObject.Instantiate(enemy_small,
              new Vector3(transform.position.x - i, transform.position.y,
          transform.position.z), Quaternion.identity);

        }
    }
    void laserfire()
    {

        if (transform.position.y <= 4 && transform.position.y >=3.8)
        {
            if (Time.time >= fire_time)
            {
                GameObject new_laser_left = Instantiate(enemy_laser, new Vector3(transform.position.x - .45f, transform.position.y,
           transform.position.z), Quaternion.identity);
                new_laser_left.GetComponent<Rigidbody2D>().AddForce(Vector2.down * laser_speed);

                Destroy(new_laser_left, 2.0f);

                GameObject new_laser_right = Instantiate(enemy_laser, new Vector3(transform.position.x + .45f, transform.position.y,
                    transform.position.z), Quaternion.identity);
                new_laser_right.GetComponent<Rigidbody2D>().AddForce(Vector2.down * laser_speed);

                Destroy(new_laser_right, 2.0f);
                fire_time = Time.time + fire_rate;
            }    
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player_laser"))
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        enemy_smallmovement();
        laserfire(); 
    }
}
