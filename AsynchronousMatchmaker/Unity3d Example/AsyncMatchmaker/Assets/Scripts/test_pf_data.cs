using UnityEngine;
using System.Collections;


public class test_pf_data : MonoBehaviour {
	//public PlayFabData dataObj;
	public bool setDDOL = true;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		if(GUILayout.Button("CHANGE SCENE"))
		{
			if(this.setDDOL == true)
			{
				DontDestroyOnLoad(this.gameObject);
			}
			Application.LoadLevel("second");
		}
	}
}
