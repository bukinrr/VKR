using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    private void Awake()
    {
        AttackType = RangeType.Melee;
    }

    protected override GameObject FindTarget()
    {
        throw new NotImplementedException();
    }

    protected override bool CanAttack(GameObject target)
    {
        throw new NotImplementedException();
    }
}
