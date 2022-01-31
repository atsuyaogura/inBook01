using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BookURLInformation : MonoBehaviour
{
    static TextAsset csvFile;
    static List<string[]> bookURLInformation = new List<string[]>();
    //500 works so up to 500

    public int[] bookID = new int[501];
    public string[] bookTitle = new string[501];
    public string[] bookAuthor = new string[501];
    public string[] bookURL = new string[501];

    static void CsvReader()
    {
        csvFile = Resources.Load("CSV/BookURLtest") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        while(reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            bookURLInformation.Add(line.Split(','));
        }
    }

    public void Init()
    {
        CsvReader();
        for (int i = 1; i < bookURLInformation.Count; i++)
        {
            bookID[i] = int.Parse(bookURLInformation[i][0]);
            bookTitle[i] = bookURLInformation[i][1];
            bookAuthor[i] = bookURLInformation[i][2];
            bookURL[i] = bookURLInformation[i][3];
        }
    }
    
}
