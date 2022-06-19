using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class task_window : MonoBehaviour
{
    public Text rew_text;
    public Text task_text;
    public GameObject reward;
    public GameObject task;
    public Save save_script;
    public all_tasks script;
    public GameObject tasks;
    public int i;
    private MoneyCount money;
    public GameObject collect_reward;
    public Image progress;
    public float fill;

    
    void Start()
    {
        fill = 0f;
        rew_text = reward.GetComponent<Text>();
        task_text = task.GetComponent<Text>();
        script = tasks.GetComponent<all_tasks>();
        save_script = GameObject.Find("save").GetComponent<Save>();
        money = GameObject.Find("MoneyCount").GetComponent<MoneyCount>();
    }

    void Update()
    {
        progress.fillAmount = fill;
        rew_text.text = script.rewards[script.tasks_ind[i]].ToString();
        task_text.text = script.tasks_text[script.tasks_ind[i]];
        MakeTasks();
    }
    public void New_Task()
    {
        MoneyCount.mon += script.rewards[i];
        money.Save();
        save_script.save_tasks_i++;
        save_script.save_tasks_ind[i]= save_script.save_tasks_i;
        save_script.Save_task();
        script.UpdateTasks();
        collect_reward.SetActive(false);
        fill = 0f;
    }
    void MakeTasks()
    {
        if (script.tasks_ind[i] == 0)
        {
            all_tasks.kill_zombies = true;
            fill =all_tasks.killed_zombies / 20;
            if (fill >= 1)
            {
                collect_reward.SetActive(true);

            }
        }
        if (script.tasks_ind[i] == 1)
        {
            fill = 0f;
            if (all_tasks.weapon_upgrade == true)
            {
                fill = 1f;
                collect_reward.SetActive(true);
            }
        }
    }
}


