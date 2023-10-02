using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InisialDataGameplay : MonoBehaviour
{

    public static InisialDataGameplay Instance;

    public LevelPackKuis levelPack = null;
    public LevelSoalKuis levelSoal = null;
    public int indexSoal = 0;

    [SerializeField]
    private bool _saatKalah = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool SaatKalah 
    {
        get { return _saatKalah; }
        set { _saatKalah = value;}
    
    }

}
