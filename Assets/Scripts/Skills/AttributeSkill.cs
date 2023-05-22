using System.Net.NetworkInformation;
using UnityEngine;

[CreateAssetMenu(fileName = "Attribute", menuName = "Spell/SpellAttribute")]
public class AttributeSkill : ScriptableObject
{
    [Header("Ui")] 
    [SerializeField] private string skillName;
    [SerializeField] public Sprite skillIcon;

    [Header("Attribute")] 
    [SerializeField] private float skillCooldown;
    [SerializeField] private int openLvl;
    [SerializeField] private int price;
    
}