using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk
{
	// Token: 0x0200001A RID: 26
	public abstract class TValleEffectorOffsetBase : TValleOffsetModifier
	{
		// Token: 0x060000CF RID: 207 RVA: 0x0000650D File Offset: 0x0000470D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00006521 File Offset: 0x00004721
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_IEffectorIsLooked = this.GetComponentEnRoot(false);
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00006536 File Offset: 0x00004736
		public Vector3 currentBodyOffset
		{
			get
			{
				return this.m_bodyOffset;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x0000653E File Offset: 0x0000473E
		public Vector3 currentLeftShoulderOffset
		{
			get
			{
				return this.m_leftShoulderOffset;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00006546 File Offset: 0x00004746
		public Vector3 currentRightShoulderOffset
		{
			get
			{
				return this.m_rightShoulderOffset;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x0000654E File Offset: 0x0000474E
		public Vector3 currentLeftThighOffset
		{
			get
			{
				return this.m_leftThighOffset;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00006556 File Offset: 0x00004756
		public Vector3 currentRightThighOffset
		{
			get
			{
				return this.m_rightThighOffset;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x0000655E File Offset: 0x0000475E
		public Vector3 currentLeftHandOffset
		{
			get
			{
				return this.m_leftHandOffset;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00006566 File Offset: 0x00004766
		public Vector3 currentRightHandOffset
		{
			get
			{
				return this.m_rightHandOffset;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x0000656E File Offset: 0x0000476E
		public Vector3 currentLeftFootOffset
		{
			get
			{
				return this.m_leftFootOffset;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00006576 File Offset: 0x00004776
		public Vector3 currentRightFootOffset
		{
			get
			{
				return this.m_rightFootOffset;
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00006580 File Offset: 0x00004780
		protected sealed override void OnModifyOffset(FullBodyBipedIK ik)
		{
			if (!this.m_id.IsCurrent())
			{
				if (this.usaBodyOffset)
				{
					TValleEffectorOffsetBase.Smooth(this.weight, ref this.m_bodyOffset, this.bodyOffset, ik.solver.GetEffector(FullBodyBipedEffector.Body).bone.position, this.velocity);
				}
				if (this.usaLeftShoulderOffset)
				{
					TValleEffectorOffsetBase.Smooth(this.weight, ref this.m_leftShoulderOffset, this.leftShoulderOffset, ik.solver.GetEffector(FullBodyBipedEffector.LeftShoulder).bone.position, this.velocity);
				}
				if (this.usaRightShoulderOffset)
				{
					TValleEffectorOffsetBase.Smooth(this.weight, ref this.m_rightShoulderOffset, this.rightShoulderOffset, ik.solver.GetEffector(FullBodyBipedEffector.RightShoulder).bone.position, this.velocity);
				}
				if (this.usaLeftThighOffset)
				{
					TValleEffectorOffsetBase.Smooth(this.weight, ref this.m_leftThighOffset, this.leftThighOffset, ik.solver.GetEffector(FullBodyBipedEffector.LeftThigh).bone.position, this.velocity);
				}
				if (this.usaRightThighOffset)
				{
					TValleEffectorOffsetBase.Smooth(this.weight, ref this.m_rightThighOffset, this.rightThighOffset, ik.solver.GetEffector(FullBodyBipedEffector.RightThigh).bone.position, this.velocity);
				}
				if (this.usaLeftHandOffset)
				{
					TValleEffectorOffsetBase.Smooth(this.weight, ref this.m_leftHandOffset, this.leftHandOffset, ik.solver.GetEffector(FullBodyBipedEffector.LeftHand).bone.position, this.velocity);
				}
				if (this.usaRightHandOffset)
				{
					TValleEffectorOffsetBase.Smooth(this.weight, ref this.m_rightHandOffset, this.rightHandOffset, ik.solver.GetEffector(FullBodyBipedEffector.RightHand).bone.position, this.velocity);
				}
				if (this.usaLeftFootOffset)
				{
					TValleEffectorOffsetBase.Smooth(this.weight, ref this.m_leftFootOffset, this.leftFootOffset, ik.solver.GetEffector(FullBodyBipedEffector.LeftFoot).bone.position, this.velocity);
				}
				if (this.usaRightFootOffset)
				{
					TValleEffectorOffsetBase.Smooth(this.weight, ref this.m_rightFootOffset, this.rightFootOffset, ik.solver.GetEffector(FullBodyBipedEffector.RightFoot).bone.position, this.velocity);
				}
				this.m_id = UpdateAutoId.current;
			}
			this.ModifyOffset(ik);
		}

		// Token: 0x060000DB RID: 219
		protected abstract void ModifyOffset(FullBodyBipedIK ik);

		// Token: 0x060000DC RID: 220 RVA: 0x000067C4 File Offset: 0x000049C4
		private static void Smooth(float w, ref Vector3 offset, Vector3 newOfsset, Vector3 position, float maxSpeed)
		{
			if (w != 1f)
			{
				newOfsset = Vector3.Lerp(Vector3.zero, newOfsset, w);
			}
			offset = Vector3.MoveTowards(position + offset, position + newOfsset, maxSpeed * Time.deltaTime) - position;
		}

		// Token: 0x04000085 RID: 133
		public bool debugDraw;

		// Token: 0x04000086 RID: 134
		public float velocity = 1.25f;

		// Token: 0x04000087 RID: 135
		private UpdateAutoId m_id;

		// Token: 0x04000088 RID: 136
		[SerializeField]
		protected Vector3 m_bodyOffset;

		// Token: 0x04000089 RID: 137
		[SerializeField]
		protected Vector3 m_leftShoulderOffset;

		// Token: 0x0400008A RID: 138
		[SerializeField]
		protected Vector3 m_rightShoulderOffset;

		// Token: 0x0400008B RID: 139
		[SerializeField]
		protected Vector3 m_leftThighOffset;

		// Token: 0x0400008C RID: 140
		[SerializeField]
		protected Vector3 m_rightThighOffset;

		// Token: 0x0400008D RID: 141
		[SerializeField]
		protected Vector3 m_leftHandOffset;

		// Token: 0x0400008E RID: 142
		[SerializeField]
		protected Vector3 m_rightHandOffset;

		// Token: 0x0400008F RID: 143
		[SerializeField]
		protected Vector3 m_leftFootOffset;

		// Token: 0x04000090 RID: 144
		[SerializeField]
		protected Vector3 m_rightFootOffset;

		// Token: 0x04000091 RID: 145
		protected IEffectorIsLooked m_IEffectorIsLooked;

		// Token: 0x04000092 RID: 146
		public bool usaBodyOffset = true;

		// Token: 0x04000093 RID: 147
		public bool usaLeftShoulderOffset = true;

		// Token: 0x04000094 RID: 148
		public bool usaRightShoulderOffset = true;

		// Token: 0x04000095 RID: 149
		public bool usaLeftThighOffset = true;

		// Token: 0x04000096 RID: 150
		public bool usaRightThighOffset = true;

		// Token: 0x04000097 RID: 151
		public bool usaLeftHandOffset = true;

		// Token: 0x04000098 RID: 152
		public bool usaRightHandOffset = true;

		// Token: 0x04000099 RID: 153
		public bool usaLeftFootOffset = true;

		// Token: 0x0400009A RID: 154
		public bool usaRightFootOffset = true;

		// Token: 0x0400009B RID: 155
		public Vector3 bodyOffset;

		// Token: 0x0400009C RID: 156
		public Vector3 leftShoulderOffset;

		// Token: 0x0400009D RID: 157
		public Vector3 rightShoulderOffset;

		// Token: 0x0400009E RID: 158
		public Vector3 leftThighOffset;

		// Token: 0x0400009F RID: 159
		public Vector3 rightThighOffset;

		// Token: 0x040000A0 RID: 160
		public Vector3 leftHandOffset;

		// Token: 0x040000A1 RID: 161
		public Vector3 rightHandOffset;

		// Token: 0x040000A2 RID: 162
		public Vector3 leftFootOffset;

		// Token: 0x040000A3 RID: 163
		public Vector3 rightFootOffset;
	}
}
