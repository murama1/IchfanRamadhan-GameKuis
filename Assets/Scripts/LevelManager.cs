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

    public void NextLevel()
    {
        //soal index selanjutnya
        _indexSoal++;

        //jika index melampaui soal terakhir, ulang dari awal
        if (_indexSoal >= _soalSoal.BanyakLevel) 
        { 
            _indexSoal = 0;
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
        
        if (!_playerProgress.MuatProgress()) 
        { 
            _playerProgress.SimpanProgress();
        }

        NextLevel();

    }

    public int GetLevel 
    { get { return _indexSoal; } }

    public void RestartLevel()
    {
        LevelSoalKuis soal = _soalSoal.AmbilLevelKe(_indexSoal);
    }
}
