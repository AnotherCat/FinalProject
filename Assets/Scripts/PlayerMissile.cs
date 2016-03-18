using UnityEngine;
using System.Collections;

public class PlayerMissile : MonoBehaviour {

    public float Speed = 200;
    public float shiftSpeed = 200;
    public float bootsMultiply = 1;

    bool GameOver = false;
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.AddForce(new Vector2(0, Speed * Time.deltaTime * bootsMultiply));

#if UNITY_EDITOR
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
        Debug.Log("Booms!!!");
        GameOver = true;
    }
	
}
