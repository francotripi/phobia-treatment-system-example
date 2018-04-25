using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AcrophobiaSceneBehaviour : NetworkBehaviour{

    private MeshRenderer BalconyFloorMeshRenderer;
    private MeshRenderer[] BalconyWallsMeshRenderer;
    private BuildingHeight MainBuildingHeight;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    [ClientRpc]
    public void RpcLoadScene()
    {
        SceneManager.LoadScene("World");
    }
    
    [ClientRpc]
    public void RpcShowFloor()
    {
        if(BalconyFloorMeshRenderer == null)
        {
            BalconyFloorMeshRenderer = GameObject.FindGameObjectWithTag("BalconyFloor").GetComponent<MeshRenderer>();
        }
        BalconyFloorMeshRenderer.enabled = true;
    }

    [ClientRpc]
    public void RpcHideFloor()
    {
        if (BalconyFloorMeshRenderer == null)
        {
            BalconyFloorMeshRenderer = GameObject.FindGameObjectWithTag("BalconyFloor").GetComponent<MeshRenderer>();
        }
        BalconyFloorMeshRenderer.enabled = false;
    }

    [ClientRpc]
    public void RpcShowRail()
    {
        if(BalconyWallsMeshRenderer == null)
        { 
            BalconyWallsMeshRenderer = GameObject.FindGameObjectWithTag("BalconyRail").GetComponentsInChildren<MeshRenderer>();
        }
        foreach (MeshRenderer wallMeshRenderer in BalconyWallsMeshRenderer)
        {
            wallMeshRenderer.enabled = true;
        }
    }

    [ClientRpc]
    public void RpcHideRail()
    {
        if (BalconyWallsMeshRenderer == null)
        {
            BalconyWallsMeshRenderer = GameObject.FindGameObjectWithTag("BalconyRail").GetComponentsInChildren<MeshRenderer>();
        }
        foreach (MeshRenderer wallMeshRenderer in BalconyWallsMeshRenderer)
        {
            wallMeshRenderer.enabled = false;
        }
    }

    [ClientRpc]
    public void RpcBuildingHeight(float value)
    {
        if(MainBuildingHeight == null)
        {
            MainBuildingHeight = GameObject.FindGameObjectWithTag("MainBuilding").GetComponent<BuildingHeight>();
        }
        MainBuildingHeight.SetCantFloors((int)value);
    }
}
