using UnityEngine;

public class PlaneBehaviour : MonoBehaviour {

    public System.String name;
    public int altitude; // Conversion m / ft
    public int destination;
    public float vitesse; // Conversion knots (kts) / km.h / mph
    public float direction;

    public float angleVertical;

    private float angleHorizontal;

    public float ThetaScale = 0.01f;
    public float radius = 5f;
    public float circleWidth = 0.02f;
    private int Size;
    private LineRenderer LineDrawer;
    private float Theta = 0f;

    // Use this for initialization
    void Start () {
        LineDrawer = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = Vector3.zero - transform.position; // Pour le moment on teste le mouvement vers le point 0 0
        movement.Normalize();
        transform.Translate(movement * vitesse);
        angleVertical = Mathf.Atan2(movement.y, movement.x);

        Theta = 0f;
        Size = (int)((1f / ThetaScale) + 1f);
        LineDrawer.SetWidth(circleWidth, circleWidth);
        LineDrawer.SetVertexCount(Size);
        for (int i = 0; i < Size; i++)
        {
            Theta += (2.0f * Mathf.PI * ThetaScale);
            float x = transform.position.x + radius * Mathf.Cos(Theta);
            float y = transform.position.y + radius * Mathf.Sin(Theta);
            LineDrawer.SetPosition(i, new Vector3(x, y, 0));

        }
    }
}
