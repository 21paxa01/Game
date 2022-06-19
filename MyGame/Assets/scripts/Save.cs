using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save : MonoBehaviour
{
    public float[] w_buy_arr = { 1, 0, 0, 0, 0, 0 ,0,0};
    public float[] w_prise_arr = { 40, 0, 0, 0, 0, 0,0,0 };
    public int[] save_cell_ind_arr = { 0, 0, 0, 0, 0, 0 };

    public float[] g_buy_arr = { 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] save_g_cell_ind_arr = { 0, 0, 0, 0, 0, 0 };
    public int inv_k = -1;

    public int[] save_tasks_ind = { 0, 1, 2 };
    public int save_tasks_i=2;
    public int save_killed_zombies;
    public bool save_weapon_upgrade;
    //public bool save_kill_zombies;

    public int[] save_damage_count = { 0, 0, 0, 0, 0, 0, 0 };
    public int[] save_reload_count = { 0, 0, 0, 0, 0, 0, 0 };
    public int[] save_ammunition_count = { 0, 0, 0, 0, 0, 0, 0 };
    public int inv_j=0;

    public bool save_anonim_first_wave=true;
    public int save_anonim_inventory;

    public float save_Music=1f;
    public float save_Sounds = 1f;
    void Start()
    {

    }
    void Update()
    {
    }
    public void Load_weapon()
    {
        if (File.Exists(Application.persistentDataPath + "/Weapon.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/Weapon.dat", FileMode.Open);
            Weapon data = (Weapon)formatter.Deserialize(file);
            file.Close();
            //buy_arr[0] = data.b_arr_1; buy_arr[1] = data.b_arr_2; buy_arr[2] = data.b_arr_3; buy_arr[3] = data.b_arr_4; buy_arr[4] = data.b_arr_5; buy_arr[5] = data.b_arr_6;
            w_prise_arr = data.p_arr;
            w_buy_arr = data.b_arr;
            save_cell_ind_arr = data.s_arr;
            inv_j = data.j;
            //prise_arr[0] = data.p_arr_1; prise_arr[1] = data.p_arr_2; prise_arr[2] = data.p_arr_3; prise_arr[3] = data.p_arr_4; prise_arr[4] = data.p_arr_5; prise_arr[5] = data.p_arr_6;

        }
    }
    public void Save_weapon()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath+"/Weapon.dat", FileMode.Create);
        Weapon data = new Weapon();
        //data.b_arr_1 = buy_arr[0]; data.b_arr_2 = buy_arr[1]; data.b_arr_3 = buy_arr[2]; data.b_arr_4 = buy_arr[3]; data.b_arr_5 = buy_arr[4]; data.b_arr_6 = buy_arr[5];
        data.p_arr = w_prise_arr;
        data.b_arr = w_buy_arr;
        data.s_arr = save_cell_ind_arr;
        data.j = inv_j;
        //data.p_arr_1 = prise_arr[0]; data.p_arr_2 = prise_arr[1]; data.p_arr_3 = prise_arr[2]; data.p_arr_4 = prise_arr[3]; data.p_arr_5 = prise_arr[4]; data.p_arr_6 = prise_arr[5];
        formatter.Serialize(file, data);
        file.Close();
    }
    public void Load_grenades()
    {
        if (File.Exists(Application.persistentDataPath + "/Grenades.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/Grenades.dat", FileMode.Open);
            Grenades data = (Grenades)formatter.Deserialize(file);
            file.Close();
            //buy_arr[0] = data.b_arr_1; buy_arr[1] = data.b_arr_2; buy_arr[2] = data.b_arr_3; buy_arr[3] = data.b_arr_4; buy_arr[4] = data.b_arr_5; buy_arr[5] = data.b_arr_6;
            g_buy_arr = data.b_arr;
            save_g_cell_ind_arr = data.s_arr;
            inv_k = data.k;
            //prise_arr[0] = data.p_arr_1; prise_arr[1] = data.p_arr_2; prise_arr[2] = data.p_arr_3; prise_arr[3] = data.p_arr_4; prise_arr[4] = data.p_arr_5; prise_arr[5] = data.p_arr_6;

        }
    }
    public void Save_grenades()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath + "/Grenades.dat", FileMode.Create);
        Grenades data = new Grenades();
        //data.b_arr_1 = buy_arr[0]; data.b_arr_2 = buy_arr[1]; data.b_arr_3 = buy_arr[2]; data.b_arr_4 = buy_arr[3]; data.b_arr_5 = buy_arr[4]; data.b_arr_6 = buy_arr[5];
        data.b_arr = g_buy_arr;
        data.s_arr = save_g_cell_ind_arr;
        data.k = inv_k;
        //data.p_arr_1 = prise_arr[0]; data.p_arr_2 = prise_arr[1]; data.p_arr_3 = prise_arr[2]; data.p_arr_4 = prise_arr[3]; data.p_arr_5 = prise_arr[4]; data.p_arr_6 = prise_arr[5];
        formatter.Serialize(file, data);
        file.Close();
    }
    public void Load_upgrade()
    {
        if (File.Exists(Application.persistentDataPath + "/Upgrades.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/Upgrades.dat", FileMode.Open);
            Upgrades data = (Upgrades)formatter.Deserialize(file);
            file.Close();
            save_ammunition_count = data.a_count;
            save_damage_count = data.d_count;
            save_reload_count = data.r_count;
        }
    }
    public void Save_upgrade()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath + "/Upgrades.dat", FileMode.Create);
        Upgrades data = new Upgrades();
        data.d_count = save_damage_count;
        data.r_count = save_reload_count;
        data.a_count = save_ammunition_count;
        formatter.Serialize(file, data);
        file.Close();
    }
    public void Load_task()
    {
        if (File.Exists(Application.persistentDataPath + "/Tasks.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/Tasks.dat", FileMode.Open);
            Tasks data = (Tasks)formatter.Deserialize(file);
            file.Close();
            save_tasks_i= data.i;
            save_tasks_ind = data.t_ind;
            save_weapon_upgrade = data.weap_up;
            save_killed_zombies = data.killed_zomb;
            //save_kill_zombies = data.kill_zombies;
        }
    }
    public void Save_task()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath + "/Tasks.dat", FileMode.Create);
        Tasks data = new Tasks();
        data.t_ind = save_tasks_ind;
        data.i = save_tasks_i;
        data.killed_zomb = save_killed_zombies;
        data.weap_up = save_weapon_upgrade;
        //data.kill_zombies = save_kill_zombies;
        formatter.Serialize(file, data);
        file.Close();
    }
    public void Load_anonim()
    {
        if (File.Exists(Application.persistentDataPath + "/Anonim.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/Anonim.dat", FileMode.Open);
            Anonim data = (Anonim)formatter.Deserialize(file);
            save_anonim_first_wave = data.first_w;
            save_anonim_inventory = data.inv;
            file.Close();
            
        }
    }
    public void Save_anonim()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath + "/Anonim.dat", FileMode.Create);
        Anonim data = new Anonim();
        data.inv = save_anonim_inventory;
        data.first_w = save_anonim_first_wave;
        formatter.Serialize(file, data);
        file.Close();
    }
    public void Load_settings()
    {
        if (File.Exists(Application.persistentDataPath + "/Settings.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/Settings.dat", FileMode.Open);
            Settings data = (Settings)formatter.Deserialize(file);
            save_Music = data.Music;
            save_Sounds = data.Sounds;
            file.Close();

        }
    }
    public void Save_settings()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath + "/Settings.dat", FileMode.Create);
        Settings data = new Settings();
        data.Music = save_Music;
        data.Sounds = save_Sounds;
        formatter.Serialize(file, data);
        file.Close();
    }
    [Serializable]
    public class Weapon
    {
        //public float b_arr_1; public float b_arr_2; public float b_arr_3; public float b_arr_4; public float b_arr_5; public float b_arr_6;
        public float[] b_arr;
        public float[] p_arr;
        public int[] s_arr;
        public int j;
        //public float p_arr_1; public float p_arr_2; public float p_arr_3; public float p_arr_4; public float p_arr_5; public float p_arr_6;
    }
    [Serializable]
    public class Upgrades
    {
        public int[] d_count;
        public int[] r_count;
        public int[] a_count;
    }
    [Serializable]
    public class Tasks
    {
        public int[] t_ind;
        public int i;
        public int killed_zomb;
        public bool weap_up;
        //public bool kill_zombies;
    }
    [Serializable]
    public class Anonim
    {
        public bool first_w;
        public int inv;
    }
    [Serializable]
    public class Settings
    {
        public float Music;
        public float Sounds;
    }
    [Serializable]
    public class Grenades
    {
        public float[] b_arr;
        public int[] s_arr;
        public int k;
    }
}
