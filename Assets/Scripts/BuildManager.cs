using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    
    public GameObject buildEffect;
    public NodeUI nodeUI;
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
    private Node selectedNode;
    
    /*
    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
    */
    

    public void selectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint getTurretToBuild()
    {
        return turretToBuild;
    }

    public void selectNodeToBuild(Node node)
    {

        if (node == selectedNode)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.hide();
    }
    public bool canBuild
    {
        get { return turretToBuild != null; }
    }

    public bool hasMoney
    {
        get { return PlayerStats.money >= turretToBuild.cost; }
    }

    
    
}
    


