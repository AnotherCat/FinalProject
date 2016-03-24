using UnityEngine;
using System.Collections;

public class PlayerMissile : MonoBehaviour {

    public float Speed = 200;
    public float shiftSpeed = 200;
    public float bootsMultiply = 1;

    public ParticleSystem explodePS;

    bool GameOver = false;
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.AddForce(new Vector2(0, Speed * Time.deltaTime * bootsMultiply));

#if UNITY_ANDROID

#else
        if(Input.GetKey(KeyCode.LeftArrow) && !GameOver)
        {
            rb2d.AddForce(new Vector2(shiftSpeed * -1 * Time.deltaTime * bootsMultiply,0));
        }else if(Input.GetKey(KeyCode.RightArrow) & !GameOver)
        {
            rb2d.AddForce(new Vector2(shiftSpeed * Time.deltaTime * bootsMultiply,0));
        }
        if(Input.GetKeyDown(KeyCode.Space) && !GameOver)
        {
            bootsMultiply = 2;
        }
#endif
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        GameOver = true;
        ParticleSystem explode = Instantiate(explodePS, transform.position, Quaternion.identity) as ParticleSystem;


        //c.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        c.gameObject.GetComponentInChildren<ParticleSystem>().emissionRate = 0;
        //GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponentInChildren<ParticleSystem>().emissionRate = 0;


        Invoke("BeforeGameover", 3.0f);
    }
	
    void BeforeGameover()
    {
        Time.timeScale = 0;
    }
}
