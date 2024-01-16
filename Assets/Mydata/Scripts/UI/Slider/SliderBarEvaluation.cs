using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderBarEvaluation : SliderBar
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        //this.SetCurren(EvaluationCtrl.Instance.CurrentEvaluation);
        //this.SetCurrenMax(EvaluationCtrl.Instance.MaxCurrentValuation);
    }
}
