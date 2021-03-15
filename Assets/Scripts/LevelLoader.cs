using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	[SerializeField] float loadDelayInSeconds;
	private int currentSceneIndex;
	private void Start() {
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (currentSceneIndex == 0)
			StartCoroutine(LoadNextScene());
	}

	public IEnumerator LoadNextScene() {
		yield return new WaitForSeconds(loadDelayInSeconds);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoadNS() {
		SceneManager.LoadScene(currentSceneIndex + 1);

	}

	public void RestartScene() {
		Time.timeScale = 1;
		SceneManager.LoadScene(currentSceneIndex);
	}
	public void LoadOptions() {
		Time.timeScale = 1;
		SceneManager.LoadScene("Options");
	}

	public void LoadMainMenu() {
		Time.timeScale = 1;
		SceneManager.LoadScene("Start Screen");
	}

	public void LoadGameOver() {
		SceneManager.LoadScene("Game Over");
	}

	public void QuitGame() {
		Application.Quit();
	}
}
