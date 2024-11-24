using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Scena0 : MonoBehaviour
{
    [SerializeField] GameObject lincoln;
    [SerializeField] GameObject king;
    [SerializeField] GameObject princess;
    [SerializeField] GameObject player;
    [SerializeField] AudioClip dialog1;
    [SerializeField] AudioClip dialog2;
    [SerializeField] AudioClip dialog3;
    [SerializeField] AudioClip dialog4;
    [SerializeField] AudioClip dialog5;
    [SerializeField] AudioClip dialog6;
    [SerializeField] AudioClip dialog7;
    [SerializeField] AudioClip dialog8;
    [SerializeField] AudioClip dialog9;

    [SerializeField] TextMeshPro textShow;
    [SerializeField] TextMeshPro text1;
    [SerializeField] TextMeshPro text2;
    [SerializeField] TextMeshPro text3;
    [SerializeField] TextMeshPro text4;
    [SerializeField] TextMeshPro text5;
    [SerializeField] TextMeshPro text6;
    [SerializeField] TextMeshPro text7;
    [SerializeField] TextMeshPro text8;
    [SerializeField] TextMeshPro text9;

    AudioSource source;
    GameObject lincoln1, lincoln2;
    private List<GameObject> spawnedLincolns = new List<GameObject>(); // Lista do przechowywania referencji do stworzonych Lincolnów
    LevelChange levelChange;
    float time = 0f;
    bool _done1 = false, _done2 =false, _done3 = false, _done4 = false, _done5 = false, _done6 = false, _done7 = false, _done8 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        Dialog6();
    }
    private void Dialog6()
    {
        source.clip = dialog6;
        source.Play();
    }
    private void Dialog6_done()
    {
        _done6 = true;
        textShow.text = "";
        Dialog7();
    }
    private void Dialog7()
    {
        source.clip = dialog7;
        source.Play();
    }
    private void Dialog7_done()
    {
        _done7 = true;
        textShow.text = "";
        Dialog8();
    }
    private void Dialog8()
    {
        source.clip = dialog8;
        source.Play();
    }
    private void Dialog8_done()
    {
        _done8 = true;
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

            if (!source.isPlaying)
            {
                if (source.clip == dialog1)
                {
                    if(player.GetComponent<Player>().GetVelocity() != Vector2.zero)
                    {
                        Dialog1_done();
                    }
                    
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
                    if (spawnedLincolns.Count == 0)
                    {
                        var lincoln1 = Instantiate(lincoln, lincoln.transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
                        spawnedLincolns.Add(lincoln1);
                    }
                    if (!spawnedLincolns[0].GetComponent<HealthEnemy>().IsStanding())
                    {
                        spawnedLincolns[0].GetComponent<HealthEnemy>().SetMaxHealth(0f);
                        Dialog2_done();
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
                    time += Time.deltaTime;
                    if (time > 7)
                    {
                        time = 0f;
                        Dialog3_done();
                    }
                    if (spawnedLincolns[0].GetComponent<HealthEnemy>().IsDead())
                    {
                        _done3 = true;
                        _done4 = true;
                        Dialog5_done();
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
                    time += Time.deltaTime;
                    if (time > 7)
                    {
                        time = 0f;

                        Dialog4_done();
                    }
                    if (spawnedLincolns[0].GetComponent<HealthEnemy>().IsDead())
                    {
                        _done4 = true;
                        Dialog5_done();
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
        else if (!_done6 && _done5)
        {
            if (source.isPlaying && source.clip == dialog6 && textShow.text == "")
            {
                StartCoroutine(TypeText(text6.text, textShow, 0.05f));
            }
            if (!source.isPlaying)
            {
                if (source.clip == dialog6)
                {
                    time += Time.deltaTime; // Dodanie czasu w sposób ci¹g³y

                    if (spawnedLincolns.Count < 5) // Zmieñ liczbê na 5
                    {
                        // Dodawanie Lincolnów
                        var positions = new List<Vector3>
                {
                    new Vector3(0f, 0f, 0f),
                    new Vector3(-6f, 0f, 0f),
                    new Vector3(6f, 0f, 0f),
                    new Vector3(3f, 0f, 0f),
                    new Vector3(-3f, 0f, 0f)
                };

                        foreach (var pos in positions)
                        {
                            var newLincoln = Instantiate(lincoln, pos, Quaternion.identity);
                            spawnedLincolns.Add(newLincoln);
                        }
                    }

                    if (time > 10) // Sprawdzenie czasu
                    {
                        time = 0f;
                        Dialog7_done();
                    }

                    // Sprawdzenie, czy wszyscy Lincolnowie s¹ martwi
                    bool allDead = true;
                    foreach (var lincoln in spawnedLincolns)
                    {
                        if (!lincoln.GetComponent<HealthEnemy>().IsDead())
                        {
                            allDead = false;
                            break;
                        }
                    }

                    if (allDead)
                    {
                        _done6 = true;
                        Dialog7_done();
                    }
                }
            }
        }

        else if (!_done7 && _done6)
        {
            if (source.isPlaying && source.clip == dialog7 && textShow.text == "")
            {
                StartCoroutine(TypeText(text7.text, textShow, 0.05f));
                time = 0f;
            }
            if (!source.isPlaying)
            {
                if (source.clip == dialog7)
                {
                    if (spawnedLincolns.Count < 3)
                    { 
                        
                    }
                    time = Time.deltaTime;

                    if (time > 30)
                    {
                        time = 0f;
                        Dialog6_done();
                    }


                }
            }
        }
        else if (!_done8 && _done7)
        {
            if (source.isPlaying && source.clip == dialog8 && textShow.text == "")
            {
                StartCoroutine(TypeText(text8.text, textShow, 0.05f));

            }
            if (!source.isPlaying)
            {
                if (source.clip == dialog8)
                {
                    player.GetComponent<HealthPlayer>().addHp();
                    //player.GetComponent<HealthPlayer>().GetHit(1,1,null);
                    Dialog8_done();
                }
            }
        }
        else if (_done8)
        {
            if (source.isPlaying && source.clip == dialog9 && textShow.text == "")
            {
                StartCoroutine(TypeText(text9.text, textShow, 0.05f));

            }
            if (!source.isPlaying)
            {
                if (source.clip == dialog9)
                {
                   
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
