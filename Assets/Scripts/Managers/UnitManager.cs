using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Provides access to all existing units.
 */
public class UnitManager : MonoBehaviour
{
	public int maxHumans = 10;
	
	public float spawnRate = 1; // seconds.
	
	// The prefab all human units are instantiated from.
	public HumanUnit humanUnitPrefab;
	
	private GUIManager guiManager;
	
	private HumanUnit selectedHuman = null;
	
	private List<HumanUnit> humanUnits = new List<HumanUnit>();
	
	private float tSpawnDelta;
	
	public void Awake()
	{
		this.guiManager = (GUIManager) Camera.main.GetComponent("GUIManager");
		
		// Detect and parse any existing human units.
		
		GameObject[] humanUnitObjects = GameObject.FindGameObjectsWithTag(TagConstants.HUMANS);
		
		if (humanUnitObjects != null)
		{
			HumanUnit currentHumanUnit;
			
			for (int i = 0; i < humanUnitObjects.Length; i++)
			{
				currentHumanUnit = (HumanUnit) humanUnitObjects[i].GetComponent("HumanUnit");
				
				if (currentHumanUnit != null)
				{
					this.humanUnits.Add(currentHumanUnit);
				}
				else
				{
					Debug.LogError("Game Object " + humanUnitObjects[i].name + " is missing HumanUnit component.");
				}
			}
		}
		
		Debug.Log("Started with " + this.GetHumanCount() + " human units.");
	}
	
	public void Update()
	{
		
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
	
	public List<HumanUnit> GetHumans()
	{
		return this.humanUnits;
	}
	
	public int GetHumanCount()
	{
		return this.humanUnits.Count;
	}
}
