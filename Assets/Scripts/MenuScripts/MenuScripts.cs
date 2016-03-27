using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour {

	public void nextScene () {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Scene1");
    }	
	
}
