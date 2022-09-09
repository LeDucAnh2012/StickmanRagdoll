using UnityEngine;
using Spine.Unity;

namespace DP.Tools
{
    public class SetupAnimationCanvas : MonoBehaviour
    {
        protected SkeletonGraphic mySkeletonGraphic;

        protected virtual void Awake()
        {
            mySkeletonGraphic = GetComponent<SkeletonGraphic>();
        }
        protected virtual void Start()
        {
            InitEvent();
        }
        public virtual void InitEvent()
        {
            mySkeletonGraphic.AnimationState.Event += Event;

            //// Start event
            //mySkeletonGraphic.AnimationState.Start += delegate (Spine.TrackEntry _entry)
            //{
            //    EventStart(_entry);
            //};

            //// end event
            //mySkeletonGraphic.AnimationState.End += delegate
            //  {
            //      EventEnd(mySkeletonGraphic.AnimationState.ToString());
            //  };
        }

        /// <summary>
        /// Set skin
        /// </summary>
        /// <param name="_name">name skin</param>
        public virtual void SetSkin(string _name)
        {
            //Debug.Log(name + "/" + mySkeletonGraphic + "/" + mySkeleton);
            if (mySkeletonGraphic != null)
            {
                mySkeletonGraphic.Skeleton = mySkeletonGraphic.Skeleton;
                mySkeletonGraphic.Skeleton.SetSkin(_name);
                mySkeletonGraphic.Skeleton.SetSlotsToSetupPose();
                mySkeletonGraphic.initialSkinName = _name;
            }
        }
        /// <summary>
        /// Event
        /// </summary>
        /// <param name="_entry">entry</param>
        /// <param name="_event">event</param>
        public virtual void Event(Spine.TrackEntry _entry, Spine.Event _event)
        {
        }

        /// <summary>
        /// Set animation
        /// </summary>
        /// <param name="_name">name animation</param>
        /// <param name="_value">loop</param>
        public virtual void SetAnimation(string _name, bool _value)
        {
            //mySkeletonGraphic.Initialize(false);
            if (mySkeletonGraphic == null)
                mySkeletonGraphic = GetComponent<SkeletonGraphic>();
            if (mySkeletonGraphic == null)
                return;

            if (_name == null)
                return;

            if (mySkeletonGraphic.startingAnimation.Equals(_name))
                return;

            //myAnimationState = mySkeletonGraphic.AnimationState;
            mySkeletonGraphic.startingAnimation = _name;
            mySkeletonGraphic.AnimationState.SetAnimation(0, _name, _value);
        }
        /// <summary>
        /// Do reset animation
        /// </summary>
        /// <param name="_name">name</param>
        public virtual void DoResetAnimation(string _name, bool _loop)
        {
            if (_name == null)
                return;
            if (mySkeletonGraphic == null)
                mySkeletonGraphic = GetComponent<SkeletonGraphic>();
            if (mySkeletonGraphic == null)
                return;

            mySkeletonGraphic.Initialize(true);
            InitEvent();
            //myAnimationState = mySkeletonGraphic.AnimationState;
            //Debug.Log("uhemd" + _name + "/" + mySkeletonGraphic);
            mySkeletonGraphic.startingAnimation = _name;
            mySkeletonGraphic.AnimationState.SetAnimation(0, _name, _loop);
            //mySkeletonGraphic.AnimationState.SetAnimation()
        }
    }
}
