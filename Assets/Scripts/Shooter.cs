using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] GameObject projectile;
	GameObject projectileParent;
	[SerializeField] GameObject gun;
	const string PROJECTILE_PARENT_NAME = "Projectiles";
	AttackerSpawner myLaneSpawner;
	Animator animator;

	private void Start() {
		SetLaneSpawner();
		animator = GetComponent<Animator>();
		CreateProjectileParent();
	}

	private void CreateProjectileParent() {
		projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
		if (!projectileParent) {
			projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
		}
	}

	private void Update() {
		if (IsAttackerInLane()) {
			animator.SetBool("isAttacking", true);
		} else {
			animator.SetBool("isAttacking", false);
		}
	}

	private void SetLaneSpawner() {
		AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

		foreach (var spawn in spawners) {
			bool isCloseEnough = (Mathf.Abs(spawn.transform.position.y - transform.position.y) <= Mathf.Epsilon);
			if (isCloseEnough) {
				myLaneSpawner = spawn;
			}
		}
	}

	private bool IsAttackerInLane() {
		if (myLaneSpawner == null)
			return false;
		return myLaneSpawner.transform.childCount <= 0 ? false : true;
	}

	public void Fire(float damage) {
		GameObject newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		return;
	}
}
