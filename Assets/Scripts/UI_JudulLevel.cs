using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_JudulLevel : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _tempatJudul = null;

    [SerializeField]
    private LevelManager _levelManager = null;

    private string _currentLevel = "0";

    // Start is called before the first frame update
    void Start()
    {
        _currentLevel = _levelManager.GetLevel.ToString();
        _tempatJudul.text = "Level " + _currentLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
