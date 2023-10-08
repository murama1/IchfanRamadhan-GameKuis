using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Level Pack Baru", menuName = "Game Kuis/Level Pack Kuis")]
public class LevelPackKuis : ScriptableObject
{




    [SerializeField]
    private LevelSoalKuis[] _isiLevel = new LevelSoalKuis[0];
    public int BanyakLevel => _isiLevel.Length;


    [SerializeField]
    private int _harga = 0;
    public int Harga => _harga;


    //ambil level
    public LevelSoalKuis AmbilLevelKe(int index) { 
        return _isiLevel[index];
    }


}
