using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class MyThirdPersonCharacter : ThirdPersonCharacter
{
    [SerializeField] CastSpellController castSpellController;
    protected override void SetRootMotion(bool applyRootMotion)
    {
        if (!castSpellController.IsPlayingCastSpellAnim)
        {
            base.SetRootMotion(applyRootMotion);
        }
        else
        {
            m_Animator.applyRootMotion = true;
        }
    }
    public override void OnAnimatorMove()
    {
        if (!castSpellController.IsPlayingCastSpellAnim)
        {
            base.OnAnimatorMove();
        }
        else
        {
            m_Animator.ApplyBuiltinRootMotion();
        }
    }
}
