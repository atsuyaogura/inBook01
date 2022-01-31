using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// ArrangeText to fit sentences to pages
/// 指定した文字数で文字列を区切る
/// </summary>
public static class StringExtentions
{
    #region Extract Title
    public static string ExtractTargetPattern(this string self, string regexPattern)
    {
        // 正規表現パターンに合う部分を摘出
        // <head>.*</head> と <body>.*</body>　の二択
        string textWithHTML = Regex.Match(self, regexPattern, RegexOptions.Singleline).Value;

        // htmlタグ削除
        string titleOrContent = Regex.Replace(textWithHTML, "<[^>]*?>", string.Empty);

        string trimedTitleOrContent = titleOrContent.Trim();

        Debug.Log(trimedTitleOrContent);
        return trimedTitleOrContent;
    }
    #endregion


    #region Cut Text by the number of characters in a page
    public static List<string> CutText(this string self, int charactersInPage, int pageCount)
    {
        var result = new List<string>();

        for (int i = 0; i < pageCount; i++)
        {
            int start = charactersInPage * i;

            if (self.Length <= start)
            {
                break;
            }
            if (self.Length < start + charactersInPage)
            {
                result.Add(self.Substring(start));
            }
            else
            {
                result.Add(self.Substring(start, charactersInPage));
            }
        }
        return result;
    }
    #endregion
}
