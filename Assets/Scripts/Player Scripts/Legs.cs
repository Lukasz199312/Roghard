using UnityEngine;
using System.Collections;

public class Legs : MonoBehaviour {

    public Controller Controller;
    public bool isTouchGround;

    private float time;

	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.M)) Controller.SpeedSkill();
	}


    void FixedUpdate()
    {
        if (Time.time - time > 1.50f)
        {

            isTouchGround = false;
            Debug.Log("Koliza Leg EXIT");
        }
    }

    void OnCollisionStay2D(Collision2D Collision_Object){

        isTouchGround = true;
       // Debug.Log("STAY IN COLISION");
       // time = Time.time;
    }

    void OnCollisionEnter2D(Collision2D Collision_Object)
    {
       // Debug.Log("Koliza Leg");
        isTouchGround = true;
       // time = Time.time;
    }

    void OnCollisionExit2D(Collision2D Collision_Object)
    {
        

        time = Time.time;
        
    }

    public bool isTouchedGround()
    {
        return isTouchGround;
    }
}
