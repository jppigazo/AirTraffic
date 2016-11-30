using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

    float rotateAngle;

    GameObject triangle;
    float angleVertical;


	// Use this for initialization
	void Start () {
        triangle = gameObject;
    }

    // Update is called once per frame
    void Update() {

        //Vector3 rot = gameObject.GetComponent<PlaneBehaviour>().transform.rotation.eulerAngles;
        if ( angleVertical != gameObject.GetComponent<PlaneBehaviour>().angleVertical )
         {  
            angleVertical = gameObject.GetComponent<PlaneBehaviour>().angleVertical;
            // change the angle to go to.
           // triangle.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 90f);
            triangle.transform.rotation = Quaternion.Euler(0.0f, 180.0f, -90f - angleVertical);
        }
        
    }
}
