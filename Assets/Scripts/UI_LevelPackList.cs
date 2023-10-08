using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{

    [SerializeField]
    private UI_LevelKuisList _levelList = null;

    [SerializeField]
    private UI_OpsiLevelPack _tombolLevelPack = null;
    
    [SerializeField]
    private RectTransform _content = null;

    //[Space, SerializeField]
    //private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];
    
    
    public void LoadLevelPack(LevelPackKuis[] levelPackKuis, PlayerProgress.MainData playerData)
    {
        foreach (var levelPack in levelPackKuis)
        { 
        //membuat salinan objek dari prefab tombol level pack
        var t = Instantiate(_tombolLevelPack);

            t.SetLevelPack(levelPack);

            //masukan objek tombol sebagai anak dari objek "conten"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;

            //cek apakah level pack terdaftar di Dictionary progress pemain
            if (!playerData.progressLevel.ContainsKey(levelPack.name))
            {
                Debug.Log($"{playerData.progressLevel.ContainsKey(levelPack.name)}");
                //jika tidak terdaftar maka level pack terkunci
                t.KunciLevelPack();
            }
            else if (playerData.progressLevel.ContainsKey(levelPack.name))
            {
                t.BukaLevelPack();
            }
        
        }
    }



    // Start is called before the first frame update
    void Awake()
    {


        //LoadLevelPack();

        //cek fungsi ini buat apa
        //if (InisialDataGameplay.Instance.SaatKalah)
        //{
        //    UI_OpsiLevelPack_EventSaatKlik(null, InisialDataGameplay.Instance.levelPack, false);
        //}

        //subscribe event
        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;



    }

    private void UI_OpsiLevelPack_EventSaatKlik(UI_OpsiLevelPack tombolLevelPack, LevelPackKuis levelPack, bool terkunci)
    {
        //Cek apakah terkunci, apabila terkunci abaikan
        if(terkunci) { return; }

        Debug.Log("dijalankan");
        

        //buka menu level
        _levelList.UnloadLevelPack(levelPack);
        _levelList.gameObject.SetActive(true);

        //init gameplay data
        InisialDataGameplay.Instance.levelPack = levelPack;




        //tutup menu level packs
        gameObject.SetActive(false);


    }

    
    private void OnDestroy()
    {
        //unsubscribe event
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

}
