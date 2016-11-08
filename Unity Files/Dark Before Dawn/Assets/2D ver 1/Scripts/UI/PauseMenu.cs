using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public GameObject pauseUI;
	private bool paused = false;

	void Start(){

		pauseUI.SetActive(false);

	}

	void Update(){

		if (Input.GetButtonDown ("Paused")) {
			paused = !paused;
		}

		if (paused) {
			pauseUI.SetActive (true);
			Time.timeScale = 0;
		}

		if (!paused) {
			pauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void Resume(){

		paused = false;

	}

	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MainMenu(){
		SceneManager.LoadScene (1);

	}

	public void Quit(){
		Application.Quit ();
	}
}
