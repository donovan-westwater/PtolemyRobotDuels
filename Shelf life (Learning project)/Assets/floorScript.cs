using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorScript : MonoBehaviour {
   [SerializeField]
    public Rigidbody rBody;
   public string trophyName;
   public void Awake()
   {
       rBody = GetComponent<Rigidbody>();
   }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnMouseGrab()
    {
        rBody.velocity = Vector3.zero;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 newWorldPostion = Camera.main.WorldToScreenPoint(cursorPoint);
    }
}
