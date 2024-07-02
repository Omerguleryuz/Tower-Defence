using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject[] towerPrefabs;
    [SerializeField] private LayerMask constructionPlotLayerMask;
    private int towerPrice = 50;


    void Update()
    {
        SelectConstructionPlot();
    }

    private void SelectConstructionPlot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, constructionPlotLayerMask))
            {
                OpenTowerMenu(hit);
                //BuildTower(GetPlotPosition(hit));
            }
        }
    }

    private void OpenTowerMenu(RaycastHit hit)
    {
        Vector3 offset = new Vector3(0, 2, 0);
        FindObjectOfType<UIManager>().towerMenu.SetActive(true);
        FindObjectOfType<UIManager>().towerMenu.transform.position = hit.transform.position + offset;
    }

    private Vector3 GetPlotPosition(RaycastHit hit)
    {
        return hit.transform.position;
    }

    public void BuildTower(Vector3 plotPosition, int towerIndex)
    {
        GoldManager goldManager = GetComponent<GoldManager>();
        UIManager uIManager = GetComponent<UIManager>();

        if (goldManager.gold >= towerPrice)
        {
            goldManager.SpendGold(towerPrice);
            uIManager.PrintGold();

            plotPosition += new Vector3(0, 0.25f, 0);
            Instantiate(towerPrefabs[towerIndex], plotPosition, Quaternion.identity);
        }
    }
}
