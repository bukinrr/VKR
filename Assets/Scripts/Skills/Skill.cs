using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    public virtual AttributeSkill _attributeSkill { get; set; }

    public virtual void ActivateSkill()
    {
        Debug.Log("Activate");
    }
}
