using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public Canvas GameOverCanvas;

    void Awake()
    {
        instance = this;
    }

    public void OnGameOver()
    {
        GameOverCanvas.enabled = true;
    }
    
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Scene1");
    }

    
}
