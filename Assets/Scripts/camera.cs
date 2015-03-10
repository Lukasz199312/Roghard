using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public Transform Player;

	// Use this for initialization
	void Start () {
        GetComponent<Camera>().transform.localScale.Set(Screen.width * 0.75f, Screen.height * 0.75f, 0);
        if (Player == null) return;
        transform.position.Set(Player.transform.position.x, Player.transform.position.y,-10);
	}
	


    void LateUpdate()
    {
        if (Player == null) return;

       // if (transform.position.sqrMagnitude != Player.position.sqrMagnitude) transform.position = Player.position;

       // transform.position = new Vector3(transform.position.x + 3.75f, transform.position.y, -10);

        transform.position = new Vector3(Player.transform.position.x +3.75f, Player.transform.position.y, -10);


    }

    void OnGUI()
    {
        //GetComponent<Camera>().transform.localScale.Set(Screen.width * 0.75f, Screen.height * 0.75f, 0);
    }
}
