using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{

    [System.Serializable]
    private struct DataSoal
    {
        public Sprite hint;
        public string pertanyaan;
        public string judul;

        public string[] jawabanTeks;
        public bool[] adalahBenar;

    }

    [SerializeField]
    private DataSoal[] _soalSoal = new DataSoal[0];


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
        if (_indexSoal >= _soalSoal.Length) 
        { 
            _indexSoal = 0;
        }

        //ambil data Pertanyaan
        DataSoal soal = _soalSoal[_indexSoal];

        //set informasi soal
        _tempatPertanyaan.SetPertanyaan(soal.judul, soal.pertanyaan, soal.hint);

        for (int i = 0; i < _tempatPilihanJawaban.Length; i++) 
        {
            UI_PoinJawaban poin = _tempatPilihanJawaban[i];
            poin.SetJawaban(soal.jawabanTeks[i], soal.adalahBenar[i]);
            
        }

        


    }

    private void Start()
    {
        NextLevel();
        //Debug.Log($"soal ke : {_indexSoal}");
    }

    public int GetLevel 
    { get { return _indexSoal; } }

    public void RestartLevel()
    {
        DataSoal soal = _soalSoal[_indexSoal];
    }
}
