using UnityEngine;

public class PlaneBehaviour : MonoBehaviour {

    public System.String name;
    public int altitude; // Conversion m / ft
    public int destination;
    public float vitesse; // Conversion knots (kts) / km.h / mph
    public float direction;

    public float angleVertical;

    private float angleHorizontal;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = Vector3.zero - transform.position; // Pour le moment on teste le mouvement vers le point 0 0
        movement.Normalize();
        transform.Translate(movement * vitesse);
        angleVertical = Mathf.Atan2(movement.y, movement.x);
    }
}
