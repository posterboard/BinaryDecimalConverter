/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numbers : MonoBehaviour
{
    public Text tOut;
    public Text inputF;
    public Text outputMode;
    public Text inputMode;
    public string[] inputList = new string[10];
    public string[] outputList = new string[10];
    int inputToInt;
    int calculationsMade = 0;

    int outputModeNum = -1;//0=binary 1=decimal
    int inputModeNum = -1;//0=binary 1=decimal

    private void Update()
    {
        Debug.Log(outputModeNum + " " + inputModeNum);
        Debug.Log(inBinary(inputToInt));
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
    }
    public void calculate()
    {


        if (int.TryParse(inputF.text, out inputToInt))//checks to see if input is an integer
        {
            inputToInt = int.Parse(inputF.text);

            if (inputModeNum == 0)
            {
                if (outputModeNum == 0)//binary to binary
                {
                    tOut.text = inputToInt.ToString();
                }
                if (outputModeNum == 1)//binary to decimal
                {
                    tOut.text = convertToDecimal(inputToInt);
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
        }
        else
        {
            tOut.text = "Error";
        }
    }
}
*/