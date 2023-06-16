using System;
using UnityEngine;

public class UiWeapon : MonoBehaviour
{
    [SerializeField] private GameObject pistol, rifle, auto;
    [SerializeField] private GameObject rifleBlockPanel;
    [SerializeField] private GameObject autoBlockPanel;
    [SerializeField] private GameObject rifleButtonUpgrade;
    [SerializeField] private GameObject autoButtonUpgrade;
    [SerializeField] private GameObject rifleMagazineText;
    [SerializeField] private GameObject autoMagazineText;
    
    public bool pistolUnlock, rifleUnlock, autoUnlock;
    private LevelSystem _levelSystem;
    
    private GameObject[] _weapons;
    private Coroutine[] _weaponCoroutines;

    private void Awake()
    {
        _weapons = new[] { pistol, rifle, auto };
        _weaponCoroutines = new Coroutine[_weapons.Length];

    }

    private void Update()
    {
        SwitchWeapons();
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        _levelSystem = levelSystem;
        _levelSystem.OnLevelChanged += CheckUnlockWeapon;
    }

    private void CheckUnlockWeapon(object sender, EventArgs e)
    {
        foreach (var weapon in _weapons)
        {
            if (_levelSystem.Level == weapon.GetComponent<RangeWeapon>().LvlUnlock)
            {
                switch (weapon.name)
                {
                    case "Rifle":
                    {
                        rifleUnlock = true;
                        rifleBlockPanel.SetActive(false);
                        rifleButtonUpgrade.SetActive(true);
                        rifleMagazineText.SetActive(true);
                        return;
                    }
                    case "Automat":
                    {
                        autoUnlock = true;
                        autoBlockPanel.SetActive(false);
                        autoButtonUpgrade.SetActive(true);
                        autoMagazineText.SetActive(true);
                        return;
                    }
                }
            }
        }
    }

    public void SwitchWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Нажал на 1");
            if (!pistol.activeSelf)
            {
                // foreach (var weapon in _weapons)
                // {
                //     weapon.GetComponent<RangeWeapon>().StopAllCoroutines();
                //     weapon.SetActive(false);
                // }
                
                StopCurrentWeaponCoroutine();
                pistol.SetActive(true);
            } 
            else if (pistol.activeSelf && (rifle.activeSelf || auto.activeSelf))
            {
                rifle.SetActive(false);
                auto.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && rifle.GetComponent<RangeWeapon>().LvlUnlock <=_levelSystem.Level)
        {
            Debug.Log("Нажал на 2");
            if (!rifle.activeSelf)
            {
                // foreach (var weapon in _weapons)
                // {
                //     weapon.GetComponent<RangeWeapon>().StopAllCoroutines();
                //     weapon.SetActive(false);
                // }
                
                StopCurrentWeaponCoroutine();
                rifle.SetActive(true);
            } 
            else if (rifle.activeSelf && (pistol.activeSelf || auto.activeSelf))
            {
                pistol.SetActive(false);
                auto.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && rifle.GetComponent<RangeWeapon>().LvlUnlock <=_levelSystem.Level)
        {
            Debug.Log("Нажал на 3");

            if (!auto.activeSelf)
            {
                // foreach (var weapon in _weapons)
                // {
                //     weapon.GetComponent<RangeWeapon>().StopAllCoroutines();
                //     weapon.SetActive(false);
                // }
                
                StopCurrentWeaponCoroutine();
                auto.SetActive(true);
            } 
            else if (auto.activeSelf && (pistol.activeSelf || rifle.activeSelf))
            {
                pistol.SetActive(false);
                rifle.SetActive(false);
            }
        }
    }
    
    private void StopCurrentWeaponCoroutine()
    {
        foreach (var coroutine in _weaponCoroutines)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
        }
    }
}