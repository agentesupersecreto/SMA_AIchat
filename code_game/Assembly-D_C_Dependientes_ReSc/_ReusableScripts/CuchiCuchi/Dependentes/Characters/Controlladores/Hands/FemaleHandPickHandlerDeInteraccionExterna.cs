using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x02000250 RID: 592
	public class FemaleHandPickHandlerDeInteraccionExterna : HandPickHandlerDeInteraccionExterna
	{
		// Token: 0x06000FAA RID: 4010 RVA: 0x00045CE3 File Offset: 0x00043EE3
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x00045CEB File Offset: 0x00043EEB
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			base.InitFingers();
		}

		// Token: 0x06000FAC RID: 4012 RVA: 0x00045CFC File Offset: 0x00043EFC
		protected override void OnAddedToUser(IInteraccionesDeCharacter character)
		{
			FemaleSkins componentEnRoot = character.character.GetComponentEnRoot<FemaleSkins>();
			Side side = this.m_side;
			if (side != Side.L)
			{
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(this.m_side.ToString());
				}
				this.m_CurrentHandUser = componentEnRoot.hitSkins.partes.manos.r;
			}
			else
			{
				this.m_CurrentHandUser = componentEnRoot.hitSkins.partes.manos.l;
			}
			base.SetUser(this.m_CurrentHandUser.boneTarget, this.m_CurrentHandUser.rigid, this.m_CurrentHandUser.credorDeColliders);
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnRemovingFromUser(IInteraccionesDeCharacter character)
		{
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x00045D9E File Offset: 0x00043F9E
		protected override void OnRemovedFromUser(IInteraccionesDeCharacter character)
		{
			base.ClearUser();
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x00045DA6 File Offset: 0x00043FA6
		public override CreadorDeCollidersParaManos GetHandColliders()
		{
			return this.m_CurrentHandUser.credorDeColliders;
		}

		// Token: 0x04000ADC RID: 2780
		[ReadOnlyUI]
		[SerializeField]
		private HandHitSkin m_CurrentHandUser;
	}
}
