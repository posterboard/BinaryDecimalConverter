//I used the Salma Alfasans Sans Serif Font by Alifinart Studio in the GUI.
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public GameObject panel;
    public GameObject instructionsPanel;
    public Text tOut;
    public Text inputF;
    public Text outputMode;
    public Text inputMode;
    public Text[] inputLog = new Text[10];
    public Text[] outputLog = new Text[10];
    string[,]  historyLog = new string[10,10];
    string inputString;
    string outputString;
    bool startReplace = false;
    int inputToInt;
    int calculationsMade = 0;
  
    int outputModeNum = -1;//0=binary 1=decimal
    int inputModeNum = -1;//0=binary 1=decimal
    private void Update()
    {
        quit();

       
    }

    private static void quit()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void history()
    {
        
    }
    public void calculate()
    {
        switch (inputMode.text)
        {//assigns variable based on dropdown selection
            case "Binary":
                inputModeNum = 0;
                break;
            case "Decimal":
                inputModeNum = 1;
                break;
            default:
                break;
        }
        switch (outputMode.text)
        {
            case "Binary":
                outputModeNum = 0;
                break;
            case "Decimal":
                outputModeNum = 1;
                break;
            default:
                break;
        }

        if (int.TryParse(inputF.text, out inputToInt))//checks to see if input is an integer
        {
            inputToInt = int.Parse(inputF.text);

            if (inputModeNum == 0)
            {
                if (outputModeNum == 0)//binary to binary
                {
                    if (inBinary(inputToInt))
                    {
                        tOut.text = inputToInt.ToString();
                    }
                    else
                    {
                        tOut.text = "Error";
                    }
                }
                if (outputModeNum == 1)//binary to decimal
                {
                    if (inBinary(inputToInt))
                    {
                        tOut.text = convertToDecimal(inputToInt);
                    }
                    else
                    {
                        tOut.text="Error";
                    }
                }
            }
            if (inputModeNum == 1)
            {
                if (outputModeNum == 0)//decimal to binary
                {

                    tOut.text = convertToBinary(inputToInt);

                }
                if (outputModeNum == 1)//decimal to binary
                {
                    tOut.text = inputToInt.ToString();
                }
            }
            outputString = tOut.text;
            inputString = inputF.text;
            if (calculationsMade < 10)
            {
                historyLog[0,9- calculationsMade] = inputString;
                historyLog[1,9- calculationsMade] = outputString;
            }
            else
            {
                startReplace = true;
            }
            calculationsMade++;


            historyLog = updateHistoryLog( startReplace, historyLog, inputString, outputString) ;
            updateLogText(historyLog);
        }
        else
        {
            tOut.text = "Error";
        }
    }
    
    public void openPanel()//history button activates this method
    {
        panel.SetActive(true);
    }
    public void closePanel()//x button activates this method
    {
        panel.SetActive(false);
    }
    string convertToBinary(int decimalInput){
        int p=decimalInput;//placeholder for input
        int temp = 0;
        string binaryString="";
       while(true)//algorithm finds the remainder of the input when divided by 2, then adds it to a string. The input is then divided by 2 and the process 
            //repeats until the input is 0.
        {
            temp = p % 2;
            if (temp == 0) {
                binaryString += "0";
            }
            else
            {
                binaryString += "1";
            }
            p /= 2;
            if (p< 1)
            { 
                break;
            }
        }
        //since the algorithm returns the smallest numbers first, the string has to be reversed
        char[] binaryChar = binaryString.ToCharArray();
        Array.Reverse(binaryChar);
        binaryString = new string(binaryChar);
        return binaryString;
        }
    string convertToDecimal(int input)
    {
        int temp = input;
        int decimalInt=0;
        int power=1;
        string decimalString = "";
        if (inBinary(temp))
        {


           
            while (temp > 0)
            {
                decimalInt += (temp % 10)*power;
                temp/= 10;
                power*=2;
            }
        }
        else
        {
            decimalString = "Error";
        }
        decimalString = decimalInt.ToString();
        return decimalString;
    }
    bool inBinary(int input)//checks if a string only contains 1s and 0s.
    {
        string inputString = input.ToString();
        bool isBinary = true;
        for (int i = 0; i < inputString.Length; i++)
        {
            if (!inputString[i].Equals('1')&&!inputString[i].Equals('0')) {
            isBinary = false;
            }
        }
        return isBinary;
    }
    string[,] updateHistoryLog(bool logsFilled,string[,] log, string replaceInput,string replaceOutput)//updates the array that holds the history data
    {
        string replaceString="";
        string[,] updatedHistoryLog=log;
        if (logsFilled == true) 
        {//start replacing existing entries after there are 10 entries
                for (int j = 9; j >0; j--)
                {
                    updatedHistoryLog[0, j ] = updatedHistoryLog[0, j-1];
                    updatedHistoryLog[1, j] = updatedHistoryLog[1, j - 1];
            }
                updatedHistoryLog[0, 0] = replaceInput;
                updatedHistoryLog[1, 0] = replaceOutput;

   
       
        }
        return updatedHistoryLog;
    }
    void updateLogText(string[,] log)//updates the text UI on screen
    {
        for(int i= 0; i < 10; i++)
        {
            inputLog[i].text = log[0, i];
            outputLog[i].text = log[1, i];
        }
    }
    public void openInstructionPanel()
    {
        instructionsPanel.SetActive(true);
    }
    public void closeInstructionPaenl()
    {
        instructionsPanel.SetActive(false);
    }
}
