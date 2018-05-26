using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DONT_USE_THIS : MonoBehaviour {

	public float speed;             //Floating point variable to store the player's movement speed.
    public WaitForSeconds pause = new WaitForSeconds(5);

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private string[] inputList = new string[6];
    int indexSlot = 0;
    int phyIndex = 0;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
    }
    //Stores the inputs of the player for physics. After a point, will override previous inputs atm.
    void storage()
    {
        if (Input.GetKeyDown("a"))
        {
            print("Stored input 'a' ");
            inputList[indexSlot] = "a";
            indexSlot += 1;
        }
        if (Input.GetKeyDown("d"))
        {
            print("Stored input 'd' ");
            inputList[indexSlot] = "d";
            indexSlot += 1;
        }
        if (Input.GetKeyDown("w"))
        {
            print("Stored input 'w' ");
            inputList[indexSlot] = "w";
            indexSlot += 1;
        }
        if (Input.GetKeyDown("s"))
        {
            print("Stored input 's' ");
            inputList[indexSlot] = "s";
            indexSlot += 1;
        }
        if (indexSlot >= inputList.Length)
        {
            indexSlot = 0;
        }
    }
    //method called when movements are planned
    /// <summary>
    /// NEEDS: TO HALT AFTER A CERTAIN AMOUNT OF DISTANCE
    /// SHOULD CLEAR ALL PERVIOUS INPUTS AFTER SUBMITTING THEM!!
    /// 
    /// When fixed up, backup and rework to make controls more customislbe
    /// </summary>
    void InactMove()
    {
        Vector2 movement = new Vector2(0,0);
        foreach (string x in inputList)
        {
            print("Now Inacting Movement!");
            if (x == "a")
            {
                //MOVE TO THE RIGHT
                movement.Set(-speed, movement.y);
                rb2d.AddForce(movement);
                yield return pause;
            }
            else if (x == "d")
            {
                //MOVE X TO THE LEFT
                movement.Set(speed, movement.y);
                rb2d.AddForce(movement);
                yield return pause;
            }
            else if (x == "w")
            {
                //MOVE Y TO THE TOP
                movement.Set(movement.x,speed);
                rb2d.AddForce(movement);
                yield return pause;
            }
            else if (x == "s")
            {
                //MOVE Y TO THE BOTTOM
                movement.Set(movement.x, -speed);
                rb2d.AddForce(movement);
                yield return pause;
            }
            inputList = new string[6];
            movement.Set(0, 0);
            rb2d.velocity = movement;
            print("This is my current vector: " + movement);
        }

    }
    //was placed in fixed update!
    void OldMovement()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");


        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");


        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        print(movement * speed + " is the speed");
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);
    }
    private void Update()
    {
        storage();
       
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            this.InactMove();
        }

    }
}
