using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using System;

public class UI_PesanLevel : MonoBehaviour
{

    [SerializeField]
    private GameObject _opsiMenang = null;

    [SerializeField]
    private GameObject _opsiKalah = null;


    [SerializeField]
    private TextMeshProUGUI _tempatPesan = null;

    [SerializeField]
    private Animator _animator = null;

    [SerializeField]
    private AudioClip[] _suaraSuara = new AudioClip[0];


    // Start is called before the first frame update
    private void Awake()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            
        }

        UI_Timer.EventWaktuHabis += UI_Timer_EventWaktuHabis;
        UI_PoinJawaban.EventJawabSoal += UI_PoinJawaban_EventJawabSoal;
    }

    private void UI_PoinJawaban_EventJawabSoal(string jawabanTeks, bool adalahBenar)
    {
        Pesan = ($"Jawaban anda adalah {adalahBenar} (Jawab : {jawabanTeks})");
        gameObject.SetActive(true);

        if (adalahBenar)
        {
            _opsiMenang.SetActive(true);
            _opsiKalah.SetActive(false);
            _animator.SetBool("Win", true);
            AudioManager.instance.PlaySFX(_suaraSuara[0]);

        }
        else
        {
            _opsiMenang.SetActive(false);
            _opsiKalah.SetActive(true);
            _animator.SetBool("Win", false);
            AudioManager.instance.PlaySFX(_suaraSuara[1]);
        }
    }

    private void OnDestroy()
    {
        UI_Timer.EventWaktuHabis -= UI_Timer_EventWaktuHabis;
        UI_PoinJawaban.EventJawabSoal -= UI_PoinJawaban_EventJawabSoal;
    }

    private void UI_Timer_EventWaktuHabis()
    {
        Pesan = "Waktu Sudah Habis!!!";
        gameObject.SetActive(true);

        _opsiMenang.SetActive(false) ;
        _opsiKalah.SetActive(true) ;
    }

    public string Pesan 
    {

        get 
        {
            Debug.Log("Getter dijalankan");
            return _tempatPesan.text;
        }
        set
        {
            Debug.Log("Setter dijalankan");
            _tempatPesan.text = value;
        }
    }


}
