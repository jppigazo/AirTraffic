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
    
    public int planesStart = 0;
    public int planesMax = 10;
    public GameObject planeObject;
    public GameObject minimapObject;
    public GameObject aeroportObject;
    public float planesSpawnRate = 0.01f;

    public int planesCount = 0;
    // Names
    int[] planesNames = new int[100];
    int tabNames = 0;

    //Altitude
    int[] altFL = new int[100];
    int altitudeStart = 400;

    public System.Collections.Generic.Dictionary<int, Destination> destinationDict = new System.Collections.Generic.Dictionary<int, Destination>();

    void InitializeDictionary()
    {
        destinationDict.Add(0, new Destination("Montpellier",new Vector3(0.0f,0.0f)));
        Instantiate(aeroportObject, new Vector3(6.75f + 0.0f/8, -3.75f + 0.0f/8), Quaternion.identity, transform);
        destinationDict.Add(1, new Destination("Lyon", new Vector3(9.0f, 4.0f)));
        Instantiate(aeroportObject, new Vector3(6.75f + 9.0f / 8, -3.75f + 4.0f / 8), Quaternion.identity, transform);
        destinationDict.Add(2, new Destination("Paris", new Vector3(-1.0f, 9f)));
        Instantiate(aeroportObject, new Vector3(6.75f - 1.0f / 8, -3.75f + 9.0f / 8), Quaternion.identity, transform);
        destinationDict.Add(3, new Destination("Toulouse", new Vector3(-9.0f, -9.0f)));
        Instantiate(aeroportObject, new Vector3(6.75f - 9.0f / 8, -3.75f - 9.0f / 8), Quaternion.identity, transform);
    }

    void spawnPlane()
    {
        int origin = (int)UnityEngine.Random.Range(0.0f, 3.9999f);

        if (DateTime.Now.Subtract(destinationDict[origin].destLastTakeOff).TotalMilliseconds > 2000)
        {
            destinationDict[origin].destLastTakeOff = DateTime.Now;

            GameObject instance = (GameObject)Instantiate(planeObject, new Vector3(destinationDict[origin].destPosition.x, destinationDict[origin].destPosition.y, 0.0f), Quaternion.Euler(0.0f, 180.0f, 0.0f));
            planesCount++;

            Instantiate(minimapObject, instance.transform);

            //Names
            instance.GetComponent<PlaneBehaviour>().planeName = String.Concat("AF-", planesNames[tabNames].ToString());
            if (tabNames < 100)
                tabNames++;
            else
                tabNames = 0;
            // Speed
            instance.GetComponent<PlaneBehaviour>().vitesse = (float)Math.Round(UnityEngine.Random.Range(950.0f, 990.0f),2);

            // Altitude
            // if spawn on 0,0 start from 0 go to FL400;
            if (origin == 0)
            {
                instance.GetComponent<PlaneBehaviour>().altitude = 0;
                instance.GetComponent<PlaneBehaviour>().altitudeOrder = 400;

                //Debug.Log("Alti depart = " + instance.GetComponent<PlaneBehaviour>().altitude);
                //Debug.Log("Alti ORDER depart = " + instance.GetComponent<PlaneBehaviour>().altitudeOrder);
            }
            else
            {
                //instance.GetComponent<PlaneBehaviour>().altitude = (int)UnityEngine.Random.Range(500.0f, 600.0f);
                instance.GetComponent<PlaneBehaviour>().altitude = altFL[(int)UnityEngine.Random.Range(0, ((altFL.Length) - 1))];
            }
            
            bool toInst = true;
            while (toInst || instance.GetComponent<PlaneBehaviour>().destination == origin)
            {
                instance.GetComponent<PlaneBehaviour>().destination = (int)UnityEngine.Random.Range(0.0f, 3.9999f);
                toInst = false;
            }
        }
    }

    // Use this for initialization
    void Start () {
        InitializeDictionary();

        // Names
        for (int i = 0; i < 100; i++)
        {
            planesNames[i] = UnityEngine.Random.Range(300, 600);
        }

        // Altitude
        for (int i = 0; i < 100; i++)
        {
            altFL[i] = altitudeStart;
            altitudeStart += 5;
            //Debug.Log(altFL[i]);
        }

        for (int i = 0; i < planesStart; i++)
        {
            if (planesCount < planesMax)
            {
                spawnPlane();
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
        if (planesCount < planesMax)
        {
            float spawnRand = UnityEngine.Random.Range(0.0f, 1.0f);
            if (spawnRand < planesSpawnRate)
            {
                spawnPlane();
            }
        }
    }
}
