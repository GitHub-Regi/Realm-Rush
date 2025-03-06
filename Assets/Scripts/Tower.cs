using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost;

    public bool CreateTower(Tower tower, UnityEngine.Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, UnityEngine.Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }
}
