using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_PoinJawaban : MonoBehaviour
{


    [SerializeField]
    private UI_PesanLevel _tempatPesan = null;

    [SerializeField]
    private TextMeshProUGUI _teksJawaban = null;

    [SerializeField]
    private bool _adalahBenar = false;

    public void SetJawaban( string teksJawaban, bool adalahBenar) 
    { 
        _teksJawaban.text = teksJawaban;
        _adalahBenar = adalahBenar;
    }

    public void pilihJawaban() 
    {
        //Debug.Log($"Jawaban anda adalah {_teksJawaban.text} ({_adalahBenar})");
        _tempatPesan.Pesan = ($"Jawaban anda adalah {_teksJawaban.text} ({_adalahBenar})");
    }

}
