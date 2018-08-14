using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGhost : MonoBehaviour {

    public GameObject player;

    public Material green;
    public Material red;

    MeshRenderer meshRenderer;

    List<Collider> activeObstacles = new List<Collider>();
    bool isClear;

    Vector3 direction = new Vector3(1.0f, 0.0f, 0.0f);

	// Use this for initialization
	void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if(activeObstacles.Count > 0)
        {
            meshRenderer.material = red;
            isClear = false;
        } else
        {
            meshRenderer.material = green;
            isClear = true;
        }

        float x = Input.GetAxis("RightHorizontal");
        float y = Input.GetAxis("RightVertical");
        if (Mathf.Abs(x) + Mathf.Abs(y) > 0.25)
        {
            direction = new Vector3(x, 0f, y).normalized;
        }

        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        if(Mathf.Abs(mx) + Mathf.Abs(my) > 0)
        {
            Vector3 charPoint = Camera.main.WorldToScreenPoint(Player.Instance.transform.position);
            Vector3 mousePoint = Input.mousePosition;
            Vector3 dir = (mousePoint - charPoint);
            direction = new Vector3(dir.x, 0f, dir.y).normalized;
        }

        transform.position = player.transform.position + direction + Vector3.up;
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Path" || other.tag == "Tower" || other.tag == "Obstacle")
        {
            activeObstacles.Add(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (activeObstacles.Contains(other))
            activeObstacles.Remove(other);
    }

    public void Activate(bool active)
    {
        if(active && !gameObject.activeSelf)
        {
            direction = player.transform.forward;
        }
        gameObject.SetActive(active);
    }

    public bool BuildTower(GameObject towerPrefab)
    {
        if (!isClear)
            return false;

        GameObject obj = Instantiate(towerPrefab);
        obj.transform.position = transform.position;


        return true;
    }
}
