using UnityEngine;

public class PlaneBehaviour : MonoBehaviour {

    public string planeName;
    public int altitude; // Conversion m / ft
    public int destination;
    public float vitesse; // Conversion knots (kts) / km.h / mph
    public float direction;

    public float angleVertical;

    private float angleHorizontal;
    private float realSpeed;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        realSpeed = vitesse / 200000; // (from 1000 km.h to 0.005 speed)

        Vector3 movement = Vector3.zero - transform.position; // Pour le moment on teste le mouvement vers le point 0 0
        if (movement.magnitude < realSpeed)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().planesCount--;
            Destroy(gameObject);
        } else
        {
            movement.Normalize();
            transform.Translate(movement * realSpeed, Space.World);
            angleVertical = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;

            Debug.Log("Name = " + planeName);
            Debug.Log("Vitesse = " + vitesse);
            Debug.Log("Altitude = " + altitude);
        }
        
    }
}
