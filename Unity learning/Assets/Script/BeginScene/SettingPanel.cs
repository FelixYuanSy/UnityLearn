using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject settingPanel;
    public Toggle SoundToggle;
    public Toggle MusicToggle;
    public Slider SoundSlider;
    public Slider MusicSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        settingPanel.SetActive(false);
    }
    public void UpdatePanelInfo()
    {
        MusicManger manager = GameDataManager.Instance.musicManger;
        SoundSlider.value = manager.soundVolume;
        MusicSlider.value = manager.musicVolume;
        SoundToggle.isOn = manager.isSoundOpen;
        MusicToggle.isOn = manager.isMusicOpen;
    }
}
