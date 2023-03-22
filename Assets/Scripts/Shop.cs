
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    public TurretBlueprint standardTurret;

    public TurretBlueprint missileLauncher;

    public TurretBlueprint laserBeamer;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.selectTurretToBuild(standardTurret);
    }

    public void selectMissileLauncher()
    {
        buildManager.selectTurretToBuild(missileLauncher);
        Debug.Log("Missile Launcher Selected");
    }

    public void selectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.selectTurretToBuild(laserBeamer);
    }
    
}
