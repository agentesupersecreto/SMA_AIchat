using System;
using UnityEngine;

namespace com.ootii.Actors
{
	// Token: 0x0200008B RID: 139
	public class ActorState
	{
		// Token: 0x060007CF RID: 1999 RVA: 0x0002AA18 File Offset: 0x00028C18
		public void Clear()
		{
			this.ID = 0;
			this.Stance = 0;
			this.IsMoveRequested = false;
			this.IsMovementBlocked = false;
			this.Rotation = Quaternion.identity;
			this.RotationYaw = Quaternion.identity;
			this.RotationTilt = Quaternion.identity;
			this.Position = Vector3.zero;
			this.Velocity = Vector3.zero;
			this.Movement = Vector3.zero;
			this.MovementGroundAdjust = Vector3.zero;
			this.MovementSlideAdjust = Vector3.zero;
			this.MovementForceAdjust = Vector3.zero;
			this.MovementCounterAdjust = Vector3.zero;
			this.MovementPlatformAdjust = Vector3.zero;
			this.RotationPlatformAdjust = Quaternion.identity;
			this.IsGrounded = false;
			this.IsSteppingUp = false;
			this.IsSteppingDown = false;
			this.IsPoppingUp = false;
			this.IsTilting = false;
			this.Ground = null;
			this.GroundPosition = Vector3.zero;
			this.GroundRotation = Quaternion.identity;
			this.PrevGround = null;
			this.PrevGroundPosition = Vector3.zero;
			this.PrevGroundRotation = Quaternion.identity;
			this.GroundLocalContactPoint = Vector3.zero;
			this.GroundSurfaceDistance = float.MaxValue;
			this.GroundSurfacePoint = Vector3.zero;
			this.GroundSurfaceNormal = Vector3.up;
			this.GroundSurfaceDirection = Vector3.down;
			this.GroundSurfaceAngle = 0f;
			this.GroundSurfaceForwardAngle = 0f;
			this.IsGroundSurfaceDirect = true;
			this.GroundSurfaceDirectDistance = 0f;
			this.GroundSurfaceDirectNormal = Vector3.up;
			this.IsColliding = false;
			this.Collider = null;
			this.ColliderHit = default(RaycastHit);
			this.ColliderHitOrigin = Vector3.zero;
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x0002ABB1 File Offset: 0x00028DB1
		public static ActorState State(ref ActorState[] rStates, int rDesiredIndex)
		{
			if (rDesiredIndex < 0)
			{
				rDesiredIndex = rStates.Length + rDesiredIndex;
			}
			return rStates[rDesiredIndex];
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x0002ABC4 File Offset: 0x00028DC4
		public static int Shift(ref ActorState[] rStates, int rCurrentIndex)
		{
			int num = (rCurrentIndex + 1) % rStates.Length;
			ActorState actorState = rStates[rCurrentIndex];
			ActorState actorState2 = rStates[num];
			actorState2.Clear();
			ActorState actorState3 = actorState;
			int id = actorState3.ID;
			actorState3.ID = id + 1;
			actorState2.ID = id;
			actorState2.Stance = actorState.Stance;
			actorState2.GroundLocalContactPoint = actorState.GroundLocalContactPoint;
			actorState2.PrevGround = actorState.Ground;
			actorState2.PrevGroundPosition = actorState.GroundPosition;
			actorState2.PrevGroundRotation = actorState.GroundRotation;
			return num;
		}

		// Token: 0x040003DA RID: 986
		public const int STATE_COUNT = 20;

		// Token: 0x040003DB RID: 987
		public int ID;

		// Token: 0x040003DC RID: 988
		public int Stance;

		// Token: 0x040003DD RID: 989
		public bool IsMoveRequested;

		// Token: 0x040003DE RID: 990
		public Quaternion Rotation;

		// Token: 0x040003DF RID: 991
		public Quaternion RotationYaw;

		// Token: 0x040003E0 RID: 992
		public Quaternion RotationTilt;

		// Token: 0x040003E1 RID: 993
		public Vector3 Position;

		// Token: 0x040003E2 RID: 994
		public Vector3 Velocity;

		// Token: 0x040003E3 RID: 995
		public Vector3 Movement;

		// Token: 0x040003E4 RID: 996
		public Vector3 MovementGroundAdjust;

		// Token: 0x040003E5 RID: 997
		public Vector3 MovementSlideAdjust;

		// Token: 0x040003E6 RID: 998
		public Vector3 MovementForceAdjust;

		// Token: 0x040003E7 RID: 999
		public Vector3 MovementCounterAdjust;

		// Token: 0x040003E8 RID: 1000
		public Vector3 MovementPlatformAdjust;

		// Token: 0x040003E9 RID: 1001
		public Quaternion RotationPlatformAdjust;

		// Token: 0x040003EA RID: 1002
		public bool IsGrounded;

		// Token: 0x040003EB RID: 1003
		public bool IsSteppingUp;

		// Token: 0x040003EC RID: 1004
		public bool IsSteppingDown;

		// Token: 0x040003ED RID: 1005
		public bool IsPoppingUp;

		// Token: 0x040003EE RID: 1006
		public bool IsTilting;

		// Token: 0x040003EF RID: 1007
		public bool IsMovementBlocked;

		// Token: 0x040003F0 RID: 1008
		public Transform Ground;

		// Token: 0x040003F1 RID: 1009
		public Vector3 GroundPosition;

		// Token: 0x040003F2 RID: 1010
		public Quaternion GroundRotation;

		// Token: 0x040003F3 RID: 1011
		public Vector3 GroundLocalContactPoint;

		// Token: 0x040003F4 RID: 1012
		public float GroundSurfaceDistance;

		// Token: 0x040003F5 RID: 1013
		public Vector3 GroundSurfacePoint;

		// Token: 0x040003F6 RID: 1014
		public Vector3 GroundSurfaceNormal;

		// Token: 0x040003F7 RID: 1015
		public Vector3 GroundSurfaceDirection;

		// Token: 0x040003F8 RID: 1016
		public bool IsGroundSurfaceDirect = true;

		// Token: 0x040003F9 RID: 1017
		public float GroundSurfaceDirectDistance;

		// Token: 0x040003FA RID: 1018
		public Vector3 GroundSurfaceDirectNormal;

		// Token: 0x040003FB RID: 1019
		public float GroundSurfaceAngle;

		// Token: 0x040003FC RID: 1020
		public float GroundSurfaceForwardAngle;

		// Token: 0x040003FD RID: 1021
		public bool IsColliding;

		// Token: 0x040003FE RID: 1022
		public Collider Collider;

		// Token: 0x040003FF RID: 1023
		public RaycastHit ColliderHit;

		// Token: 0x04000400 RID: 1024
		public Vector3 ColliderHitOrigin;

		// Token: 0x04000401 RID: 1025
		public Transform PrevGround;

		// Token: 0x04000402 RID: 1026
		public Vector3 PrevGroundPosition;

		// Token: 0x04000403 RID: 1027
		public Quaternion PrevGroundRotation;
	}
}
