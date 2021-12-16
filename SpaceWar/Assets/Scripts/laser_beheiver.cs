using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_beheiver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("enemy_laser"))
        {
            Destroy(this.gameObject);
        }
       
    }
}
