using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour {

    public BuildButton First;
    public BuildButton Second;
    public BuildButton Third;

    public BuildButton Highlighted;

	void OnEnable()
    {
        First.Highlight(true);
        Second.Highlight(false);
        Third.Highlight(false);
        Highlighted = First;
    }

    public GameObject GetTower()
    {
        return Highlighted.towerPrefab;
    }

    public void HighlightFirst()
    {
        First.Highlight(true);
        Second.Highlight(false);
        Third.Highlight(false);
        Highlighted = First;
    }

    public void HighlightSecond()
    {
        First.Highlight(false);
        Second.Highlight(true);
        Third.Highlight(false);
        Highlighted = Second;
    }

    public void HighlightThird()
    {
        First.Highlight(false);
        Second.Highlight(false);
        Third.Highlight(true);
        Highlighted = Third;
    }

    public void Confirm()
    {
        UI.Instance.Confirm();
    }

    public void ToggleRight()
    {
        if(Highlighted == First)
        {
            First.Highlight(false);
            Second.Highlight(true);
            Highlighted = Second;
        }
        else if (Highlighted == Second)
        {
            Second.Highlight(false);
            Third.Highlight(true);
            Highlighted = Third;
        }
        else if (Highlighted == Third)
        {
            Third.Highlight(false);
            First.Highlight(true);
            Highlighted = First;
        }
    }

    public void ToggleLeft()
    {
        if (Highlighted == First)
        {
            First.Highlight(false);
            Third.Highlight(true);
            Highlighted = Third;
        }
        else if (Highlighted == Second)
        {
            Second.Highlight(false);
            First.Highlight(true);
            Highlighted = First;
        }
        else if (Highlighted == Third)
        {
            Third.Highlight(false);
            Second.Highlight(true);
            Highlighted = Second;
        }
    }


}
