using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [HideInInspector] public int gold;

    private void Start()
    {
        gold = 100;
    }

    public void SpendGold(int amount)
    {
        gold -= amount;
    }

    public void EarnGold(int amount)
    {
        gold += amount;
    }
}
