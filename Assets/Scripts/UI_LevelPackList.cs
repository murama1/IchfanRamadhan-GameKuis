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

    [Space, SerializeField]
    private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];
    
    
    private void LoadLevelPack()
    {
        foreach (var levelPack in _levelPacks)
        { 
        //membuat salinan objek dari prefab tombol level pack
        var t = Instantiate(_tombolLevelPack);

            t.SetLevelPack(levelPack);

            //masukan objek tombol sebagai anak dari objek "conten"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;

        
        }
    }



    // Start is called before the first frame update
    void Start()
    {


        LoadLevelPack();

        //UI_OpsiLevelPack_EventSaatKlik(InisialDataGameplay.Instance.levelPack);

        //if (InisialDataGameplay.Instance.SaatKalah)
        //{
        //    UI_OpsiLevelPack_EventSaatKlik(InisialDataGameplay.Instance.levelPack);

        //}

        //subscribe event
        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;



    }

    private void UI_OpsiLevelPack_EventSaatKlik(LevelPackKuis levelPack)
    {
        
        //buka menu level
        _levelList.UnloadLevelPack(levelPack);
        _levelList.gameObject.SetActive(true);

        //test init gameplay data
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
