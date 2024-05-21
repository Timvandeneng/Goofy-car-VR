using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadManager : MonoBehaviour
{

    public string Combination;
    public string DesiredCombination;

    [SerializeField] private Keypad_Key[] Keys;
    private ModuleInput moduleInput;

    [SerializeField] private float Timer;
    private float resetTimer;
    private bool CountDown;

    // Start is called before the first frame update
    void Start()
    {
        moduleInput = GetComponent<ModuleInput>();

        resetTimer = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        CheckCombination();
        CountDownFunct();
    }

    void CheckCombination()
    {
        if (Combination.Length == DesiredCombination.Length)
        {
            if (Combination != DesiredCombination)
            {
                for (int i = 0; i < Keys.Length; i++)
                {
                    Keys[i].Wrong();
                }
                CountDown = true;
                Combination = "";
            }
            else
            {
                for (int i = 0; i < Keys.Length; i++)
                {
                    Keys[i].Correct();
                }
                CountDown = true;
                moduleInput.digitalValue = true;
                Combination = "";
            }
        }
    }

    void CountDownFunct()
    {
        if (CountDown)
            Timer -= Time.deltaTime;

        if(Timer < 0)
        {
            for (int i = 0; i < Keys.Length; i++)
            {
                Keys[i].Reset();
            }
            Timer = resetTimer;
            CountDown = false;
            moduleInput.digitalValue = false;
        }
    }
}
