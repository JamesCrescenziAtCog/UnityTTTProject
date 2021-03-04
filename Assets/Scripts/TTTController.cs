using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft;
using System.Linq;

public class TTTController : MonoBehaviour
{


    //["", "X", ""]
    //["", "X", "O"]
    //["","", ""]
    [Serializable]
    public class DataModel
    {
        public string[][] board;
        public int winLine_StartBox;
        public int winLine_EndBox;
        public int status;
    }


    public async void callMethod()
    {
        string[][] val = new string[3][];
        val[0] = new[] { "X", "", "" };
        val[1] = new[] { "", "O", "" };
        val[2] = new[] {"X", "", ""};
        
        var response = await NextGameState(val);

        //Debug.Log("Returned data: " + response.value);

    }

    public async Task<DataModel> NextGameState(string[][] value)
    {

        HttpClient hc = new HttpClient();
        var valueToString = Newtonsoft.Json.JsonConvert.SerializeObject(value);
        var data = new StringContent(valueToString, Encoding.UTF8, "application/json");
        var response = await hc.PostAsync("http://localhost:5000/api/Game/", data);
        var dtTest = await response.Content.ReadAsStringAsync();
        Debug.Log(response.IsSuccessStatusCode);

        Debug.Log("Call Data: " + dtTest);
        DataModel rv = Newtonsoft.Json.JsonConvert.DeserializeObject<DataModel>(dtTest);

       // DataModel rv = new DataModel {board=rvRaw.board, };

        //var rv = rvRaw.Select(x =>new dataModel {board=x.board, status=x.status,winLine_StartBox=x.winLine_StartBox,winLine_EndBox=x.winLine_EndBox});

        //Debug.Log(rv.board);

        return rv;



    
    }



}
