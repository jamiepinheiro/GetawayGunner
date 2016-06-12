using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public Material road;
	GameObject[] terrain;
	float textureOffset = 0;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
		terrain = GameObject.FindGameObjectsWithTag("Terrain");

		road.SetTextureOffset("_MainTex", new Vector2(0, textureOffset));

		if(!Game.gameOver){

			textureOffset += 0.5f * Time.deltaTime;

			foreach (GameObject ter in terrain){

				ter.transform.Translate(0, 0, 5 * Time.deltaTime, Space.World);

				if(ter.transform.position.z > 100){

					ter.transform.Translate(0, 0, -200, Space.World);

				}

			}

		}

	}
}
