using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public TextMeshProUGUI upgradeCost;
    public Button upgradeButton;

    public  void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Upgraded";
            upgradeButton.interactable = false;
        }
        
        
        ui.SetActive(true);
    }

    public void hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.upgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
