using UnityEngine;
using System.Collections;
using Assets.Scripts.Player_Scripts;

public class Controller : MonoBehaviour {

    public Vector2 ForceVelocity = new Vector2(0,0);

    [Range(0, 100)]
    public float Speed = 0;

    private bool addForce = false;
    public Vector2 Force;
    public Legs LegController;

    public Vector2 Old_Velocity;

    private Vector2 MaxVelocity = new Vector2(0,0);

	// Use this for initialization
	void Start () {
        Jump.Initialize(1, 0.75f, GetComponent<Rigidbody2D>(), LegController, ForceVelocity);
	}

	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate()
    {
        Old_Velocity = GetComponent<Rigidbody2D>().velocity;

        addForce = false;


        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);

        if (GetComponent<Rigidbody2D>().velocity.x == 100) Debug.Log("DONE");

    }

    void LateUpdate()
    {


        if (GetComponent<Rigidbody2D>().velocity.y < Old_Velocity.y && Jump.Improve == true )
        {
            Debug.Log("Opadam");

            float vel = 0;

            if (GetComponent<Rigidbody2D>().velocity.y > 4)
            {
                vel = GetComponent<Rigidbody2D>().velocity.y - 3;

                Debug.Log("Case 1");
            }
            else if (GetComponent<Rigidbody2D>().velocity.y > 3)
            {
                vel = GetComponent<Rigidbody2D>().velocity.y - 2.75f;

                Debug.Log("Case 1");
            }

            else if (GetComponent<Rigidbody2D>().velocity.y > 2)
            {
                vel = GetComponent<Rigidbody2D>().velocity.y - 1.50f;
                Debug.Log("Case 2");
            }

            else if (GetComponent<Rigidbody2D>().velocity.y > 1)
            {
                vel = GetComponent<Rigidbody2D>().velocity.y - 0.75f;
                Debug.Log("Case 2");
            }



            else vel = GetComponent<Rigidbody2D>().velocity.y;

            if (GetComponent<Rigidbody2D>().velocity.y < -6) vel = -6;

            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, vel);
   
        }


      




        Jump.UpdateStatus();

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            LegController.isTouchGround = false;
            Jump.Improve = false;
            Jump.Start();

       
        }
    }

  void  OnCollisionEnter2D(Collision2D Collision_Object){


   }

  public void SpeedSkill()
  {
      GetComponent<Rigidbody2D>().AddForce(Force, ForceMode2D.Impulse);
  }

	
}
//Input.touches[0].phase == TouchPhase.Began