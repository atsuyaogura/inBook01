using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Photon.Pun;
using Photon.Realtime;


public class PageInstantiateManager: MonoBehaviourPunCallbacks
{
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartForMasterClient();
        }
        else return;
    }


    void StartForMasterClient()
    {
        string url = ChosenBookInformation.targetURL;
        StartCoroutine(Get(url));
    }

    [PunRPC]
    private void StartForVisiter(string bookURL)
    {
        if (ChosenBookInformation.targetURL == null)
        {
            ChosenBookInformation.targetURL = bookURL;
            StartCoroutine(Get(bookURL));
        }
        else return;
    }

    #region Get Text Coroutine

    private IEnumerator Get(string url)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(url))
        {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("ConnectionError: " + unityWebRequest.error);
            }
            else if (unityWebRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("ProtocolError: " + unityWebRequest.error);
            }

            else
            {
                byte[] predata = unityWebRequest.downloadHandler.data;
                Encoding sjisEncoding = Encoding.GetEncoding("Shift_JIS");
                byte[] dst = Encoding.Convert(sjisEncoding, Encoding.Default, predata);
                string scrapedSentences = Encoding.Default.GetString(dst);

                Debug.Log("Recieved following text : " + "/n" + scrapedSentences);

                // InstantiatePagePrefab();
                InstantiatePagePrefab(scrapedSentences);
            }
        }
    }
    #endregion


    #region Instantiage PagePrefab

    [SerializeField]
    private GameObject firstPage;

    [SerializeField]
    private GameObject pagePrefab;

    // 1ページ当たりの文字数
    int charactersInPage = 270;

    List<GameObject> pagePrefabList = new List<GameObject>();

    void InstantiatePagePrefab(string sentences)
    {
        string bookTitle = sentences.ExtractTargetPattern("<h1 class=\"title\">.*</h1>");
        string bookAuthor = sentences.ExtractTargetPattern("<h2 class=\"author\">.*</h2>");

        string bookContent = sentences.ExtractTargetPattern("<div class=\"main_text\">.*</div>");

        // タイトルとなる1枚目を作成
        //--------------------------------------------------------------------------

        TMP_Text[] titleAndAuthorBox = firstPage.GetComponentsInChildren<TMP_Text>();
        titleAndAuthorBox[0].text = bookTitle;
        titleAndAuthorBox[1].text = bookAuthor;
        //--------------------------------------------------------------------------


        // 中身のページを作成
        //--------------------------------------------------------------------------

        // ページ数
        int pageCount = (int)Math.Ceiling((double)bookContent.Length / charactersInPage);

        //見開きページのpagePrefab数
        int pagePrefabsCount = (int)Math.Ceiling((double)pageCount / 2);

        // Instantiage the book text pages
        var sentencesInPageList = bookContent.CutText(charactersInPage, pageCount);

        for (int i = 0; i < pagePrefabsCount; i++)
        {
            pagePrefabList.Add(pagePrefab);

            Vector3 spawnPosition = new Vector3(0, 1.5f, 3 * i + 6);
            TMP_Text[] textBox = pagePrefabList[i].GetComponentsInChildren<TMP_Text>();

            // pageText[0], pageText[1] are contents
            textBox[0].text = sentencesInPageList[i * 2];
            textBox[1].text = sentencesInPageList[i * 2 + 1];

            // pageText[2], pageText[3] are page number
            textBox[2].text = (i * 2 + 1).ToString();
            textBox[3].text = (i * 2 + 2).ToString();

            Debug.Log(sentencesInPageList[i * 2]);
            Debug.Log(sentencesInPageList[i * 2 + 1]);

            Instantiate(pagePrefabList[i], spawnPosition, Quaternion.identity, transform);
        }

        //--------------------------------------------------------------------------
    }
    #endregion



    #region PunPRC for visiter

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + "Joined" + PhotonNetwork.CurrentRoom.Name);

        photonView.RPC(nameof(StartForVisiter), RpcTarget.OthersBuffered, ChosenBookInformation.targetURL);
    }

    #endregion
}
