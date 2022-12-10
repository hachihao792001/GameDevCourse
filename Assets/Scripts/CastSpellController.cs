using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
public class CastSpellController : MonoBehaviour
{
    [SerializeField] ThirdPersonUserControl userControl;
    [SerializeField] Animator animator;
    [SerializeField] Collider _collider;
    [SerializeField] Rigidbody _rb;
    public bool IsPlayingCastSpellAnim;

    [SerializeField] GameObject _firePillarPrefab;
    [SerializeField] float _firePillarSpawnDistance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("CastSpell");
            if (!userControl.IsMoving)
            {
                animator.SetTrigger("CastSpellLeg");
                _collider.enabled = false;
                _rb.isKinematic = true;
                animator.applyRootMotion = true;
            }
            IsPlayingCastSpellAnim = true;
        }
    }

    public void OnCastSpell()
    {
        Instantiate(_firePillarPrefab, transform.position + transform.forward * _firePillarSpawnDistance, Quaternion.identity);
    }
    public void CastSpellDone()
    {
        IsPlayingCastSpellAnim = false;
        _collider.enabled = true;
        _rb.isKinematic = false; animator.applyRootMotion = false;
    }
}
