using UnityEngine;
using System.Collections;

public class infoText : MonoBehaviour
{

    private
    // Use this for initialization
    void Start()
    {
        TextMesh textObject = GameObject.Find("avion").GetComponent<TextMesh>();
        textObject.text = "test";

    }

    // Update is called once per frame
    void Update()
    {

    }
}