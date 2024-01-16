using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBeQueenChar : AICharacter
{
    protected override void InteractAfterMove() {
        base.InteractAfterMove();
        transform.forward = -Vector3.forward;
    }
}
