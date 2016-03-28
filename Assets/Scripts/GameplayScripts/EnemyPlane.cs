using UnityEngine;
using System.Collections;

public class EnemyPlane : MonoBehaviour {

    public float Speed = 50;
    public float shiftSpeed = 65;

    public float maxRange = 2;

    public Transform missile;

    Rigidbody2D rb2d;

    void Start()
    {
        Speed *= PlayerMissile.Level;
        shiftSpeed *= PlayerMissile.Level;
        maxRange *= PlayerMissile.Level;

        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.AddForce(new Vector2(0, Speed * Time.deltaTime));

        if (transform.position.x <= missile.transform.position.x && Vector2.Distance(transform.position, missile.position) < maxRange)
        {
            rb2d.AddForce(new Vector2(shiftSpeed * -1 * Time.deltaTime, 0));
        }
        else if(transform.position.x > missile.transform.position.x && Vector2.Distance(transform.position, missile.position) < maxRange)
        {
            rb2d.AddForce(new Vector2(shiftSpeed * Time.deltaTime, 0));
        }
    }
    
}
