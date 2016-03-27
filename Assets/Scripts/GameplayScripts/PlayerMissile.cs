using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMissile : MonoBehaviour {

    public static int Level = 1;

    public float Speed = 50;
    public float shiftSpeed = 60;
    public float bootsMultiply = 2;

    private float boots = 1;

    public ParticleSystem explodePS;
    public ParticleSystem bootsPS;
    public Transform plane;

    bool GameOver = false;
    Rigidbody2D rb2d;

    void Start()
    {
        Speed *= PlayerMissile.Level;
        shiftSpeed *= PlayerMissile.Level;

        rb2d = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(Random.Range(Camera.main.transform.position.x - Camera.main.orthographicSize * Screen.width / Screen.height, Camera.main.transform.position.x + Camera.main.orthographicSize * Screen.width / Screen.height),transform.position.y);
    }

    void FixedUpdate()
    {
        rb2d.AddForce(new Vector2(0, Speed * Time.deltaTime * boots));

#if UNITY_ANDROID

#else
        if(Input.GetKey(KeyCode.LeftArrow) && !GameOver)
        {

            rb2d.AddForce(new Vector2(shiftSpeed * -1 * Time.deltaTime * boots, 0));
        }else if(Input.GetKey(KeyCode.RightArrow) & !GameOver)
        {
            rb2d.AddForce(new Vector2(shiftSpeed * Time.deltaTime * boots, 0));
        }
        if(Input.GetKeyDown(KeyCode.Space) && !GameOver)
        {
            boots = bootsMultiply;
            bootsPS.enableEmission = true;
        }
#endif


        if(Vector2.Distance(transform.position,plane.position) > 30)
        {
            Invoke("BeforeGameover", 1.0f);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        GameOver = true;
        ParticleSystem explode = Instantiate(explodePS, transform.position, Quaternion.identity) as ParticleSystem;
        Destroy(explode.gameObject, 3);

        c.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        c.gameObject.GetComponentInChildren<ParticleSystem>().enableEmission = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponentInChildren<ParticleSystem>().enableEmission = false;
        bootsPS.enableEmission = false;

        c.transform.GetComponentInChildren<SpriteRenderer>().enabled = false;
        transform.GetComponentInChildren<SpriteRenderer>().enabled = false;

        Invoke("Win", 3.0f);
    }
	
    void BeforeGameover()
    {
        Invoke("PauseGame", 5.0f);
        UIManager.instance.OnGameOver();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void Win()
    {
        Level += 1;
        SceneManager.LoadScene("Scene1");
    }
}
