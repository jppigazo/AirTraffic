using UnityEngine;
using System.Collections;
using System;

public class Destination
{
    public string destName;
    public Vector3 destPosition;
    public DateTime destLastTakeOff;

    public Destination(string destName, Vector3 destPosition)
    {
        this.destName = destName;
        this.destPosition = destPosition;
        this.destLastTakeOff = DateTime.Now.AddSeconds(-5.0);
    }
}

public class GameManager : MonoBehaviour {

    public int planesStart;
    public int planesMax;
    public GameObject planeObject;

    public int planesCount = 0;

    public System.Collections.Generic.IDictionary<int, Destination> destinationDict;

    void InitializeDictionary()
    {
        destinationDict.Add(0, new Destination("Montpellier",new Vector3(0.0f,0.0f)));
        destinationDict.Add(1, new Destination("Lyon", new Vector3(9.0f, 4.0f)));
        destinationDict.Add(2, new Destination("Paris", new Vector3(-1.0f, 9f)));
        destinationDict.Add(3, new Destination("Toulouse", new Vector3(-9.0f, -9.0f)));
    }

<<<<<<< HEAD
    void spawnPlane()
    {
        int origin = (int)UnityEngine.Random.Range(0.0f, 3.9999f);

        if (DateTime.Now.Subtract(destinationDict[origin].destLastTakeOff).TotalMilliseconds > 2000)
        {
            GameObject instance = (GameObject)Instantiate(planeObject, new Vector3(destinationDict[origin].destPosition.x, destinationDict[origin].destPosition.y, 0.0f), Quaternion.Euler(0.0f, 180.0f, 0.0f));
            planesCount++;

            instance.GetComponent<PlaneBehaviour>().planeName = string.Concat("AF-40", planesCount);
            instance.GetComponent<PlaneBehaviour>().vitesse = UnityEngine.Random.Range(950.0f, 990.0f);
            instance.GetComponent<PlaneBehaviour>().altitude = (int)UnityEngine.Random.Range(500.0f, 600.0f);

            bool toInst = true;
            while (toInst || instance.GetComponent<PlaneBehaviour>().destination == origin)
            {
                instance.GetComponent<PlaneBehaviour>().destination = (int)UnityEngine.Random.Range(0.0f, 3.9999f);
                toInst = false;
            }

            destinationDict[origin].destLastTakeOff = DateTime.Now;
        }
    }

    // Use this for initialization
    void Start () {
        InitializeDictionary();
        

=======
    // Use this for initialization
    void Start () {
>>>>>>> origin/master
	    for (int i = 0; i < planesStart; i++)
        {
            if (planesCount < planesMax)
            {
<<<<<<< HEAD
                spawnPlane();
=======
                float radius = Random.Range(4.900f, 5.000f);
                float angle = Random.Range(-Mathf.PI, Mathf.PI);
                GameObject instance = (GameObject) Instantiate(planeObject, new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0.0f), Quaternion.Euler(0.0f, 180.0f, 0.0f));
                planesCount++;

                instance.GetComponent<PlaneBehaviour>().planeName = string.Concat("AF-40", i);
                instance.GetComponent<PlaneBehaviour>().vitesse = Random.Range(950.0f,990.0f);
                instance.GetComponent<PlaneBehaviour>().altitude = (int) Random.Range(500.0f, 600.0f);
>>>>>>> origin/master
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
        if (planesCount < planesMax)
        {
            float spawnRand = UnityEngine.Random.Range(0.0f, 1.0f);
            if (spawnRand < 0.01f)
            {
<<<<<<< HEAD
                spawnPlane();
=======
                float radius = Random.Range(3.0f, 5.0f);
                float angle = Random.Range(-Mathf.PI, Mathf.PI);
                GameObject instance = (GameObject)Instantiate(planeObject, new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0.0f), Quaternion.Euler(0.0f, 180.0f, 0.0f));
                planesCount++;

                instance.GetComponent<PlaneBehaviour>().planeName = string.Concat("AF-40", planesCount);
                instance.GetComponent<PlaneBehaviour>().vitesse = Random.Range(950.0f, 990.0f);
                instance.GetComponent<PlaneBehaviour>().altitude = (int)Random.Range(500.0f, 600.0f);
>>>>>>> origin/master
            }
        }
    }
}
