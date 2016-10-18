using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buttons : MonoBehaviour {

	public void HandleButton(string button_name){
		switch (button_name) {
		case "level 1":
			Application.LoadLevel ("Player Controls");
			break;
		}
	}

}
