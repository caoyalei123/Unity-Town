using UnityEngine;
using System.Collections;

/**
 * Represents a shop location.
 * Shop locations remove cash from units.
 */
public class ShopLocation : BuildingLocation
{
	public int interactionCost = 20;
	
	public void Awake()
	{
		// TODO: Move stat buffs / other location data into JSON file.
		
		this.unitStatBuffs = new System.Collections.Generic.Dictionary<string, float>();
		this.unitStatBuffs.Add(UnitStatConstants.ENERGY, -5);
		this.unitStatBuffs.Add(UnitStatConstants.MOOD, 10);
	}
	
	public override void Start()
	{
		base.Start();
	}
	
	public override void Update()
	{
		base.Update();
	}
	
	public override void RunHumanInteraction(HumanUnit humanUnit)
	{
		if (humanUnit.cash >= this.interactionCost)
		{
			base.RunHumanInteraction(humanUnit);
			
			humanUnit.cash -= this.interactionCost;
		}
	}
}
