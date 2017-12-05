using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject coin_prefab;
	public GameObject coin_spawner;
	public float wait_seconds_spawn_coin = 5f;
	public int max_coins = 100;

	private static int coins_count;

	void Start () {
		SpawnCoin();
		StartCoroutine(WaitAndSpawn(wait_seconds_spawn_coin));
	}

	private IEnumerator WaitAndSpawn(float wait_time)
	{
		while (true)
		{
			yield return new WaitForSeconds(wait_time);
			if(coin_spawner.transform.childCount < max_coins)
			{
				SpawnCoin();
			}			
		}
	}

	private void SpawnCoin()
	{
		Vector3 new_pos = new Vector3(Random.Range(-23f, 23f), 0f, Random.Range(-23f, 23f));
		GameObject coin = Instantiate(coin_prefab) as GameObject;
		coin.transform.parent = coin_spawner.transform;
		coin.transform.position = coin_prefab.transform.position + new_pos;
		coin.transform.rotation = coin_prefab.transform.rotation;
		//Debug.Log("Coins spawned: " + coin_spawner.transform.childCount);
	}
}
