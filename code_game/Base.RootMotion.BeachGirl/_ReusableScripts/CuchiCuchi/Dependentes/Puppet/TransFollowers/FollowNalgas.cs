using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Miscellaneous;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.TransFollowers
{
	// Token: 0x02000108 RID: 264
	[Obsolete("", true)]
	public class FollowNalgas : MatrixFollowerGlobalUpdaterEvents
	{
		// Token: 0x06000A4A RID: 2634 RVA: 0x0002DFAB File Offset: 0x0002C1AB
		protected sealed override void EditorAdded()
		{
			base.EditorAdded();
			this.m_CustomUpdate = true;
			this.m_InitType = MatrixFollowerBase.InitType.awake;
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x0002DFC4 File Offset: 0x0002C1C4
		protected sealed override void AwakeUnityEvent()
		{
			this.m_ikUpdater = this.GetComponentEnRoot(false);
			if (this.m_ikUpdater == null)
			{
				throw new ArgumentNullException("m_ikUpdater", "m_ikUpdater null reference.");
			}
			string text;
			string text2;
			switch (this.m_side)
			{
			case Side.L:
				text = Singleton<MapasDeHuesos>.instance.mapas.nalgasBonesMap.scaler.l;
				text2 = Singleton<MapasDeHuesos>.instance.mapas.nalgasBonesMap.physicsTrack.l;
				goto IL_00CB;
			case Side.R:
				text = Singleton<MapasDeHuesos>.instance.mapas.nalgasBonesMap.scaler.r;
				text2 = Singleton<MapasDeHuesos>.instance.mapas.nalgasBonesMap.physicsTrack.r;
				goto IL_00CB;
			}
			throw new ArgumentOutOfRangeException(this.m_side.ToString());
			IL_00CB:
			Transform boneTransform = this.GetComponentEnRoot(false).GetBoneTransform(HumanBodyBones.Hips);
			this.m_nalgaPhysics = boneTransform.FindDeepChild(text2, true);
			this.m_nalgaScaler = boneTransform.FindDeepChild(text, true);
			this.m_deffScale = this.m_nalgaPhysics.localScale;
			base.AwakeUnityEvent();
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x0002E0DD File Offset: 0x0002C2DD
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_ikUpdater.onAllIKsUpdated += this.M_ikUpdater_iKsUpdated_AntesDePupppet;
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x0002E0FC File Offset: 0x0002C2FC
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_ikUpdater.onAllIKsUpdated -= this.M_ikUpdater_iKsUpdated_AntesDePupppet;
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x0002E11C File Offset: 0x0002C31C
		private void M_ikUpdater_iKsUpdated_AntesDePupppet(IIKUpdater obj)
		{
			base.Follow();
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x0002E124 File Offset: 0x0002C324
		protected sealed override bool Following()
		{
			return this.m_nalgaPhysics && this.m_nalgaScaler;
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0002E140 File Offset: 0x0002C340
		protected sealed override Matrix4x4 GetLocalToWorldMatrix()
		{
			Matrix4x4 identity = Matrix4x4.identity;
			if (this.transferenciaDeEscalaWiegth == 1f)
			{
				identity.SetTRS(this.m_nalgaPhysics.position, this.m_nalgaPhysics.rotation, this.m_nalgaScaler.lossyScale);
			}
			else
			{
				identity.SetTRS(this.m_nalgaPhysics.position, this.m_nalgaPhysics.rotation, Vector3.Lerp(this.m_nalgaPhysics.lossyScale, this.m_nalgaScaler.lossyScale, this.transferenciaDeEscalaWiegth));
			}
			return identity;
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x0002E1C9 File Offset: 0x0002C3C9
		protected sealed override void FollowingValidarMatrix(ref Matrix4x4 matrix)
		{
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x0002E1CB File Offset: 0x0002C3CB
		protected sealed override void Followed()
		{
		}

		// Token: 0x04000642 RID: 1602
		[Range(0f, 1f)]
		public float transferenciaDeEscalaWiegth = 0.63f;

		// Token: 0x04000643 RID: 1603
		[SerializeField]
		private Side m_side;

		// Token: 0x04000644 RID: 1604
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_nalgaPhysics;

		// Token: 0x04000645 RID: 1605
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_nalgaScaler;

		// Token: 0x04000646 RID: 1606
		private IIKUpdater m_ikUpdater;

		// Token: 0x04000647 RID: 1607
		private Vector3 m_deffScale;
	}
}
