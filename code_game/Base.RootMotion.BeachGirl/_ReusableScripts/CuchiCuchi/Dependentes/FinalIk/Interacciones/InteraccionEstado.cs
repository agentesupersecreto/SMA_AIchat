using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x0200009F RID: 159
	[Serializable]
	public class InteraccionEstado
	{
		// Token: 0x06000630 RID: 1584 RVA: 0x0001E114 File Offset: 0x0001C314
		public InteraccionEstado(InteraccionInfo info, IInteraccion interaccion, InteraccionEstado.InteractionCallBacks interaccionCallBacks)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info", "info null reference.");
			}
			if (interaccionCallBacks == null)
			{
				throw new ArgumentNullException("interaccion", "interaccion null reference.");
			}
			if (interaccion == null)
			{
				throw new ArgumentNullException("interaccion", "interaccion null reference.");
			}
			if (!info.isValid)
			{
				throw new InvalidOperationException();
			}
			this.info = info;
			this.m_interaccionCallBacks = interaccionCallBacks;
			this.m_interaccion = interaccion;
			foreach (InteraccionEffectorParInfo interaccionEffectorParInfo in info.effectorsInteractions)
			{
				InteraccionEstado.EstadoDeEffector estadoDeEffector = new InteraccionEstado.EstadoDeEffector();
				estadoDeEffector.Init(this);
				this.m_estados.Add(estadoDeEffector);
				this.m_estadoDePar.Add(interaccionEffectorParInfo, estadoDeEffector);
				this.m_ParDeEstado.Add(estadoDeEffector, interaccionEffectorParInfo);
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000631 RID: 1585 RVA: 0x0001E21C File Offset: 0x0001C41C
		public IReadOnlyList<InteraccionEstado.EstadoDeEffector> estados
		{
			get
			{
				return this.m_estados;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x0001E224 File Offset: 0x0001C424
		public IInteraccion interaccion
		{
			get
			{
				return this.m_interaccion;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000633 RID: 1587 RVA: 0x0001E22C File Offset: 0x0001C42C
		public bool ejecutandose
		{
			get
			{
				return this.m_Ejecutandose;
			}
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0001E234 File Offset: 0x0001C434
		public InteraccionEffectorParInfo ParDeEstado(InteraccionEstado.EstadoDeEffector estado)
		{
			if (estado == null)
			{
				return null;
			}
			InteraccionEffectorParInfo interaccionEffectorParInfo;
			if (this.m_ParDeEstado.TryGetValue(estado, out interaccionEffectorParInfo))
			{
				return interaccionEffectorParInfo;
			}
			return null;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0001E25C File Offset: 0x0001C45C
		public void DetenerTodos()
		{
			for (int i = 0; i < this.m_estados.Count; i++)
			{
				this.m_estados[i].FlagToStop();
			}
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0001E290 File Offset: 0x0001C490
		public bool NingunaEjecutandose()
		{
			for (int i = 0; i < this.m_estados.Count; i++)
			{
				if (!this.m_estados[i].terminada)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0001E2CC File Offset: 0x0001C4CC
		public bool AlgunaComenzo()
		{
			for (int i = 0; i < this.m_estados.Count; i++)
			{
				if (this.m_estados[i].comenzada)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0001E308 File Offset: 0x0001C508
		public float EstadosTimerWeigthPromedio(float defaultValue = 0f)
		{
			float num = 0f;
			if (this.m_estados.Count == 0)
			{
				Debug.LogError("no existen estados");
				return defaultValue;
			}
			for (int i = 0; i < this.m_estados.Count; i++)
			{
				InteraccionEstado.EstadoDeEffector estadoDeEffector = this.m_estados[i];
				if (estadoDeEffector.comenzada)
				{
					num += estadoDeEffector.timerWeigth;
				}
				else
				{
					num += defaultValue;
				}
			}
			return num / (float)this.m_estados.Count;
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0001E37C File Offset: 0x0001C57C
		public bool EsperandoEjecucion()
		{
			for (int i = 0; i < this.m_estados.Count; i++)
			{
				InteraccionEstado.EstadoDeEffector estadoDeEffector = this.m_estados[i];
				if (this.m_ParDeEstado[estadoDeEffector].activado && estadoDeEffector.esperandoEjecucion)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0001E3CC File Offset: 0x0001C5CC
		private void OnOrdenComienza(InteraccionEstado.EstadoDeEffector estado, IInteractionOrden orden)
		{
			for (int i = 0; i < this.m_estados.Count; i++)
			{
				if (this.m_ParDeEstado[this.m_estados[i]].activado && !this.m_estados[i].comenzada)
				{
					return;
				}
			}
			if (!this.m_Ejecutandose)
			{
				this.m_Ejecutandose = true;
				this.m_interaccionCallBacks.InteraccionComienza();
			}
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x0001E43B File Offset: 0x0001C63B
		private void OnOrdenTermina(InteraccionEstado.EstadoDeEffector estado, IInteractionOrden orden)
		{
			this.DetenerTodos();
			if (this.m_Ejecutandose && this.NingunaEjecutandose())
			{
				this.m_Ejecutandose = false;
				this.m_interaccionCallBacks.InteraccionTermina();
			}
		}

		// Token: 0x04000448 RID: 1096
		private Dictionary<InteraccionEstado.EstadoDeEffector, InteraccionEffectorParInfo> m_ParDeEstado = new Dictionary<InteraccionEstado.EstadoDeEffector, InteraccionEffectorParInfo>();

		// Token: 0x04000449 RID: 1097
		private Dictionary<InteraccionEffectorParInfo, InteraccionEstado.EstadoDeEffector> m_estadoDePar = new Dictionary<InteraccionEffectorParInfo, InteraccionEstado.EstadoDeEffector>();

		// Token: 0x0400044A RID: 1098
		[SerializeField]
		[ReadOnlyUI]
		private List<InteraccionEstado.EstadoDeEffector> m_estados = new List<InteraccionEstado.EstadoDeEffector>();

		// Token: 0x0400044B RID: 1099
		public readonly InteraccionInfo info;

		// Token: 0x0400044C RID: 1100
		private IInteraccion m_interaccion;

		// Token: 0x0400044D RID: 1101
		private InteraccionEstado.InteractionCallBacks m_interaccionCallBacks;

		// Token: 0x0400044E RID: 1102
		[SerializeField]
		[ReadOnlyUI]
		private bool m_Ejecutandose;

		// Token: 0x0400044F RID: 1103
		public int interactionLayer;

		// Token: 0x04000450 RID: 1104
		public bool detenerDelMismoLayer;

		// Token: 0x04000451 RID: 1105
		public InteraccionStartParams parametros;

		// Token: 0x04000452 RID: 1106
		public InteraccionStartParamsModificadores parametrosModificadores = InteraccionStartParamsModificadores.@default;

		// Token: 0x02000186 RID: 390
		public interface InteractionCallBacks
		{
			// Token: 0x06000C38 RID: 3128
			void InteraccionComienza();

			// Token: 0x06000C39 RID: 3129
			void InteraccionTermina();
		}

		// Token: 0x02000187 RID: 391
		[Serializable]
		public class EstadoDeEffector
		{
			// Token: 0x17000252 RID: 594
			// (get) Token: 0x06000C3A RID: 3130 RVA: 0x000372AD File Offset: 0x000354AD
			public bool terminada
			{
				get
				{
					return this.m_currentOrder == null || this.m_currentOrder.Termino();
				}
			}

			// Token: 0x17000253 RID: 595
			// (get) Token: 0x06000C3B RID: 3131 RVA: 0x000372C4 File Offset: 0x000354C4
			public bool ejecutandose
			{
				get
				{
					return this.m_currentOrder != null && this.comenzada && !this.m_currentOrder.Termino();
				}
			}

			// Token: 0x17000254 RID: 596
			// (get) Token: 0x06000C3C RID: 3132 RVA: 0x000372E6 File Offset: 0x000354E6
			public bool comenzada
			{
				get
				{
					return this.m_currentOrder != null && this.m_currentOrder.stared;
				}
			}

			// Token: 0x17000255 RID: 597
			// (get) Token: 0x06000C3D RID: 3133 RVA: 0x000372FD File Offset: 0x000354FD
			public bool esperandoEjecucion
			{
				get
				{
					return this.m_currentOrder != null && !this.m_currentOrder.stared;
				}
			}

			// Token: 0x17000256 RID: 598
			// (get) Token: 0x06000C3E RID: 3134 RVA: 0x00037317 File Offset: 0x00035517
			public IInteractionOrden currentOrder
			{
				get
				{
					return this.m_currentOrder;
				}
			}

			// Token: 0x17000257 RID: 599
			// (get) Token: 0x06000C3F RID: 3135 RVA: 0x0003731F File Offset: 0x0003551F
			public float timerWeigth
			{
				get
				{
					if (this.m_currentOrder == null)
					{
						return 0f;
					}
					return this.m_currentOrder.timerWeigth;
				}
			}

			// Token: 0x17000258 RID: 600
			// (get) Token: 0x06000C40 RID: 3136 RVA: 0x0003733A File Offset: 0x0003553A
			public Action<IInteractionOrden> comenzadaCallBack
			{
				get
				{
					return this.m_comenzadaCallBack;
				}
			}

			// Token: 0x17000259 RID: 601
			// (get) Token: 0x06000C41 RID: 3137 RVA: 0x00037342 File Offset: 0x00035542
			public Action<IInteractionOrden> terminadaCallBack
			{
				get
				{
					return this.m_terminadaCallBack;
				}
			}

			// Token: 0x06000C42 RID: 3138 RVA: 0x0003734A File Offset: 0x0003554A
			public void FlagToStop()
			{
				if (this.m_currentOrder == null)
				{
					return;
				}
				this.m_currentOrder.flagToStop = true;
			}

			// Token: 0x06000C43 RID: 3139 RVA: 0x00037361 File Offset: 0x00035561
			public void Init(InteraccionEstado owner)
			{
				this.m_owner = owner;
				this.m_comenzadaCallBack = new Action<IInteractionOrden>(this.ComienzaOrden);
				this.m_terminadaCallBack = new Action<IInteractionOrden>(this.TerminaOrden);
			}

			// Token: 0x06000C44 RID: 3140 RVA: 0x0003738E File Offset: 0x0003558E
			private void ComienzaOrden(IInteractionOrden orden)
			{
				this.m_currentOrder = orden;
				this.m_owner.OnOrdenComienza(this, orden);
			}

			// Token: 0x06000C45 RID: 3141 RVA: 0x000373A4 File Offset: 0x000355A4
			private void TerminaOrden(IInteractionOrden orden)
			{
				this.m_currentOrder = null;
				this.m_owner.OnOrdenTermina(this, orden);
			}

			// Token: 0x040008CA RID: 2250
			private IInteractionOrden m_currentOrder;

			// Token: 0x040008CB RID: 2251
			[NonSerialized]
			private InteraccionEstado m_owner;

			// Token: 0x040008CC RID: 2252
			private Action<IInteractionOrden> m_comenzadaCallBack;

			// Token: 0x040008CD RID: 2253
			private Action<IInteractionOrden> m_terminadaCallBack;
		}
	}
}
