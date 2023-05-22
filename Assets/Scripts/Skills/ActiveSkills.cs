using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveSkills : MonoBehaviour
{
    public bool Cast = false;
    public int SkillID = 0;


    [SerializeField] public List<Skill> Skills;
    [SerializeField] private GameObject selectCircle = null;


    private Ray p_ray;
    private RaycastHit p_hit;
    private Camera p_camera = null;

    private PlayerController _playerController;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _playerController = GetComponent<PlayerController>();
        p_camera = Camera.main;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            SkillID = 0;
            Skills[SkillID].ActivateSkill();
            Cast = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            SkillID = 1;
            Cast = true;
        }

        if (Input.GetKey(KeyCode.E))
        {
            SkillID = 2;
            Cast = true;
        }


        // if (Cast)
        // {
        //     if (rayMousePostiton("Terrain"))
        //     {
        //         selectCircle.transform.position = new Vector3(p_hit.point.x, p_hit.point.y + 0.5f, p_hit.point.z);
        //         selectCircle.SetActive(true);
        //     }
        //
        //     if (Input.GetMouseButton(1))
        //     {
        //         Cast = false;
        //         selectCircle.SetActive(false);
        //     }
        //
        //     if (Input.GetMouseButton(0))
        //     {
        //         Skills[SkillID].ActivateSkill();
        //     }
        // }
        // else
        // {
        //     selectCircle.SetActive(false);
        // }
    }

    private bool rayMousePostiton(string tag)
    {
        p_ray = p_camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(p_ray, out p_hit) && p_hit.collider.CompareTag(tag))
        {
            return true;
        }

        return false;
    }
    
}