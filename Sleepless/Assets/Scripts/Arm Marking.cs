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

    [SerializeField] private GameObject leftTally1;
    [SerializeField] private GameObject rightTally1;
    [SerializeField] private GameObject leftTally2;
    [SerializeField] private GameObject rightTally2;
    [SerializeField] private GameObject leftTally3;
    [SerializeField] private GameObject rightTally3;



    [SerializeField] private TMP_Text _instructionsText;


    private Arm _markedArm;

    private List<GameObject> _everythingOnList;
    private List<GameObject> _everythingOffList;

    private List<GameObject> _rightTallyList;
    private List<GameObject> _leftTallyList;

    private int _leftCount;
    private int _rightCount;    
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
    rightMark, 
    leftTally1,leftTally2,leftTally3,
    rightTally1,rightTally2,rightTally3
};


        _leftTallyList = new List<GameObject>()
        {
            leftTally1,leftTally2, leftTally3
        };

        _rightTallyList = new List<GameObject>()
        {
            rightTally1,rightTally2, rightTally3
        };




        EverythingOff();
        _uiSpawnTimes = 0;
        _leftCount = 0;
        _rightCount = 0;    

    }

    // Update is called once per frame

    public enum Arm
    {
        left, right
    }
    void Update()
    {
     if (_uiSpawnTimes == 4)
        {
            EverythingOn();

            if(_markedArm == Arm.left)
            {
                _instructionsText.SetText($"Score: {_leftCount}/3");
            }
            else
            {
                _instructionsText.SetText($"Score: {_rightCount}/3");
            }
            

        }
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
             //   _everythingOffList.Remove(rightMark);
            }
            else
            {
                rightMark.SetActive(true);
                _everythingOnList.Remove(leftMark);
                _everythingOnList.Add(rightMark);
              //  _everythingOffList.Remove(leftMark);
            }

            //CloseArmUI();
        }

        else
        {
            _instructionsText.SetText("click the marked arm");
            Arm selectedArm = arm;

            if(selectedArm == Arm.left)
            {
                /*
                _leftCount++;
                for (int i = 0; i < _leftCount; i++)
                {
                    _leftTallyList[i].SetActive(true);
                    _everythingOnList.Add(_leftTallyList[i]);
                }
                */
                if (_leftCount < _leftTallyList.Count)
                {
                    _leftTallyList[_leftCount].SetActive(true);
                    _everythingOnList.Add(_leftTallyList[_leftCount]);
                    _leftCount++;
                }
            }
            else
            {
                /*
                _rightCount++;
                for (int i = 0; i < _rightCount; i++)
                {
                    _rightTallyList[i].SetActive(true);
                    _everythingOnList.Add(_rightTallyList[i]);
                }
                */
                if (_rightCount < _rightTallyList.Count)
                {
                    _rightTallyList[_rightCount].SetActive(true);
                    _everythingOnList.Add(_rightTallyList[_rightCount]);
                    _rightCount++;
                }
            }

        }
        CloseArmUI();
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
