using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpsiLevelPack : MonoBehaviour
{

    public static event System.Action<UI_OpsiLevelPack, LevelPackKuis, bool> EventSaatKlik;


    [SerializeField]
    private Button _tombol = null;

    [SerializeField] 
    private TextMeshProUGUI _packName = null;
    
    [SerializeField]
    private LevelPackKuis _levelPack = null;

 

    //field untuk label terkunci
    [Space, Header("Properti Pengunci Level Pack")]
    [SerializeField]
    private TextMeshProUGUI _labelTerkunci = null;
    
    [SerializeField]
    private TextMeshProUGUI _labelHarga = null;

    [SerializeField]
    private Image _iconKoin = null;
    
    [SerializeField]
    private bool _terkunci = false;


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
        EventSaatKlik?.Invoke(this, _levelPack, _terkunci);
    }

    private void OnDestroy()
    {
        //unsubscribe event
        _tombol.onClick.RemoveListener(SaatKlik);

    }

    public void KunciLevelPack()
    {
        _terkunci = true;
        _labelTerkunci.gameObject.SetActive(true);
        _labelHarga.transform.gameObject.SetActive(true);
        _iconKoin.gameObject.SetActive(true);
        _labelHarga.text = $"{_levelPack.Harga}";
    }

    public void BukaLevelPack()
    {
        _terkunci = false;
        _labelTerkunci.gameObject.SetActive(false);
        _labelHarga.transform.gameObject.SetActive(false);
        _iconKoin.gameObject.SetActive(false);
    }

}
