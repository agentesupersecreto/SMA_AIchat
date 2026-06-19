using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x020003A1 RID: 929
	[RequireComponent(typeof(IReactorInyectable))]
	public class InyectorDeCalculoDeOrgasmo : CustomMonobehaviour, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06001458 RID: 5208 RVA: 0x00005F51 File Offset: 0x00004151
		public TipoDeCalculadorDeEstimulo tipo
		{
			get
			{
				return TipoDeCalculadorDeEstimulo.frame;
			}
		}

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06001459 RID: 5209 RVA: 0x00058318 File Offset: 0x00056518
		public Emocion emo
		{
			get
			{
				return this.m_placer;
			}
		}

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x0600145A RID: 5210 RVA: 0x00058320 File Offset: 0x00056520
		public bool estimuloExisteEnFrame
		{
			get
			{
				return this.m_estimuloExisteEnFrame;
			}
		}

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x0600145B RID: 5211 RVA: 0x00058328 File Offset: 0x00056528
		public ICalculoDeEstimulo calculoMasFuerteBase
		{
			get
			{
				return this.m_inyectado;
			}
		}

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x0600145C RID: 5212 RVA: 0x00058330 File Offset: 0x00056530
		public double prioridad
		{
			get
			{
				return 9999.0 * Emocion.APrioridad(this.m_placer);
			}
		}

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x0600145D RID: 5213 RVA: 0x00058347 File Offset: 0x00056547
		public int cantidadDeCalculosConEstimulosEnFrame
		{
			get
			{
				if (!this.m_estimuloExisteEnFrame)
				{
					return 0;
				}
				return 1;
			}
		}

		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x0600145E RID: 5214 RVA: 0x00058347 File Offset: 0x00056547
		public int cantidadDeCalculosEnFrame
		{
			get
			{
				if (!this.m_estimuloExisteEnFrame)
				{
					return 0;
				}
				return 1;
			}
		}

		// Token: 0x0600145F RID: 5215 RVA: 0x00058354 File Offset: 0x00056554
		public ICalculoDeEstimulo GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(int index)
		{
			if (!this.m_estimuloExisteEnFrame)
			{
				return null;
			}
			if (index == 0)
			{
				return this.m_inyectado;
			}
			return null;
		}

		// Token: 0x06001460 RID: 5216 RVA: 0x00058354 File Offset: 0x00056554
		public ICalculoDeEstimulo GetCalculoEnFrameBase(int index)
		{
			if (!this.m_estimuloExisteEnFrame)
			{
				return null;
			}
			if (index == 0)
			{
				return this.m_inyectado;
			}
			return null;
		}

		// Token: 0x06001461 RID: 5217 RVA: 0x0005836B File Offset: 0x0005656B
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IReactorInyectable = base.GetComponent<IReactorInyectable>();
			this.m_placer = this.GetComponentEnRoot(false);
			this.m_inyectado.Init(this);
		}

		// Token: 0x06001462 RID: 5218 RVA: 0x00058398 File Offset: 0x00056598
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_IReactorInyectable.reaccionando += this.M_IReactorInyectable_reaccionando;
		}

		// Token: 0x06001463 RID: 5219 RVA: 0x000583B7 File Offset: 0x000565B7
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_IReactorInyectable != null)
			{
				this.m_IReactorInyectable.reaccionando -= this.M_IReactorInyectable_reaccionando;
			}
		}

		// Token: 0x06001464 RID: 5220 RVA: 0x000583E0 File Offset: 0x000565E0
		private void M_IReactorInyectable_reaccionando(IList<ICalculoDeEstimulo> calculos, IReactorInyectable reactor)
		{
			this.m_estimuloExisteEnFrame = false;
			if (!this.m_flagForzedToInyect)
			{
				if (!this.m_placer.currentFrameIsValueAtMax)
				{
					return;
				}
				for (int i = 0; i < calculos.Count; i++)
				{
					if (calculos[i].EsOrgasmo())
					{
						return;
					}
				}
			}
			this.m_inyectado.emocion = this.m_placer;
			this.m_inyectado.prioridad = 1000000000.0 / this.prioridad;
			calculos.Insert(0, this.m_inyectado);
			this.m_estimuloExisteEnFrame = true;
			this.m_flagForzedToInyect = false;
		}

		// Token: 0x06001465 RID: 5221 RVA: 0x00058471 File Offset: 0x00056671
		public void ForzeOrgasmReaction()
		{
			this.m_flagForzedToInyect = true;
		}

		// Token: 0x06001467 RID: 5223 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001468 RID: 5224 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001469 RID: 5225 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x0600146B RID: 5227 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x0600146C RID: 5228 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x040010BE RID: 4286
		private IReactorInyectable m_IReactorInyectable;

		// Token: 0x040010BF RID: 4287
		private Placer m_placer;

		// Token: 0x040010C0 RID: 4288
		[ReadOnlyUI]
		[SerializeField]
		private InyectorDeCalculoDeOrgasmo.OrgasmoCalculoInyectado m_inyectado = new InyectorDeCalculoDeOrgasmo.OrgasmoCalculoInyectado();

		// Token: 0x040010C1 RID: 4289
		[ReadOnlyUI]
		[SerializeField]
		private bool m_estimuloExisteEnFrame;

		// Token: 0x040010C2 RID: 4290
		[ReadOnlyUI]
		[SerializeField]
		private bool m_flagForzedToInyect;

		// Token: 0x020003A2 RID: 930
		public class OrgasmoCalculoInyectado : ICalculoDeEstimulo, ICalculoDeEstimuloBuffeador
		{
			// Token: 0x1700050E RID: 1294
			// (get) Token: 0x0600146D RID: 5229 RVA: 0x000584A5 File Offset: 0x000566A5
			// (set) Token: 0x0600146E RID: 5230 RVA: 0x000584AD File Offset: 0x000566AD
			public bool causoMaxValue { get; set; } = true;

			// Token: 0x0600146F RID: 5231 RVA: 0x000584B6 File Offset: 0x000566B6
			public void Init(ICalculadorDeEstimulo Calculador)
			{
				if (Calculador == null)
				{
					throw new ArgumentNullException("Calculador", "Calculador null reference.");
				}
				this.m_calculador = Calculador;
			}

			// Token: 0x1700050F RID: 1295
			// (get) Token: 0x06001470 RID: 5232 RVA: 0x000584D2 File Offset: 0x000566D2
			// (set) Token: 0x06001471 RID: 5233 RVA: 0x000584DA File Offset: 0x000566DA
			public bool canProduceBuff { get; set; } = true;

			// Token: 0x17000510 RID: 1296
			// (get) Token: 0x06001472 RID: 5234 RVA: 0x000584E3 File Offset: 0x000566E3
			// (set) Token: 0x06001473 RID: 5235 RVA: 0x00005A42 File Offset: 0x00003C42
			Emocion ICalculoDeEstimulo.emocion
			{
				get
				{
					return this.emocion;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000511 RID: 1297
			// (get) Token: 0x06001474 RID: 5236 RVA: 0x000584EB File Offset: 0x000566EB
			double ICalculoDeEstimulo.prioridad
			{
				get
				{
					return this.prioridad;
				}
			}

			// Token: 0x17000512 RID: 1298
			// (get) Token: 0x06001475 RID: 5237 RVA: 0x000584F3 File Offset: 0x000566F3
			// (set) Token: 0x06001476 RID: 5238 RVA: 0x00005A42 File Offset: 0x00003C42
			public ICalculadorDeEstimulo producidoPor
			{
				get
				{
					return this.m_calculador;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000513 RID: 1299
			// (get) Token: 0x06001477 RID: 5239 RVA: 0x00006060 File Offset: 0x00004260
			// (set) Token: 0x06001478 RID: 5240 RVA: 0x00005A42 File Offset: 0x00003C42
			public string tag
			{
				get
				{
					return null;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000514 RID: 1300
			// (get) Token: 0x06001479 RID: 5241 RVA: 0x00005F51 File Offset: 0x00004151
			// (set) Token: 0x0600147A RID: 5242 RVA: 0x00005A42 File Offset: 0x00003C42
			public TipoDeCalculoDeEstimulo tipo
			{
				get
				{
					return TipoDeCalculoDeEstimulo.frame;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000515 RID: 1301
			// (get) Token: 0x0600147B RID: 5243 RVA: 0x000584FB File Offset: 0x000566FB
			// (set) Token: 0x0600147C RID: 5244 RVA: 0x00058503 File Offset: 0x00056703
			public ICalculadorDeEstimulo producidoPorSegundario
			{
				get
				{
					return this.m_calculadorSec;
				}
				set
				{
					this.m_calculadorSec = value;
				}
			}

			// Token: 0x040010C4 RID: 4292
			private ICalculadorDeEstimulo m_calculador;

			// Token: 0x040010C5 RID: 4293
			private ICalculadorDeEstimulo m_calculadorSec;

			// Token: 0x040010C7 RID: 4295
			public Emocion emocion;

			// Token: 0x040010C8 RID: 4296
			public double prioridad;
		}
	}
}
