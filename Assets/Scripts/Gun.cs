using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour {

	public GameObject crosshair, animation;
	Vector2 mousePos, startPos, oldPos;
	RaycastHit hit;
	
	// Use this for initialization
	void Start () {
	
		mousePos = new Vector2(Screen.width/2.0f, Screen.height/2.0f);

	}
	
	// Update is called once per frame
	void Update () {

		if(Game.playing && !Game.gameOver){

			crosshair.SetActive(true);
		
			if(Input.GetMouseButtonDown(0)){

				startPos = Input.mousePosition;
				oldPos = mousePos;

			}

			if(Input.GetMouseButton(0)){

				mousePos = new Vector2(oldPos.x + (Input.mousePosition.x - startPos.x), oldPos.y + (Input.mousePosition.y - startPos.y));

				animation.SetActive(true);
				crosshair.transform.position = mousePos;
				
				Ray ray = Camera.main.ScreenPointToRay(mousePos);

				Debug.DrawRay(ray.origin, ray.direction, Color.green);

				if(Physics.Raycast(ray.origin, ray.direction, out hit)){
		
					transform.LookAt(hit.point, Vector3.forward);

					if(hit.collider.gameObject.tag == "Chicken"){

						crosshair.GetComponent<Image>().color = Color.red;
						hit.collider.gameObject.SendMessage("Hit");

					}else{
						crosshair.GetComponent<Image>().color = Color.black;
					}

				}

			}else{
				animation.SetActive(false);
			}

		}else{

			animation.SetActive(false);
			crosshair.SetActive(false);

		}
	
	}

}
