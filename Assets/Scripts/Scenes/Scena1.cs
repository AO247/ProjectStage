using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Scena1 : MonoBehaviour
{
    [SerializeField] GameObject lincoln;
    [SerializeField] GameObject king;
    [SerializeField] GameObject princess;
    [SerializeField] GameObject player;
    [SerializeField] GameObject wiesniok;
    [SerializeField] AudioClip dialog1;
    [SerializeField] AudioClip dialog2;
    [SerializeField] AudioClip dialog3;
    [SerializeField] AudioClip dialog4;
    [SerializeField] AudioClip dialog5;

    [SerializeField] TextMeshPro textShow;
    [SerializeField] TextMeshPro text1;
    [SerializeField] TextMeshPro text2;
    [SerializeField] TextMeshPro text3;
    [SerializeField] TextMeshPro text4;
    [SerializeField] TextMeshPro text5;
    LevelChange levelChange;
    AudioSource source;
    GameObject lincoln1, lincoln2;
    private List<GameObject> spawnedLincolns = new List<GameObject>(); // Lista do przechowywania referencji do stworzonych Lincolnów

    float time = 0f;
    float hp;
    bool _done1 = false, _done2 = false, _done3 = false, _done4 = false, _done5 = false, _done6 = false, _done7 = false, _done8 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = player.GetComponent<HealthPlayer>().GetHP();
        levelChange = GetComponent<LevelChange>();

        source = GetComponent<AudioSource>();
        Dialog1();

    }

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
        Dialog3();
    }
    private void Dialog3()
    {
        source.clip = dialog3;
        source.Play();
    }
    private void Dialog3_done()
    {
        _done3 = true;
        textShow.text = "";
        Dialog4();
    }
    private void Dialog4()
    {
        source.clip = dialog4;
        source.Play();
    }
    private void Dialog4_done()
    {
        _done4 = true;
        textShow.text = "";
        Dialog5();
    }
    private void Dialog5()
    {
        source.clip = dialog5;
        source.Play();
    }
    private void Dialog5_done()
    {
        _done5 = true;
        textShow.text = "";
        levelChange.ChangeLevel();
    }

    void Update()
    {
        if (!_done1)
        {
            if (source.isPlaying && source.clip == dialog1 && textShow.text == "")
            {
                StartCoroutine(TypeText(text1.text, textShow, 0.05f));
            }
            if (spawnedLincolns.Count < 3) // Zmieñ liczbê na 5
            {
                // Dodawanie Lincolnów
                var positions = new List<Vector3>
                {

                    new Vector3(-6f, 0f, 0f),
                    new Vector3(6f, 0f, 0f),
                    new Vector3(3f, 0f, 0f),

                };

                foreach (var pos in positions)
                {
                    var newLincoln = Instantiate(wiesniok, pos, Quaternion.identity);
                    spawnedLincolns.Add(newLincoln);
                }
            }
            if (!source.isPlaying)
            {

                if (source.clip == dialog1)
                {
                    if (player.GetComponent<Player>().GetVelocity() != Vector2.zero)
                    {
                        if (hp > player.GetComponent<HealthPlayer>().GetHP())
                        {
                            _done1 = true;
                            Dialog2_done();
                        }
                        bool allDead = true;
                        foreach (var lic in spawnedLincolns)
                        {
                            if(!lic.GetComponent<HealthEnemy>().IsDead())
                            {
                                allDead = false;
                                break;
                            }
                        }
                        if(allDead)
                        {
                            _done2 = true;
                            Dialog3_done();
                        }

                    }

                }
            }
        }
       
        else if (!_done3 && _done2)
        {
            if (source.isPlaying && source.clip == dialog3 && textShow.text == "")
            {
                StartCoroutine(TypeText(text3.text, textShow, 0.05f));
            }

            if (!source.isPlaying)
            {
                if (source.clip == dialog3)
                {
                    bool allDead = true;
                    foreach (var lic in spawnedLincolns)
                    {
                        if (!lic.GetComponent<HealthEnemy>().IsDead())
                        {
                            allDead = false;
                            break;
                        }
                    }
                    if (allDead)
                    {
                        _done2 = true;
                        Dialog3_done();
                    }


                }
            }
        }
        else if (!_done4 && _done3)
        {
            if (source.isPlaying && source.clip == dialog4 && textShow.text == "")
            {
                StartCoroutine(TypeText(text4.text, textShow, 0.05f));
            }

            if (!source.isPlaying)
            {
                if (source.clip == dialog4)
                {
                    if (spawnedLincolns.Count < 8) // Zmieñ liczbê na 5
                    {
                        // Dodawanie Lincolnów
                        var positions = new List<Vector3>
                        {

                            new Vector3(-6f, 0f, 0f),
                            new Vector3(6f, 0f, 0f),
                            new Vector3(3f, 0f, 0f),
                            new Vector3(-6f, 0f, 0f),
                        };

                        foreach (var pos in positions)
                        {
                            var newLincoln = Instantiate(lincoln, pos, Quaternion.identity);
                            spawnedLincolns.Add(newLincoln);
                        }
                    }


                    bool allDead = true;
                    foreach (var lic in spawnedLincolns)
                    {
                        if (!lic.GetComponent<HealthEnemy>().IsDead())
                        {
                            allDead = false;
                            break;
                        }
                    }
                    if (allDead)
                    {
                        _done2 = true;
                        Dialog4_done();
                    }

                }

            }
        }
        else if (!_done5 && _done4)
        {
            if (source.isPlaying && source.clip == dialog5 && textShow.text == "")
            {
                StartCoroutine(TypeText(text5.text, textShow, 0.05f));
            }

            spawnedLincolns[0].GetComponent<HealthEnemy>().Dead();
            if (spawnedLincolns[0].GetComponent<HealthEnemy>().IsDead())
            {
                _done4 = true;
                Dialog5_done();
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
