using System;
using System.Collections;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.Holes;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.PhysicsScripts;
using com.ootii.Actors;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers
{
	// Token: 0x02000195 RID: 405
	public abstract class MovementLimitSegunHoleFondoBase : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000985 RID: 2437 RVA: 0x0002F283 File Offset: 0x0002D483
		public bool peneAdentro
		{
			get
			{
				return this.m_peneAdentro;
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x0002F28B File Offset: 0x0002D48B
		public HoleFondoHitSkin fondo
		{
			get
			{
				return this.m_fondo;
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000987 RID: 2439 RVA: 0x0002F293 File Offset: 0x0002D493
		public HoleAnchuraHitSkin ancho
		{
			get
			{
				return this.m_ancho;
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x0002F29B File Offset: 0x0002D49B
		public HoleEntradaHitSkin entrada
		{
			get
			{
				return this.m_entrada;
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000989 RID: 2441 RVA: 0x0002F2A3 File Offset: 0x0002D4A3
		public IHole hole
		{
			get
			{
				return this.m_hole;
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x0002F2AB File Offset: 0x0002D4AB
		public IFemaleCharacterIdleable holeOwner
		{
			get
			{
				return this.m_holeOwner;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x0600098B RID: 2443
		protected abstract bool isMoving { get; }

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x0600098C RID: 2444
		protected abstract float acumulandoForceMod { get; }

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x0600098D RID: 2445
		protected abstract float acumulandoForceModPorAceptacion { get; }

		// Token: 0x0600098E RID: 2446 RVA: 0x0002F2B3 File Offset: 0x0002D4B3
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mainController = this.GetComponentEnRoot(false);
			if (this.m_mainController == null)
			{
				throw new ArgumentNullException("m_mainController", "m_mainController null reference.");
			}
			base.SetYieldStart();
		}

		// Token: 0x0600098F RID: 2447
		protected abstract Penetrador TryGetPenetrator();

		// Token: 0x06000990 RID: 2448 RVA: 0x0002F2E6 File Offset: 0x0002D4E6
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (this.m_Penetrador == null)
			{
				this.m_Penetrador = this.TryGetPenetrator();
				yield return null;
			}
			this.m_Penetrador.peneEnteredInHole += this.M_pene_peneEnteredInHole;
			this.m_Penetrador.peneExitedInHole += this.M_pene_peneExitedInHole;
			this.m_Penetrador.onUpdated += this.M_Penetrador_onUpdated;
			yield break;
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0002F2F8 File Offset: 0x0002D4F8
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_Penetrador)
			{
				this.m_Penetrador.peneEnteredInHole -= this.M_pene_peneEnteredInHole;
				this.m_Penetrador.peneExitedInHole -= this.M_pene_peneExitedInHole;
				this.m_Penetrador.onUpdated -= this.M_Penetrador_onUpdated;
			}
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0002F360 File Offset: 0x0002D560
		private void M_pene_peneEnteredInHole(IHole target, IPene sender)
		{
			if (this.m_peneAdentro)
			{
				Debug.LogError("Pene entro a dos holes o no se registro salida de hole, " + typeof(PelvisMovementLimitSegunHoleFondo).Name + " no es compatible.", this);
				this.M_pene_peneExitedInHole(this.m_hole, this.m_Penetrador);
			}
			FemaleChar femaleChar = target.owner as FemaleChar;
			FemaleSkins femaleSkins = ((femaleChar != null) ? femaleChar.femaleSkins : null);
			if (femaleSkins != null)
			{
				if (femaleSkins.hitSkins.fondoSkinDeHole.TryGetValue(target, out this.m_fondo))
				{
					this.m_hole = target;
					((IColisionableContraColliders)this.m_fondo).collisionEnterBase += this.PelvisMovementLimitSegunHoleFondo_collision;
					((IColisionableContraColliders)this.m_fondo).collisionStayBase += this.PelvisMovementLimitSegunHoleFondo_collision;
				}
				if (femaleSkins.hitSkins.anchoSkinDeHole.TryGetValue(target, out this.m_ancho))
				{
					this.m_hole = target;
					((IColisionableContraColliders)this.m_ancho).collisionEnterBase += this.PelvisMovementLimitSegunHoleAncho_collision;
					((IColisionableContraColliders)this.m_ancho).collisionStayBase += this.PelvisMovementLimitSegunHoleAncho_collision;
				}
				if (femaleSkins.hitSkins.entradaSkinDeHole.TryGetValue(target, out this.m_entrada) && this.usarFuerzasInvertidas)
				{
					this.m_hole = target;
					((IColisionableContraColliders)this.m_entrada).collisionEnterBase += this.PelvisMovementLimitSegunHoleEntrada_collision;
					((IColisionableContraColliders)this.m_entrada).collisionStayBase += this.PelvisMovementLimitSegunHoleEntrada_collision;
				}
				if (this.m_hole != null)
				{
					this.m_peneAdentro = true;
					this.holePointsDataCollector = ((Behaviour)this.m_hole).GetComponentNotNull<HolePointsDataCollector>();
					this.m_holeOwner = this.m_hole.gameObject.GetComponentInParent<IFemaleCharacterIdleable>();
				}
			}
			this.OnPeneEnteredInHole(target, sender);
		}

		// Token: 0x06000993 RID: 2451
		protected abstract void OnPeneEnteredInHole(IHole target, IPene sender);

		// Token: 0x06000994 RID: 2452
		protected abstract void OnPeneExitedInHole(IHole target, IPene sender);

		// Token: 0x06000995 RID: 2453 RVA: 0x0002F504 File Offset: 0x0002D704
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
			this.m_entrada = null;
			this.m_peneAdentro = false;
			this.m_hole = null;
			this.m_holeOwner = null;
			this.holePointsDataCollector = null;
			this.m_forceAcumulada = Vector3.zero;
			this.m_forceAcumuladaInvertida = Vector3.zero;
			this.m_deudaAcumulada = Vector3.zero;
			this.m_deudaAcumuladaInvertida = Vector3.zero;
			this.OnPeneExitedInHole(target, sender);
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0002F62C File Offset: 0x0002D82C
		private void PelvisMovementLimitSegunHoleFondo_collision(ColisionBasicaV2 obj)
		{
			if (!base.enabled)
			{
				return;
			}
			MovementLimitSegunHoleFondoBase.AcumularForce(ref this.m_forceAcumulada, obj, this.config.forceMod, this.config.onStillMod, this.isMoving || this.m_mainController.State.Velocity.sqrMagnitude > 0f, 1f * this.acumulandoForceMod, ref this.m_deudaAcumulada, this.config.forceToDeuda);
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0002F6A8 File Offset: 0x0002D8A8
		private void PelvisMovementLimitSegunHoleAncho_collision(ColisionBasicaV2 obj)
		{
			if (!base.enabled)
			{
				return;
			}
			MovementLimitSegunHoleFondoBase.AcumularForce(ref this.m_forceAcumulada, obj, this.config.forceMod, this.config.onStillMod, this.isMoving || this.m_mainController.State.Velocity.sqrMagnitude > 0f, 0.1f * this.acumulandoForceMod, ref this.m_deudaAcumulada, this.config.forceToDeuda);
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0002F724 File Offset: 0x0002D924
		private void PelvisMovementLimitSegunHoleEntrada_collision(ColisionBasicaV2 obj)
		{
			if (!base.enabled || !this.usarFuerzasInvertidas)
			{
				return;
			}
			MovementLimitSegunHoleFondoBase.AcumularForce(ref this.m_forceAcumuladaInvertida, obj, this.configInverted.forceModV2, this.configInverted.onStillMod, this.isMoving || this.m_mainController.State.Velocity.sqrMagnitude > 0f, this.acumulandoForceMod * this.acumulandoForceModPorAceptacion, ref this.m_deudaAcumuladaInvertida, this.configInverted.forceToDeuda);
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x0002F7A9 File Offset: 0x0002D9A9
		private void M_Penetrador_onUpdated()
		{
			if (!base.enabled || this.m_Penetrador.isPenetrating)
			{
				return;
			}
			MovementLimitSegunHoleFondoBase.AcumularForcePorStress(ref this.m_forceAcumulada, ref this.m_forceAcumuladaInvertida, this.m_Penetrador, this.configPenisStress, this.acumulandoForceMod);
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0002F7E4 File Offset: 0x0002D9E4
		protected static float CalculeStressModPolarizado(Penetrador penetrator, MovementLimitSegunHoleFondoBase.ConfigPenisStress config)
		{
			float num = (penetrator.currentRealErectionValue / 100f).InPow(3f);
			float worldLengthFromUnderSkin = penetrator.worldLengthFromUnderSkin;
			float realCurrentWorldLengthFromUnderSkin = penetrator.realCurrentWorldLengthFromUnderSkin;
			int num2 = ((realCurrentWorldLengthFromUnderSkin < worldLengthFromUnderSkin) ? 1 : (-1));
			float num3 = realCurrentWorldLengthFromUnderSkin / worldLengthFromUnderSkin;
			num3 = (float.IsFinite(num3) ? num3 : 1f);
			float num4;
			if (realCurrentWorldLengthFromUnderSkin > worldLengthFromUnderSkin)
			{
				num4 = Mathf.InverseLerp(1f / config.stressToStart, 1f / config.stressToMax, num3);
			}
			else
			{
				num4 = Mathf.InverseLerp(config.stressToStart, config.stressToMax, num3);
			}
			return num4 * num * (float)num2;
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0002F874 File Offset: 0x0002DA74
		public static void AcumularForcePorStress(ref Vector3 forceAcumulada, ref Vector3 forceAcumuladaInvertida, Penetrador penetrator, MovementLimitSegunHoleFondoBase.ConfigPenisStress config, float customMod)
		{
			float num = MovementLimitSegunHoleFondoBase.CalculeStressModPolarizado(penetrator, config);
			Vector3 vector = penetrator.penisLinearChain.currentDefaultWorldForwardDirection.SetMagnitud(config.maxforceMagV2);
			if (num > 0f)
			{
				forceAcumulada += vector * num;
				return;
			}
			forceAcumuladaInvertida += vector * num;
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0002F8DC File Offset: 0x0002DADC
		public static void AcumularForce(ref Vector3 forceAcumulada, ColisionBasicaV2 collision, float forceMod, float onStillMod, bool isMoving, float customMod, ref Vector3 deudaAcumulada, float forceToDeuda)
		{
			float num = forceMod * customMod;
			if (!isMoving)
			{
				num *= onStillMod;
			}
			Vector3 vector;
			if (collision.usaPhyscisVelocidadRelativa)
			{
				vector = collision.physcisVelocidadRelativa * num;
			}
			else
			{
				vector = collision.velocidadEmuladaRelativa * num;
			}
			forceAcumulada += vector;
			deudaAcumulada += vector * forceToDeuda;
		}

		// Token: 0x04000712 RID: 1810
		public bool debugDraw;

		// Token: 0x04000713 RID: 1811
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x04000714 RID: 1812
		public bool usarFuerzasInvertidas;

		// Token: 0x04000715 RID: 1813
		public MovementLimitSegunHoleFondoBase.Config config = new MovementLimitSegunHoleFondoBase.Config();

		// Token: 0x04000716 RID: 1814
		public MovementLimitSegunHoleFondoBase.ConfigInverted configInverted = new MovementLimitSegunHoleFondoBase.ConfigInverted();

		// Token: 0x04000717 RID: 1815
		public MovementLimitSegunHoleFondoBase.ConfigPenisStress configPenisStress = new MovementLimitSegunHoleFondoBase.ConfigPenisStress();

		// Token: 0x04000718 RID: 1816
		protected Penetrador m_Penetrador;

		// Token: 0x04000719 RID: 1817
		private IFemaleCharacterIdleable m_holeOwner;

		// Token: 0x0400071A RID: 1818
		protected IHole m_hole;

		// Token: 0x0400071B RID: 1819
		protected HolePointsDataCollector holePointsDataCollector;

		// Token: 0x0400071C RID: 1820
		[ReadOnlyUI]
		[SerializeField]
		protected HoleFondoHitSkin m_fondo;

		// Token: 0x0400071D RID: 1821
		[ReadOnlyUI]
		[SerializeField]
		protected HoleAnchuraHitSkin m_ancho;

		// Token: 0x0400071E RID: 1822
		[ReadOnlyUI]
		[SerializeField]
		protected HoleEntradaHitSkin m_entrada;

		// Token: 0x0400071F RID: 1823
		[ReadOnlyUI]
		[SerializeField]
		protected bool m_peneAdentro;

		// Token: 0x04000720 RID: 1824
		[SerializeField]
		protected Vector3 m_forceAcumulada;

		// Token: 0x04000721 RID: 1825
		[SerializeField]
		protected Vector3 m_forceAcumuladaInvertida;

		// Token: 0x04000722 RID: 1826
		[SerializeField]
		protected Vector3 m_deudaAcumulada;

		// Token: 0x04000723 RID: 1827
		[SerializeField]
		protected Vector3 m_deudaAcumuladaInvertida;

		// Token: 0x04000724 RID: 1828
		private ICharacterController m_mainController;

		// Token: 0x02000196 RID: 406
		[Serializable]
		public class Config
		{
			// Token: 0x04000725 RID: 1829
			public float forceMod = 0.001f;

			// Token: 0x04000726 RID: 1830
			public float maxforceMag = 0.02f;

			// Token: 0x04000727 RID: 1831
			[Range(0f, 1f)]
			public float applyForcesAfterPenW = 0.2f;

			// Token: 0x04000728 RID: 1832
			public float sensibilidadMin = 0.1f;

			// Token: 0x04000729 RID: 1833
			public float sensibilidadMinGrabingDick = 0.1f;

			// Token: 0x0400072A RID: 1834
			public float penWInPowerToForce = 3f;

			// Token: 0x0400072B RID: 1835
			public float penWOutPowerToInputs = 1f;

			// Token: 0x0400072C RID: 1836
			public float onStillMod = 0.2f;

			// Token: 0x0400072D RID: 1837
			public float forceToDeuda = -0.1f;

			// Token: 0x0400072E RID: 1838
			public float deudaRestoreSpeed = 0.2f;
		}

		// Token: 0x02000197 RID: 407
		[Serializable]
		public class ConfigInverted
		{
			// Token: 0x0400072F RID: 1839
			public float minForceModWhenNoAceptacionV2 = 0.666f;

			// Token: 0x04000730 RID: 1840
			public float forceModV2 = 0.00025f;

			// Token: 0x04000731 RID: 1841
			public float maxforceMagV2 = 0.0025f;

			// Token: 0x04000732 RID: 1842
			[Range(0f, 1f)]
			public float applyForcesAfterPenW = 0.75f;

			// Token: 0x04000733 RID: 1843
			[Range(0f, 1f)]
			public float applyForcesBeforePenW = 1f;

			// Token: 0x04000734 RID: 1844
			public float sensibilidadMin = 0.1f;

			// Token: 0x04000735 RID: 1845
			public float sensibilidadMinGrabingDick = 0.9f;

			// Token: 0x04000736 RID: 1846
			public float penWInPowerToForce = 6f;

			// Token: 0x04000737 RID: 1847
			public float penWOutPowerToInputs = 3f;

			// Token: 0x04000738 RID: 1848
			public float onStillMod = 0.2f;

			// Token: 0x04000739 RID: 1849
			public float forceToDeuda = 3f;

			// Token: 0x0400073A RID: 1850
			public float deudaRestoreSpeed = 0.333f;
		}

		// Token: 0x02000198 RID: 408
		[Serializable]
		public class ConfigPenisStress
		{
			// Token: 0x0400073B RID: 1851
			public float maxforceMagV2 = 0.0025f;

			// Token: 0x0400073C RID: 1852
			public float stressToStart = 0.975f;

			// Token: 0x0400073D RID: 1853
			public float stressToMax = 0.8f;
		}
	}
}
