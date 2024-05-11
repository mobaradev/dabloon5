using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pucksense : MonoBehaviour
{
	public TextMeshProUGUI dabloonsText; // Reference to the TextMeshProUGUI element that displays the dabloons count
    private int dabloonsscount = 0; // To hold the number of dabloons
	
    private void Start()
    {
        PlayerPrefs.SetInt("dabloons", 0);
		PlayerPrefs.Save();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Increment the dabloons count when an object enters the collider
		dabloonsscount = (PlayerPrefs.GetInt("dabloons", 0)+1);
        PlayerPrefs.SetInt("dabloons", dabloonsscount);
        UpdateDabloonsDisplay();
    }

    private void UpdateDabloonsDisplay()
    {
        // Update the displayed text
        if (dabloonsText != null)
        {
            dabloonsText.text = "Dabloons: " + dabloonsscount.ToString();
        }
        else
        {
            Debug.LogError("Dabloons text component is not assigned.");
        }
    }

}
