using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelMenuDataManager : MonoBehaviour
{

    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private TextMeshProUGUI _tempatKoin = null;

    [SerializeField]
    private UI_LevelPackList _LevelPackList = null;

    [SerializeField]
    private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];



    // Start is called before the first frame update
    void Start()
    {

        //play BGM
        if (AudioManager.instance != null) { 
            AudioManager.instance.PlayBGM(0); }
        


        if (!_playerProgress.MuatProgress())
        {
            _playerProgress.SimpanProgress();
        }

        //muat semua level pack yang ada di game
        _LevelPackList.LoadLevelPack(_levelPacks, _playerProgress.progressData);

        _tempatKoin.text = $"{_playerProgress.progressData.koin}";
    }

    private void OnApplicationQuit()
    {
        InisialDataGameplay.Instance.SaatKalah = false;
    }
}
