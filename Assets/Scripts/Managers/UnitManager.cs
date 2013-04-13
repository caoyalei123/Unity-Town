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
		
		Debug.Log("Started with " + this.getHumanCount() + " humans.");
	}
	
	/**
	 * Selected a given human unit.
	 */
	public void selectHuman(HumanUnit human)
	{
		this.selectedHuman = human;
		
		this.guiManager.showHumanUnitGUI(human);
	}
	
	/**
	 * Deselects the currently selected human unit.
	 */
	public void deselectHuman()
	{
		if (this.selectedHuman != null)
		{
			this.selectedHuman.deselectUnit();
			this.selectedHuman = null;
		}
		
		this.guiManager.hideHumanUnitGUI();
	}
	
	public GameObject[] getHumans()
	{
		return this.humans;
	}
	
	public int getHumanCount()
	{
		return this.humans.Length;
	}
}
