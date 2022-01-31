using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookCreate : MonoBehaviour
{
    // define array of bookPrefab, which is called bookPrefabColletion.
    public GameObject[] bookPrefabCollection = new GameObject[500];

    [SerializeField]
    private BookURLInformation bookURLInfo;

    [SerializeField]
    private GameObject bookPrefab;

    // Instantiate position setting
    private float bookRadius = 10f;
    private float bookAngle = 7.2f;


    private void Start()
    {
        bookURLInfo.Init();

        CreateBooks(bookURLInfo.bookID, bookURLInfo.bookTitle, bookURLInfo.bookAuthor, bookURLInfo.bookURL);
    }

    //method that creates 500 bookprefabs
    public void CreateBooks(int[] ID, string[] title, string[] author, string[] uRLs)
    {

        for (int i = 0; i < 500; i++)
        {
            Vector3 spawnPosition = new Vector3(bookRadius * Mathf.Cos(bookAngle * Mathf.Deg2Rad * i),
                                                1.0f + (float)(i / 50 * 1.5),
                                                bookRadius * Mathf.Sin(bookAngle * Mathf.Deg2Rad * i));
            Quaternion rot = Quaternion.AngleAxis(90 - (bookAngle * i), Vector3.up);
            bookPrefabCollection[i] = Instantiate(bookPrefab, spawnPosition, rot, transform);

            bookPrefabCollection[i].GetComponent<BookCreateID>().bookID = ID[i+1];

            Text[] bookTexts = bookPrefabCollection[i].GetComponentsInChildren<Text>();
            bookTexts[0].text = title[i+1];
            bookTexts[1].text = author[i+1];
            bookTexts[2].text = uRLs[i+1];
        }
    }
}