
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;

public class DictionaryAPI : MonoBehaviour
{
    private string url;
    
    private void Start()
    {
        Search("올빼미");
    }

    private void Search(string query)
    {
        url = "https://stdict.korean.go.kr/api/search.do?certkey_no=2236&key=F0454675BC5AD1A01C984B5371D4E99D&type_search=search&q=" + query;
        SetText();
    }

    private void SetText()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        string status = response.StatusCode.ToString();
        if (status == "OK")
        {
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string text = reader.ReadToEnd();

            // 파싱할 부분의 시작부분 검색
            int index1 = text.IndexOf("<definition><![CDATA[") + 21;

            // 끝부분 검색
            int index2 = text.IndexOf("]]></definition>");

            //다시 담기
            string str = text.Substring(index1, index2 - index1);

            Debug.Log(str);
        }
        else
        {
            Debug.Log("Error 발생=" + status);
        }
    }
}