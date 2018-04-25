using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcrophobiaUI : MonoBehaviour {

    private bool balconyFloorHidden = false;
    private bool balconyWallsHidden = false;

    private AcrophobiaSceneBehaviour acrophobiaScene;

    public void LoadScene()
    {
        acrophobiaScene = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<AcrophobiaSceneBehaviour>();
        acrophobiaScene.RpcLoadScene();
        GameObject.FindGameObjectWithTag("StreamingButton").GetComponent<Button>().interactable = true;
    }

    public void Floor()
    {
        if (!balconyFloorHidden)
        {
            acrophobiaScene.RpcHideFloor();
            balconyFloorHidden = true;            
        }
        else
        {
            acrophobiaScene.RpcShowFloor();
            balconyFloorHidden = false;         
        } 
    }

    public void Rail()
    {
        if (!balconyWallsHidden)
        {
            acrophobiaScene.RpcHideRail();
            balconyWallsHidden = true;         
        }
        else
        {
            acrophobiaScene.RpcShowRail();
            balconyWallsHidden = false;       
        }   
    }

    public void ChangeBuildingHeight(Slider slider)
    {
        acrophobiaScene.RpcBuildingHeight(slider.value);
        GameObject.FindGameObjectWithTag("BuildingHeightText").GetComponent<Text>().text = "Number of floors: " + slider.value;
    }

}
