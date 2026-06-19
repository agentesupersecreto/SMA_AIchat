using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Mapas;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles
{
	// Token: 0x02000019 RID: 25
	public class AutoRatingProfilePreview : Singleton<AutoRatingProfilePreview>
	{
		// Token: 0x0600010C RID: 268 RVA: 0x00005ECC File Offset: 0x000040CC
		protected override void DoAwake()
		{
			base.DoAwake();
			if (this.loaderInterpretacionDeApariencia == null)
			{
				throw new ArgumentNullException("loaderInterpretacionDeApariencia", "loaderInterpretacionDeApariencia null reference.");
			}
			if (this.frontal == null)
			{
				throw new ArgumentNullException("frontal", "frontal null reference.");
			}
			if (this.lateral == null)
			{
				throw new ArgumentNullException("lateral", "lateral null reference.");
			}
			if (this.frontalCloseUp == null)
			{
				throw new ArgumentNullException("frontalCloseUp", "frontalCloseUp null reference.");
			}
			if (this.lateralCloseUp == null)
			{
				throw new ArgumentNullException("lateralCloseUp", "lateralCloseUp null reference.");
			}
			if (this.renderTexture == null)
			{
				throw new ArgumentNullException("renderTexture", "renderTexture null reference.");
			}
			this.frontalCloseUp.delay *= 2f;
			this.lateralCloseUp.delay *= 2f;
			this.esGlobal = true;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00005FC8 File Offset: 0x000041C8
		private void Start()
		{
			GlobalUpdater.instancia.Invokar(new Action(this.Ocultar), 1f);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00005FE6 File Offset: 0x000041E6
		public void Mostrar()
		{
			this.m_stadoLuces = Singleton<LucesEnEscena>.instance.GetCurrentState();
			Singleton<LucesEnEscena>.instance.SetDirectionalsState(false);
			base.gameObject.SetActive(true);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000600F File Offset: 0x0000420F
		public void Ocultar()
		{
			this.loaderInterpretacionDeApariencia.LoadInterpretacion(ref MapaSingleton<MapaSingletonDefaultInterpretacion>.instance.interpretacion);
			base.gameObject.SetActive(false);
			if (this.m_stadoLuces != null)
			{
				Singleton<LucesEnEscena>.instance.SetState(this.m_stadoLuces);
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000604A File Offset: 0x0000424A
		public void TakeFrame()
		{
			this.frontal.TakeFrame();
			this.lateral.TakeFrame();
			this.frontalCloseUp.TakeFrame();
			this.lateralCloseUp.TakeFrame();
		}

		// Token: 0x0400009C RID: 156
		public LoaderInterpretacionDeApariencia loaderInterpretacionDeApariencia;

		// Token: 0x0400009D RID: 157
		public PreviewCamera frontal;

		// Token: 0x0400009E RID: 158
		public PreviewCamera lateral;

		// Token: 0x0400009F RID: 159
		public PreviewCamera frontalCloseUp;

		// Token: 0x040000A0 RID: 160
		public PreviewCamera lateralCloseUp;

		// Token: 0x040000A1 RID: 161
		public RenderTexture renderTexture;

		// Token: 0x040000A2 RID: 162
		private Dictionary<LuzEnEscena, bool> m_stadoLuces;
	}
}
