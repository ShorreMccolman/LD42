using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {


	void Start () {
		
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            if (UI.Instance.IsMenuOpen())
            {
                UI.Instance.Decline();
            }
            else
            {
                Player.Instance.Menu();
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if(UI.Instance.IsMenuOpen())
            {
                UI.Instance.Confirm();
            } else
            {
                Player.Instance.Use();
            }
        }
    }
}
