﻿using UnityEngine;
using System.Collections;
using System.IO;
using NiceJson;

public class JsonTest : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        ExampleTest();
        //InputOutputFileTest();
        CreateJsonTest();
    }

    private void ExampleTest()
    {
        JsonExample example = new JsonExample();
        Debug.Log("Test InputOutputFileTest done");
    }

    private void InputOutputFileTest()
    {
        string inputfile = "/Samples/sample.json";
        string outputPutfile = "/Samples/sample2.json";

        //Debug.Log("Reading file " + inputfile + " ...");

        string jsonString = File.ReadAllText("Assets/" + inputfile);

        //Debug.Log("Parse file");

        JsonNode node = JsonNode.ParseJsonString(jsonString);

        //Debug.Log("Saving file " + outputPutfile + " ...");

        File.WriteAllText("Assets/" + outputPutfile, node.ToJsonPrettyPrintString());

        Debug.Log("Test InputOutputFileTest done");
    }

    private void CreateJsonTest()
    {
        JsonArray weekDiet = new JsonArray();
        for(int i=0;i<7;i++)
        {
            JsonObject diet = new JsonObject();
            diet["DayNumber"] = i;
            diet["Breakfast"] = "Banana"+ i;
            diet["Lunch"] = "Banana"+ i;
            diet["Dinner"] = "Banana"+ i;
            diet["WithSugar"] = (i % 2 == 0);
            diet["RandomNumber"] = Random.Range(0f,1.5f);

            weekDiet.Add(diet);
        }

        for (int i=0;i<7;i++)
        {
            if (i % 2 == 1)
            {
                weekDiet[i]["RandomNumber"] = 3;
                weekDiet[i]["RandomNumber"] = weekDiet[i]["RandomNumber"] * 2f;
            }
        }

        Debug.Log("Test InputOutputFileTest done: \n"+ weekDiet.ToJsonPrettyPrintString());
    }
}