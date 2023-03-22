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
    
    [Header("Optional")]
    public GameObject turret;
    
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
        if (!buildManager.canBuild)
        {
            return;
        }
        
        if (turret != null)
        {
            Debug.Log("Cant build there - TODO display on screen");
            return;
        }
        //build a turret
        buildManager.buildTurretOn(this);

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
