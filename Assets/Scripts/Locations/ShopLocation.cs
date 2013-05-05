using UnityEngine;
using System.Collections;

/**
 * Represents a shop location.
 * Shop locations remove cash from units.
 */
public class ShopLocation : BuildingLocation
{
	public int interactionCost = 20;
	
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
		base.RunHumanInteraction(humanUnit);
		
		if (humanUnit.cash >= this.interactionCost)
		{
			humanUnit.cash -= this.interactionCost;
		}
	}
}
