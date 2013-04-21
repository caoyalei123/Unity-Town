using UnityEngine;
using System.Collections;

/**
 * Provides access to all existing units.
 */
public class UnitManager : MonoBehaviour
{
	private GUIManager guiManager;
	
	private HumanUnit selectedHuman = null;
	
	private GameObject[] humans;
	
	public void Awake()
	{
		this.guiManager = (GUIManager) Camera.main.GetComponent("GUIManager");
		
		this.humans = GameObject.FindGameObjectsWithTag(TagConstants.HUMANS);
		
		Debug.Log("Started with " + this.GetHumanCount() + " humans.");
	}
	
	/**
	 * Selected a given human unit.
	 */
	public void SelectHuman(HumanUnit human)
	{
		this.selectedHuman = human;
		
		this.guiManager.ShowHumanUnitGUI(human);
	}
	
	/**
	 * Deselects the currently selected human unit.
	 */
	public void DeselectHuman()
	{
		if (this.selectedHuman != null)
		{
			this.selectedHuman.DeselectUnit();
			this.selectedHuman = null;
		}
		
		this.guiManager.HideHumanUnitGUI();
	}
	
	public GameObject[] GetHumans()
	{
		return this.humans;
	}
	
	public int GetHumanCount()
	{
		return this.humans.Length;
	}
}
