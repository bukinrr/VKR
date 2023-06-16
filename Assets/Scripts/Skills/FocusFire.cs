using System;
using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class FocusFire : AbstractSkill
{
    [SerializeField] private int attackSpeedBonus;
    [SerializeField] private int bulletSpeedBonus;

    private void Awake()
    {
        FillAmount = ReloadObject.GetComponent<Image>().fillAmount;
    }

    public override void ActivateSkill(RangeWeapon weapon)
    {
        if (!Reload)
        {
            UIReloadSkill();
        }
    }

    protected override void UIReloadSkill()
    {
        StartCoroutine(UiReloadSkill());
        StartCoroutine(ReloadSkill());
    }

    

    private IEnumerator UiReloadSkill()
    {
        Reload = true;
        ReloadObject.SetActive(true);

        float timer = 0f;
        while (timer < cooldown)
        {
            timer += Time.deltaTime;

            float fillAmount = timer / cooldown;
            FillAmount = 1 - fillAmount;
            yield return null;
        }
        

        ReloadObject.SetActive(false);
        Reload = false;
    }

    private IEnumerator ReloadSkill()
    {
        pistol.IncreaseAttackSpeed(this, attackSpeedBonus);
        pistol.IncreaseSpeedBullet(this, bulletSpeedBonus);

        yield return new WaitForSeconds(10f);

        pistol.ReduceAttackSpeed(this, attackSpeedBonus);
        pistol.ReduceSpeedBullet(this, bulletSpeedBonus);
    }
}