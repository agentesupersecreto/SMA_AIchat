using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones
{
	// Token: 0x0200003A RID: 58
	public class InteracionSegundariaExterna : InteraccionSegundariaBase
	{
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600027E RID: 638 RVA: 0x0000D787 File Offset: 0x0000B987
		public override IInteractionController user
		{
			get
			{
				return this.m_User;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600027F RID: 639 RVA: 0x0000D78F File Offset: 0x0000B98F
		protected override bool detenerTodasDelMismoLayer
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000D792 File Offset: 0x0000B992
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!this.m_datos.isValid)
			{
				Debug.LogWarning(base.name + "_Interaccion, no tiene datos validos");
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000D7BC File Offset: 0x0000B9BC
		protected override void OnAdded(IInteraccionesDeCharacter interaccionesDeCharacter)
		{
			base.OnAdded(interaccionesDeCharacter);
			this.m_User = interaccionesDeCharacter.character.GetComponentInChildren<IInteractionController>(false);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000D7D7 File Offset: 0x0000B9D7
		protected override void OnRemoved(IInteraccionesDeCharacter interaccionesDeCharacter)
		{
			base.OnRemoved(interaccionesDeCharacter);
			this.m_User = null;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000D7E7 File Offset: 0x0000B9E7
		protected override bool AntesDeDetenerse()
		{
			return true;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000D7EC File Offset: 0x0000B9EC
		protected override void Comienza()
		{
			this.m_ejecutandoseUser = this.user;
			ICharacter componentInParent = ((Component)this.user).GetComponentInParent<ICharacter>();
			if (componentInParent == null)
			{
				throw new ArgumentNullException("@char", "@char null reference.");
			}
			this.m_animController = componentInParent.GetComponentInChildren<AnimController>();
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000D835 File Offset: 0x0000BA35
		protected override void DespuesDeDetenerse()
		{
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000D837 File Offset: 0x0000BA37
		protected override void DespuesDeEjecutarse(InteraccionStartParams parametros)
		{
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000D83C File Offset: 0x0000BA3C
		protected override void JustoAntesDeEjecutarse(ref InteraccionStartParams parametros)
		{
			IReadOnlyList<InteraccionDeCharacter> interaccionesSegundariasBases = base.owner.interaccionesSegundariasBases;
			for (int i = 0; i < interaccionesSegundariasBases.Count; i++)
			{
				InteracionSegundariaExterna.<>c__DisplayClass16_0 CS$<>8__locals1 = new InteracionSegundariaExterna.<>c__DisplayClass16_0();
				InteracionSegundariaExterna.<>c__DisplayClass16_0 CS$<>8__locals2 = CS$<>8__locals1;
				InteraccionDeCharacter interaccionDeCharacter = interaccionesSegundariasBases[i];
				CS$<>8__locals2.inter = ((interaccionDeCharacter != null) ? interaccionDeCharacter.instancia : null);
				if (!(CS$<>8__locals1.inter == null) && !(CS$<>8__locals1.inter == this) && CS$<>8__locals1.inter.ejecutandose && this.m_detenerAntesDeEjecutar.Where(delegate(FullBodyBipedEffector effect)
				{
					InteraccionEffectorParInfo interaccionEffectorParInfo;
					return CS$<>8__locals1.inter.datosDeParesDeEfecctors.effectorsInteractionsDictionary.TryGetValue((int)effect, out interaccionEffectorParInfo);
				}).Count<FullBodyBipedEffector>() > 0)
				{
					CS$<>8__locals1.inter.Detener(false);
				}
			}
			if (this.followCharacterPoseBeforeStart)
			{
				base.FolloweOwnerCharacterPose(this.followScalePose);
			}
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000D8ED File Offset: 0x0000BAED
		protected override void OnForzada()
		{
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000D8EF File Offset: 0x0000BAEF
		protected override bool OnPuedeEjecutarseConParametros(InteraccionStartParams parametros)
		{
			return true;
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000D8F2 File Offset: 0x0000BAF2
		protected override void Termina()
		{
			this.m_animController = null;
			this.m_ejecutandoseUser = null;
		}

		// Token: 0x040001C0 RID: 448
		public bool followCharacterPoseBeforeStart;

		// Token: 0x040001C1 RID: 449
		[SerializeField]
		private IInteractionController m_User;

		// Token: 0x040001C2 RID: 450
		private AnimController m_animController;

		// Token: 0x040001C3 RID: 451
		[ReadOnlyUI]
		[SerializeField]
		private IInteractionController m_ejecutandoseUser;

		// Token: 0x040001C4 RID: 452
		[SerializeField]
		private List<FullBodyBipedEffector> m_detenerAntesDeEjecutar = new List<FullBodyBipedEffector>();
	}
}
