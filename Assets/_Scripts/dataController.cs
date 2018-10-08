using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

[System.Serializable]

public class AllDataStore {

}

public class DataController : MonoBehaviour


{
    public string path;
    public string jsonString;


    public AllDataStore allData = new AllDataStore();
}

void Start()
{
    DontDestroyOnLoad(transform.gameObject);
    path = Application.streamingAssetsPath + "/SaveData.json";
    //SaveAllData();
    //LoadAllData();
}


public void SaveAllData() {

    File.WriteAllText(path, JsonUtility.ToJson(allData));
}


public void LoadAllData() {
    jsonString = File.ReadAllText(path);
    allData = JsonUtility.FromJson<AllDataStore>(jsonString);
}