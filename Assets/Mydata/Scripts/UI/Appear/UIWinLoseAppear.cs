using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWinLoseAppear : BaseAppear
{
    protected override void Start()
    {
        SetStartPos();
        //StartCoroutine(WaitForSecond());
        Appear();
    }

    /*    IEnumerator WaitForSecond()
        {
            yield return new WaitForSeconds(5f);
            Appear();
        }

        public override void Appear()
        {
            this.show = true;
        }*/
}
