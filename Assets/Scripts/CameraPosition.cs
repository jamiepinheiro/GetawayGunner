using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour {

	Vector3 currentPos;
	Quaternion currentRot;

	Vector3 gamePosition = new Vector3(0, 3.5f, -2.5f);
	Quaternion gameRotation = Quaternion.Euler(8, 0, 0);

	Vector3 startPosition = new Vector3(-30, 9, 9);
	Quaternion startRotation = Quaternion.Euler(5, 90, 0);

	Vector3 endPosition = new Vector3(0, 20, -2.5f);
	Quaternion endRotation = Quaternion.Euler(8, 0, 0);

	// Use this for initialization
	void Start () {
	
		currentPos = transform.position;
		currentRot = transform.rotation;

	}
	
	// Update is called once per frame
	void Update () {

		if(CameraShake.shake == 0){

			if(!Game.playing && !Game.gameOver){

				currentPos = startPosition;
				currentRot = startRotation;

			}else if(Game.playing && !Game.gameOver){

				currentPos = Vector3.Lerp(currentPos, gamePosition, 1 * Time.deltaTime);
				currentRot = Quaternion.Lerp(currentRot, gameRotation, 1 * Time.deltaTime);

			}else if(Game.playing && Game.gameOver){

				currentPos = Vector3.Lerp(currentPos, endPosition, 0.5f * Time.deltaTime);
				currentRot = Quaternion.Lerp(currentRot, endRotation, 1 * Time.deltaTime);

			}

			transform.position = currentPos;
			transform.rotation = currentRot;

		}
	
	}
}
