using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArachnophobiaUI : MonoBehaviour {

    

    public void LoadScene()
    { 
        GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ArachnophobiaSceneBehaviour>().RpcLoadScene();
        GameObject.FindGameObjectWithTag("StreamingButton").GetComponent<Button>().interactable = true;
    }

    public void ShowSpider()
    {
        GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ArachnophobiaSceneBehaviour>().RpcShowSpider();
    }

    public void ChangeSpiderSize(Slider slider)
    {
        GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ArachnophobiaSceneBehaviour>().RpcSpiderSize(slider.value);
    }

}
