using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript: MonoBehaviour {
    //Bullets need rigidBody trigger, and use trigger collision?
    //Aim sprite's rotation should tie into this script
    //Test to see if it triggers upon creation, if so, move it as soon as possible!!!!
    // Use this for initialization
    public Text winText;
    void Start () {
        winText = GameObject.Find("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")){
            if(col.gameObject.Equals(GameObject.Find("Player Two")))
            {
                winText.text = "Player 1 wins";
                Destroy(GameObject.Find("Player Two"));
                //this.enabled = false;
                Destroy(GameObject.Find("Bullet(Clone)"));

            }
            else
            {
                winText.text = "Player 2 wins!";
                Destroy(GameObject.Find("Player"));
                //this.enabled = false;
                Destroy(this);
            }
            

             
        }
    }
}
