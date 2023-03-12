using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Slider slider;

	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;
	}

	public void setHealth(int health)
	{
		slider.value = health;
	}

	// Update is called once per frame
	void Update()
	{
			
	}
}

