using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
	[SerializeField] GameObject winLabel;
	[SerializeField] GameObject loseLabel;
	[SerializeField] float waitToLoad = 3.5f;
	int numberOfAttackers = 0;
	bool levelTimerFinished = false;

	private void Start() {
		winLabel.SetActive(false);
		loseLabel.SetActive(false);
	}

	IEnumerator HandleWinCondition() {
		winLabel.SetActive(true);
		GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(waitToLoad);
		//FindObjectOfType<LevelLoader>().LoadNextScene();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void HandleLoseCondition() {
		loseLabel.SetActive(true);
		Time.timeScale = 0;
	}

	public void AttackerSpawned() {
		numberOfAttackers++;
	}

	public void AttackerKilled() {
		numberOfAttackers--;
		if (numberOfAttackers <= 0 && levelTimerFinished) {
			Debug.Log("END GAME");
			StartCoroutine(HandleWinCondition());
		}
	}
	public void LevelTimerFinished() {
		levelTimerFinished = true;
		StopSpawners();
	}
	private void StopSpawners() {
		AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
		foreach (var spawn in spawners) {
			spawn.StopSpawning();
		}
	}
}
