using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_MenuConfirmMessage : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _koinText = null;

    [SerializeField]
    private PlayerProgress _playerData;
    
    [SerializeField]
    private GameObject _pesanCukupKoin;
    
    [SerializeField]
    private GameObject _pesanTakCukupKoin;

    private UI_OpsiLevelPack _tombolLevelPack = null;

    private LevelPackKuis _levelPack = null;
    

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.activeSelf) 
        {
            gameObject.SetActive(false);
        }
        
        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(UI_OpsiLevelPack tombolLevelPack, LevelPackKuis levelPack, bool terkunci)
    {
        ////cek terkunci atau tidak, jika tidak maka abaikan
        if (!terkunci) { return; }

        gameObject.SetActive(true);

        //cek kecukupan koin untuk membeli level pack
        if (_playerData.progressData.koin < levelPack.Harga)
        {
            //jika tidak cukup
            _pesanCukupKoin.SetActive(false);
            _pesanTakCukupKoin.SetActive(true);
            return;
        }

        //jika cukup
        _pesanCukupKoin.SetActive(true);
        _pesanTakCukupKoin.SetActive(false);
        _tombolLevelPack = tombolLevelPack;
        _levelPack = levelPack;


    }


    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    public void BukaLevel()
    {
        _playerData.progressData.koin -= _levelPack.Harga;
        _playerData.progressData.progressLevel[_levelPack.name] = 1;


        _playerData.SimpanProgress();
        _koinText.text = $"{_playerData.progressData.koin}";

        _tombolLevelPack.BukaLevelPack();
    }
}
