using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

	[SerializeField] float minSpawnDelay = 3f;
	[SerializeField] float maxSpawnDelay = 5f;
	[SerializeField] Attacker[] attackersPrefab;

	bool spawn = true;
	// Start is called before the first frame 
	IEnumerator Start()
    {
		while (spawn) {
			yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
			SpawnAttacker(); 
		}
		
	}

	private Attacker GetAttacker() {
		Attacker attacker = attackersPrefab[Random.Range(0, attackersPrefab.Length)];
		return attacker;
	}

	private void SpawnAttacker() {
		Attacker newAttaker = Instantiate
			(GetAttacker(), transform.position, transform.rotation)
			as Attacker;
		newAttaker.transform.parent = transform;
	}

	public void StopSpawning() {
		spawn = false;
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	 private IEnumerator Spawn() {
		yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
	}

}
