using UnityEngine;
using System;

public class PlaneBehaviour : MonoBehaviour {

    public new string planeName;
    public int altitude; // Conversion m / ft
    public int destination;
    public float vitesse; // Conversion knots (kts) / km.h / mph
    public float direction;

    public float angleVertical;

    private MeshRenderer meshRend;

    private float angleHorizontal;
    private float realSpeed;

    // Use this for initialization
    void Start () {
        meshRend = gameObject.GetComponent<MeshRenderer>();
    }

    void onTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
    }
<<<<<<< HEAD

    // Update is called once per frame
    void Update () {
        realSpeed = vitesse / 200000; // (from 1000 km.h to 0.005 speed)
=======
	
	// Update is called once per frame
	void Update () {
        realSpeed = vitesse / 800000; // (from 1000 km/h to 0.005 speed)
>>>>>>> origin/master

        Vector3 movement = Vector3.zero - transform.position; // Pour le moment on teste le mouvement vers le point 0 0
        if (movement.magnitude < realSpeed)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().planesCount--;
            Destroy(gameObject);
        }
        else
        {
            movement.Normalize();
            transform.Translate(movement * realSpeed, Space.World);
            angleVertical = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        }
<<<<<<< HEAD

        if (Math.Abs(gameObject.transform.position.x) < 4.7f && Math.Abs(gameObject.transform.position.y) < 4.7f)
        {
            meshRend.enabled = true;
        } else
        {
            meshRend.enabled = false;
        }
=======
>>>>>>> origin/master
    }
}
