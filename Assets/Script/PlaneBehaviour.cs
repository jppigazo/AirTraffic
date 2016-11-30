using UnityEngine;
using System;

public class PlaneBehaviour : MonoBehaviour {

    public string planeName;
    public int altitude; // Conversion m / ft
    public int destination;
    public float vitesse; // Conversion knots (kts) / km.h / mph
    public int direction;

    public int altitudeOrder;
    public float vitesseOrder;
    public int directionOrder;

    public float angleVertical;

    private MeshRenderer meshRend;

    private float realSpeed;

    void movePlane()
    {
        realSpeed = vitesse / 200000; // (from 1000 km.h to 0.005 speed)

        Vector3 movement;

        if (directionOrder == -1)
        {
            movement = GameObject.Find("GameManager").GetComponent<GameManager>().destinationDict[destination].destPosition - transform.position;
        } else
        {
            movement = new Vector3(2 * realSpeed * (float)-Math.Sin(direction*Mathf.Deg2Rad), 2 * realSpeed * (float)Math.Cos(direction * Mathf.Deg2Rad),0);

        }

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
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, -90f - angleVertical);
            direction = 180 - (int)transform.rotation.eulerAngles.z;
            if (direction < 0) { direction += 360; }
        }

        if (Math.Abs(gameObject.transform.position.x) < 4.7f && Math.Abs(gameObject.transform.position.y) < 4.7f)
        {
            meshRend.enabled = true;
        }
        else
        {
            meshRend.enabled = false;
        }
    }

    // Use this for initialization
    void Start () {
        meshRend = gameObject.GetComponent<MeshRenderer>();

        movePlane();

        vitesseOrder = vitesse;
        directionOrder = -1;
        altitudeOrder = altitude;
    }

    // Update is called once per frame
    void Update () {
        if (vitesse != vitesseOrder)
        {
            vitesse += Math.Sign(vitesseOrder - vitesse)*Math.Min(Math.Abs(vitesseOrder - vitesse), 2);
        }

        if (altitude != altitudeOrder)
        {
            altitude += Math.Sign(altitudeOrder - altitude) * Math.Min(Math.Abs(altitudeOrder - altitude), 3);
        }

        if (directionOrder != -1 && direction != directionOrder)
        {
            if (Math.Abs(directionOrder - direction) < 180)
            {
                direction += Math.Sign(directionOrder - direction) * Math.Min(Math.Abs(directionOrder - direction), 5);
            } else
            {
                direction -= Math.Sign(directionOrder - direction) * Math.Min(360-Math.Abs(directionOrder - direction), 5);
            }
        }

        movePlane();

        if (Physics.OverlapSphere(transform.position + new Vector3(0, 0.2f, 0), 0.2f).Length > 1)
        {
            Debug.Log("Hello");
        }
    }
}
