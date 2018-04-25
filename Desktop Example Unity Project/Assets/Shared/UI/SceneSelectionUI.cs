using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSelectionUI : MonoBehaviour {

    public GameObject arachnophobiaNetworkManagerPrefab;
    public GameObject acrophobiaNetworkManagerPrefab;

    public Button arachnophobiaButton;
    public Button acrophobiaButton;

    private LoadSceneUI loadSceneUI;

    void Start () {
        loadSceneUI = this.GetComponentInParent<LoadSceneUI>();

        arachnophobiaButton.onClick.AddListener(this.InstantiateArachnophobiaNetworkManager);
        arachnophobiaButton.onClick.AddListener(loadSceneUI.LoadArachnophobiaUI);

        acrophobiaButton.onClick.AddListener(this.InstantiateAcrophobiaNetworkManager);
        acrophobiaButton.onClick.AddListener(loadSceneUI.LoadAcrophobiaUI);
	}

    private void InstantiateArachnophobiaNetworkManager()
    {
        Instantiate(arachnophobiaNetworkManagerPrefab);
    }

    private void InstantiateAcrophobiaNetworkManager()
    {
        Instantiate(acrophobiaNetworkManagerPrefab);
    }

}
