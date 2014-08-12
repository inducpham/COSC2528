using UnityEngine;
using System.Collections;

public class MouseHighlight : MonoBehaviour {

	private Color _baseColor;

	protected void Load () {
		_baseColor = renderer.material.color;
	}

	protected void OnMouseEnter () {
		_baseColor = renderer.material.color;
		renderer.material.color = Color.red;
	} 

	protected void OnMouseExit() {
		renderer.material.color = _baseColor;
	}

}