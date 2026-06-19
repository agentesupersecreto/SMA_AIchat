using System;
using System.Collections;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers
{
	// Token: 0x020001AD RID: 429
	[Obsolete("re hacer despues")]
	public sealed class PelvisMovementLimitSegunHoleFondoDUMMY : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000A45 RID: 2629 RVA: 0x0003358E File Offset: 0x0003178E
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update3);
			}
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00033596 File Offset: 0x00031796
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetYieldStart();
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x000335A4 File Offset: 0x000317A4
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (this.m_pene == null)
			{
				this.m_pene = this.GetComponentEnRoot(true);
				yield return null;
			}
			this.m_pene.peneEnteredInHole += this.M_pene_peneEnteredInHole;
			this.m_pene.peneExitedInHole += this.M_pene_peneExitedInHole;
			yield break;
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x000335B4 File Offset: 0x000317B4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_pene)
			{
				this.m_pene.peneEnteredInHole -= this.M_pene_peneEnteredInHole;
				this.m_pene.peneExitedInHole -= this.M_pene_peneExitedInHole;
			}
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x00033604 File Offset: 0x00031804
		private void M_pene_peneEnteredInHole(IHole target, IPene sender)
		{
			if (this.m_peneAdentro)
			{
				Debug.LogError("Pene entro a dos holes o no se registro salida de hole, " + typeof(PelvisMovementLimitSegunHoleFondo).Name + " no es compatible.", this);
				this.M_pene_peneExitedInHole(this.m_hole, this.m_pene);
			}
			FemaleChar femaleChar = target.owner as FemaleChar;
			FemaleSkins femaleSkins = ((femaleChar != null) ? femaleChar.femaleSkins : null);
			if (femaleSkins != null)
			{
				if (femaleSkins.hitSkins.fondoSkinDeHole.TryGetValue(target, out this.m_fondo))
				{
					this.m_peneAdentro = true;
					this.m_hole = target;
					((IColisionableContraColliders)this.m_fondo).collisionEnterBase += this.PelvisMovementLimitSegunHoleFondo_collision;
					((IColisionableContraColliders)this.m_fondo).collisionStayBase += this.PelvisMovementLimitSegunHoleFondo_collision;
				}
				if (femaleSkins.hitSkins.anchoSkinDeHole.TryGetValue(target, out this.m_ancho))
				{
					this.m_peneAdentro = true;
					this.m_hole = target;
					((IColisionableContraColliders)this.m_ancho).collisionEnterBase += this.PelvisMovementLimitSegunHoleAncho_collision;
					((IColisionableContraColliders)this.m_ancho).collisionStayBase += this.PelvisMovementLimitSegunHoleAncho_collision;
				}
				if (femaleSkins.hitSkins.entradaSkinDeHole.TryGetValue(target, out this.m_entrada))
				{
					this.m_peneAdentro = true;
					this.m_hole = target;
					((IColisionableContraColliders)this.m_entrada).collisionEnterBase += this.PelvisMovementLimitSegunHoleEntrada_collision;
					((IColisionableContraColliders)this.m_entrada).collisionStayBase += this.PelvisMovementLimitSegunHoleEntrada_collision;
				}
			}
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x00033774 File Offset: 0x00031974
		private void M_pene_peneExitedInHole(IHole target, IPene sender)
		{
			if (this.m_fondo != null)
			{
				((IColisionableContraColliders)this.m_fondo).collisionEnterBase -= this.PelvisMovementLimitSegunHoleFondo_collision;
				((IColisionableContraColliders)this.m_fondo).collisionStayBase -= this.PelvisMovementLimitSegunHoleFondo_collision;
			}
			if (this.m_ancho != null)
			{
				((IColisionableContraColliders)this.m_ancho).collisionEnterBase -= this.PelvisMovementLimitSegunHoleAncho_collision;
				((IColisionableContraColliders)this.m_ancho).collisionStayBase -= this.PelvisMovementLimitSegunHoleAncho_collision;
			}
			if (this.m_entrada != null)
			{
				((IColisionableContraColliders)this.m_entrada).collisionEnterBase -= this.PelvisMovementLimitSegunHoleEntrada_collision;
				((IColisionableContraColliders)this.m_entrada).collisionStayBase -= this.PelvisMovementLimitSegunHoleEntrada_collision;
			}
			this.m_ancho = null;
			this.m_fondo = null;
			this.m_peneAdentro = false;
			this.m_hole = null;
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x00033854 File Offset: 0x00031A54
		private void PelvisMovementLimitSegunHoleFondo_collision(ColisionBasicaV2 obj)
		{
			if (!base.enabled)
			{
				return;
			}
			MovementLimitSegunHoleFondoBase.AcumularForce(ref this.m_forceAcumulada, obj, this.config.forceMod, this.config.onStillMod, this.flagAsMoving, 1f, ref this.m_deudaAcumulada, 1f);
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x000338A4 File Offset: 0x00031AA4
		private void PelvisMovementLimitSegunHoleAncho_collision(ColisionBasicaV2 obj)
		{
			if (!base.enabled)
			{
				return;
			}
			MovementLimitSegunHoleFondoBase.AcumularForce(ref this.m_forceAcumulada, obj, this.config.forceMod, this.config.onStillMod, this.flagAsMoving, 0.333f, ref this.m_deudaAcumulada, 1f);
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x000338F4 File Offset: 0x00031AF4
		private void PelvisMovementLimitSegunHoleEntrada_collision(ColisionBasicaV2 obj)
		{
			if (!base.enabled)
			{
				return;
			}
			MovementLimitSegunHoleFondoBase.AcumularForce(ref this.m_forceAcumulada, obj, this.configInver.forceModV2, this.config.onStillMod, this.flagAsMoving, 1f, ref this.m_deudaAcumulada, 1f);
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x00002BEA File Offset: 0x00000DEA
		public override void OnUpdateEvent1()
		{
		}

		// Token: 0x040007BC RID: 1980
		public MovementLimitSegunHoleFondoBase.Config config = new MovementLimitSegunHoleFondoBase.Config();

		// Token: 0x040007BD RID: 1981
		public MovementLimitSegunHoleFondoBase.ConfigInverted configInver = new MovementLimitSegunHoleFondoBase.ConfigInverted();

		// Token: 0x040007BE RID: 1982
		public PelvisMovementLimitSegunHoleFondo.ConfigPelvis configPelvis = new PelvisMovementLimitSegunHoleFondo.ConfigPelvis();

		// Token: 0x040007BF RID: 1983
		public bool flagAsMoving = true;

		// Token: 0x040007C0 RID: 1984
		public bool debugDraw;

		// Token: 0x040007C1 RID: 1985
		private Penis m_pene;

		// Token: 0x040007C2 RID: 1986
		private IHole m_hole;

		// Token: 0x040007C3 RID: 1987
		[ReadOnlyUI]
		[SerializeField]
		private HoleFondoHitSkin m_fondo;

		// Token: 0x040007C4 RID: 1988
		[ReadOnlyUI]
		[SerializeField]
		private HoleAnchuraHitSkin m_ancho;

		// Token: 0x040007C5 RID: 1989
		[ReadOnlyUI]
		[SerializeField]
		private HoleEntradaHitSkin m_entrada;

		// Token: 0x040007C6 RID: 1990
		[ReadOnlyUI]
		[SerializeField]
		private bool m_peneAdentro;

		// Token: 0x040007C7 RID: 1991
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_forceAcumulada;

		// Token: 0x040007C8 RID: 1992
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_deudaAcumulada;
	}
}
