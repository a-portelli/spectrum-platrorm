using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leftUI : MonoBehaviour
{
    //sets public counter for script
    public int j = 0;

    //global bool for button turn on
    public bool buttonIsClicked = true;

    //creates Toggles
    public Toggle toggleA;
    public Toggle toggleB;
    public Toggle toggleC;
    public Toggle toggleD;
    public Toggle toggleEW;

    //creates public text variabls for display
    public Text nodeName;
    public Text iff;
    public Text accuracy;
    public Text lat;
    public Text lon;

    public Text status;
    public Text timeText;
    public Text tagText;

    public Text antTypeText;
    public Text antSectorText;
    public Text antFreqText;

    public Text antBeamHeight;
    public Text aziText;
    public Text antRangeText;

    //variables from node scripts (A,B,C,D,EW)

    //NODE A
    public readNodeA _readNodeA; 

    //NODE B
    public readNodeB _readNodeB; 

    //NODE C
    public readNodeC _readNodeC; 

    //NODE D
    public readNodeD _readNodeD; 

    //NODE EW
    public readNodeEW1 _readNodeEW1;

    //Radar Script
    public radarScript _radarScript;

    //Sets Toggle A to be on first
    private void Start()
    {
        toggleA.isOn = true;
    }
    private void Update() {

        if(toggleA.isOn == true)
        {
            nodeName.text = "Node A";
            iff.text = _readNodeA.iff;
            accuracy.text = _readNodeA.accuracy.ToString();
            status.text = _readNodeA.status.ToString();
            timeText.text = _readNodeA.timeData.ToString();
            tagText.text = _readNodeA.tag.ToString();
            antTypeText.text = _readNodeA.antType.ToString();
            antSectorText.text = _readNodeA.antSector.ToString();
            antFreqText.text = _readNodeA.antFreq.ToString();
            aziText.text = _readNodeA.antAzi.ToString();
            antRangeText.text = _readNodeA.antRange.ToString();

            lat.text = _readNodeA.latDisplay.ToString();
            lon.text = _readNodeA.lonDisplay.ToString();
        }
        else if (toggleB.isOn == true)
        {
            nodeName.text = "Node B";
            iff.text = _readNodeB.iff;
            accuracy.text = _readNodeB.accuracy.ToString();
            status.text = _readNodeB.status.ToString();
            timeText.text = _readNodeB.timeData.ToString();
            tagText.text = _readNodeB.tag.ToString();
            antTypeText.text = _readNodeB.antType.ToString();
            antSectorText.text = _readNodeB.antSector.ToString();
            antFreqText.text = _readNodeB.antFreq.ToString();
            aziText.text = _readNodeB.antAzi.ToString();
            antRangeText.text = _readNodeB.antRange.ToString();

            lat.text = _readNodeB.latDisplay.ToString();
            lon.text = _readNodeB.lonDisplay.ToString();
        }
        else if (toggleC.isOn == true)
        {
            nodeName.text = "Node C";
            iff.text = _readNodeC.iff;
            accuracy.text = _readNodeC.accuracy.ToString();
            status.text = _readNodeC.status.ToString();
            timeText.text = _readNodeC.timeData.ToString();
            tagText.text = _readNodeC.tag.ToString();
            antTypeText.text = _readNodeC.antType.ToString();
            antSectorText.text = _readNodeC.antSector.ToString();
            antFreqText.text = _readNodeC.antFreq.ToString();
            aziText.text = _readNodeC.antAzi.ToString();
            antRangeText.text = _readNodeC.antRange.ToString();

            lat.text = _readNodeC.latDisplay.ToString();
            lon.text = _readNodeC.lonDisplay.ToString();
        }
        else if (toggleD.isOn == true)
        {
            nodeName.text = "Node D";
            iff.text = _readNodeD.iff;
            accuracy.text = _readNodeD.accuracy.ToString();
            status.text = _readNodeD.status.ToString();
            timeText.text = _readNodeD.timeData.ToString();
            tagText.text = _readNodeD.tag.ToString();
            antTypeText.text = _readNodeD.antType.ToString();
            antSectorText.text = _readNodeD.antSector.ToString();
            antFreqText.text = _readNodeD.antFreq.ToString();
            aziText.text = _readNodeD.antAzi.ToString();
            antRangeText.text = _readNodeD.antRange.ToString();

            lat.text = _readNodeD.latDisplay.ToString();
            lon.text = _readNodeD.lonDisplay.ToString();
        }
        else 
        {
            nodeName.text = "Node EW";
            iff.text = _readNodeEW1.iff;
            accuracy.text = _readNodeEW1.accuracy.ToString();
            status.text = _readNodeEW1.status.ToString();
            timeText.text = _readNodeEW1.timeData.ToString();
            tagText.text = _readNodeEW1.tag.ToString();
            antSectorText.text = _readNodeEW1.antSector.ToString();
            antFreqText.text = _readNodeEW1.antFreq.ToString();
            aziText.text = _radarScript.azi.ToString();
            antRangeText.text = _readNodeEW1.antRange.ToString();

            lat.text = _readNodeEW1.latDisplay.ToString();
            lon.text = _readNodeEW1.lonDisplay.ToString();
        }
    }

}
