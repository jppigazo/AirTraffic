using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

    float rotateAngle;

    GameObject triangle;
    float angleVertical;

	// Use this for initialization
	void Start () {
        triangle = gameObject.transform.parent.gameobject;
    }

    // Update is called once per frame
    void Update() {
        if( angleVertical != PlaneBehaviour.angleVertical)
        {
            angleVertical = PlaneBehaviour.angleVertical;
            // change the angle to go to.
            triangle.transform.rotation = angleVertical;
        }
	    
	}
}
