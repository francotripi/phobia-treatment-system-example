using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneUI : MonoBehaviour {

    public GameObject arachnophobiaUIPrefab;
    public GameObject acrophobiaUIPrefab;
    public GameObject sceneSelectionPrefab;

    public Button resetUIButton;
    public RawImage streamingRawImage;

    private GameObject sceneControlPanel;
    private GameObject sceneSelection;
    private GameObject arachnophobiaUI;
    private GameObject acrophobiaUI;

    private void Start()
    {
        sceneControlPanel = GameObject.Find("SceneControlPanel");
        sceneSelection = GameObject.Find("SceneSelection");
    }

    public void LoadArachnophobiaUI()
    {
        Destroy(sceneSelection);
        arachnophobiaUI = Instantiate(arachnophobiaUIPrefab, sceneControlPanel.transform);
        resetUIButton.interactable = true;
    }

    public void LoadAcrophobiaUI()
    {
        Destroy(sceneSelection);
        acrophobiaUI = Instantiate(acrophobiaUIPrefab, sceneControlPanel.transform);
        resetUIButton.interactable = true;
    }

    public void ResetUI()
    {   
        if(arachnophobiaUI != null)
            Destroy(arachnophobiaUI);
        if (acrophobiaUI != null)
            Destroy(acrophobiaUI);

        if (sceneSelection == null)
            sceneSelection = Instantiate(sceneSelectionPrefab, sceneControlPanel.transform);

        resetUIButton.interactable = false;
        streamingRawImage.texture = null;
        Destroy(GameObject.FindGameObjectWithTag("NetworkManager"));
        Destroy(GameObject.FindGameObjectWithTag("SceneManager"));
    }
}
