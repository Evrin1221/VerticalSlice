using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMarking : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject image;
    [SerializeField] private GameObject leftArm;
    [SerializeField] private GameObject rightArm;
    [SerializeField] private GameObject instructions;
    void Start()
    {

        EverythingOff();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenArmUI()
    {
        EverythingOn();
        Time.timeScale = 0f; // optional: pauses gameplay
    }

    public void CloseArmUI()
    {
        EverythingOff();
        Time.timeScale = 1f;
    }


    private void EverythingOff()
    {
        image.SetActive(false);
        leftArm.SetActive(false);
        rightArm.SetActive(false);
        instructions.SetActive(false);
    }

    private void EverythingOn()
    {
        image.SetActive(true);
        leftArm.SetActive(true);
        rightArm.SetActive(true);
        instructions.SetActive(true);
    }
}
