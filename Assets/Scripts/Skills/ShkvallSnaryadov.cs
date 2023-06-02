using System.Collections;
using Google.Protobuf.WellKnownTypes;
using UnityEngine;


public class ShkvallSnaryadov : Skill
{
    [SerializeField] private int bonusAttackSpeed;
    [SerializeField] private int bonusBulletSpeed;
    [SerializeField] private float timeDuration;
    [SerializeField] private float timeReload;
    [SerializeField] private Bullet _bullet;
    private RangeWeapon _rangeWeapon;
    

    [SerializeField] private AttributeSkill _attribute;
    public override AttributeSkill _attributeSkill
    {
        get => _attributeSkill;
        set { _attributeSkill = value; }
    }

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        _rangeWeapon = GetComponent<RangeWeapon>();
    }

    public override void ActivateSkill()
    {
        StartCoroutine(IEIncreaseAttackAndBulletSpeed());
    }

    private IEnumerator IEIncreaseAttackAndBulletSpeed()
    {
        _rangeWeapon.IncreaseAttackSpeed(this, bonusAttackSpeed);
        _bullet.IncreaseSpeedBullet(this, bonusBulletSpeed);
        yield return timeDuration;
        _rangeWeapon.ReduceAttackSpeed(this, bonusAttackSpeed);
        _bullet.ReduceSpeedBullet(this, bonusBulletSpeed);
        yield return timeReload;
    }
}