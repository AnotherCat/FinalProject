using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Input.gyro.enabled = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
