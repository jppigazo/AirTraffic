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
            GameObject instance = Instantiate(planeObject, new Vector3(Random.Range())
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
