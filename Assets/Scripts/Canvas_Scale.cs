using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Canvas_Scale : MonoBehaviour {
    public Camera camera;

    private RectTransform CanvasTransform;
	// Use this for initialization
	void Start () {
        CanvasTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        CanvasTransform.position = camera.transform.position;

        Debug.Log("LastUPate");
	}
}
