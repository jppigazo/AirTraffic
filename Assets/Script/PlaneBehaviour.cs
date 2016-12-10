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

    public string followTxt;
    

    private MeshRenderer meshRend;

    private float realSpeed;

    void movePlane()
    {
        realSpeed = vitesse / 300000; // (from 1000 km.h to 0.005 speed)

        Vector3 movement;

        if (directionOrder == -1)
        {
            movement = GameObject.Find("GameManager").GetComponent<GameManager>().destinationDict[destination].destPosition - transform.position;
        }
        else
        {
            movement = new Vector3(2 * realSpeed * (float)-Math.Sin(direction * Mathf.Deg2Rad), 2 * realSpeed * (float)Math.Cos(direction * Mathf.Deg2Rad), 0);

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
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                r.enabled = true;
        }
        else
        {
            meshRend.enabled = false;
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                r.enabled = false;
        }


        foreach (Collider col in Physics.OverlapSphere(transform.position + new Vector3(0, 0.2f, 0), 0.1f))
        {
            if (col.gameObject != gameObject && Math.Abs(col.GetComponent<PlaneBehaviour>().altitude - altitude) < 5 && Math.Abs(gameObject.transform.position.x) < 4.7f && Math.Abs(gameObject.transform.position.x) > 0.5f &&
             Math.Abs(gameObject.transform.position.y) < 4.7f && Math.Abs(gameObject.transform.position.y) > 0.5f)
            {
                GameObject.Find("LevelManager").GetComponent<LevelManager>().StopLevel();
            }
        }


        /*
                if (Math.Abs(gameObject.transform.position.x) < 4.5f && Math.Abs(gameObject.transform.position.y) < 4.5f)
                {
                    gameObject.GetComponent<SphereCollider>().enabled = true;
                }
                else
                {
                    gameObject.GetComponent<SphereCollider>().enabled = false;
                }
        */

     
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

        string infoPlane;
        //float x, y;
        if (vitesse != vitesseOrder)
        {
            vitesse += Math.Sign(vitesseOrder - vitesse)*Math.Min(Math.Abs(vitesseOrder - vitesse), 2);
           //Debug.Log("SpeedOrder = " + vitesseOrder + "/ speed = " + vitesse);
        }

        if (altitude == 0)
            altitudeOrder = 400;
        if (altitude != altitudeOrder)
        {
            altitude += Math.Sign(altitudeOrder - altitude) * Math.Min(Math.Abs(altitudeOrder - altitude), 3);
           //Debug.Log("Altitude changed on planeBehaviour");
        }
        
        if (directionOrder != -1 && direction != directionOrder)
        {
            //Debug.Log("Direction changed");
            if (Math.Abs(directionOrder - direction) < 180)
            {
                direction += Math.Sign(directionOrder - direction) * Math.Min(Math.Abs(directionOrder - direction), 1);
                //Debug.Log("Direction changed on planeBehaviour");
            } else
            {
                direction -= Math.Sign(directionOrder - direction) * Math.Min(360-Math.Abs(directionOrder - direction), 1);
                //Debug.Log("Direction changed on planeBehaviour");
            }
        }

        
        infoPlane = "";
        //infoPlane = planeName;
        //infoPlane = string.Concat("\n", infoPlane);
        infoPlane = string.Concat(altitude, infoPlane);
        infoPlane = string.Concat(" ", infoPlane);
        infoPlane = string.Concat(vitesse, infoPlane);
        infoPlane = string.Concat("\n", infoPlane);
        infoPlane = string.Concat(planeName, infoPlane);

        Debug.Log(infoPlane);

        GetComponentInChildren<TextMesh>().text = infoPlane;
        GetComponentInChildren<TextMesh>().text.Replace("\\n", "\n");
        GetComponentInChildren<TextMesh>().transform.rotation = Camera.main.transform.rotation;
        


        movePlane();

        // Collision
        if( Math.Abs(gameObject.transform.position.x) < 4.7f && Math.Abs(gameObject.transform.position.x) > 0.5f &&
             Math.Abs(gameObject.transform.position.y) < 4.7f && Math.Abs(gameObject.transform.position.y) > 0.5f )        {
            if (Physics.OverlapSphere(transform.position + new Vector3(0, 0.2f, 0), 0.2f).Length > 1)
            {
                GameObject.Find("LevelManager").GetComponent<LevelManager>().StopLevel();
            }
        }
        
    }
    
}
