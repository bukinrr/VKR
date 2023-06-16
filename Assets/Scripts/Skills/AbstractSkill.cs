using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractSkill : MonoBehaviour
{
    [SerializeField] private Image skillImage;
    [SerializeField] private string skillName;
    [SerializeField] protected float cooldown;
    [SerializeField] protected GameObject ReloadObject;
    [SerializeField] protected RangeWeapon pistol;
    [SerializeField] protected RangeWeapon rifle;
    [SerializeField] protected RangeWeapon auto;

    protected float ReloadProgress;
    protected float FillAmount;
    protected bool Reload;

    public abstract void ActivateSkill(RangeWeapon weapon);
    protected abstract void UIReloadSkill();
}