using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject GameManager;
    public GameObject DiffChoice;
    public GameObject GameOverText;

    // Use this for initialization
    void Start () {
        //StartLevel();
        DiffChoice = GameObject.Find("DifficultyTxt");
        GameOverText = GameObject.Find("GameOver");
        GameObject.Find("GameOver").SetActive(false);

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

        GameOverText.SetActive(true);
        DiffChoice.SetActive(true);
    }

    public void StartLevel(int planesMax, float planesSpawnRate)
    {
        GameObject instance = Instantiate(GameManager);
        instance.name = "GameManager";
        instance.GetComponent<GameManager>().planesMax = planesMax;
        instance.GetComponent<GameManager>().planesSpawnRate = planesSpawnRate;
        DiffChoice.SetActive(false);
        if(GameOverText.activeSelf)
            GameObject.Find("GameOver").SetActive(false);
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
