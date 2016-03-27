using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour {

    public Camera cam;
    public List<Transform> bgs = new List<Transform>();

    private Vector2 lastPos;
    private float thresholdPos = 5f;

    private float lastSize;
    private float thresholdSize = 0.5f;

    void Start()
    {
        
        for(int i = 0;i < 10; i++)
        {
            Instantiate(bgs[Random.Range(0, bgs.Count)], 
                new Vector2(
                    Random.Range(cam.transform.position.x - cam.orthographicSize * Screen.width / Screen.height, cam.transform.position.x + cam.orthographicSize * Screen.width / Screen.height)
                , Random.Range(cam.transform.position.y - cam.orthographicSize, cam.transform.position.y + cam.orthographicSize))
                , Quaternion.identity);
        }
    }

    void Update()
    {

        if (Vector2.Distance(cam.transform.position,lastPos) > thresholdPos)
        {
            
            for (int i = 0; i < 10; i++)
            {
                Instantiate(bgs[Random.Range(0, bgs.Count)],
                    new Vector2(
                        Random.Range(cam.transform.position.x - cam.orthographicSize * (Screen.width + 3) / Screen.height, cam.transform.position.x + cam.orthographicSize * (Screen.width + 3) / Screen.height)
                    , Random.Range(cam.transform.position.y + cam.orthographicSize,cam.transform.position.y + cam.orthographicSize + 3))
                    , Quaternion.identity);
            }

            lastPos = cam.transform.position;
        }
        if(Mathf.Abs(cam.orthographicSize - lastSize) < thresholdSize)
        {

            lastSize = cam.orthographicSize;
        }
    }
}
