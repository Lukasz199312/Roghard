using UnityEngine;
using System.Collections;

public class Broken_Stones : MonoBehaviour {

    public GameObject Stone;
    public Vector2 Force = new Vector2(0, 0);

    private GameObject CloneStone;

	// Use this for initialization
	void Start () {
        if (Stone == null) return;

        
      
	}

    void FixedUpdate()
    {

    }
	
	// Update is called once per frame
	void Update () {
        
       
	}

    void OnBecameInvisible()
    {
        //Destroy(gameObject,0.02f);
    }

    void OnCollisionEnter2D(Collision2D Collision_Object){
        if ( Collision_Object.collider.name == "Legs") return;

       

        Debug.Log("Kolizja w Stone");
        
       // renderer.enabled = false;
        CloneStone = (GameObject)Instantiate(Stone, transform.position, Quaternion.identity) as GameObject;

        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 0.02f);

    }
}
