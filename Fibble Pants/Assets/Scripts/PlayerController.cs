using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;// This is required to script for UI features
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 100.0f;

    public Text countText;
    public Text winText;


    private Rigidbody2D rb2d;
    private int count;
    
    void Start()

    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = " ";
        SetCountText();
        // These define values for Unity
        

    }

    void Update() //Code for movement
    {
        if (Input.GetKey("up"))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up);
            
        }
        else if (Input.GetKey("down"))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.down);
            
        }
        else if (Input.GetKey("left"))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left);
            
        }
        else if (Input.GetKey("right"))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right);//These detect if the arrow keys are pressed and applies force in the corresponding direction if they are
            
        }

        Vector2 movement = new Vector2();

        rb2d.AddForce(movement * speed);


    }

    void OnTriggerEnter2D(Collider2D other) //This code is to enable the gems to be collected
    {
        if (other.gameObject.CompareTag("PickUp"))//This descriminates what can be collected
        {
            other.gameObject.SetActive(false); //This is what counts how many are collected
            count = count + 1; //The count is set to 0 
            SetCountText();
        }
    }

    void SetCountText() 
    {
        countText.text = "count:  " + count.ToString();//This controls the display
        if (count >= 10) // This initiates a response if the count exceeds 9
        {
            winText.text = "You are Winner?";//This just controls what the text is

        }



    }



}


