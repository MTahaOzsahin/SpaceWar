using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public GameObject impact_effect;
    public GameObject player_laser;
    public Image player_bar;

    float health = 100.0f;
    float current_health = 100.0f;

    float movement_speed = 5.0f;
    float laser_speed = 500.0f;

    public gamemanager gamemanager;

    void playermovement()
    {
        float button_detection = Input.GetAxis("Horizontal");

        transform.Translate(button_detection * Time.deltaTime*movement_speed, 0, 0);
    }

    void laserfire()
    {
        GameObject new_laser_left = Instantiate(player_laser, new Vector3 (transform.position.x -.45f, transform.position.y, 
            transform.position.z), Quaternion.identity);
        new_laser_left.GetComponent<Rigidbody2D>().AddForce(Vector2.up*laser_speed);

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
            lowerhealth(10.0f);
        }
    }

    void vanish()
    {
        Destroy(gameObject);
        GameObject new_impact = Instantiate(impact_effect, transform.position, Quaternion.identity);
        Destroy(new_impact, 1f);

        gamemanager.show_panel();

    }

    void lowerhealth(float value)
    {
        current_health -= value;
        player_bar.fillAmount = current_health / health;

        if (current_health <= 0)
        {
            vanish();
        }
    }
    // Update is called once per frame
    void Update()
    {
        playermovement();
        combat();
    }
}
