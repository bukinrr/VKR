using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class FireBullets : AbstractSkill
{

    [SerializeField] private int damageBonus;

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
        pistol.IncreaseDamage(this,damageBonus);

        yield return new WaitForSeconds(10f);
        
        pistol.ReduceDamage(this,damageBonus);
    }
}
