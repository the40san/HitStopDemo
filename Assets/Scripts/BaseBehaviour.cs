using UnityEngine;

namespace FortyWorks.Player
{
    public class BaseBehaviour : MonoBehaviour
    {
        private const float DELTA_TO_FPS = 1f / 60;
        protected Animator _animator;
        
        // 状態変数
        private float _hitStopTimer;

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        protected virtual void Update()
        {
            UpdateHitStop();
        }
        
        protected virtual void LateUpdate()
        {
        }

        protected void SetHitStop(float frame)
        {
            _hitStopTimer = frame;
        }

        /// <summary>
        /// 毎フレーム呼ばれる
        /// </summary>
        private void UpdateHitStop()
        {
            if (_hitStopTimer > 0)
            {
                _animator.speed = 0.02f;
                _hitStopTimer -= Time.unscaledDeltaTime / DELTA_TO_FPS;
                
                return;
            }
            
            _animator.speed = 1.0f;
        }
        
    }
}