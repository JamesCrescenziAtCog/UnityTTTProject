using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TTTController : MonoBehaviour
{
    //["", "X", ""]
    //["", "X", "O"]
    //["","", ""]
    [Serializable]
    public class dataModel
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
        val[1] = new[] { "", "", "" };
        val[2] = new[] {"", "", ""};
        
        var response = await NextGameState(val);

        //Debug.Log("Returned data: " + response.value);

    }

    public async Task<dataModel> NextGameState(string[][] value)
    {
        //dataModel rv =  new dataModel();

        HttpClient hc = new HttpClient();



        //var data = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(value)));
        //string valueToString = Newtonsoft.Json();
        string valueToString = "[[\"X\", \"\", \"\"], [\"\",\"\",\"\"],[\"\",\"\",\"\"]]";
        //for (var i = 0; i < 3; i++)
        //{
        //     valueToString += JsonUtility.ToJson(value[i], true);
        //}


        var data = new StringContent(valueToString, Encoding.UTF8, "application/json");
        Debug.Log(valueToString);
        Debug.Log(valueToString.Length);
        Debug.Log(value[0][0]);
        Debug.Log(data);

        //var response = await hc.PostAsync("https://mk-tictactoe-game.azurewebsites.net/api/Game/", data);
        var response = await hc.PostAsync("http://localhost:5000/api/Game/", data);
        var dtTest = await response.Content.ReadAsStringAsync();
        Debug.Log(response.IsSuccessStatusCode);

        Debug.Log("Call Data: " + dtTest);
        var rv = JsonUtility.FromJson<dataModel>(dtTest);

        Debug.Log("Return value: " + rv.ToString());
        Debug.Log("Test1: " + rv.winLine_StartBox);

        return rv;



    
    }

}
