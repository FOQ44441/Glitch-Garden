using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
	[Range(0f, 5f)]
	float currnetMS = 1f;
	GameObject currentTarget;

	private void Awake() {
		
	}
	// Start is called before the first frame update
	void Start()
    {
		FindObjectOfType<LevelController>().AttackerSpawned();
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector2.left * currnetMS * Time.deltaTime);
		UpdateAnimationState();
	}
	private void UpdateAnimationState() {
		if (!currentTarget) {
			GetComponent<Animator>().SetBool("isAttacking", false);
		}
	}

	private void OnDestroy() {
		LevelController levelController = FindObjectOfType<LevelController>();
		if (levelController) {
			levelController.AttackerKilled();
		}

	}

	public void SetMoveSpeed(float speed) {
		currnetMS = speed;

	}

	public void Attack(GameObject target) {
		GetComponent<Animator>().SetBool("isAttacking", true);
		currentTarget = target;
	}

	public void StrikeCurrentTarget(float damage) {
		if (!currentTarget)
			return;
		Health health = currentTarget.GetComponent<Health>();
		if (health) {
			health.DealDamage(damage);
		}
	}
}
