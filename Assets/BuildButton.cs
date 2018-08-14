using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour {

    public Image BG;
    public GameObject towerPrefab;

	public void Highlight(bool isLit)
    {
        BG.sprite = isLit ? UI.Instance.buttonHighlightedSprite : UI.Instance.buttonSprite;
    }
}
