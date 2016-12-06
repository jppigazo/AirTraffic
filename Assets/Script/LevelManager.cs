using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject GameManager;
    public GameObject DiffChoice;

    // Use this for initialization
    void Start () {
        //StartLevel();
        DiffChoice = GameObject.Find("DifficultyTxt");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StopLevel()
    {
        Destroy(GameObject.Find("GameManager"));
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Avion"))
        {
            Destroy(go);
        }
        DiffChoice.SetActive(true);
    }

    public void StartLevel(int planesMax, float planesSpawnRate)
    {
        GameObject instance = Instantiate(GameManager);
        instance.name = "GameManager";
        instance.GetComponent<GameManager>().planesMax = planesMax;
        instance.GetComponent<GameManager>().planesSpawnRate = planesSpawnRate;
        DiffChoice.SetActive(false);
    }

    public void EasyStart()
    {
        StartLevel(10, 0.01f);
    }

    public void MedStart()
    {
        StartLevel(15, 0.01f);
    }

    public void HardStart()
    {
        StartLevel(25, 0.01f);
    }
}
