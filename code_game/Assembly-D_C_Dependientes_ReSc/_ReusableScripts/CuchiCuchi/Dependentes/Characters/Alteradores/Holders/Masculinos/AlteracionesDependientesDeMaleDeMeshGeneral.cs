using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Characters;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Holders.Masculinos
{
	// Token: 0x02000291 RID: 657
	public class AlteracionesDependientesDeMaleDeMeshGeneral : HolderDeAlteradores<AlteradorGenericoConInicial>
	{
		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x0600111B RID: 4379 RVA: 0x00014284 File Offset: 0x00012484
		protected override GlobalUpdater.UpdateType updateType
		{
			get
			{
				return GlobalUpdater.UpdateType.lateUpdate3;
			}
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x0600111C RID: 4380 RVA: 0x000509B3 File Offset: 0x0004EBB3
		// (set) Token: 0x0600111D RID: 4381 RVA: 0x000509C0 File Offset: 0x0004EBC0
		public float alteradorDeEscalaValor
		{
			get
			{
				return this.m_alteradorDeEscala.valor;
			}
			set
			{
				this.m_alteradorDeEscala.valor = value;
			}
		}

		// Token: 0x0600111E RID: 4382 RVA: 0x000509D0 File Offset: 0x0004EBD0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ControlladorDeMaleHeight = this.GetComponentEnRoot(false);
			if (this.m_ControlladorDeMaleHeight == null)
			{
				throw new ArgumentNullException("m_ControlladorDeMaleHeight", "m_ControlladorDeMaleHeight null reference.");
			}
			this.m_IMaleCharAtributos = this.GetComponentEnRoot(false);
			if (this.m_IMaleCharAtributos == null)
			{
				throw new ArgumentNullException("m_IMaleCharAtributos", "m_IMaleCharAtributos null reference.");
			}
		}

		// Token: 0x0600111F RID: 4383 RVA: 0x00050A34 File Offset: 0x0004EC34
		protected override void InstanciarAlteradores(List<AlteradorGenericoConInicial> resultado)
		{
			MapaDeMaleBlendShapes instance = MapaSingleton<MapaDeMaleBlendShapes>.instance;
			this.m_alteradorDeEscala = new AlteradorGenericoConInicial(instance.altura, this, delegate(float v)
			{
				this.m_ControlladorDeMaleHeight.alturaModding.ForceNewValue(v, false);
			}, () => 1f, this.m_IMaleCharAtributos.minAlturaMod, this.m_IMaleCharAtributos.maxAlturaMod);
			resultado.Add(this.m_alteradorDeEscala);
		}

		// Token: 0x04000C85 RID: 3205
		private ControlladorDeMaleHeight m_ControlladorDeMaleHeight;

		// Token: 0x04000C86 RID: 3206
		private AlteradorGenericoConInicial m_alteradorDeEscala;

		// Token: 0x04000C87 RID: 3207
		private IMaleCharAtributos m_IMaleCharAtributos;
	}
}
