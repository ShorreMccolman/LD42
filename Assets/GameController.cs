using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public List<GameObject> Obstacles = new List<GameObject>();

	// Use this for initialization
	void Start () {

        for (int i = 0; i < Obstacles.Count; i++)
        {
            GameObject temp = Obstacles[i];
            int randomIndex = Random.Range(i, Obstacles.Count);
            Obstacles[i] = Obstacles[randomIndex];
            Obstacles[randomIndex] = temp;
        }

        for (int i = 0; i < Obstacles.Count; i++)
        {
            Obstacles[i].SetActive(i < 5);
        }
    }

        // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	}
}
