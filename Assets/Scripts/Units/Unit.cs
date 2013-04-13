using UnityEngine;
using System.Collections;

/**
 * Represents a base unit.
 */
public class Unit : MonoBehaviour
{
	public GameObject indicator;
	
	protected AstarAI aStarAI;
	
	protected bool selected;
	
	public virtual void Awake()
	{
		this.aStarAI = (AstarAI) this.gameObject.GetComponent("AstarAI");
	}
	
	public virtual void Start()
	{
		this.hideIndicator();
	}
	
	public void OnMouseUp()
	{
		this.selectUnit();
	}
	
	public virtual void selectUnit()
	{
		this.showIndicator();
		
		this.selected = true;
	}
	
	public void deselectUnit()
	{
		this.hideIndicator();
		
		this.selected = false;
	}
	
	private void showIndicator()
	{
		this.indicator.renderer.enabled = true;
	}
	
	private void hideIndicator()
	{
		this.indicator.renderer.enabled = false;
	}
}
