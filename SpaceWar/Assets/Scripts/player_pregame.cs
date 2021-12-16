using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_pregame : MonoBehaviour
{
    public GameObject impact_effect;
    public GameObject player_laser;
    public gamemanager gamemanager;
    public Rigidbody2D rigidbody2D;



    float movement_speed = 5.0f;
    float laser_speed = 500.0f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }



    void playermovement()
    {
        float button_detection = Input.GetAxis("Horizontal");

        transform.Translate(button_detection * Time.deltaTime * movement_speed, 0, 0);
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(1.5f * Time.deltaTime * movement_speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(-1.5f * Time.deltaTime * movement_speed, 0, 0);
        }
    }

    void laserfire()
    {
        GameObject new_laser_left = Instantiate(player_laser, new Vector3(transform.position.x - .45f, transform.position.y,
            transform.position.z), Quaternion.identity);
        new_laser_left.GetComponent<Rigidbody2D>().AddForce(Vector2.up * laser_speed);

        Destroy(new_laser_left, 2.0f);

        GameObject new_laser_right = Instantiate(player_laser, new Vector3(transform.position.x + .45f, transform.position.y,
            transform.position.z), Quaternion.identity);
        new_laser_right.GetComponent<Rigidbody2D>().AddForce(Vector2.up * laser_speed);

        Destroy(new_laser_right, 2.0f);
    }
    void combat()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            laserfire();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy_laser"))
        {
            Destroy(collision.gameObject);
            vanish();
        }
    }

    void vanish()
    {
        Destroy(gameObject);
        GameObject new_impact = Instantiate(impact_effect, transform.position, Quaternion.identity);
        Destroy(new_impact, 1f);

        gamemanager.show_panel();

    }
    private void Update()
    {
        playermovement();
        combat();
    }
}
