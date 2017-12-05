using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour {

	public Slider volumeSlider;
	public Button saveButton;
	//public Slider difficultySlider;

	private MusicManager musicManager;
	
	void Start()
	{
		musicManager = FindObjectOfType<MusicManager>();
		SetDefaults();
		//difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	void Update()
	{
		if (musicManager)
		{
			musicManager.SetVolume(volumeSlider.value);
		}			
	}

	public void SaveAndGoBack()
	{
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		//PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		PlayerPrefsManager.SavePreferences();
	}

	public void SetDefaults()
	{
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		//difficultySlider.value = 2f;
	}

}
