using UnityEngine;
using System.Collections;

/**
 * Provides access to GUI elements.
 */
public class GUIManager : MonoBehaviour
{
	public HumanUnitGUI humanUnitGUI;
	
	public void ShowHumanUnitGUI(HumanUnit human)
	{
		this.humanUnitGUI.human = human;
		this.humanUnitGUI.gameObject.SetActive(true);
	}
	
	public void HideHumanUnitGUI()
	{
		this.humanUnitGUI.human = null;
		this.humanUnitGUI.gameObject.SetActive(false);
	}
}
