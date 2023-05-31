using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectionMenu : MonoBehaviour
{
    public Skill[] availableSkills;
    public GameObject skillButtonPrefab;
    public Transform skillButtonContainer;

    private void Start()
    {
        // Создайте кнопки для каждой доступной способности и поместите их в контейнер
        foreach (Skill skill in availableSkills)
        {
            GameObject buttonObject = Instantiate(skillButtonPrefab, skillButtonContainer);
            Button button = buttonObject.GetComponent<Button>();

            // Прикрепите обработчик события для нажатия кнопки, чтобы активировать способность
            button.onClick.AddListener(() => ActivateSkill(skill));
        }
    }

    private void ActivateSkill(Skill skill)
    {
        // Активируйте выбранную способность
        skill.ActivateSkill();
    }
}
