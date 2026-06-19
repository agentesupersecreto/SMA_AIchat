using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Inputs
{
	// Token: 0x0200023A RID: 570
	[RequireComponent(typeof(CharacterRotationMode))]
	public sealed class UserFacePointOfView : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000F1A RID: 3866 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000F1B RID: 3867 RVA: 0x00043534 File Offset: 0x00041734
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_CharacterRotationMode = base.GetComponent<CharacterRotationMode>();
		}

		// Token: 0x06000F1C RID: 3868 RVA: 0x00043548 File Offset: 0x00041748
		public override void OnUpdateEvent1()
		{
			if (Singleton<PlayerInputProxy>.instance.characterMovement.facingPointOfView)
			{
				this.m_CharacterRotationMode.modo = CharacterRotationMode.Modo.bodyRotation;
				return;
			}
			this.m_CharacterRotationMode.modo = CharacterRotationMode.Modo.headRotation;
		}

		// Token: 0x04000A50 RID: 2640
		private CharacterRotationMode m_CharacterRotationMode;
	}
}
