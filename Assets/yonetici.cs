using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class yonetici : MonoBehaviour
{
    [SerializeField]
    TextAsset sorular;
    string[] tumsSorular;
    string cevap;
    [SerializeField]
    TextMeshProUGUI soru_txt;
    [SerializeField]
    TextMeshProUGUI a_txt,b_txt,c_txt,d_txt;
    [SerializeField]
    GameObject a_btn,b_btn,c_btn,d_btn;
    int SoruIndexNo = 0;
    int puan = 0;
    [SerializeField]
    TextMeshProUGUI puan_txt;
    [SerializeField]
    GameObject kaybettinPNL;
    [SerializeField]
    GameObject durdurPNL;
    void Start()
    {
        tumsSorular = sorular.ToString().Split('\n');
        if (PlayerPrefs.HasKey("Oyun›lkKezAcildi"))
        {
            SoruIndexNo = PlayerPrefs.GetInt("indexNo");
        }
        else
        {
            PlayerPrefs.SetString("Oyun›lkKezAcildi", "True");
            SoruIndexNo = 0;
            PlayerPrefs.SetInt("indexNo", SoruIndexNo);
        }

        YeniSoruGoster(SoruIndexNo);
        PuaniGuncelle(puan);

    }
    void YeniSoruGoster(int deger)
    {
        string[] soruyuParcala = tumsSorular[deger].Split("&");
        soru_txt.text = soruyuParcala[0].Trim();
        a_txt.text = soruyuParcala[1].Trim();
        b_txt.text = soruyuParcala[2].Trim();
        c_txt.text = soruyuParcala[3].Trim();
        d_txt.text = soruyuParcala[4].Trim();
        a_btn.name = soruyuParcala[1].Trim();
        b_btn.name = soruyuParcala[2].Trim();
        c_btn.name = soruyuParcala[3].Trim();
        d_btn.name = soruyuParcala[4].Trim();
        cevap = soruyuParcala[5].Trim();
        PlayerPrefs.SetInt("indexNo", SoruIndexNo);
    }
    void PuaniGuncelle(int deger)
    {
        puan += deger;
        puan_txt.text = "PUAN : "+  puan.ToString();
    }
    public void CevapKontrol(string deger)
    {
        if(deger == cevap)
        {
            PuaniGuncelle(10);
            SoruIndexNo ++;
            if (SoruIndexNo == tumsSorular.Length)
            {
                SoruIndexNo = 0;
            }
            YeniSoruGoster(SoruIndexNo);
        }
        else
        {
            kaybettinPNL.SetActive(true);
        }
    }
    public void OyundanCikBTN()
    {
        Application.Quit();
    }
    public void YenidenOynaBTN()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    public void DevamEtBTN()
    {
        durdurPNL.SetActive(false);
    }
    public void OyunuDurdurBTN()
    {
        durdurPNL.SetActive(true);
    }
}
