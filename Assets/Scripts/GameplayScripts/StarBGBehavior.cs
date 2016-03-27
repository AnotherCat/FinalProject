using UnityEngine;
using System.Collections;

public class StarBGBehavior : MonoBehaviour {
    
    void Update()
    {
        if(Vector2.Distance(transform.position,Camera.main.transform.position) > Camera.main.transform.position.x + Camera.main.orthographicSize + 3)
        {
            Destroy(gameObject);
        }
    }
}
