using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Particulas.Penes
{
	// Token: 0x0200015D RID: 349
	[Obsolete("", true)]
	public class ParticulasDeSemenParaPene : AplicableBehaviour
	{
		// Token: 0x170001AE RID: 430
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x00024EDA File Offset: 0x000230DA
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.fixedUpdate1);
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x060007EA RID: 2026 RVA: 0x00024EE3 File Offset: 0x000230E3
		public Penis penis
		{
			get
			{
				return this.m_pene;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x00024EEB File Offset: 0x000230EB
		public bool eyaculando
		{
			get
			{
				return this.m_eyaculando;
			}
		}

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x060007EC RID: 2028 RVA: 0x00024EF4 File Offset: 0x000230F4
		// (remove) Token: 0x060007ED RID: 2029 RVA: 0x00024F2C File Offset: 0x0002312C
		public event Action<ParticulasDeSemenParaPene> eyaculating;

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x060007EE RID: 2030 RVA: 0x00024F64 File Offset: 0x00023164
		// (remove) Token: 0x060007EF RID: 2031 RVA: 0x00024F9C File Offset: 0x0002319C
		public event Action<ParticulasDeSemenParaPene> eyaculated;

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x060007F0 RID: 2032 RVA: 0x00024FD4 File Offset: 0x000231D4
		// (remove) Token: 0x060007F1 RID: 2033 RVA: 0x0002500C File Offset: 0x0002320C
		public event ParticulasDeSemenParaPene.EmitingHandler emiting;

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x060007F2 RID: 2034 RVA: 0x00025044 File Offset: 0x00023244
		// (remove) Token: 0x060007F3 RID: 2035 RVA: 0x0002507C File Offset: 0x0002327C
		public event ParticulasDeSemenParaPene.EmitingHandler emited;

		// Token: 0x060007F4 RID: 2036 RVA: 0x000250B1 File Offset: 0x000232B1
		protected override void AwakeUnityEvent()
		{
			this.m_eyaculando = false;
			base.AwakeUnityEvent();
			this.eyac = new CoroutineCapsule(this);
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x000250D8 File Offset: 0x000232D8
		public void Init(Penis pene)
		{
			if (pene == null)
			{
				throw new ArgumentNullException("pene", "pene null reference.");
			}
			this.m_pene = pene;
			if (pene.isStared)
			{
				this.Iniciar();
				return;
			}
			pene.stared += this.Pene_stared;
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x00025126 File Offset: 0x00023326
		private void Pene_stared(object obj)
		{
			this.Iniciar();
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x00025130 File Offset: 0x00023330
		private void Iniciar()
		{
			Transform tipBone = this.m_pene.penisLinearChain.tipBone;
			if (tipBone == null)
			{
				throw new ArgumentNullException("tip", "tip null reference.");
			}
			base.transform.rotation = tipBone.rotation;
			base.transform.position = tipBone.position;
			base.transform.localScale = Vector3.one;
			this.followTarget = tipBone;
			this.m_ParticleSystem = Object.Instantiate<ParticleSystem>(Singleton<ColleccionDeParticulas>.instance.semenParaPene);
			this.m_ParticleSystem.name = "Semen De " + this.m_pene.name;
			this.m_ParticleSystem.transform.parent = base.transform;
			this.m_ParticleSystem.transform.localRotation = Quaternion.identity;
			this.m_ParticleSystem.transform.localPosition = Vector3.zero;
			this.m_ParticleSystem.transform.localScale = Vector3.one;
			this.m_SemenParticles = this.m_ParticleSystem.GetComponent<SemenParticles>();
			this.m_defaultStartSpeed = this.m_ParticleSystem.main.startSpeed;
			this.m_defaultStartSpeed.mode = ParticleSystemCurveMode.TwoConstants;
			this.m_startSpeedMin = this.m_defaultStartSpeed.constantMin;
			this.m_startSpeedMax = this.m_defaultStartSpeed.constantMax;
			this.m_defaultStartGravity = this.m_ParticleSystem.main.gravityModifier;
			this.m_defaultStartGravity.mode = ParticleSystemCurveMode.Constant;
			this.m_startGravity = this.m_defaultStartGravity.constant;
			if (this.m_SemenParticles == null)
			{
				throw new ArgumentNullException("m_SemenParticles", "m_SemenParticles null reference.");
			}
			this.m_ParticleSystem.main.playOnAwake = false;
			this.m_ParticleSystem.gameObject.SetActive(false);
			this.m_ParticleSystem.gameObject.SetActive(true);
			this.m_ParticleSystem.Stop();
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x00025324 File Offset: 0x00023524
		public void Eyacular(float cantidadMod = 1f, float velMod = 1f, float grabMod = 1f)
		{
			if (this.eyac.ejecutandose || this.m_eyaculando)
			{
				return;
			}
			this.eyac.Start(this.EyacCo(cantidadMod, velMod, grabMod), null, null);
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x00025366 File Offset: 0x00023566
		private IEnumerator EyacCo(float cantidadMod, float velMod, float gravMod)
		{
			this.m_eyaculando = true;
			float num = 1f.Random(0.2f);
			this.m_defaultStartSpeed.constantMax = this.m_startSpeedMax * velMod * num;
			this.m_defaultStartSpeed.constantMin = this.m_startSpeedMin * velMod * num;
			this.m_defaultStartGravity.constantMin = this.m_startGravity * gravMod;
			ParticleSystem.MainModule main = this.m_ParticleSystem.main;
			main.startSpeed = this.m_defaultStartSpeed;
			main.gravityModifier = this.m_defaultStartGravity;
			Action<ParticulasDeSemenParaPene> action = this.eyaculating;
			if (action != null)
			{
				action(this);
			}
			int cantidadContrac = Random.Range(-1, 1) + this.cantidadDeContracciones;
			float coolDownConstract = this.eyaculacionContraccionCoolDown;
			int cantidadEmicion = (int)((float)this.cantidadDeEmiciones * Random.Range(0.666f, 1.5f) * cantidadMod);
			int num4;
			for (int i = 0; i < cantidadContrac; i = num4 + 1)
			{
				if (i > 0)
				{
					coolDownConstract *= this.eyaculacionAumentoCoolDownPorCadaContraccion;
					cantidadEmicion = (int)((float)cantidadEmicion * this.eyaculacionDisminicionDeParticulasPorCadaContraccion);
					this.m_defaultStartSpeed.constantMax = this.m_defaultStartSpeed.constantMax * this.eyaculacionDisminicionDeVelocidadPorCadaContraccion;
					this.m_defaultStartSpeed.constantMin = this.m_defaultStartSpeed.constantMin * this.eyaculacionDisminicionDeVelocidadPorCadaContraccion;
					yield return new WaitForSeconds(coolDownConstract.Random(0.333f));
				}
				yield return this.waitFixed;
				ParticulasDeSemenParaPene.EmitingMods @default = ParticulasDeSemenParaPene.EmitingMods.@default;
				ParticleSystem.MinMaxCurve defaultStartSpeed = this.m_defaultStartSpeed;
				int num2 = cantidadEmicion;
				ParticleSystem.MinMaxCurve defaultStartGravity = this.m_defaultStartGravity;
				int num3 = MapaSingleton<ConfiguracionGlobal>.instance.layers.layerMaskToSemenNoHoles;
				ParticulasDeSemenParaPene.EmitingHandler emitingHandler = this.emiting;
				if (emitingHandler != null)
				{
					emitingHandler(num2, cantidadContrac, i + 1, ref @default, this);
				}
				if (@default.aborting)
				{
					break;
				}
				num2 = (int)((float)num2 * @default.cantidad);
				defaultStartSpeed.constantMax *= @default.velocidad;
				defaultStartSpeed.constantMin *= @default.velocidad;
				defaultStartGravity.constant *= @default.gravedad;
				num3 |= @default.layerMask;
				main.startSpeed = defaultStartSpeed;
				main.gravityModifier = defaultStartGravity;
				this.m_ParticleSystem.collision.collidesWith = num3;
				this.m_ParticleSystem.Emit(num2);
				this.m_SemenParticles.flagToSkipUpdate = true;
				ParticulasDeSemenParaPene.EmitingHandler emitingHandler2 = this.emited;
				if (emitingHandler2 != null)
				{
					emitingHandler2(num2, cantidadContrac, i + 1, ref @default, this);
				}
				num4 = i;
			}
			this.m_eyaculando = false;
			if (this.eyac.ejecutandose)
			{
				this.eyac.Stop();
			}
			Action<ParticulasDeSemenParaPene> action2 = this.eyaculated;
			if (action2 != null)
			{
				action2(this);
			}
			yield break;
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0002538C File Offset: 0x0002358C
		public override void OnUpdateEvent1()
		{
			if (this.m_pene.hidden || this.followTarget == null)
			{
				return;
			}
			if (this.followRotationOffset != Quaternion.identity)
			{
				base.transform.SetPositionAndRotation(this.followTarget.position, this.followTarget.rotation * this.followRotationOffset);
				return;
			}
			base.transform.SetPositionAndRotation(this.followTarget.position, this.followTarget.rotation);
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x060007FB RID: 2043 RVA: 0x00025415 File Offset: 0x00023615
		public override string aplicarButtonString
		{
			get
			{
				return "Eyacular";
			}
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0002541C File Offset: 0x0002361C
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.Eyacular(1f, 1f, 1f);
		}

		// Token: 0x0400063A RID: 1594
		public Transform followTarget;

		// Token: 0x0400063B RID: 1595
		public Quaternion followRotationOffset;

		// Token: 0x0400063C RID: 1596
		private ParticleSystem m_ParticleSystem;

		// Token: 0x0400063D RID: 1597
		private Penis m_pene;

		// Token: 0x0400063E RID: 1598
		private CoroutineCapsule eyac;

		// Token: 0x0400063F RID: 1599
		private WaitForFixedUpdate waitFixed = new WaitForFixedUpdate();

		// Token: 0x04000640 RID: 1600
		private SemenParticles m_SemenParticles;

		// Token: 0x04000641 RID: 1601
		public int cantidadDeContracciones = 6;

		// Token: 0x04000642 RID: 1602
		public int cantidadDeEmiciones = 150;

		// Token: 0x04000643 RID: 1603
		public float eyaculacionContraccionCoolDown = 0.666f;

		// Token: 0x04000644 RID: 1604
		public float eyaculacionAumentoCoolDownPorCadaContraccion = 1.33f;

		// Token: 0x04000645 RID: 1605
		public float eyaculacionDisminicionDeParticulasPorCadaContraccion = 0.666f;

		// Token: 0x04000646 RID: 1606
		public float eyaculacionDisminicionDeVelocidadPorCadaContraccion = 0.666f;

		// Token: 0x04000647 RID: 1607
		[ReadOnlyUI]
		[SerializeField]
		private bool m_eyaculando;

		// Token: 0x04000648 RID: 1608
		[SerializeField]
		private float m_startGravity;

		// Token: 0x04000649 RID: 1609
		[SerializeField]
		private float m_startSpeedMin;

		// Token: 0x0400064A RID: 1610
		[SerializeField]
		private float m_startSpeedMax;

		// Token: 0x0400064B RID: 1611
		private ParticleSystem.MinMaxCurve m_defaultStartSpeed;

		// Token: 0x0400064C RID: 1612
		private ParticleSystem.MinMaxCurve m_defaultStartGravity;

		// Token: 0x0200015E RID: 350
		public struct EmitingMods
		{
			// Token: 0x170001B2 RID: 434
			// (get) Token: 0x060007FE RID: 2046 RVA: 0x00025498 File Offset: 0x00023698
			public static ParticulasDeSemenParaPene.EmitingMods @default
			{
				get
				{
					return new ParticulasDeSemenParaPene.EmitingMods
					{
						cantidad = 1f,
						velocidad = 1f,
						gravedad = 1f,
						layerMask = 0
					};
				}
			}

			// Token: 0x060007FF RID: 2047 RVA: 0x000254DF File Offset: 0x000236DF
			public void Abort()
			{
				this.m_abort = true;
			}

			// Token: 0x170001B3 RID: 435
			// (get) Token: 0x06000800 RID: 2048 RVA: 0x000254E8 File Offset: 0x000236E8
			public bool aborting
			{
				get
				{
					return this.m_abort;
				}
			}

			// Token: 0x04000651 RID: 1617
			private bool m_abort;

			// Token: 0x04000652 RID: 1618
			public LayerMask layerMask;

			// Token: 0x04000653 RID: 1619
			public float cantidad;

			// Token: 0x04000654 RID: 1620
			public float velocidad;

			// Token: 0x04000655 RID: 1621
			public float gravedad;
		}

		// Token: 0x0200015F RID: 351
		// (Invoke) Token: 0x06000802 RID: 2050
		public delegate void EmitingHandler(int cantidadDeParticulas, int cantidadDeEmiciones, int currentEmicion, ref ParticulasDeSemenParaPene.EmitingMods mod, ParticulasDeSemenParaPene sender);
	}
}
