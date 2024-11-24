using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Scena3 : MonoBehaviour
{
    [SerializeField] GameObject lincoln;
    [SerializeField] GameObject king;
    [SerializeField] GameObject princess;
    [SerializeField] GameObject guard;
    [SerializeField] GameObject player;
    [SerializeField] GameObject wiesniok;

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

    private LevelChange levelChange;
    //Player player;
    AudioSource source;
    //GameObject lincoln1, lincoln2;
    //private List<GameObject> spawnedLincolns = new List<GameObject>(); // Lista do przechowywania referencji do stworzonych Lincolnów

    //GameObject 
    private List<GameObject> spawnedGuards = new List<GameObject>();
    //private List<GameObject> spawnedLincolns = new List<GameObject>();
    //private Player movement;
    float time = 0f;
    bool movement;
    float hp;
    bool _done1 = false, _done2 = false, _done3 = false, _done4 = false, _done5 = false, _done6 = false, _done7 = false, _done8 = false, _done9 = false;
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
        Dialog9();
    }

    private void Dialog9()
    {
        source.clip = dialog9;
        source.Play();
    }

    private void Dialog9_done()
    {
        _done9 = true;
        textShow.text = "";
        levelChange.ChangeLevel();
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
                    //if (player.GetComponent<Player>().GetVelocity() != Vector2.zero)
                    //{
                        Dialog1_done();
                   // }

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
                    
                        Dialog3_done();
                    
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

                    Dialog4_done();

                }
            }
        }
        else if (!_done5 && _done4)
        {
            if (source.isPlaying && source.clip == dialog5 && textShow.text == "")
            {
                StartCoroutine(TypeText(text5.text, textShow, 0.05f));
            }

            if (!source.isPlaying)
            {
                if (source.clip == dialog5)
                {

                    Dialog5_done();

                }
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

                    Dialog6_done();

                }
            }
        }

        else if (!_done7 && _done6)
        {
            if (source.isPlaying && source.clip == dialog7 && textShow.text == "")
            {
                StartCoroutine(TypeText(text7.text, textShow, 0.05f));
                player.GetComponent<Player>().SetReverseControls(true);

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
                    var newGuard = Instantiate(guard, pos, Quaternion.identity);
                    spawnedGuards.Add(newGuard);
                }
            }
            if (!source.isPlaying)
            {
                if (source.clip == dialog7)
                {

                    if (player.GetComponent<Player>().GetVelocity() != Vector2.zero)
                    {
                        bool allDead = true;
                        foreach (var lic in spawnedGuards)
                        {
                            if (!lic.GetComponent<HealthEnemy>().IsDead())
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
                    if (player.GetComponent<Player>().GetVelocity() != Vector2.zero)
                    {

                        bool allDead = true;
                        foreach (var lic in spawnedGuards)
                        {
                            if (!lic.GetComponent<HealthEnemy>().IsDead())
                            {
                                allDead = false;
                                break;
                            }
                        }
                        if (allDead)
                        {
                            _done7 = true;
                            Dialog8_done();
                        }

                    }

                }
            }
        }
        else if (_done8)
        {
            if (source.isPlaying && source.clip == dialog9 && textShow.text == "")
            {
                StartCoroutine(TypeText(text9.text, textShow, 0.05f));
            }
            if (spawnedGuards.Count < 8)
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
            if (!source.isPlaying)
            {
                if (source.clip == dialog9)
                {
                    bool allDead = true;
                    foreach (var pos in spawnedGuards)
                    {
                        if(!pos.GetComponent<HealthEnemy>().IsDead())
                        {
                            allDead = false;
                        }
                    }
                    if (allDead)
                    { 
                        Dialog9_done();

                    }

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
