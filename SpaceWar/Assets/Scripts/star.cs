using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    SpriteRenderer spriterenderer;

    private void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {

        float randomnumber = Random.Range(0.01f, 0.1f);

        transform.localScale = new Vector3(randomnumber, randomnumber, 1);

        if (randomnumber > 0.05f)
        {
            spriterenderer.enabled = false;
        }


        InvokeRepeating("apperince_change", 0f, 2f);
    }

    void apperince_change()
    {
        spriterenderer.enabled = !spriterenderer.enabled;
    }
    
}
