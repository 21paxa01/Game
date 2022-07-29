using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCount : MonoBehaviour
{
    Text text;
    public static float money;
    public static float mon=0f;
    void Start()
    {
        Load();
        //PlayerPrefs.SetFloat("money", mon);
        text = GetComponent<Text>();
        /*if (PlayerPrefs.HasKey("money"))
        {
            mon = PlayerPrefs.GetFloat("money");
            money = mon;
        }*/
        money = mon;
    }

    // Update is called once per frame
    void Update()
    {
        if (mon > money + 1)
        {
            mon--;
            
        }
        //PlayerPrefs.SetFloat("money", mon);
        money = mon;
        text.text = money.ToString();
    }
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath+"/MoneyCount.dat",FileMode.Create);
        Money money_count=new Money();
        money_count.count = mon;
        formatter.Serialize(file, money_count);
        file.Close();
    }
    void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/MoneyCount.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/MoneyCount.dat", FileMode.Open);
            Money money_count = (Money)formatter.Deserialize(file);
            file.Close();
            mon = money_count.count;
        }
    }
    [Serializable]
    public class Money
    {
        public float count;
    }
}
