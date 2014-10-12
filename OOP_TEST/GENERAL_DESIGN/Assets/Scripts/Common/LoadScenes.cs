using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LoadScenes : MonoBehaviour {


	void Start(){

		GetComponent<Button>().onClick.AddListener(() => { LoadScene(); });

	}



	public void LoadScene(){


		Debug.Log("HERE I M");
		Application.LoadLevel (1);
	}
}
