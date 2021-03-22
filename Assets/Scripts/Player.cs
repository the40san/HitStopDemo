using UnityEngine;

namespace FortyWorks.Player
{
    public class Player : BaseBehaviour
    {
        private AttackCollider _attackCollider;
        
        protected override void Awake()
        {
            base.Awake();
            _attackCollider = GetComponentInChildren<AttackCollider>();
        }

        protected override void Update()
        {
            base.Update();
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExecuteAttack();
            }

            if (_attackCollider.Triggering)
            {
                var enemy = _attackCollider.TriggeringObject as Enemy;
                if (enemy == null)
                    return;
                
                 enemy.OnHitAttack();
                this.OnHitAttack();
                _attackCollider.Reset();
                _attackCollider.enabled = false;
            }
        }

        private void ExecuteAttack()
        {
            _animator.CrossFade("Attack", 0);
        }

        /// <summary>
        /// Animator Eventから呼ばれる
        /// </summary>
        private void OnHit()
        {
            _attackCollider.enabled = true;
        }

        private void OnHitAttack()
        {
            SetHitStop(7f);
            Camera.Instance.Shake();
        }
    }
}