using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ResetScene : MonoBehaviour
{

    public void OnClick()
    {
        Application.LoadLevel("1");
        Debug.Log("Load LEVEL");
    }
}
