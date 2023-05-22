using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpellHUD : MonoBehaviour
{
    public List<Image> slotsIcon;
    public List<Image> reloadsIcon;

    private ActiveSkills _activeSkills;

    private void Start()
    {
        _activeSkills = GameObject.FindGameObjectWithTag("Player").GetComponent<ActiveSkills>();
        //var skills = _activeSkills.Skills();
        // for (int i = 0; i < _activeSkills.Skills.Count; i++)
        // {
        //     slotsIcon[i].sprite = _activeSkills.Skills[i]._attributeSkill.skillIcon;
        // }
    }
}
