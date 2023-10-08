using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{


    [SerializeField]
    private PlayerProgress _playerProgress = null;

    
    [SerializeField]
    private LevelPackKuis _soalSoal = null;


    [SerializeField]
    private UI_Pertanyaan _tempatPertanyaan = null;
    
    [SerializeField]
    private UI_PoinJawaban[] _tempatPilihanJawaban = new UI_PoinJawaban[0];

    private int _indexSoal = -1;

    //untuk scene
    [SerializeField]
    private GameSceneManager _gameSceneManager = null;

    [SerializeField]
    private string _namaSceneManager = null;

    public void NextLevel()
    {
        //soal index selanjutnya
        _indexSoal++;

        //jika index melampaui soal terakhir, ulang dari awal
        if (_indexSoal >= _soalSoal.BanyakLevel) 
        {
            //gunakan apabila setelah level habis kembali ke soal pertama
            //_indexSoal = 0;

            //gunakan apabila setelah level habis kembali ke scene pilihan
            _gameSceneManager.BukaScene(_namaSceneManager);
            return;
        }

        //ambil data Pertanyaan
        LevelSoalKuis soal = _soalSoal.AmbilLevelKe(_indexSoal);

        //set informasi soal
        _tempatPertanyaan.SetPertanyaan($"Soal {_indexSoal + 1}", soal.pertanyaan, soal.hint);

        for (int i = 0; i < _tempatPilihanJawaban.Length; i++) 
        {
            UI_PoinJawaban poin = _tempatPilihanJawaban[i];
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetJawaban(opsi.jawabanTeks, opsi.adalahBenar);
            
        }

        


    }

    private void Start()
    {

        //if (!_playerProgress.MuatProgress())
        //{
        //    _playerProgress.SimpanProgress();
        //}
        GetInitialDataGameplay();
        NextLevel();

        //subscribe event
        UI_PoinJawaban.EventJawabSoal += UI_PoinJawaban_EventJawabSoal;

    }

    private void UI_PoinJawaban_EventJawabSoal(string jawaban, bool adalahBenar)
    {
        if (!adalahBenar) { return; }
        //beda dengan tutorial, tidak pakai initial game data
        var namaLevelPack = _soalSoal.name;
        int levelTerakhir = _playerProgress.progressData.progressLevel[namaLevelPack];
        
        if (_indexSoal + 2 > levelTerakhir)
        {
            _playerProgress.progressData.koin += 20;
            _playerProgress.progressData.progressLevel[namaLevelPack] = _indexSoal + 2;
            _playerProgress.SimpanProgress();
        }
    }

    private void OnDestroy()
    {
        UI_PoinJawaban.EventJawabSoal -= UI_PoinJawaban_EventJawabSoal;
    }

    public int GetLevel 
    { get { return _indexSoal; } }

    public void RestartLevel()
    {
        LevelSoalKuis soal = _soalSoal.AmbilLevelKe(_indexSoal);
    }

    private void GetInitialDataGameplay() {
        if (InisialDataGameplay.Instance.levelPack != null)
        {
            _soalSoal = InisialDataGameplay.Instance.levelPack;
            _indexSoal = InisialDataGameplay.Instance.indexSoal - 1;
        }
       
    
    }

    private void OnApplicationQuit()
    {
        InisialDataGameplay.Instance.SaatKalah = false;
    }

}
