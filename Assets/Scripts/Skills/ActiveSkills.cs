using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell", order = 51)]
public class ActiveSkills: ScriptableObject
{
    
    [Header("Имя способности")]
    [SerializeField] private string spellName;
    [Header("Описание способности")]
    [SerializeField] private string description;
    [Header("Иконка способности")]
    [SerializeField] private Sprite icon;
    [Header("Уровень открытия способности")]
    [SerializeField] private int lvlUnlock;
    [Header("Стоимость открытия способности")] 
    [SerializeField] private int goldCost;
    [Header("Перезарядка способности")]
    [SerializeField] private float spellCooldown;
    

}
