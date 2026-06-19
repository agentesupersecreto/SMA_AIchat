using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Miscellaneous;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.TransFollowers
{
	// Token: 0x02000109 RID: 265
	[Obsolete("", true)]
	public class FollowTetas : MatrixFollowerGlobalUpdaterEvents
	{
		// Token: 0x06000A54 RID: 2644 RVA: 0x0002E1E0 File Offset: 0x0002C3E0
		protected sealed override void EditorAdded()
		{
			base.EditorAdded();
			this.m_CustomUpdate = true;
			this.m_InitType = MatrixFollowerBase.InitType.awake;
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x0002E1F8 File Offset: 0x0002C3F8
		protected sealed override void AwakeUnityEvent()
		{
			this.m_ikUpdater = this.GetComponentEnRoot(false);
			if (this.m_ikUpdater == null)
			{
				throw new ArgumentNullException("m_ikUpdater", "m_ikUpdater null reference.");
			}
			Animator componentEnRoot = this.GetComponentEnRoot(false);
			string text;
			switch (this.m_side)
			{
			case Side.L:
				text = Singleton<MapasDeHuesos>.instance.mapas.tetasBonesMap.pezon.physcis.l;
				this.m_hand = componentEnRoot.GetBoneTransform(HumanBodyBones.LeftHand);
				goto IL_00C5;
			case Side.R:
				text = Singleton<MapasDeHuesos>.instance.mapas.tetasBonesMap.pezon.physcis.r;
				this.m_hand = componentEnRoot.GetBoneTransform(HumanBodyBones.RightHand);
				goto IL_00C5;
			}
			throw new ArgumentOutOfRangeException(this.m_side.ToString());
			IL_00C5:
			Transform boneTransform = componentEnRoot.GetBoneTransform(HumanBodyBones.Hips);
			this.m_pezon = boneTransform.FindDeepChild(text, true);
			base.AwakeUnityEvent();
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x0002E2E6 File Offset: 0x0002C4E6
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_ikUpdater.onAllIKsUpdated += this.M_ikUpdater_iKsUpdated_AntesDePupppet;
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x0002E305 File Offset: 0x0002C505
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_ikUpdater.onAllIKsUpdated -= this.M_ikUpdater_iKsUpdated_AntesDePupppet;
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x0002E325 File Offset: 0x0002C525
		private void M_ikUpdater_iKsUpdated_AntesDePupppet(IIKUpdater obj)
		{
			base.Follow();
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x0002E32D File Offset: 0x0002C52D
		protected sealed override bool Following()
		{
			return this.m_pezon && this.m_hand;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x0002E34C File Offset: 0x0002C54C
		protected sealed override Matrix4x4 GetLocalToWorldMatrix()
		{
			Matrix4x4 identity = Matrix4x4.identity;
			identity.SetTRS(this.m_pezon.position, this.m_pezon.rotation, this.m_hand.lossyScale);
			return identity;
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x0002E388 File Offset: 0x0002C588
		protected sealed override void FollowingValidarMatrix(ref Matrix4x4 matrix)
		{
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x0002E38A File Offset: 0x0002C58A
		protected sealed override void Followed()
		{
		}

		// Token: 0x04000648 RID: 1608
		[SerializeField]
		private Side m_side;

		// Token: 0x04000649 RID: 1609
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_pezon;

		// Token: 0x0400064A RID: 1610
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_hand;

		// Token: 0x0400064B RID: 1611
		private IIKUpdater m_ikUpdater;
	}
}
