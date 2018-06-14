using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour {

	// Use this for initialization //Seconds to read the text
	public float xDisp = .05f;
	public float yDisp = .05f;
	public GameObject parentObject;

	void Start()
	{
		//Invoke("Hide", time);
	}

	void Hide(){
		Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {
		//Vector2 wantedPos = this.transform.position;
		//Vector2 wantedPos = Camera.main.WorldToViewportPoint (this.transform.position);
		transform.position = new Vector2(xDisp, yDisp);
		//transform.position = new Vector2(xDisp,yDisp);

			}
}
//REPLACE TEXT WITH TEXT MESH?