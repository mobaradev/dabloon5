using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageCounter : MonoBehaviour
{
    public Button myButton; // Reference to the button
    public Sprite MAX; 
    public Sprite DABcat;
    public Sprite RICK;
    public Sprite COW;
	public Sprite toothless;
    public TextMeshProUGUI dabloonText; // Text element showing the dabloon count
	public Text finishtxt;
	
    public TextMeshProUGUI fishcounterText; // Text element to display the image-based counter
    public TextMeshProUGUI steakcounterText;
    public TextMeshProUGUI breadcounterText;
    public TextMeshProUGUI fruitcounterText;
    public Image compareimg;

    private int fishCount = 0;
    private int steakCount = 0;
    private int breadCount = 0;
    private int fruitCount = 0;

    private void Start()
    {
        myButton.onClick.AddListener(UpdateCounter);
    }

    private void UpdateCounter()
    {
        if (dabloonText.text.StartsWith("Dabloons: ") && int.TryParse(dabloonText.text.Substring(10), out int dabloonCount))
        {
            if (dabloonCount >= 10 && compareimg.gameObject.activeInHierarchy)
            {
                if (compareimg.sprite == MAX)
                {
                    fishCount++;
                    fishcounterText.text = fishCount.ToString();
                }
                else if (compareimg.sprite == DABcat)
                {
                    steakCount++;
                    steakcounterText.text = steakCount.ToString();
                }
                else if (compareimg.sprite == RICK)
                {
                    fruitCount++;
                    fruitcounterText.text = fruitCount.ToString();
                }
                else if (compareimg.sprite == COW)
                {
                    breadCount++;
                    breadcounterText.text = breadCount.ToString();
                }
				else if (compareimg.sprite ==toothless){
					if(fishCount==2 && steakCount==2 && breadCount==2 && fruitCount==2){
						finishtxt.text = "YOU FINISHED THE GAME!";
					}
				}
		
            }
        }
    }
}
