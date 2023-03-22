using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    
    public GameObject buildEffect;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one buildManager in scene!");
            return;
        }
        
        instance = this;
    }

    
    private TurretBlueprint turretToBuild;
    
    /*
    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
    */
    

    public void selectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public bool canBuild
    {
        get { return turretToBuild != null; }
    }

    public bool hasMoney
    {
        get { return PlayerStats.money >= turretToBuild.cost; }
    }

    public void buildTurretOn(Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;
        GameObject Turret = (GameObject) Instantiate(turretToBuild.prefab,node.GetBuildPosition(),Quaternion.identity);
        node.turret = Turret;

        GameObject effect = (GameObject) Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect,5f);
        
        Debug.Log($"Turret build. Money left: {PlayerStats.money}");
    }
    
}
    


