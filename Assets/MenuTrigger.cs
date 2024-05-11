using UnityEngine;
using UnityEngine.UI; // Include this for UI elements like Text and Image
using System.Collections;

public class MenuTrigger : MonoBehaviour
{
    public GameObject menu; // Assign the menu GameObject in the inspector
    public AudioSource audioSource; // Assign an AudioSource component in the inspector
    public AudioClip enterClip; // Assign an AudioClip for entering the collider
    public Text menuText; // Assign the Text component to display custom text
    public Image menuImage; // Assign the Image component to display a custom image
    public Sprite newImage; // Assign a new Sprite for the Image component
    public string newText; // New text to display when colliding
    public float fadeOutDuration = 1.0f; // Duration in seconds for the audio fade out
	public GameObject targetGameObject;

    void Start()
    {
        // Ensure the menu, audio, and UI elements are not active at start
        if (menu != null)
            menu.SetActive(false);
        if (audioSource != null)
            audioSource.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the collider
        if (other.CompareTag("MainCamera"))
        {
            // Show the menu and update UI elements
            SpriteRenderer spriteRenderer = targetGameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = true;
            }
            if (menuText != null)
            {
                menuText.text = newText;
                menuText.gameObject.SetActive(true);
            }
            if (menuImage != null)
            {
                menuImage.sprite = newImage;
                menuImage.gameObject.SetActive(true);
            }
			if (menu != null)
							menu.SetActive(true);
            // Play the audio clip
            if (audioSource != null && enterClip != null)
            {
                audioSource.clip = enterClip;
                audioSource.Play();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player exits the collider
        if (other.CompareTag("MainCamera"))
        {
            // Hide the menu and UI elements
            if (menu != null)
                menu.SetActive(false);

            // Start fading out the audio
            if (audioSource != null)
                StartCoroutine(FadeOutAudioSource(fadeOutDuration));
        }
    }

    IEnumerator FadeOutAudioSource(float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume; // Reset the volume for the next play
    }
	
	void btnclick(){
		// Hide the menu and UI elements
		if (menu != null)
			menu.SetActive(false);

		// Start fading out the audio
		if (audioSource != null)
			StartCoroutine(FadeOutAudioSource(fadeOutDuration));
	}
}
