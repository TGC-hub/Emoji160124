using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FollowTarget
{
    protected override void Start()
    {
        base.Start();
        target = LevelSpawner.Instance.CurrentLevel.MainChar.transform;
    }
    protected virtual void FixedUpdate()
    {
        target = LevelSpawner.Instance.CurrentLevel.MainChar.transform;
    }
    protected override void SetDesiredPositions()
    {
        var pos = transform.position;
        pos.x = target.position.x;
        transform.position = pos;
    }

    protected override void UpdatePos()
    {
    }
}
