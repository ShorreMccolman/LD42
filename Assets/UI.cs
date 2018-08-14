using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI Instance;
    void Awake()
    {
        Instance = this;
    }

    public Sprite buttonSprite;
    public Sprite buttonHighlightedSprite;

    bool buildMenuOpen;
    public BuildMenu buildMenu;

    public HUD hud;

    float cooldown;

    public bool IsMenuOpen()
    {
        return buildMenuOpen;
    }

    public void Confirm()
    {
        if (buildMenuOpen)
        {
            Player.Instance.ActivateGhost(buildMenu.GetTower());
            OpenBuildMenu(false);
        }
    }

    public void Decline()
    {
        if (buildMenuOpen)
            OpenBuildMenu(false);
    }

    public void OpenBuildMenu(bool open)
    {
        buildMenuOpen = open;
        buildMenu.gameObject.SetActive(buildMenuOpen);
    }

    void Update()
    {
        if(buildMenuOpen)
        {
            buildMenu.transform.position = Camera.main.WorldToScreenPoint(Player.Instance.transform.position) + Vector3.up * 25;
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            return;
        }

        if (!buildMenuOpen)
            return;

        float horz = Input.GetAxis("RightHorizontal");
        if (horz > 0.5)
        {
            buildMenu.ToggleRight();
            cooldown = 0.25f;
        }
        else if (horz < -0.5)
        {
            buildMenu.ToggleLeft();
            cooldown = 0.25f;
        }
    }
}