using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	AudioSource audioSourse;

    // Start is called before the first frame update
    void Start()
    {
		DontDestroyOnLoad(this);
		audioSourse = GetComponent<AudioSource>();
		audioSourse.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume) {
		audioSourse.volume = volume;
	}
}
