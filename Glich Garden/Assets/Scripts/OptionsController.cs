using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
	[SerializeField] Slider	volumeSlider;
	[SerializeField] float	defaultVolume = 0.8f;
	[SerializeField] Slider	difficultySlider;
	[SerializeField] float	defaultDifficulty =1f;

	// Start is called before the first frame update
	void Start()
    {
		volumeSlider.value = PlayerPrefsController.GetMasterVolume();
		difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
		var musicPlayer = FindObjectOfType<MusicPlayer>();
		if (musicPlayer) {
			musicPlayer.SetVolume(volumeSlider.value);
		} else {
			Debug.LogWarning("No Music player, did you start from splash screen");
		}
    }

	private void SaveMusicVolume() {
		PlayerPrefsController.SetMasterVolume(volumeSlider.value);
	}
	private void SaveDifficult() {
		PlayerPrefsController.SetDifficulty(difficultySlider.value);
	}

	public void ResetOptionsValues() {
		volumeSlider.value = defaultVolume;
		difficultySlider.value = defaultDifficulty;
	}
	private void OnDestroy() {
		SaveMusicVolume();
		SaveDifficult();
	}
}
