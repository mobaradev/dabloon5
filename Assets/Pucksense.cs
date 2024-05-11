using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pucksense : MonoBehaviour
{
	public TextMeshProUGUI dabloonsText; // Reference to the TextMeshProUGUI element that displays the dabloons count
    private int dabloonsCount = 0; // To hold the number of dabloons

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Increment the dabloons count when an object enters the collider
        dabloonsCount++;
        UpdateDabloonsDisplay();
    }

    private void UpdateDabloonsDisplay()
    {
        // Update the displayed text
        if (dabloonsText != null)
        {
            dabloonsText.text = "Dabloons: " + dabloonsCount;
        }
        else
        {
            Debug.LogError("Dabloons text component is not assigned.");
        }
    }

}
