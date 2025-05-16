using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    private static GameDataManager instance = new GameDataManager();
    public static GameDataManager Instance { get { return instance; } }
    public MusicManger musicManger;
    private GameDataManager()
    {   
        musicManger = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicManger),"Music") as MusicManger;
        if(!musicManger.isFirstOpen)
        {
            musicManger.isFirstOpen = true;
            musicManger.isMusicOpen = true;
            musicManger.isSoundOpen = true;
            musicManger.musicVolume = 1;
            musicManger.soundVolume = 1;
            PlayerPrefsDataMgr.Instance.SaveData(musicManger, "Music");
        }
    }
}
