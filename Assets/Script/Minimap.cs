using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.transform.position = 0.25f*gameObject.transform.parent.position + 6.75f*Vector3.right + 3.75f*Vector3.down;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = 0.25f * gameObject.transform.parent.position + 6.75f * Vector3.right + 3.75f * Vector3.down;
    }
}
