using UnityEngine;
using System.Collections;

public class Tors : MonoBehaviour {
    public Horn_Force Skill;

    private Horn_Force Skills;
	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D Collision_Object){
        Debug.Log("Kolizja - Torse");
        

        Skills = Instantiate(Skill.gameObject, transform.position, Quaternion.identity) as Horn_Force;
        Skills.Active();
    
    }

    void OnCollisionStay2D(Collision2D Collision_Object)
    {
        Debug.Log("Kolizja - Torse");


        Skills = Instantiate(Skill.gameObject, transform.position, Quaternion.identity) as Horn_Force;
        Skills.Active();

    }
}
