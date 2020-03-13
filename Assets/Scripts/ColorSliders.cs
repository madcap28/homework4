using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSliders : MonoBehaviour
{
	public GameObject sphere;
	MeshRenderer sphereRenderer;
	public Slider redSlider;
	public Slider greenSlider;
	public Slider blueSlider;
    
    void Start()
    {
        sphereRenderer = sphere.GetComponent<MeshRenderer>();
    }
	
	void Update()
	{
		Color newColor = new Color(redSlider.value/255, greenSlider.value/255, blueSlider.value/255, 1);
		sphereRenderer.material.SetColor("_Color", newColor);
	}
}
