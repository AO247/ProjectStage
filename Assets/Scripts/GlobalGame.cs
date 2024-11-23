using UnityEngine;

public class GlobalGame : MonoBehaviour
{
    public static GlobalGame Instance;
    public int ending = 0;

    void Awake()
    {
      if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Zachowaj ten obiekt między scenami
            Debug.Log("GlobalGame instance created.");
        }
        else
        {
            Destroy(gameObject); // Jeśli instancja już istnieje, usuń duplikaty
            Debug.Log("GlobalGame instance already exists, destroying duplicate.");
        }
    }

    void Update()
    {
    
    }

}
