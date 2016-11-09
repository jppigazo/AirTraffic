using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int planesCount;
    public int planesMax;
    public GameObject planeObject;

    private

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < planesCount; i++)
        {
            float radius = Random.Range(2.0f, 5.0f);
            float angle = Random.Range(-Mathf.PI, Mathf.PI);
            Instantiate(planeObject, new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0.0f), Quaternion.Euler(0.0f, 180.0f, 0.0f));
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
