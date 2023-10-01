using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpsiLevelPack : MonoBehaviour
{

    public static event System.Action<LevelPackKuis> EventSaatKlik;


    [SerializeField]
    private Button _tombol = null;

    [SerializeField] 
    private TextMeshProUGUI _packName = null;
    
    [SerializeField]
    private LevelPackKuis _levelPack = null;


    public void SetLevelPack(LevelPackKuis levelPack) {
        _packName.text = levelPack.name;
        _levelPack = levelPack;

        
    
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (_levelPack != null) {
            SetLevelPack(_levelPack);
        }

        //subscribe event
        _tombol.onClick.AddListener(SaatKlik);

    }




    private void SaatKlik()
    {
        //Debug.Log("clicked");
        // "?" sebelum method adalah untuk mengecek apakah ada yang subscribe method "EventSaatKlik". jika tidak ada, maka method invoke tidak dipanggil
        EventSaatKlik?.Invoke(_levelPack);
    }

    private void OnDestroy()
    {
        //unsubscribe event
        _tombol.onClick.RemoveListener(SaatKlik);

    }

}
