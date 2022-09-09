using UnityEngine;
using Spine.Unity;
using Sirenix.OdinInspector;

namespace DP.Tools
{
    public class SetupAnimation : MonoBehaviour
    {
        //[TabGroup("BASE"), SerializeField]
        //[SpineAnimation]
        //private string Die;
        //[TabGroup("BASE"), SerializeField]
        //[SpineEvent]
        //private string EventDie;
        //==========================================================================================================================================
        public bool IsEndDie { get; set; }

        //==========================================================================================================================================
        protected SkeletonAnimation mySkeletonAnimation;
        protected Spine.Skeleton mySkeleton;

        protected Spine.AnimationState myAnimationState;

        //==========================================================================================================================================
        protected virtual void Awake()
        {
            mySkeletonAnimation = GetComponent<SkeletonAnimation>();
            if (mySkeletonAnimation != null)
                mySkeleton = mySkeletonAnimation.Skeleton;
            if (mySkeletonAnimation != null)
                myAnimationState = mySkeletonAnimation.AnimationState;
        }

        protected virtual void Start()
        {
            mySkeletonAnimation.state.Event += Event;
        }

        /// <summary>
        /// Flip axis with X
        /// </summary>
        /// <param name="_value">value</param>
        [System.Obsolete]
        public virtual void SetFlipX(bool _value)
        {
            if (mySkeleton != null && !mySkeleton.FlipX.Equals(_value))
                mySkeleton.FlipX = _value;
        }

        /// <summary>
        /// Flip axis with Y
        /// </summary>
        /// <param name="_value">value</param>
        [System.Obsolete]
        public virtual void SetFlipY(bool _value)
        {
            if (mySkeleton != null && !mySkeleton.FlipY.Equals(_value))
                mySkeleton.FlipY = _value;
        }

        /// <summary>
        /// Set skin
        /// </summary>
        /// <param name="_nameSkin">name skin</param>
        public virtual void SetSkin(string _nameSkin)
        {
            if (mySkeletonAnimation != null)
            {
                mySkeleton.SetSkin(_nameSkin);
                mySkeleton.SetSlotsToSetupPose();
                mySkeletonAnimation.LateUpdate();
            }
        }

        public void SetAttachment(string slotName, string nameAttachment)
        {
            if (mySkeletonAnimation != null)
            {
                mySkeleton.SetAttachment(slotName, nameAttachment);
            }
            else
                Debug.Log("Skeleton null--");
        }

        /// <summary>
        /// Check Event
        /// </summary>
        /// <param name="_entry">entry</param>
        /// <param name="_event">event</param>
        public virtual void Event(Spine.TrackEntry _entry, Spine.Event _event)
        {
            //if (_event.Data.Name.Equals(EventDie))
            //{
            //    IsEndDie = true;
            //    EndDie();
            //}
        }

        ///// <summary>
        ///// When end event die
        ///// </summary>
        //public virtual void EndDie()
        //{
        //}
        /// <summary>
        /// Set Animation
        /// </summary>
        /// <param name="_name">name</param>
        /// <param name="_loop">loop</param>
        protected virtual void SetAnimation(string _name, bool _loop)
        {
            if (mySkeletonAnimation == null)
                mySkeletonAnimation = GetComponent<SkeletonAnimation>();
            if (mySkeletonAnimation != null && _name != null)
            {
                if (mySkeletonAnimation.AnimationName.Equals(_name))
                    return;
                //Debug.Log("=============> set anim: " + _name);
                myAnimationState.SetAnimation(0, _name, _loop);
            }
        }

        /// <summary>
        /// Reset animation
        /// </summary>
        /// <param name="_name">Name anim</param>
        /// <param name="_loop">Is loop</param>
        protected virtual void ResetAnimation(string _name, bool _loop)
        {
            if (mySkeletonAnimation == null)
                mySkeletonAnimation = GetComponent<SkeletonAnimation>();
            if (mySkeletonAnimation != null && _name != null)
            {
                //Debug.Log("=============> set anim: " + _name);
                myAnimationState.SetAnimation(0, _name, _loop);
            }
        }

        ////Set animation die
        //public virtual void SetDie()
        //{
        //    if (Die == null)
        //        return;
        //    SetAnimation(Die, false);
        //}
        // Set timescale
        public virtual void SetTimeScale(float _timeScale)
        {
            if (mySkeletonAnimation != null)
            {
                mySkeletonAnimation.timeScale = _timeScale;
            }
        }

        // Get timescale
        public virtual float GetTimeScale()
        {
            if (mySkeletonAnimation == null)
                return -1f;
            else
                return mySkeletonAnimation.timeScale;
        }
    }
}