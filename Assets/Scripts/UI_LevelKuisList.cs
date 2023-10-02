using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelKuisList : MonoBehaviour
{
    [SerializeField]
    private UI_OpsiLevelKuis _tombolLevelKuis = null;

    [SerializeField]
    private RectTransform _content = null;

    [SerializeField]
    private LevelPackKuis _levelPackKuis = null;

    [SerializeField]
    private GameSceneManager _gameSceneManager = null;

    [SerializeField]
    private string _gameplayScene = null;



    public void UnloadLevelPack(LevelPackKuis levelPack)
    {

        HapusIsiKonten();
        
    
        for (int i=0; i < levelPack.BanyakLevel; i++) 
        {
            //membuat salinan objek dari prefab tombol level pack
            var t = Instantiate(_tombolLevelKuis);

            t.SetLevelKuis(levelPack.AmbilLevelKe(i), i);

            //masukan objek tombol sebagai anak dari objek "conten"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;


        }
    }


    // Start is called before the first frame update
    void Start()
    {

        UnloadLevelPack(InisialDataGameplay.Instance.levelPack);
        UI_OpsiLevelKuis.EventSaatKlik += UI_OpsiLevelKuis_EventSaatKlik;
        
    }

    private void OnDestroy()
    {
        UI_OpsiLevelKuis.EventSaatKlik -= UI_OpsiLevelKuis_EventSaatKlik;
    }

    private void UI_OpsiLevelKuis_EventSaatKlik(int index)
    {
        //personal code, add reference ke inisialdatagameplay
        _levelPackKuis = InisialDataGameplay.Instance.levelPack;
        InisialDataGameplay.Instance.levelSoal = _levelPackKuis.AmbilLevelKe(index);
        InisialDataGameplay.Instance.indexSoal = index;
        //end of personal code

        _gameSceneManager.BukaScene(_gameplayScene);
    }

    private void HapusIsiKonten()
    {
        var cc = _content.childCount;

        for (int i= 0; i < cc; i++) 
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }


}
