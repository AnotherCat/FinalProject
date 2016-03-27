using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public Canvas GameOverCanvas;
    public Text levelText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1;
        GetComponent<AudioSource>().Play();
        levelText.text = "Level " + PlayerMissile.Level;
    }

    public void OnGameOver()
    {
        GameOverCanvas.enabled = true;
    }
    
    public void OnRestartButtonClicked()
    {
        PlayerMissile.Level = 1;
        SceneManager.LoadScene("Scene1");
    }

    
}
