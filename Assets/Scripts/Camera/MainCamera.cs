using UnityEngine;
using System.Collections;

/**
 * Controls the behavior of the main game camera.
 * Allows the camera to be moved in the scene when
 * the user's mouse pointer reaches the edges of
 * the screen.
 */
public class MainCamera : MonoBehaviour
{
	// The maximum distance from the screen's edge
	// the mouse pointer must be to move the camera.
	public float edgePadding = 20f;
	// The speed at which the camera moves.
	public float moveSpeed = 10f;
	// The speed at which the camera zooms in on mouse scroll.
	public float zoomSpeed = 50f;
	
	// Camera directions.
	private Vector3 directionLeft = Vector3.left;
	private Vector3 directionRight = Vector3.right;
	private Vector3 directionUp = Vector3.up;
	private Vector3 directionDown = Vector3.down;
	private Vector3 directionForward = Vector3.forward;
	private Vector3 directionBack = Vector3.back;
	
	public void Update()
	{
		if (Input.mousePosition.x <= this.edgePadding)
		{
			// Move left.
			this.transform.Translate(this.directionLeft * this.moveSpeed * Time.deltaTime);
		}
		else if (Input.mousePosition.x >= (Screen.width - this.edgePadding))
		{
			// Move right.
			this.transform.Translate(this.directionRight * this.moveSpeed * Time.deltaTime);
		}
		
		if (Input.mousePosition.y >= (Screen.height - this.edgePadding))
		{
			// Move up.
			this.transform.Translate(this.directionUp * this.moveSpeed * Time.deltaTime);
		}
		else if (Input.mousePosition.y <= this.edgePadding)
		{
			// Move down.
			this.transform.Translate(this.directionDown * this.moveSpeed * Time.deltaTime);
		}
		
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			// Move forward (zoom in.)
			this.transform.Translate(this.directionForward * this.zoomSpeed * Time.deltaTime);
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			// Move backward (zoom out.)
			transform.Translate(this.directionBack * this.zoomSpeed * Time.deltaTime);
		}
	}
}