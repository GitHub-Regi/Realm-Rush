using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost;
    [SerializeField] float buildDelay;

    void Start()
    {
        StartCoroutine(Build());
    }

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

    IEnumerator Build()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);

            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);

            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }
    }
}
