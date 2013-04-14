using UnityEngine;
using System.Collections;

/**
 * Displays information about a human unit.
 */
public class HumanUnitGUI : MonoBehaviour
{
	public HumanUnit human;
	
	public void OnGUI()
	{
		GUI.Box(new Rect(10, 10, 200, 120), "Human Unit");
		
		GUI.DrawTexture(new Rect (20, 40, 50, 50), this.human.previewTexture);
		
		GUI.Label(new Rect (90, 40, 60, 20), "Name:");
		GUI.Label(new Rect (140, 40, 60, 20), this.human.name);
		
		GUI.Label(new Rect (90, 60, 60, 20), "Age:");
		GUI.Label(new Rect (140, 60, 60, 20), this.human.age.ToString());
		
		GUI.Label(new Rect (90, 80, 60, 20), "Cash:");
		GUI.Label(new Rect (140, 80, 60, 20), this.human.cash.ToString());
	}
}
