using UnityEngine;
using System.Collections;

public class Tors : MonoBehaviour {
    public Horn_Force Skill;
    public bool ActiveSkill;
    public float time;

    private Horn_Force Skills;
	// Use this for initialization
	void Start () {
        ActiveSkill = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D Collision_Object){
        Debug.Log("Kolizja - Torse");

        if (Collision_Object.gameObject.layer != 10) return;

        if (ActiveSkill == false)
        {
            // dead Function
            Debug.Log("You Are Dead");
            Application.LoadLevel(Application.loadedLevel);
            return;
        } 

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
