using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public GameObject impact_effect;
    public GameObject enenmy_laser;
    public Image enenmy_bar;

    public Transform player;


    float health = 100.0f;
    float current_health = 100.0f;

    float movement_speed = 3.0f;
    float laser_speed = 500.0f;

    float fire_rate = 0.2f;
    float fire_time = 0f;

    public gamemanager gamemanager;

    void laserfire()
    {
        GameObject new_laser = Instantiate(enenmy_laser, transform.position, Quaternion.identity);
        new_laser.GetComponent<Rigidbody2D>().AddForce(Vector2.down * laser_speed);

        Destroy(new_laser, 2.0f);
    }

    void enemymovement()
    {
        if (player)
        {


            if (transform.position.x < player.position.x)
            {
                transform.Translate(movement_speed * Time.deltaTime, 0, 0);
            }
            if (transform.position.x > player.position.x)
            {
                transform.Translate(-movement_speed * Time.deltaTime, 0, 0);
            }

            if (player.position.x - transform.position.x <= 0.2f)
            {

                if (Time.time >= fire_time)
                {
                    laserfire();
                    fire_time = Time.time + fire_rate;
                }

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player_laser"))
        {
            Destroy(collision.gameObject);
            lowerhealth(5f);
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
        enenmy_bar.fillAmount = current_health / health;

        if (current_health <= 0)
        {
            vanish();
        }
    }



    void Update()
    {
        enemymovement();
    }
}
