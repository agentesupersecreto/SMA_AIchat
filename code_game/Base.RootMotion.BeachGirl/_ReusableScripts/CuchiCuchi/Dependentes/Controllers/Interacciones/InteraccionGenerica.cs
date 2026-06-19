using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000EC RID: 236
	public sealed class InteraccionGenerica : Interaccion
	{
		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x060008BD RID: 2237 RVA: 0x0002841C File Offset: 0x0002661C
		public override int Tipo
		{
			get
			{
				return this.m_interactionLayer;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x060008BE RID: 2238 RVA: 0x00028424 File Offset: 0x00026624
		protected override bool detenerTodasDelMismoLayer
		{
			get
			{
				return this.m_detenerTodasDelMismoLayer;
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x060008BF RID: 2239 RVA: 0x0002842C File Offset: 0x0002662C
		public sealed override IInteractionController user
		{
			get
			{
				return this.m_InteractionsController;
			}
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00028434 File Offset: 0x00026634
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!this.m_datos.isValid)
			{
				Debug.LogWarning(base.name + "_Interaccion, no tiene datos validos");
			}
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x0002845E File Offset: 0x0002665E
		protected sealed override bool OnPuedeEjecutarseConParametros(InteraccionStartParams parametros)
		{
			this.m_InteractionsController = this.GetComponentEnRoot(false);
			return this.m_InteractionsController != null;
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00028478 File Offset: 0x00026678
		protected override void OnForzada()
		{
			if (this.m_InteractionsController == null)
			{
				this.m_InteractionsController = this.GetComponentEnRoot(false);
			}
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x00028490 File Offset: 0x00026690
		protected override void JustoAntesDeEjecutarse(ref InteraccionStartParams parametros)
		{
			for (int i = 0; i < this.m_detenerAntesDeEjecutar.Count; i++)
			{
				Interaccion interaccion = this.m_detenerAntesDeEjecutar[i];
				if (!(interaccion == this) && interaccion.algunaEstaEjecutandose)
				{
					interaccion.Detener(false);
				}
			}
			for (int j = 0; j < this.m_ejecutarAntesDeEjecutar.Count; j++)
			{
				Interaccion interaccion2 = this.m_ejecutarAntesDeEjecutar[j];
				if (!(interaccion2 == this) && !interaccion2.algunaEstaEjecutandose)
				{
					interaccion2.Ejecutar(parametros.prioridad, parametros.duracion, parametros.priConfig, parametros.velocidadInMod, parametros.velocidadOutMod, false);
				}
			}
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x00028532 File Offset: 0x00026732
		protected sealed override void DespuesDeEjecutarse(InteraccionStartParams parametros)
		{
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x00028534 File Offset: 0x00026734
		protected sealed override bool AntesDeDetenerse()
		{
			if (this.m_InteractionsController == null)
			{
				this.m_InteractionsController = this.GetComponentEnRoot(false);
			}
			return this.m_InteractionsController != null;
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x00028554 File Offset: 0x00026754
		protected sealed override void DespuesDeDetenerse()
		{
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x00028556 File Offset: 0x00026756
		protected sealed override void Comienza()
		{
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x00028558 File Offset: 0x00026758
		protected sealed override void Termina()
		{
		}

		// Token: 0x0400059A RID: 1434
		[SerializeField]
		private int m_interactionLayer = -1;

		// Token: 0x0400059B RID: 1435
		[SerializeField]
		private bool m_detenerTodasDelMismoLayer;

		// Token: 0x0400059C RID: 1436
		[SerializeField]
		[CoolArrayItem]
		private List<Interaccion> m_ejecutarAntesDeEjecutar = new List<Interaccion>();

		// Token: 0x0400059D RID: 1437
		[SerializeField]
		[CoolArrayItem]
		private List<Interaccion> m_detenerAntesDeEjecutar = new List<Interaccion>();

		// Token: 0x0400059E RID: 1438
		private IInteractionController m_InteractionsController;
	}
}
