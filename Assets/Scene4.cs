using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Scena4 : MonoBehaviour
{
    [SerializeField] GameObject lincoln;
    [SerializeField] GameObject king;
    [SerializeField] GameObject princess;
    [SerializeField] GameObject guard;
    [SerializeField] GameObject player;
    [SerializeField] GameObject wiesniok;

    [SerializeField] AudioClip dialog1;
    [SerializeField] AudioClip dialog2;

    [SerializeField] TextMeshPro textShow;
    [SerializeField] TextMeshPro text1;
    [SerializeField] TextMeshPro text2;

    private LevelChange levelChange;
    //Player player;
    AudioSource source;
    //GameObject lincoln1, lincoln2;
    //private List<GameObject> spawnedLincolns = new List<GameObject>(); // Lista do przechowywania referencji do stworzonych Lincolnów

    //GameObject 
    private List<GameObject> spawnedGuards = new List<GameObject>();
    private List<GameObject> castleCount = new List<GameObject>();
    //private List<GameObject> spawnedLincolns = new List<GameObject>();
    //private Player movement;
    float time = 0f;
    bool movement;
    float hp;
    bool _done1 = false, _done2 = false, _done3 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelChange = GetComponent<LevelChange>();
        //movement = GetComponent<Player>().GetSetReverseControls();
        source = GetComponent<AudioSource>();
        hp = player.GetComponent<HealthPlayer>().GetHP();
        Dialog1();

    }
    #region dialofi
    private void Dialog1()
    {
        source.clip = dialog1;
        source.Play();
    }

    private void Dialog1_done()
    {
        _done1 = true;
        textShow.text = "";
        Dialog2();
    }
    private void Dialog2()
    {
        source.clip = dialog2;
        source.Play();
    }

    private void Dialog2_done()
    {
        _done2 = true;
        textShow.text = "";
      
    }

    #endregion

    void Update()
    {
        if (!_done1)
        {
            if (source.isPlaying && source.clip == dialog1 && textShow.text == "")
            {
                StartCoroutine(TypeText(text1.text, textShow, 0.05f));
            }

            if (!source.isPlaying)
            {
                if (source.clip == dialog1)
                {
                    Dialog1_done();

                }
            }
        }
        else if (!_done2 && _done1)
        {
            if (source.isPlaying && source.clip == dialog2 && textShow.text == "")
            {
                StartCoroutine(TypeText(text2.text, textShow, 0.05f));
            }

            if (!source.isPlaying)
            {
                if (source.clip == dialog2)
                {
                    Dialog2_done();

                }
            }
        }

       
        else if (_done2)
        {
            if (castleCount.Count < 1)
            {
                var newPrincess = Instantiate(princess, new Vector3(2f, 0f, 0f), Quaternion.identity);
                castleCount.Add(newPrincess);
            }
            if (castleCount.Count == 1)
            {
                var newKing = Instantiate(king, new Vector3(0f, 3f, 0f), Quaternion.identity);
                castleCount.Add(newKing);
            }
            if (spawnedGuards.Count < 4)
            {
                var positions = new List<Vector3>
                {

                    new Vector3(-6f, 0f, 0f),
                    new Vector3(6f, 0f, 0f),
                    new Vector3(3f, 0f, 0f),
                    new Vector3(2f, 0f, 0f),
                };

                foreach (var pos in positions)
                {
                    var newGuard = Instantiate(wiesniok, pos, Quaternion.identity);
                    spawnedGuards.Add(newGuard);
                }
            }

        }

    }
    private IEnumerator TypeText(string fullText, TextMeshPro targetText, float delay)
    {
        targetText.text = ""; // Reset tekstu
        foreach (char c in fullText)
        {
            targetText.text += c; // Dodawanie kolejnego znaku
            yield return new WaitForSeconds(delay); // OpóŸnienie miêdzy znakami
        }
    }
}
