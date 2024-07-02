using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text goldText;
    public GameObject towerMenu;
    private GoldManager goldManager;
    
    private enum Tower
    {
        gun,
        rocket,
        bombard
    }
    
    void Start()
    {
        goldManager = GetComponent<GoldManager>();

        PrintGold();
    }

    public void PrintGold()
    {
        goldText.text = goldManager.gold.ToString();
    }

    public void SelectTowerToBuild(int towerIndex)
    {
        Vector3 buildPosition = towerMenu.transform.position += new Vector3
            (0, -2, 0);
        FindObjectOfType<Builder>().BuildTower(buildPosition, towerIndex);

        towerMenu.SetActive(false);
    }
}
