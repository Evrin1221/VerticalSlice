using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArmMarking : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject image;
    [SerializeField] private GameObject leftArm;
    [SerializeField] private GameObject rightArm;
    [SerializeField] private GameObject instructions;


    [SerializeField] private GameObject leftMark;
    [SerializeField] private GameObject rightMark;




    [SerializeField] private TMP_Text _instructionsText;


    private Arm _markedArm;

    private List<GameObject> _everythingOnList;
    private List<GameObject> _everythingOffList;

    private int _uiSpawnTimes;
    void Start()
    {

        _everythingOnList = new List<GameObject>()
        {
        image,
        leftArm,
        rightArm,
        instructions,


        };

        _everythingOffList = new List<GameObject>()
{
    image,
    leftArm,
    rightArm,
    instructions,
    leftMark,
    rightMark 
};



        EverythingOff();
        _uiSpawnTimes = 0;

    }

    // Update is called once per frame

    public enum Arm
    {
        left, right
    }
    void Update()
    {
     
    }

    public void PickArm(Arm arm)
    {
        if (_uiSpawnTimes == 0)
        {
            _markedArm = arm;


            if (_markedArm == Arm.left)
            {
               leftMark.SetActive(true);
                _everythingOnList.Remove(rightMark);
                _everythingOnList.Add(leftMark);
                _everythingOffList.Remove(rightMark);
            }
            else
            {
                rightMark.SetActive(true);
                _everythingOnList.Remove(leftMark);
                _everythingOnList.Add(rightMark);
                _everythingOffList.Remove(leftMark);
            }

            CloseArmUI();
        }

        else
        {

        }
    }

    public void OpenArmUI()
    {
        EverythingOn();
        //Time.timeScale = 0f; // optional: pauses gameplay
        
    }

    public void CloseArmUI()
    {
        EverythingOff();
        Time.timeScale = 1f;
        _uiSpawnTimes++;
    }


    private void EverythingOff()
    {

        for (int i = 0; i < _everythingOffList.Count; i++)
        {
            _everythingOffList[i].SetActive(false);
        }
         
    }

    private void EverythingOn()
    {
        foreach (GameObject obj in _everythingOnList)
        {
            obj.SetActive(true);
        
    }


    }


    public void MarkLeftArm()
    {
        PickArm(Arm.left);
        Debug.Log("left");
       
    }

    public void MarkRightArm()
    {
        PickArm(Arm.right);
        Debug.Log("right");
    }
}
