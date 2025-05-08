using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    // 创建数据管理类
    //创建静态实例
    private static PlayerPrefsManager instance = new PlayerPrefsManager();
    //创建让别的类使用的静态实例
    public static PlayerPrefsManager Instance
    {
        get 
        {
            return instance;
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData(object data, string keyName)
    {
        
        Type dataType = data.GetType();
        //1.获取传入对象的所有字段
        FieldInfo[] fileInfo = dataType.GetFields();

        //2.定义key规则
        //keyname+类型+字段类型+字段名   
        //3.遍历字段进行存储
        string saveKeyName = "";
        FieldInfo info;
        for(int i = 0; i < fileInfo.Length; i++)
        {
            info = fileInfo[i];
            saveKeyName = keyName + "_" + dataType.Name + "_" + info.FieldType.Name + "_" +info.Name;
            SaveValue(info.GetValue(data), saveKeyName);
        }



    }
    private void SaveValue(object value, string keyname)
    {
        Type valueType = value.GetType();
        if(valueType == typeof(int))
        {
            PlayerPrefs.SetInt(keyname, (int)value);
        }
        else if(valueType == typeof(float))
        {
            PlayerPrefs.SetFloat(keyname, (float)value);
        }
        else if(valueType == typeof(string))
        {       
            PlayerPrefs.SetString(keyname, value.ToString());
        }
        else if(valueType == typeof(bool))
        {
            PlayerPrefs.SetInt(keyname, (bool)value ? 1 : 0);
        }
        else if(typeof(IList).IsAssignableFrom(valueType))
        {
            //用父类装子类
            IList list = value as IList;
            //先存储数量
            PlayerPrefs.SetInt(keyname, list.Count);
            int index = 0;
            foreach(object obj in list)
            {
                //存储值,采用递归来实现对值判断
                SaveValue(obj, keyname+index);
                ++index;
            }
        }
        else if(typeof(IDictionary).IsAssignableFrom(valueType))
        {
            IDictionary dict = value as IDictionary;
            PlayerPrefs.SetInt(keyname, dict.Keys.Count);
            int index = 0;
            foreach(object key in dict)
            {
                //先存key再存value
                SaveValue(key, keyname + index);
                SaveValue(dict[key], keyname + index);
                ++index;
            }
        }
    }
    //使用type减少代码(减少在外部new之后再传入)
    public object LoadData(Type type, string keyName)
    {
        Type dataType = type;
        FieldInfo[] fields = dataType.GetFields();
        for(int i = 0; i< fields.Length; i++)
        {
            FieldInfo field = fields[i];
            if(field.FieldType == typeof(string))
            {

            }
        }

        return null;
    }
}
