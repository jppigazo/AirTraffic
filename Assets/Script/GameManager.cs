using UnityEngine;
using System.Collections;

public class Destination
{
    public string destName;
    public Vector3 destPosition;

    public Destination(string destName, Vector3 destPosition)
    {
        this.destName = destName;
        this.destPosition = destPosition;
    }
}

public class GameManager : MonoBehaviour {

    public int planesStart;
    public int planesMax;
    public GameObject planeObject;

    public int planesCount = 0;

    public System.Collections.Generic.Dictionary<int, Destination> destinationDict = new System.Collections.Generic.Dictionary<int, Destination>();

    void InitializeDictionary()
    {
        destinationDict.Add(0, new Destination("Montpellier",new Vector3(0.0f,0.0f)));
        destinationDict.Add(1, new Destination("Lyon", new Vector3(4.5f, 2.0f)));
        destinationDict.Add(2, new Destination("Paris", new Vector3(-1.0f, 4.5f)));
        destinationDict.Add(3, new Destination("Toulouse", new Vector3(-4.5f, -4.5f)));
    }

    // Use this for initialization
    void Start () {
        InitializeDictionary();

        for (int i = 0; i < 4; i++)
        {
            Debug.Log(destinationDict[0].destPosition.x);
        }
        

	    for (int i = 0; i < planesStart; i++)
        {
            if (planesCount < planesMax)
            {
                float radius = Random.Range(2.0f, 5.0f);
                float angle = Random.Range(-Mathf.PI, Mathf.PI);
                GameObject instance = (GameObject) Instantiate(planeObject, new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0.0f), Quaternion.Euler(0.0f, 180.0f, 0.0f));
                planesCount++;

                instance.GetComponent<PlaneBehaviour>().planeName = string.Concat("AF-40", i);
                instance.GetComponent<PlaneBehaviour>().vitesse = Random.Range(950.0f,990.0f);
                instance.GetComponent<PlaneBehaviour>().altitude = (int) Random.Range(500.0f, 600.0f);
                instance.GetComponent<PlaneBehaviour>().destination = (int)Random.Range(0.0f, 3.9999f);
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
        if (planesCount < planesMax)
        {
            float spawnRand = Random.Range(0.0f, 1.0f);
            if (spawnRand < 0.01f)
            {
                float radius = Random.Range(3.0f, 5.0f);
                float angle = Random.Range(-Mathf.PI, Mathf.PI);
                GameObject instance = (GameObject)Instantiate(planeObject, new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0.0f), Quaternion.Euler(0.0f, 180.0f, 0.0f));
                planesCount++;

                instance.GetComponent<PlaneBehaviour>().planeName = string.Concat("AF-40", planesCount);
                instance.GetComponent<PlaneBehaviour>().vitesse = Random.Range(950.0f, 990.0f);
                instance.GetComponent<PlaneBehaviour>().altitude = (int)Random.Range(500.0f, 600.0f);
                instance.GetComponent<PlaneBehaviour>().destination = (int)Random.Range(0.0f, 4.9999f);
            }
        }
    }
}
