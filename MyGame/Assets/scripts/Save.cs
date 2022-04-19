using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save : MonoBehaviour
{
    public float[] w_buy_arr = { 1, 0, 0, 0, 0, 0 };
    public float[] w_prise_arr = { 40, 0, 0, 0, 0, 0 };
    public int inv_j=0;
    void Start()
    {

    }
    void Update()
    {
    }
    public void Load()
    {
        if (File.Exists(@"D:\Game\MyGame\Mechanik.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(@"D:\Game\MyGame\Mechanik.dat", FileMode.Open);
            SaveData data = (SaveData)formatter.Deserialize(file);
            file.Close();
            //buy_arr[0] = data.b_arr_1; buy_arr[1] = data.b_arr_2; buy_arr[2] = data.b_arr_3; buy_arr[3] = data.b_arr_4; buy_arr[4] = data.b_arr_5; buy_arr[5] = data.b_arr_6;
            w_prise_arr = data.p_arr;
            w_buy_arr = data.b_arr;
            inv_j = data.j;
            //prise_arr[0] = data.p_arr_1; prise_arr[1] = data.p_arr_2; prise_arr[2] = data.p_arr_3; prise_arr[3] = data.p_arr_4; prise_arr[4] = data.p_arr_5; prise_arr[5] = data.p_arr_6;

        }
    }
    public void save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(@"D:\Game\MyGame\Mechanik.dat", FileMode.Create);
        SaveData data = new SaveData();
        //data.b_arr_1 = buy_arr[0]; data.b_arr_2 = buy_arr[1]; data.b_arr_3 = buy_arr[2]; data.b_arr_4 = buy_arr[3]; data.b_arr_5 = buy_arr[4]; data.b_arr_6 = buy_arr[5];
        data.p_arr = w_prise_arr;
        data.b_arr = w_buy_arr;
        data.j = inv_j;
        //data.p_arr_1 = prise_arr[0]; data.p_arr_2 = prise_arr[1]; data.p_arr_3 = prise_arr[2]; data.p_arr_4 = prise_arr[3]; data.p_arr_5 = prise_arr[4]; data.p_arr_6 = prise_arr[5];
        formatter.Serialize(file, data);
        file.Close();
    }
    [Serializable]
    public class SaveData
    {
        //public float b_arr_1; public float b_arr_2; public float b_arr_3; public float b_arr_4; public float b_arr_5; public float b_arr_6;
        public float[] b_arr;
        public float[] p_arr;
        public int j;
        //public float p_arr_1; public float p_arr_2; public float p_arr_3; public float p_arr_4; public float p_arr_5; public float p_arr_6;
    }
}
