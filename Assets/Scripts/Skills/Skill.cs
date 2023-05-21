using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] private Image skillIcon;
    [SerializeField] private float skillCooldown;

    [SerializeField] private int openLvl;
    
    /*enum ActiveSKills
    {
        
    }

    enum PassiveSkills
    {
        
    }
    */

}
