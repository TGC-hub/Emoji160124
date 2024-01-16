using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextEvaluationLevel : BaseText
{
    protected virtual void FixedUpdate()
    {
        CompareEvaluation();
    }

    protected virtual void CompareEvaluation()
    {
        //float value = EvaluationCtrl.Instance.CurrentEvaluation - EvaluationCtrl.Instance.EvaluationDevil();
        //if (value > 0)
        //{
        //    this.text.SetText("You are Angle");
        //}
        //else
        //{
        //    this.text.SetText("You are Devil");
        //}
    }
}
