using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchAden : MonoBehaviour
{
    public enum SwitchState { On, Off }

    public UnityEvent whenTurnedOn;
    public UnityEvent whenTurnedOff;

    SwitchState curState;
    Animator anim;

    private void Start()
    {
        curState = SwitchState.Off;

        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 11)
        {
            Destroy(other.gameObject);

            if (curState == SwitchState.On)
            {
                anim.SetBool("IsOn", false);
                curState = SwitchState.Off;
                whenTurnedOff.Invoke();
            }
            else
            {
                anim.SetBool("IsOn", true);
                curState = SwitchState.On;
                whenTurnedOn.Invoke();
            }
        }
    }
}
