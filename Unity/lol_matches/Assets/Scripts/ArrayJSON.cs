using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayJSON : MonoBehaviour
{
    public static T[] FromJson<T>(string json)
    {
        string newJson = "{\"Matches\":" + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);

        return wrapper.Matches;
    }

    public static string ToJson<T>(T[] array, bool formatPrint = false)
    {
        Wrapper<T> wrapper  = new Wrapper<T> { Matches = array };
        return JsonUtility.ToJson(wrapper, formatPrint);
    }


 [Serializable]
private class Wrapper<T>
{
    public T[] Matches;
}

}
