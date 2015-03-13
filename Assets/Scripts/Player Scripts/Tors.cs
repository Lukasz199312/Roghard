using UnityEngine;
using System.Collections;

public class Tors : MonoBehaviour {
    public Horn_Force Skill;
    public bool ActiveSkill;
    public float Coldowntime;
    public float DurationTime;

    public bool IsTap { get; set; }

    public GameObject gm;

    private Horn_Force Skills;
	// Use this for initialization
	void Start () {
        ActiveSkill = false;

        DurationTime = Time.time;
        Coldowntime = Time.time;
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

        GameObject SkillHorn = Instantiate(gm, transform.position, Quaternion.identity) as GameObject;
        SkillHorn.GetComponent<Horn_Force>().Active();
        
    
    }

    void OnCollisionStay2D(Collision2D Collision_Object)
    {


        Debug.Log("Kolizja - Torse");


        Skills = Instantiate(Skill.gameObject, transform.position, Quaternion.identity) as Horn_Force;
        Skills.Active();

    }


    public void StartSkill()
    {
        IsTap = true;
        if (Time.time - Coldowntime > 1){
            ActiveSkill = true;
            Coldowntime = Time.time;
            DurationTime = Time.time;
           
            Debug.Log("Skill Active");
        }



      

    }

    public void SkillUpdate()
    {
        if (Time.time - DurationTime > 2 && ActiveSkill == true)
        {
            ActiveSkill = false;
            Debug.Log("Skill Desactive");
        }
    }
}
