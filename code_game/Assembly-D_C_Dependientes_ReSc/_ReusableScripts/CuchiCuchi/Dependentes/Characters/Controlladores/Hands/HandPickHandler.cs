using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x0200026A RID: 618
	public sealed class HandPickHandler : HandPickHandlerBase
	{
		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06001054 RID: 4180 RVA: 0x0004BB6C File Offset: 0x00049D6C
		public Muscle targetMuscle
		{
			get
			{
				return this.m_targetMuscle;
			}
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06001055 RID: 4181 RVA: 0x0004BB74 File Offset: 0x00049D74
		private CreadorDeCollidersParaManos colliders
		{
			get
			{
				Side side = this.m_side;
				if (side == Side.L)
				{
					return this.m_PuppetExtraColliders.CreadorDeCollidersParaManosL;
				}
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(this.m_side.ToString());
				}
				return this.m_PuppetExtraColliders.CreadorDeCollidersParaManosR;
			}
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x0004BBC0 File Offset: 0x00049DC0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PuppetExtraColliders = this.GetComponentEnRoot(false);
			if (this.m_PuppetExtraColliders == null)
			{
				throw new ArgumentNullException("m_PuppetExtraColliders", "m_PuppetExtraColliders null reference.");
			}
			this.m_PuppetExtraColliders.stared += this.M_PuppetExtraColliders_stared;
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x0004BC18 File Offset: 0x00049E18
		private void M_PuppetExtraColliders_stared(object sender)
		{
			this.m_targetMuscle = this.m_PuppetExtraColliders.pupet.GetMuscle(this.m_side, Muscle.GroupCompleto.Hand);
			Transform transform = this.m_targetMuscle.transform;
			Rigidbody rigidbody = this.m_targetMuscle.rigidbody;
			base.InitFingers();
			base.SetUser(transform, rigidbody, this.colliders);
		}

		// Token: 0x06001058 RID: 4184 RVA: 0x0004BC6E File Offset: 0x00049E6E
		public override CreadorDeCollidersParaManos GetHandColliders()
		{
			return this.colliders;
		}

		// Token: 0x04000BCC RID: 3020
		private PuppetExtraColliders m_PuppetExtraColliders;

		// Token: 0x04000BCD RID: 3021
		[Header("Male")]
		[SerializeReference]
		private Muscle m_targetMuscle;
	}
}
