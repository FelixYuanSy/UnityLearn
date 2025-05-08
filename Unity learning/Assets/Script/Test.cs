using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public string name = "zhutousan";
    public int age = 12;
    public float height = 177.5f;
    List<int> list = new List<int>() { 1,2,3,4};
    Dictionary<int,string> dic = new Dictionary<int, string>()
    {
        {1,"123" },
        {2,"234" }
    };
   
}
public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo info = new PlayerInfo();
        PlayerPrefsManager.Instance.SaveData(info,"Player1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
