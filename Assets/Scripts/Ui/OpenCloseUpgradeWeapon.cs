using System;
using UnityEngine;
using UnityEngine.Serialization;

public class OpenCloseUpgradeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject currentButton, otherButton1, otherButton2;
    [SerializeField] private GameObject upgradePanel;
    [FormerlySerializedAs("_switchWeapon")] [SerializeField] private UiWeapon uiWeapon;

    private bool activeBool;
    

    public void OpenCloseUpgradePanel()
    {
        if (activeBool == false)
        {
            activeBool = true;
            upgradePanel.SetActive(activeBool);
            //otherButton1.SetActive(!activeBool);
            //otherButton2.SetActive(!activeBool);
        }
        else
        {
            activeBool = false;
            upgradePanel.SetActive(activeBool);
            //otherButton1.SetActive(!activeBool);
            //otherButton2.SetActive(!activeBool);
        }
    }
}
