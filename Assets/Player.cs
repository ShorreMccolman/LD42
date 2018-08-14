using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static Player Instance;
    void Awake()
    { Instance = this; }

    public TowerGhost Ghost;
    GameObject currentTowerPrefab;

	// Use this for initialization
	void Start () {
        
	}

    public void Use()
    {
        BuildTower();
    }

    public void Menu()
    {
        if (Ghost.gameObject.activeSelf)
            DeactivateGhost();
        else
            UI.Instance.OpenBuildMenu(true);
    }

    public void ActivateGhost(GameObject towerPrefab)
    {
        currentTowerPrefab = towerPrefab;
        Ghost.Activate(true);
    }

    public void DeactivateGhost()
    {
        Ghost.Activate(false);
    }

	void BuildTower ()
    {
        if(Ghost.gameObject.activeSelf)
        {

            Tower tower = currentTowerPrefab.GetComponent<Tower>();
            int cost = tower.cost;
            int currency = UI.Instance.hud.GetCurrency();

            if (cost > currency)
                return;

            bool success = Ghost.BuildTower(currentTowerPrefab);
            if (success)
            {
                UI.Instance.hud.ModifyCurrency(-cost);
                Ghost.Activate(false);
            }
        }
	}
}
