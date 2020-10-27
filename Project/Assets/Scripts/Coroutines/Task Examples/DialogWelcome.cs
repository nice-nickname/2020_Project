using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogWelcome : MonoBehaviour
{
    private Dialog Dialog;

    private void Awake()
    {
        Dialog = GetComponent<Dialog>();
    }

    private void Start()
    {
        Dialog.StartTalk();
        Talk();
    }

    public void Talk()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        Dialog.Talk();
    }

}
