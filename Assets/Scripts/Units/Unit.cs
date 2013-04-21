using UnityEngine;
using System.Collections;

/**
 * Represents a base unit.
 */
public class Unit : MonoBehaviour
{
	public GameObject indicator;
	public Texture previewTexture;
	
	protected AstarAI aStarAI;
	
	protected bool selected;
	
	public virtual void Awake()
	{
		this.aStarAI = (AstarAI) this.gameObject.GetComponent("AstarAI");
	}
	
	public virtual void Start()
	{
		this.HideIndicator();
	}
	
	public void OnMouseUp()
	{
		this.SelectUnit();
	}
	
	public virtual void SelectUnit()
	{
		this.ShowIndicator();
		
		this.selected = true;
	}
	
	public void DeselectUnit()
	{
		this.HideIndicator();
		
		this.selected = false;
	}
	
	private void ShowIndicator()
	{
		this.indicator.renderer.enabled = true;
	}
	
	private void HideIndicator()
	{
		this.indicator.renderer.enabled = false;
	}
}
