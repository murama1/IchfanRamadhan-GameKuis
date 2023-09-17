using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Timer : MonoBehaviour
{
    [SerializeField]
    private UI_PesanLevel _tempatPesan = null;
    
    [SerializeField]
    private Slider _timeBar = null; //container slider time
    
    [SerializeField]
    private float _waktuJawab = 30f;
    private float _sisaWaktu = 0f;

    private bool waktuBerjalan = false;

    public void UlangiWaktu() 
    {
        _sisaWaktu = _waktuJawab;
    
    }
    
    // Start is called before the first frame update
    void Start()
    {
        UlangiWaktu();
        waktuBerjalan = true;
    }

    // Update is called once per frame
    void Update()
    {
        PerhitunganWaktu();
    }

    private void PerhitunganWaktu() 
    {
        if (!waktuBerjalan)
        {
            return;
        }
        
        _sisaWaktu -= Time.deltaTime;

        //UI slider
        _timeBar.value = _sisaWaktu / _waktuJawab;

        if (_sisaWaktu < 0f)
        {
            //Debug.Log("Waktu Habis");
            //UI Mengganti message waktu habis
            _tempatPesan.Pesan = ("Waktu Habis");
            _tempatPesan.gameObject.SetActive(true);

            //logic waktu berjalan
            waktuBerjalan = false;
            return;
        }

        //Debug.Log(_sisaWaktu);
    }

    public bool WaktuBerjalan {  
        get { return waktuBerjalan;} 
        set { waktuBerjalan = value;} 
    }

}
