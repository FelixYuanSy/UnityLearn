using System;
using System.Collections.Generic;
using UnityEngine;

public class Father
{

}

public class Son : Father
{

}

public class Reflection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //判断一个类型的对象是否可以让另一个类型给自己分配空间
        Type fatherType = typeof(Father);
        Type sonType = typeof(Son);
        //函数功能,是否可以分配空间给sontype
        if (fatherType.IsAssignableFrom(sonType))
        {
            print("father 可以装 son");
            Father F = Activator.CreateInstance(sonType) as Father;
        }
        else
        {
            print("father 不能装 son");
        }
        //结论,不继承不能开辟空间

        //通过反射获取泛型类型
        List<string> list = new List<string>();
        Type listType = list.GetType();

        //功能为获取泛型类型
        Type[] types = listType.GetGenericArguments();
        print(types[0]);

        Dictionary<string,int> dic = new Dictionary<string,int>();
        Type dicType = dic.GetType();
        types = dicType.GetGenericArguments();
        print(types[0]);
        print(types[1]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
