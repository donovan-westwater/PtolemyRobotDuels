using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NEEDS TO MOVE MORE SMOOTHLY, AND MOVE FATHER WITH A SINGLE INPUT!!
//Make middle step: IMPLUSEES!!!!! (USE A DICTIONARY ENUMERATE THE IMPLUES!!!)
//learn about finite state machines
//add a boolean to toggle on the movement temporarly!!! (MIGHT BE FINTE STATE MACHINE?)
public class Player_Control_Test : MonoBehaviour {

    public static float speed = 1;             //Floating point variable to store the player's movement speed.
    public float step;
    float offsetNum = 5;
    enum moveStates {RIGHT,LEFT,UP,DOWN,ENTER};
    Vector2 movement = new Vector2(0, 0);
    int currentAction = 0;
    bool submit = false;

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private string[] inputList = new string[6];
    int indexSlot = 0;
    int phyIndex = 0;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        step = speed * Time.deltaTime;
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(pause());
      
    }
    //Stores the inputs of the player for physics. After a point, will override previous inputs atm.
    //Should replace strings inputs with variables storing the strings, and have the stored values be the states, not input itself
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
    //MAKING NEW METHOD FOR MOVEMENT! TOGGLES ON MOVE UNTIL REACHING POSTION
    void processMove(int index,float distance)
    {
        print("PROCCESING MOVE AT " + index + " " + distance);
        string x = inputList[index];
        if (x == "a" && distance > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - distance, transform.position.y), step);
            distance -= step;


        }
        else if (x == "d"&& distance > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + distance, transform.position.y), step);
            distance -= step;

        }
        else if (x == "w" && distance > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + distance), step);
            distance -= step;
        }
        else if (x == "s" && distance > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y - distance), step);
            distance -= step;
        }
       
    }
    //method called when movements are planned
    /// <summary>
    /// NEEDS: TO HALT AFTER A CERTAIN AMOUNT OF DISTANCE
    /// SHOULD CLEAR ALL PERVIOUS INPUTS AFTER SUBMITTING THEM!!
    /// 
    /// When fixed up, backup and rework to make controls more customislbe
    /// movement should become a finite state machine (Should toggle on and off)
    /// </summary>
    void InactMove()
    {
        foreach (string x in inputList)
        {
            print("Now Inacting Movement!");
            if (x == "a")
            {
                currentAction =(int) moveStates.RIGHT;
                //MOVE TO THE RIGHT
               transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - offsetNum, transform.position.y), step);
                //movement.Set(-speed, movement.y);
                //pause();
                //rb2d.AddForce(movement);
                
            }
            else if (x == "d")
            {
                currentAction = (int)moveStates.LEFT;
                //MOVE X TO THE LEFT
               transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + offsetNum, transform.position.y), step);
                //movement.Set(speed, movement.y);
                //pause();
                // rb2d.AddForce(movement);

            }
            else if (x == "w")
            {
                currentAction = (int)moveStates.UP;
                //MOVE Y TO THE TOP
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y+offsetNum), step);
                //movement.Set(movement.x,speed);
                //pause();
                // rb2d.AddForce(movement);

            }
            else if (x == "s")
            {
                currentAction = (int)moveStates.DOWN;
                //MOVE Y TO THE BOTTOM
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y-offsetNum), step);
                //movement.Set(movement.x, -speed);
                //pause();
                // rb2d.AddForce(movement);

            }
            
            //movement.Set(0, 0);
            //rb2d.velocity = movement;
            //print("This is my current vector: " + movement);
        }
        inputList = new string[6];
    }
    IEnumerator pause()
    {
        yield return new WaitForSeconds(30);
    }
   
    private void Update()
    {
        step = speed * Time.deltaTime;
        storage();
        if (Input.GetKeyDown("space"))
        {
            submit = true;
        }
        if (submit)
        {
            processMove(currentAction, offsetNum);
            offsetNum -= step;
            if (offsetNum <= 0)
            {
                currentAction += 1;
                offsetNum = 5;
            }
            if (currentAction >= inputList.Length)
            {
                currentAction = 0;
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
