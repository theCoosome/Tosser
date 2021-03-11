//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Valve.VR
{
    using System;
    using UnityEngine;
    
    
    public partial class SteamVR_Actions
    {
        
        private static SteamVR_Action_Boolean p_viveBase_InteractUI;
        
        private static SteamVR_Action_Boolean p_viveBase_Teleport;
        
        private static SteamVR_Action_Boolean p_viveBase_GrabPinch;
        
        private static SteamVR_Action_Boolean p_viveBase_Reset;
        
        private static SteamVR_Action_Pose p_viveBase_Pose;
        
        private static SteamVR_Action_Skeleton p_viveBase_SkeletonLeftHand;
        
        private static SteamVR_Action_Skeleton p_viveBase_SkeletonRightHand;
        
        private static SteamVR_Action_Single p_viveBase_Squeeze;
        
        private static SteamVR_Action_Boolean p_viveBase_HeadsetOnHead;
        
        private static SteamVR_Action_Boolean p_viveBase_SnapTurnLeft;
        
        private static SteamVR_Action_Boolean p_viveBase_SnapTurnRight;
        
        private static SteamVR_Action_Vibration p_viveBase_Haptic;
        
        public static SteamVR_Action_Boolean viveBase_InteractUI
        {
            get
            {
                return SteamVR_Actions.p_viveBase_InteractUI.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean viveBase_Teleport
        {
            get
            {
                return SteamVR_Actions.p_viveBase_Teleport.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean viveBase_GrabPinch
        {
            get
            {
                return SteamVR_Actions.p_viveBase_GrabPinch.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean viveBase_Reset
        {
            get
            {
                return SteamVR_Actions.p_viveBase_Reset.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Pose viveBase_Pose
        {
            get
            {
                return SteamVR_Actions.p_viveBase_Pose.GetCopy<SteamVR_Action_Pose>();
            }
        }
        
        public static SteamVR_Action_Skeleton viveBase_SkeletonLeftHand
        {
            get
            {
                return SteamVR_Actions.p_viveBase_SkeletonLeftHand.GetCopy<SteamVR_Action_Skeleton>();
            }
        }
        
        public static SteamVR_Action_Skeleton viveBase_SkeletonRightHand
        {
            get
            {
                return SteamVR_Actions.p_viveBase_SkeletonRightHand.GetCopy<SteamVR_Action_Skeleton>();
            }
        }
        
        public static SteamVR_Action_Single viveBase_Squeeze
        {
            get
            {
                return SteamVR_Actions.p_viveBase_Squeeze.GetCopy<SteamVR_Action_Single>();
            }
        }
        
        public static SteamVR_Action_Boolean viveBase_HeadsetOnHead
        {
            get
            {
                return SteamVR_Actions.p_viveBase_HeadsetOnHead.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean viveBase_SnapTurnLeft
        {
            get
            {
                return SteamVR_Actions.p_viveBase_SnapTurnLeft.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean viveBase_SnapTurnRight
        {
            get
            {
                return SteamVR_Actions.p_viveBase_SnapTurnRight.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Vibration viveBase_Haptic
        {
            get
            {
                return SteamVR_Actions.p_viveBase_Haptic.GetCopy<SteamVR_Action_Vibration>();
            }
        }
        
        private static void InitializeActionArrays()
        {
            Valve.VR.SteamVR_Input.actions = new Valve.VR.SteamVR_Action[] {
                    SteamVR_Actions.viveBase_InteractUI,
                    SteamVR_Actions.viveBase_Teleport,
                    SteamVR_Actions.viveBase_GrabPinch,
                    SteamVR_Actions.viveBase_Reset,
                    SteamVR_Actions.viveBase_Pose,
                    SteamVR_Actions.viveBase_SkeletonLeftHand,
                    SteamVR_Actions.viveBase_SkeletonRightHand,
                    SteamVR_Actions.viveBase_Squeeze,
                    SteamVR_Actions.viveBase_HeadsetOnHead,
                    SteamVR_Actions.viveBase_SnapTurnLeft,
                    SteamVR_Actions.viveBase_SnapTurnRight,
                    SteamVR_Actions.viveBase_Haptic};
            Valve.VR.SteamVR_Input.actionsIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.viveBase_InteractUI,
                    SteamVR_Actions.viveBase_Teleport,
                    SteamVR_Actions.viveBase_GrabPinch,
                    SteamVR_Actions.viveBase_Reset,
                    SteamVR_Actions.viveBase_Pose,
                    SteamVR_Actions.viveBase_SkeletonLeftHand,
                    SteamVR_Actions.viveBase_SkeletonRightHand,
                    SteamVR_Actions.viveBase_Squeeze,
                    SteamVR_Actions.viveBase_HeadsetOnHead,
                    SteamVR_Actions.viveBase_SnapTurnLeft,
                    SteamVR_Actions.viveBase_SnapTurnRight};
            Valve.VR.SteamVR_Input.actionsOut = new Valve.VR.ISteamVR_Action_Out[] {
                    SteamVR_Actions.viveBase_Haptic};
            Valve.VR.SteamVR_Input.actionsVibration = new Valve.VR.SteamVR_Action_Vibration[] {
                    SteamVR_Actions.viveBase_Haptic};
            Valve.VR.SteamVR_Input.actionsPose = new Valve.VR.SteamVR_Action_Pose[] {
                    SteamVR_Actions.viveBase_Pose};
            Valve.VR.SteamVR_Input.actionsBoolean = new Valve.VR.SteamVR_Action_Boolean[] {
                    SteamVR_Actions.viveBase_InteractUI,
                    SteamVR_Actions.viveBase_Teleport,
                    SteamVR_Actions.viveBase_GrabPinch,
                    SteamVR_Actions.viveBase_Reset,
                    SteamVR_Actions.viveBase_HeadsetOnHead,
                    SteamVR_Actions.viveBase_SnapTurnLeft,
                    SteamVR_Actions.viveBase_SnapTurnRight};
            Valve.VR.SteamVR_Input.actionsSingle = new Valve.VR.SteamVR_Action_Single[] {
                    SteamVR_Actions.viveBase_Squeeze};
            Valve.VR.SteamVR_Input.actionsVector2 = new Valve.VR.SteamVR_Action_Vector2[0];
            Valve.VR.SteamVR_Input.actionsVector3 = new Valve.VR.SteamVR_Action_Vector3[0];
            Valve.VR.SteamVR_Input.actionsSkeleton = new Valve.VR.SteamVR_Action_Skeleton[] {
                    SteamVR_Actions.viveBase_SkeletonLeftHand,
                    SteamVR_Actions.viveBase_SkeletonRightHand};
            Valve.VR.SteamVR_Input.actionsNonPoseNonSkeletonIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.viveBase_InteractUI,
                    SteamVR_Actions.viveBase_Teleport,
                    SteamVR_Actions.viveBase_GrabPinch,
                    SteamVR_Actions.viveBase_Reset,
                    SteamVR_Actions.viveBase_Squeeze,
                    SteamVR_Actions.viveBase_HeadsetOnHead,
                    SteamVR_Actions.viveBase_SnapTurnLeft,
                    SteamVR_Actions.viveBase_SnapTurnRight};
        }
        
        private static void PreInitActions()
        {
            SteamVR_Actions.p_viveBase_InteractUI = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/ViveBase/in/InteractUI")));
            SteamVR_Actions.p_viveBase_Teleport = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/ViveBase/in/Teleport")));
            SteamVR_Actions.p_viveBase_GrabPinch = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/ViveBase/in/GrabPinch")));
            SteamVR_Actions.p_viveBase_Reset = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/ViveBase/in/Reset")));
            SteamVR_Actions.p_viveBase_Pose = ((SteamVR_Action_Pose)(SteamVR_Action.Create<SteamVR_Action_Pose>("/actions/ViveBase/in/Pose")));
            SteamVR_Actions.p_viveBase_SkeletonLeftHand = ((SteamVR_Action_Skeleton)(SteamVR_Action.Create<SteamVR_Action_Skeleton>("/actions/ViveBase/in/SkeletonLeftHand")));
            SteamVR_Actions.p_viveBase_SkeletonRightHand = ((SteamVR_Action_Skeleton)(SteamVR_Action.Create<SteamVR_Action_Skeleton>("/actions/ViveBase/in/SkeletonRightHand")));
            SteamVR_Actions.p_viveBase_Squeeze = ((SteamVR_Action_Single)(SteamVR_Action.Create<SteamVR_Action_Single>("/actions/ViveBase/in/Squeeze")));
            SteamVR_Actions.p_viveBase_HeadsetOnHead = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/ViveBase/in/HeadsetOnHead")));
            SteamVR_Actions.p_viveBase_SnapTurnLeft = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/ViveBase/in/SnapTurnLeft")));
            SteamVR_Actions.p_viveBase_SnapTurnRight = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/ViveBase/in/SnapTurnRight")));
            SteamVR_Actions.p_viveBase_Haptic = ((SteamVR_Action_Vibration)(SteamVR_Action.Create<SteamVR_Action_Vibration>("/actions/ViveBase/out/Haptic")));
        }
    }
}
