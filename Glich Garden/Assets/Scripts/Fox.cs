using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision) {
		GameObject defender = collision.gameObject;

		if (defender.GetComponent<Gravestone>()) {
			gameObject.GetComponent<Animator>().SetTrigger("jumpTrigger");
		} else if (defender.GetComponent<Defender>()) {
			gameObject.GetComponent<Attacker>().Attack(defender);
		}
	}
}
