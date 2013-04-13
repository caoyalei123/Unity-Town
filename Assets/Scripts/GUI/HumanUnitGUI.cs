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
		GUI.Box(new Rect(10, 10, 140, 120), "Human Unit");
		
		GUI.Label(new Rect (20, 40, 60, 20), "Name:");
		GUI.Label(new Rect (70, 40, 60, 20), this.human.name);
		
		GUI.Label(new Rect (20, 60, 60, 20), "Age:");
		GUI.Label(new Rect (70, 60, 60, 20), this.human.age.ToString());
		
		GUI.Label(new Rect (20, 80, 60, 20), "Cash:");
		GUI.Label(new Rect (70, 80, 60, 20), this.human.cash.ToString());
	}
}
