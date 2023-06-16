using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : Character
{
    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject rifle;
    [SerializeField] private GameObject auto;
    private GameObject[] _weapons;

    private UiWeapon _uiWeapon;
    //private RangeWeapon _rangeWeapon;


    void Start()
    {
        Init();
    }

    void Update()
    {
        //_rangeWeapon.LaunchShoot();
        DestroyPlayer();
        _uiWeapon.SwitchWeapons();
        ChangeWeapon();
    }

    protected override void Init()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _weapons = new[] { pistol, rifle, auto };
        //_rangeWeapon = GetComponentInChildren<RangeWeapon>();
        _uiWeapon = FindObjectOfType<UiWeapon>().GetComponent<UiWeapon>();
    }

    private void DestroyPlayer()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }

    private void ChangeWeapon()
    {
        foreach (var weapon in _weapons)
        {
            if (weapon.activeSelf)
            {
                var activeWeapon = weapon.GetComponent<RangeWeapon>();
                activeWeapon.LaunchShoot();
            }
        }
    }
}