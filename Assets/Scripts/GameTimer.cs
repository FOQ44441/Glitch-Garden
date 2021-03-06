﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	[Tooltip("Level timer in SECONDS")]
	[SerializeField] float levelTime = 10;
	bool triggeredLevelFinished;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (triggeredLevelFinished) { return; }
		GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

		if (Time.timeSinceLevelLoad >= levelTime) {
			FindObjectOfType<LevelController>().LevelTimerFinished();
			triggeredLevelFinished = true;
		}
    }
}
