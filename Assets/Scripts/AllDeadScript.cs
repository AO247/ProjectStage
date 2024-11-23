using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllDeadScript : MonoBehaviour
{
    GameObject player;
    LevelChange levelChange;
    List<GameObject> _enemies = new List<GameObject>();
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        levelChange = GetComponent<LevelChange>();
    }

    // Update is called once per frame
    void Update()
    {
        _enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        bool allDead = true;
        foreach (GameObject enemy in _enemies) {
            if(enemy.GetComponent<HealthEnemy>().IsDead() == false)
            {
                allDead = false;
                break;
            }
        }
        if (allDead)
        {
            levelChange.ChangeLevel();
        }
    }


}
