using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor = Color.red;
    public Vector3 offset;
    
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    
    private Color startColor;
    private Renderer rend;

    private BuildManager buildManager;
   

    // Start is called before the first frame update
    void Start()
    {
        turret = null;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        
        if (turret != null)
        {
            //Debug.Log("Cant build there - TODO display on screen");
            buildManager.selectNodeToBuild(this);
            return;
        }
        //build a turret
        

        if (!buildManager.canBuild)
        {
            return;
        }
        BuildTurret(buildManager.getTurretToBuild());
        //buildManager.buildTurretOn(this);
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.money -= blueprint.cost;
        GameObject _turret = (GameObject) Instantiate(blueprint.prefab,GetBuildPosition(),Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject) Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect,5f);
        
        Debug.Log($"Turret build. ");
    }

    public void upgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeCost;
        
        //get rid of the old turret
        Destroy(turret);
        
        //building a new turret
        GameObject _turret = (GameObject) Instantiate(turretBlueprint.upgradedPrefab,GetBuildPosition(),Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject) Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect,5f);
        
        isUpgraded = true;
        
        
        Debug.Log($"Turret upgraded.");
    }
    
    private void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.canBuild)
        {
            return;
        }

        if (buildManager.hasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    private void OnMouseExit()
    {
        
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
