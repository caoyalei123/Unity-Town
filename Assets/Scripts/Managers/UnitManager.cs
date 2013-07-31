using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Provides access to all existing units.
 */
public class UnitManager : MonoBehaviour
{
	public int maxHumans = 10;
	
	public float spawnDelay = 2; // seconds.
	
	// The prefab all human units are instantiated from.
	public HumanUnit humanUnitPrefab;
	
	public GameObject humanUnitSpawnNode;
	
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
		
		// Prevent units colliding with each other.
		int unitLayerMask = LayerMask.NameToLayer(LayerConstants.UNITS);
		Physics.IgnoreLayerCollision(unitLayerMask, unitLayerMask);
	}
	
	public void Update()
	{
		tSpawnDelta += Time.deltaTime;
		
		if (this.GetHumanCount() < this.maxHumans)
		{
			if (tSpawnDelta >= this.spawnDelay)
			{
				this.SpawnHumanUnit();
				
				this.tSpawnDelta = 0;
			}
		}
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
	
	private void SpawnHumanUnit()
	{
		if (this.humanUnitPrefab == null)
		{
			Debug.LogError("Cannot instantiate human unit from null prefab.");
			return;
		}
		
		HumanUnit humanUnit = (HumanUnit) Instantiate(this.humanUnitPrefab,
			this.humanUnitSpawnNode.transform.position,
			this.humanUnitPrefab.transform.rotation);
		
		this.humanUnits.Add(humanUnit);
	}
}
