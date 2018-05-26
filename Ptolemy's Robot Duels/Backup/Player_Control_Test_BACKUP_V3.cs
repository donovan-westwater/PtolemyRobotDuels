﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NEEDS TO MOVE MORE SMOOTHLY, AND MOVE FATHER WITH A SINGLE INPUT!!
//Make middle step: IMPLUSEES!!!!! (USE A DICTIONARY ENUMERATE THE IMPLUES!!!)
//learn about finite state machines
//add a boolean to toggle on the movement temporarly!!! (MIGHT BE FINTE STATE MACHINE?)
public class Player_Control_Test : MonoBehaviour {

    public static float speed = 1;             //Floating point variable to store the player's movement speed.
    public float step;
    float offset = 5;
    float offsetNum;
    
    public string[] Inputs = { "a", "d", "w", "s", "space" }; //Replace with a dictionary?
    enum moveStates {STILL, RIGHT,LEFT,UP,DOWN,ENTER};
    Vector2 movement = new Vector2(0, 0);
    int currentAction = 0;
    bool submit = false;

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private moveStates[] inputList = new moveStates[6];
    int indexSlot = 0;
    int phyIndex = 0;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        offsetNum = offset;
        step = speed * Time.deltaTime;
        rb2d = GetComponent<Rigidbody2D>();
        inputList = new moveStates[6];


    }
    //Stores the inputs of the player for physics. After a point, will override previous inputs atm.
    //Should replace strings inputs with variables storing the strings, and have the stored values be the states, not input itself
    void storage()
    {
        if (Input.GetKeyDown(Inputs[0]))
        {
            print("Stored input '" +Inputs[0]+"' ");
            inputList[indexSlot] = moveStates.LEFT;
            indexSlot += 1;
        }
        if (Input.GetKeyDown(Inputs[1]))
        {
            print("Stored input '" + Inputs[1] + "' ");
            inputList[indexSlot] = moveStates.RIGHT;
            indexSlot += 1;
        }
        if (Input.GetKeyDown(Inputs[2]))
        {
            print("Stored input '" + Inputs[2] + "' ");
            inputList[indexSlot] = moveStates.UP;
            indexSlot += 1;
        }
        if (Input.GetKeyDown(Inputs[3]))
        {
            print("Stored input '" + Inputs[3] + "' ");
            inputList[indexSlot] = moveStates.DOWN;
            indexSlot += 1;
        }
        if (indexSlot >= inputList.Length)
        {
            indexSlot = 0;
        }
    }
    //MAKING NEW METHOD FOR MOVEMENT! TOGGLES ON MOVE UNTIL REACHING POSTION
    void processMove(int index,float distance)
    {
        //print("PROCCESING MOVE AT " + index + " " + distance);
        moveStates x = inputList[index];
        if (x == moveStates.LEFT && distance > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - distance, transform.position.y), step);
            distance -= step;


        }
        else if (x == moveStates.RIGHT && distance > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + distance, transform.position.y), step);
            distance -= step;

        }
        else if (x == moveStates.UP && distance > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + distance), step);
            distance -= step;
        }
        else if (x == moveStates.DOWN && distance > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y - distance), step);
            distance -= step;
        }
       
    }
    
   
    private void Update()
    {
        step = speed * Time.deltaTime;
        if(submit == false)
        {
            storage();
        }
        
        if (Input.GetKeyDown(Inputs[4]))
        {
            submit = true;
        }
        if (submit)
        {
            processMove(currentAction, offsetNum);
            print("This is the current move: "+inputList[currentAction]);
            print(""+inputList[1]);
            
            offsetNum -= step;
            if (offsetNum <= 0)
            {
                currentAction += 1;
                offsetNum = offset;
            }
            if (currentAction >= inputList.Length)
            {
                print("Over and out?");
                currentAction = 0;
                inputList = new moveStates[6];
                submit = false;
            }
        }
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        

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
}
