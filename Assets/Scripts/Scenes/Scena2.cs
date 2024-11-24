using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scena2 : MonoBehaviour
{
    [SerializeField] GameObject lincoln;
    [SerializeField] GameObject king;
    [SerializeField] GameObject princess;
    [SerializeField] GameObject player;
    AudioSource source;
    public AudioClip dialog1;
    public AudioClip dialog2;
    GameObject lincoln1, lincoln2;
    private List<GameObject> spawnedLincolns = new List<GameObject>(); // Lista do przechowywania referencji do stworzonych Lincolnów
    bool lincolnSpawned = false;

    bool _done1 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        spawnedLincolns[0].GetComponent<HealthEnemy>().Dead();
        //Dialog2();
    }
    private void Dialog2()
    {
        source.clip = dialog2;
        source.Play();
    }
    void Update()
    {   if (!_done1)
        {
            if (source.isPlaying)
            {
                if (source.clip == dialog1 && source.time >= 5f && !lincolnSpawned)
                {
                    // Tworzenie dwóch Lincolnów i zapisywanie ich referencji w liœcie
                    var lincoln1 = Instantiate(lincoln, lincoln.transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
                    var lincoln2 = Instantiate(lincoln, lincoln.transform.position + new Vector3(-1f, 0f, 0f), Quaternion.identity);

                    // Dodanie do listy
                    spawnedLincolns.Add(lincoln1);
                    spawnedLincolns.Add(lincoln2);

                    lincolnSpawned = true; // Ustawienie flagi, aby unikn¹æ wielokrotnego tworzenia
                }
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
    }
    }
