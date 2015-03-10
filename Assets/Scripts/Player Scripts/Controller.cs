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
    public Tors TorseController;

    public Vector2 Old_Velocity;

    private Vector2 MaxVelocity = new Vector2(0,0);

	// Use this for initialization
	void Start () {
        Jump.Initialize(1, 0.75f, GetComponent<Rigidbody2D>(), LegController, ForceVelocity);
	}

	// Update is called once per frame
	void Update () {
       // gameObject gm = Instantiate()
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
      

            float vel = 0;

            if (GetComponent<Rigidbody2D>().velocity.y > 4)
            {
                vel = GetComponent<Rigidbody2D>().velocity.y - 3;

               
            }
            else if (GetComponent<Rigidbody2D>().velocity.y > 3)
            {
                vel = GetComponent<Rigidbody2D>().velocity.y - 2.75f;

                
            }

            else if (GetComponent<Rigidbody2D>().velocity.y > 2)
            {
                vel = GetComponent<Rigidbody2D>().velocity.y - 1.50f;
                
            }

            else if (GetComponent<Rigidbody2D>().velocity.y > 1)
            {
                vel = GetComponent<Rigidbody2D>().velocity.y - 0.75f;
               
            }



            else vel = GetComponent<Rigidbody2D>().velocity.y;

            if (GetComponent<Rigidbody2D>().velocity.y < -6) vel = -6;

            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, vel);
   
        }


      




        Jump.UpdateStatus();
        TorseController.SkillUpdate();



        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                LegController.isTouchGround = false;
                Jump.Improve = false;
                Jump.Start();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LegController.isTouchGround = false;
            Jump.Improve = false;
            Jump.Start();
        }

        if (Input.GetKeyDown(KeyCode.Z) )
        {
            
            TorseController.StartSkill();

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