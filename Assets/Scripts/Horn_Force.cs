using UnityEngine;
using System.Collections;

public class Horn_Force : MonoBehaviour {

    public Vector2 Force_Power;
    public float Destroy_Time;

    private bool isActived = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce(Force_Power, ForceMode2D.Impulse);
        Destroy(this.gameObject, Destroy_Time);
	}

    public void Active()
    {
        Debug.Log("Aktywacja");
        isActived = true;
    }

}
