using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_behevier_1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player_laser"))
        {
            Destroy(this.gameObject);
        }
    }
}
