using TMPro;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text priceDamage,priceAttackSpeed, priceMaxAmmoMagazine,priceBulletSpeed;
    [SerializeField] private TMP_Text damageLvl, attackSpeedLvl, maxAmmoInMagazineLlv, bulletSpeedLvl;
    [SerializeField] private RangeWeapon weapon;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private int priceIncreaseAmount;

    private int _priceDamageLvl, _priceAttackSpeedLvl, _priceMaxAmmoInMagazineLvl, _priceBulletSpeedLvl;
    private int _damageLvl, _attackSpeedLvl, _maxAmmoInMagazineLvl, _bulletSpeedLvl;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _damageLvl = 1;
        _attackSpeedLvl = 1;
        _maxAmmoInMagazineLvl = 1;
        _bulletSpeedLvl = 1;
        
        _priceDamageLvl = 100;
        _priceAttackSpeedLvl = 100;
        _priceMaxAmmoInMagazineLvl = 100;
        _priceBulletSpeedLvl = 100;

        priceDamage.text = _priceDamageLvl.ToString();
        priceAttackSpeed.text = _priceAttackSpeedLvl.ToString();
        priceMaxAmmoMagazine.text = _priceMaxAmmoInMagazineLvl.ToString();
        priceBulletSpeed.text = _priceBulletSpeedLvl.ToString();
        
    }

    public void CallDamageUp(int valueDamageUp)
    {
        DamageUp(valueDamageUp);
    }
    public void CallAttackSpeedUp(int valueAttackSpeedUp)
    {
        AttackSpeedUp(valueAttackSpeedUp);
    }
    public void CallMaxAmmoInMagazineUp(int valueAddMaxAmmoUp)
    {
        MaxAmmoInMagazineUp(valueAddMaxAmmoUp);
    }
    public void CallBulletSpeedUp(int valueBulletSpeedUp)
    {
        BulletSpeedUp(valueBulletSpeedUp);
    }

    private void DamageUp(int damageUp)
    {
        if (resourceManager.ReduceCoins(_priceDamageLvl))
        {
            resourceManager.ReduceCoins(_priceDamageLvl);
            _priceDamageLvl += priceIncreaseAmount;
            weapon.IncreaseDamage(this, damageUp);
            _damageLvl++;
            damageLvl.text = _damageLvl.ToString();
            priceDamage.text = _priceDamageLvl.ToString();
        }
    }
    private void AttackSpeedUp(int attackSpeedUp)
    {
        if (resourceManager.ReduceCoins(_priceAttackSpeedLvl))
        {
            resourceManager.ReduceCoins(_priceAttackSpeedLvl);
            _priceAttackSpeedLvl += priceIncreaseAmount;
            weapon.IncreaseAttackSpeed(this, attackSpeedUp);
            _attackSpeedLvl++;
            attackSpeedLvl.text = _attackSpeedLvl.ToString();
            priceAttackSpeed.text = _priceAttackSpeedLvl.ToString();
        }
    }
    private void MaxAmmoInMagazineUp(int ammoUp)
    {
        if (resourceManager.ReduceCoins(_priceMaxAmmoInMagazineLvl))
        {
            resourceManager.ReduceCoins(_priceMaxAmmoInMagazineLvl);
            _priceMaxAmmoInMagazineLvl += priceIncreaseAmount;
            
            weapon.IncreaseMaxCountBulletInMagazine(this, ammoUp);
            weapon.UpdateUIAmmoString();
            
            _maxAmmoInMagazineLvl++;
            maxAmmoInMagazineLlv.text = _maxAmmoInMagazineLvl.ToString();
            priceMaxAmmoMagazine.text = _priceMaxAmmoInMagazineLvl.ToString();
        }
    }
    private void BulletSpeedUp(int bulletSpeedUp)
    {
        if (resourceManager.ReduceCoins(_priceBulletSpeedLvl))
        {
            resourceManager.ReduceCoins(_priceBulletSpeedLvl);
            _priceBulletSpeedLvl += priceIncreaseAmount;
            weapon.IncreaseSpeedBullet(this, bulletSpeedUp);
            _bulletSpeedLvl++;
            bulletSpeedLvl.text = _bulletSpeedLvl.ToString();
            priceBulletSpeed.text = _priceBulletSpeedLvl.ToString();
        }
    }
}
