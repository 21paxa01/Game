using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class all_tasks : MonoBehaviour
{
    public string[] tasks_text = { "kill 5 zombies", "upgrade any weapon", "", "", "", "", "", "", "", "", "", "" };
    public float[] rewards = { 300, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] tasks_ind = { 0, 1, 2 };
    public int i=2;
    public Save save_script;

    public static bool kill_zombies;
    public static float killed_zombies;
    public static bool weapon_upgrade;
    void Start()
    {
        kill_zombies = false;
        killed_zombies = 0; 
        save_script = GameObject.Find("save").GetComponent<Save>();
        UpdateTasks();
    }

    void Update()
    {
        if (kill_zombies == true)
            killed_zombies = save_script.save_killed_zombies;
        weapon_upgrade = save_script.save_weapon_upgrade;
    }
    public void UpdateTasks()
    {
        save_script.Load_task();
        i = save_script.save_tasks_i;
        tasks_ind = save_script.save_tasks_ind;
        //kill_zombies = save_script.save_kill_zombies;
    }
}