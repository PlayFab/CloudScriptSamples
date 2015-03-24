using UnityEngine;
using System.Collections;

public class UI_Base : MonoBehaviour {
	
	
	public int zDepth = 0;// distance from the camera lower # are higher in the stack
	private string tooltip = string.Empty;
	
	// Use this for initialization
	public virtual void Start () {
		//GUI.depth = zDepth;
		//Debug.Log(GUI.depth);

	}
	
	public virtual void OnGUI()
	{
		CheckAndDrawToolTip();
	}
	
	
	public void CheckAndDrawToolTip()
	{
		if(GUI.tooltip != string.Empty && this.tooltip == string.Empty)
		{
			//Debug.Log("!!!:" + GUI.tooltip + ":!!!");
			GUI.Box(new Rect(Input.mousePosition.x + 15, Screen.height-Input.mousePosition.y, GUI.tooltip.Length < 10 ? GUI.tooltip.Length * 10 : GUI.tooltip.Length * 8, 22), GUI.tooltip);
		}
		//else if(this.tooltip != string.Empty)
		//{
		// THIS TOOL TIP IS NOT WORKING WHEN OVER WINDOWS... NO IDEA WHY, WILL INVESTIGATE LATER
		//Debug.Log("!!!:" + this.tooltip + ":!!!");
		//GUI.Box(new Rect(Input.mousePosition.x + 15, Screen.height-Input.mousePosition.y, this.tooltip.Length * 7, 20), GUI.tooltip);
		//GUI.Box(new Rect(5, 5, this.tooltip.Length * 7, 20), this.tooltip);
		//}
	}
}
