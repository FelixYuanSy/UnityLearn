using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManger : MonoBehaviour
{
    public bool isSoundOpen;
    public bool isMusicOpen;
    public float soundVolume;
    public float musicVolume;
    public bool isFirstOpen;
    public static MusicManger Instance;
    public List<AudioSource> audioClips = new List<AudioSource>();

    //音频片段
    public AudioClip backGround;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        for(int i = 0; i<3; i++)
        {
            var audio = this.gameObject.AddComponent<AudioSource>();
            audioClips.Add(audio);
        }
    }
    //用index来表示在哪个声道播放,用name来选择播放的片段,isLoop是否循环
    private void Play(int index,string name,bool isLoop)
    {
        //用一个自判断类型来获取到播放片段
        var clip = GetAudioClip(name);
        if(clip != null)
        {
            //先存入list对应索引,再取出来播放
            audioClips[index].clip = clip;
            audioClips[index].loop = isLoop;
            audioClips[index].Play();           //此Play()为AudioSource的播放
        }
    }
    private AudioClip GetAudioClip(string name)
    {
        switch(name)
        {
            case "background_music":
                return backGround;
            default:
                Debug.LogError("No match music file:" +  name);
                return null;
        }
    }

    //控制音量大小
    //只需要写setget方法来设置音量
    //利用index获取和控制声道的音量
    //背景音乐和音效用不同的index(声道)
    //调整之后clip换音乐应该可以保持调整之前的音量,因为音量的获取的音乐单独控制
    public float getVolume(int index)
    {
        Debug.Log("获取" + index + "声道音量");
        return audioClips[index].volume;
    }

    public void SetVolume(int index, float volume)
    {
        audioClips[index].volume = volume;
    }
}
