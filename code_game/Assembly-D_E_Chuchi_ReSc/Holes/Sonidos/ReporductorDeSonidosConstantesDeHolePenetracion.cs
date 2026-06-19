using System;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.Sonidos;
using Assets._ReusableScripts.Sonidos.Blends.Genericos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Sonidos
{
	// Token: 0x0200018D RID: 397
	[RequireComponent(typeof(ReproductorGenericoDeSonidosBlendingConstantes))]
	public class ReporductorDeSonidosConstantesDeHolePenetracion : CustomUpdatedMonobehaviourBase, IReproductorDeSonidos
	{
		// Token: 0x06000950 RID: 2384 RVA: 0x00029842 File Offset: 0x00027A42
		void IReproductorDeSonidos.RegistrarPedido(SonidoProductor other, Vector3 point, float input, SonidoMods mods, object extraData, bool ignorarChecks)
		{
			((IReproductorDeSonidos)this.m_reproductor).RegistrarPedido(other, point, input, mods, extraData, ignorarChecks);
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000951 RID: 2385 RVA: 0x00029858 File Offset: 0x00027A58
		public sealed override int updateEvent1Index
		{
			get
			{
				return 48;
			}
		}

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x06000952 RID: 2386 RVA: 0x0002985C File Offset: 0x00027A5C
		// (remove) Token: 0x06000953 RID: 2387 RVA: 0x00029894 File Offset: 0x00027A94
		public event ReporductorDeSonidosConstantesDeHolePenetracion.CambiosDeBlendingWeightHanlder calculandoBlendingWeight;

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x06000954 RID: 2388 RVA: 0x000298CC File Offset: 0x00027ACC
		// (remove) Token: 0x06000955 RID: 2389 RVA: 0x00029904 File Offset: 0x00027B04
		public event ReporductorDeSonidosConstantesDeHolePenetracion.CambiosDeBlendingWeightHanlder modificandoBlendingWeight;

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x00029939 File Offset: 0x00027B39
		public HolePointsDataCollector collector
		{
			get
			{
				return this.m_collector;
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000957 RID: 2391 RVA: 0x00029941 File Offset: 0x00027B41
		public ReproductorGenericoDeSonidosBlendingConstantes reproductor
		{
			get
			{
				return this.m_reproductor;
			}
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x00029949 File Offset: 0x00027B49
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_reproductor = base.GetComponent<ReproductorGenericoDeSonidosBlendingConstantes>();
			this.m_reproductor.preparandoSlotDeSonido += this.M_reproductor_preparandoSlotDeSonido;
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x00029974 File Offset: 0x00027B74
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_reproductor.enabled = true;
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x00029988 File Offset: 0x00027B88
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_reproductor.enabled = false;
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0002999D File Offset: 0x00027B9D
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_reproductor.preparandoSlotDeSonido -= this.M_reproductor_preparandoSlotDeSonido;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x000299C0 File Offset: 0x00027BC0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			BoneStretchedChain componentInParent = base.GetComponentInParent<BoneStretchedChain>();
			if (componentInParent == null)
			{
				throw new ArgumentNullException("hole", "hole null reference.");
			}
			this.m_collector = componentInParent.GetComponentNotNull<HolePointsDataCollector>();
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x00029A00 File Offset: 0x00027C00
		public override void OnUpdateEvent1()
		{
			try
			{
				if (this.m_collector.hole.isPenetrated)
				{
					if (this.paraEstado != ReporductorDeSonidosConstantesDeHolePenetracion.EstadoTipo.entrandoSaliendo)
					{
						bool entrando = this.collector.stepData.entrando;
						bool flag = this.paraEstado == ReporductorDeSonidosConstantesDeHolePenetracion.EstadoTipo.entrando;
						if (entrando != flag)
						{
							return;
						}
					}
					SonidoProductor component = this.m_collector.hole.penetraciones.currentHits.primero.penis.punta.physicBone.GetComponent<SonidoProductor>();
					if (!(component == null))
					{
						ReporductorDeSonidosConstantesDeHolePenetracion.VelocidadTipo velocidadTipo = this.usarVelodidad;
						float num;
						if (velocidadTipo != ReporductorDeSonidosConstantesDeHolePenetracion.VelocidadTipo.hole)
						{
							if (velocidadTipo != ReporductorDeSonidosConstantesDeHolePenetracion.VelocidadTipo.pene)
							{
								throw new ArgumentOutOfRangeException(this.usarVelodidad.ToString());
							}
							num = this.m_collector.stepData.localPenisDeepVelocityV2;
						}
						else
						{
							num = this.m_collector.stepData.localHoleDeepVelocity;
						}
						Vector3 vector = this.m_collector.hole.ObtenerCentroDePuntosGlobal();
						ReporductorDeSonidosConstantesDeHolePenetracion.CambiosDeBlendingWeightHanlder cambiosDeBlendingWeightHanlder = this.calculandoBlendingWeight;
						if (cambiosDeBlendingWeightHanlder != null)
						{
							cambiosDeBlendingWeightHanlder(this.m_dataTemp, component, this);
						}
						ReporductorDeSonidosConstantesDeHolePenetracion.CambiosDeBlendingWeightHanlder cambiosDeBlendingWeightHanlder2 = this.modificandoBlendingWeight;
						if (cambiosDeBlendingWeightHanlder2 != null)
						{
							cambiosDeBlendingWeightHanlder2(this.m_dataTemp, component, this);
						}
						this.m_reproductor.Registrar(component, vector, num, SonidoMods.@default, this.m_dataTemp.blendWeight.GetValueOrDefault());
					}
				}
			}
			finally
			{
				((IClearable)this.m_dataTemp).Clear();
				this.m_reproductor.PostRegistro();
				this.m_reproductor.ActualizarSlots(false);
			}
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x00029B88 File Offset: 0x00027D88
		private void M_reproductor_preparandoSlotDeSonido(ref ReproductorDeSonidos.PedidoDeReporduccion pedido, ISonido slot, object sender)
		{
			slot.invertido = !this.collector.stepData.entrando;
		}

		// Token: 0x04000739 RID: 1849
		private HolePointsDataCollector m_collector;

		// Token: 0x0400073A RID: 1850
		private ReproductorGenericoDeSonidosBlendingConstantes m_reproductor;

		// Token: 0x0400073B RID: 1851
		private SonidoBlendingExtraData m_dataTemp = new SonidoBlendingExtraData();

		// Token: 0x0400073C RID: 1852
		public ReporductorDeSonidosConstantesDeHolePenetracion.EstadoTipo paraEstado;

		// Token: 0x0400073D RID: 1853
		public ReporductorDeSonidosConstantesDeHolePenetracion.VelocidadTipo usarVelodidad = ReporductorDeSonidosConstantesDeHolePenetracion.VelocidadTipo.pene;

		// Token: 0x0200018E RID: 398
		// (Invoke) Token: 0x06000961 RID: 2401
		public delegate void CambiosDeBlendingWeightHanlder(SonidoBlendingExtraData data, SonidoProductor productor, ReporductorDeSonidosConstantesDeHolePenetracion sender);

		// Token: 0x0200018F RID: 399
		public enum EstadoTipo
		{
			// Token: 0x0400073F RID: 1855
			entrandoSaliendo,
			// Token: 0x04000740 RID: 1856
			entrando,
			// Token: 0x04000741 RID: 1857
			saliendo
		}

		// Token: 0x02000190 RID: 400
		public enum VelocidadTipo
		{
			// Token: 0x04000743 RID: 1859
			hole,
			// Token: 0x04000744 RID: 1860
			pene
		}
	}
}
