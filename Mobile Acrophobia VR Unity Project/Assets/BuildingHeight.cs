using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHeight : MonoBehaviour {

	public Transform baseCube;
	public Transform mainRoom; 

	public int baseCubeYScale;

	void Start () {
		baseCubeYScale = 0;
		LocateMainRoom ();
	}

	public void SetCantFloors(int floors){
			baseCubeYScale = floors - 1;
			LocateMainRoom ();
			LocatePlayer (baseCubeYScale * 3f);
	}

	private void LocateMainRoom(){
		mainRoom.transform.localPosition = new Vector3 (baseCube.localPosition.x, 
			baseCubeYScale * 3f, 
			baseCube.localPosition.z);
	}
    
	private void LocatePlayer(float yPosition){
        //GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerPosition> ().OnBuildingChangeHeight (yPosition);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float playerHeight = player.transform.localScale.y;
        player.transform.localPosition = new Vector3(player.transform.localPosition.x, mainRoom.transform.position.y + playerHeight, player.transform.localPosition.z);
    }
		
}
