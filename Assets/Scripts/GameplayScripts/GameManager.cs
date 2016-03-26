using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Input.gyro.enabled = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
