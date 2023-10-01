using UnityEngine;

[CreateAssetMenu (
    fileName = "Soal Baru",
    menuName = "Game Kuis/Level Soal Kuis"
    )]

public class LevelSoalKuis : ScriptableObject
{

    [System.Serializable]
    public struct OpsiJawaban 
    {
        public string jawabanTeks;
        public bool adalahBenar;

    }

    public Sprite hint;
    public string pertanyaan;
    //public string judul;
    public int levelPackIndex = 0;

    public OpsiJawaban[] opsiJawaban = new OpsiJawaban[0];



}
