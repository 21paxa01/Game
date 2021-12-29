using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Transform karl;
    private int a = 0;
    void Start()
    {
        SceneManager.UnloadScene(0);
        StartCoroutine(MENU());
    }

   
    void Update()
    {
        if (karl.position.x >= 10.5f && a == 0)
            Scene();
    }
    IEnumerator MENU()
    {
        yield return new WaitForSeconds(6f);
        Scene();
    }
    public void Scene()
    {
        a = 1;
        SceneManager.LoadScene(1);
    }
}
