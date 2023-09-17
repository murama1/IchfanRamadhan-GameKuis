using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class UI_PesanLevel : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _tempatPesan = null;

    // Start is called before the first frame update
    private void Awake()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            
        }
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
