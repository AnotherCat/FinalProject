using UnityEngine;
using System.Collections;

public class EnemyPlane : MonoBehaviour {

    public float Speed = 195;
    public float shiftSpeed = 200;

    public Transform missile;

    Rigidbody2D rb2d;

    void Start()
    {
        transform.position = new Vector2(Random.Range(missile.transform.position.x-5f, missile.transform.position.x+5f),0);
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.AddForce(new Vector2(0, Speed * Time.deltaTime));

        if (transform.position.x <= missile.transform.position.x && Vector2.Distance(transform.position, missile.position) < 8)
        {
            rb2d.AddForce(new Vector2(shiftSpeed * -1 * Time.deltaTime, 0));
        }
        else if(transform.position.x > missile.transform.position.x && Vector2.Distance(transform.position, missile.position) < 8)
        {
            rb2d.AddForce(new Vector2(shiftSpeed * Time.deltaTime, 0));
        }
    }
    
}
