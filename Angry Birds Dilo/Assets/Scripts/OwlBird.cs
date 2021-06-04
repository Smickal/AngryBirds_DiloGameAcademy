using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBird : Birds
{

    [SerializeField]
    public GameObject owlBird;
    public float powerEX = 10.0f;
    public float radiusEX = 2.0f;
    public float upForce = 1.0f;

    public bool _isExploded = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() == null) return;
        if ((collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy") && _isExploded == false)
        {
            Debug.Log("BOOM!");
            _isExploded = true;
            Detonate();
            Destroy(owlBird);
        }
    }

    void Detonate()
    {
        Vector2 birdPosition = owlBird.transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(birdPosition, radiusEX);

        foreach(Collider2D hit in colliders)
        {
            Vector2 direction = hit.transform.position - transform.position;
            Debug.Log(hit);
            if(hit != null)
            {
                hit.GetComponent<Rigidbody2D>().AddForce(direction * powerEX,ForceMode2D.Impulse);
            }
            
        }
    }

    public override void OnTap()
    {
        //kosong
    }

}
