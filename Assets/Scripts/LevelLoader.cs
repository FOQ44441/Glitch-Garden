using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	[SerializeField] float loadDelayInSeconds;

	private void Start() {
		StartCoroutine(LoadNextScene());
	}

	public IEnumerator LoadNextScene() {
		yield return new WaitForSeconds(loadDelayInSeconds);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
