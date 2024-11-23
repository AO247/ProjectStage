using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincessKingDead : MonoBehaviour
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
         foreach (GameObject enemy in _enemies) {
            if(enemy.GetComponent<HealthEnemy>().IsDead() != false)
            {
                levelChange.ChangeLevel();
            }
        }
    }
}
