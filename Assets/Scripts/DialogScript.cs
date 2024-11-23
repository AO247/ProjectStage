using UnityEngine;
using TMPro;
using System.Collections;
using System;
using Unity.VisualScripting;
public class DialogScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    [SerializeField] private AudioClip[] dialogueSoundClip;

    [SerializeField] private int _enemySpawnNumber;

    [SerializeField] public GameObject enemyPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    public void StartDialog()
    {
        index = 0;
        SoundFXMaster.instance.PlaySoundFXClip(dialogueSoundClip[index], transform, 1f);
        StartCoroutine(TypeLine());
        for(int i = 0 ; i < _enemySpawnNumber; i++)
        {
            Instantiate(enemyPrefab, new Vector3(i*2, 0, i*2), Quaternion.identity);
        }
    }


    IEnumerator TypeLine(){
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if (index < lines.Length - 1)
        {
            index++;
            SoundFXMaster.instance.PlaySoundFXClip(dialogueSoundClip[index], transform, 1f);
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
