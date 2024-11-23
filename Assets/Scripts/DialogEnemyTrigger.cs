using System.Collections.Generic;
using UnityEngine;

public class DialogEnemyTrigger : MonoBehaviour
{
    List<GameObject> _enemies = new List<GameObject>();

    public DialogScript _dialog;

void Awake()
{
    _dialog = GetComponent<DialogScript>();
    if (_dialog == null)
    {
        Debug.LogError("DialogScript component not found on this GameObject.");
    }
}
    void Update()
    {
         _enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        foreach (GameObject enemy in _enemies) {
            if(enemy.GetComponent<HealthEnemy>().IsStanding() == false)
            {
                _dialog.StartDialog();
            }
        }
    }


}
