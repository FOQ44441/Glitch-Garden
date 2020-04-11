﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
	[Range(0f, 5f)]
	//[SerializeField] float walkSpeed = 1f;
	float currnetMS = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector2.left * currnetMS * Time.deltaTime);

    }

	public void SetMoveSpeed(float speed) {
		currnetMS = speed;
	}
}
