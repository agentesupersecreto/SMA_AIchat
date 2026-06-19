using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts
{
	// Token: 0x02000076 RID: 118
	public class ModificadorDeMasaDeContactosUser : ModificadorDeContactosUserBase<ModificadorDeMasaDeContactos.Data>
	{
		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000298 RID: 664 RVA: 0x00008107 File Offset: 0x00006307
		public override ModificadorDeMasaDeContactos.Data data
		{
			get
			{
				return this.m_data;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000299 RID: 665 RVA: 0x0000810F File Offset: 0x0000630F
		public ModificableDeFloat otherMassScaleMod
		{
			get
			{
				return this.m_otherMassScaleMod;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600029A RID: 666 RVA: 0x00008117 File Offset: 0x00006317
		public ModificableDeFloat massScaleModificable
		{
			get
			{
				return this.m_MassScaleMod;
			}
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00008120 File Offset: 0x00006320
		public ModificableDeFloat GetAgaintsLayerModificable(int layer)
		{
			ModificableDeFloat modificableDeFloat = this.m_perLayerMassScaleMod[layer];
			if (modificableDeFloat == null)
			{
				modificableDeFloat = new ModificableDeFloat(1f);
				this.m_perLayerMassScaleMod[layer] = modificableDeFloat;
			}
			return modificableDeFloat;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000814E File Offset: 0x0000634E
		protected override void AwakeUnityEvent()
		{
			this.m_data = default(ModificadorDeMasaDeContactos.Data);
			this.m_data.inverseMassScalePerLayer = new float[32];
			base.AwakeUnityEvent();
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00008174 File Offset: 0x00006374
		protected override void Subcribe()
		{
			Singleton<ModificadorDeMasaDeContactos>.instance.Add(this);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00008181 File Offset: 0x00006381
		protected override void UnSubcribe()
		{
			if (Singleton<ModificadorDeMasaDeContactos>.IsInScene)
			{
				Singleton<ModificadorDeMasaDeContactos>.instance.Remove(this);
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00008198 File Offset: 0x00006398
		public override void UpdateData()
		{
			this.m_data.layer = base.gameObject.layer;
			this.m_data.otherInverseMassScaleMod = this.m_otherMassScaleMod.ModificarValor(1f);
			this.m_data.inverseMassScaleMod = 1f / this.m_MassScaleMod.ModificarValor(1f);
			for (int i = 0; i < this.m_perLayerMassScaleMod.Length; i++)
			{
				ModificableDeFloat modificableDeFloat = this.m_perLayerMassScaleMod[i];
				if (modificableDeFloat == null)
				{
					this.m_data.inverseMassScalePerLayer[i] = 1f;
				}
				else
				{
					this.m_data.inverseMassScalePerLayer[i] = 1f / modificableDeFloat.ModificarValor(1f);
				}
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00008248 File Offset: 0x00006448
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			for (int i = 0; i < this.m_perLayerMassScaleMod.Length; i++)
			{
				if (this.m_perLayerMassScaleMod[i] == null)
				{
					this.m_perLayerMassScaleMod[i] = new ModificableDeFloat(1f);
				}
			}
		}

		// Token: 0x040001A6 RID: 422
		[SerializeField]
		private ModificadorDeMasaDeContactos.Data m_data;

		// Token: 0x040001A7 RID: 423
		[SerializeReference]
		private ModificableDeFloat m_otherMassScaleMod = new ModificableDeFloat(1f);

		// Token: 0x040001A8 RID: 424
		[SerializeReference]
		private ModificableDeFloat m_MassScaleMod = new ModificableDeFloat(1f);

		// Token: 0x040001A9 RID: 425
		[SerializeReference]
		private ModificableDeFloat[] m_perLayerMassScaleMod = new ModificableDeFloat[32];
	}
}
