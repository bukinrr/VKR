using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    private bool setActive = false;

    public void OpenClosedInventory()
    {
        setActive = !setActive;
        inventory.SetActive(setActive);
    }
}