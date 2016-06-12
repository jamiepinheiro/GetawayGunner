using UnityEngine;
using System.Collections;

public class SpawnChickens : MonoBehaviour {

	public GameObject chicken1, chicken2, chicken3;
	float spawnTimer;
	float z = 30;
	Quaternion rot = Quaternion.Euler(0, 0, 0);

	// Use this for initialization
	void Start () {

		spawnTimer = 100;
	
	}
	
	// Update is called once per frame
	void Update () {

		spawnTimer += Time.deltaTime;
	
		if(spawnTimer > 3 && Game.playing && !Game.gameOver){

			int rand = Random.Range(0, 3);

			if(rand == 0){

				Instantiate(chicken1, new Vector3(Random.Range(-15, 15), 0.6f, z + Random.Range(-15, 15)), rot);
				Instantiate(chicken1, new Vector3(Random.Range(-15, 15), 0.6f, z + Random.Range(-15, 15)), rot);
				Instantiate(chicken1, new Vector3(Random.Range(-15, 15), 0.6f, z + Random.Range(-15, 15)), rot);
				Instantiate(chicken1, new Vector3(Random.Range(-15, 15), 0.6f, z + Random.Range(-15, 15)), rot);


			}else if(rand == 1){

				Instantiate(chicken2, new Vector3(Random.Range(-15, 15), 1, z + Random.Range(-15, 15)), rot);
				Instantiate(chicken2, new Vector3(Random.Range(-15, 15), 1, z + Random.Range(-15, 15)), rot);

			}else if(rand == 2){

				Instantiate(chicken3, new Vector3(Random.Range(-15, 15), 1.3f, z + Random.Range(-15, 15)), rot);

			}

			spawnTimer = 0;

		}

	}
}
