using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas
{
	// Token: 0x0200003F RID: 63
	[RequireComponent(typeof(PanelCharacterCompleteInfoLoader))]
	public class PanelCharacterCompleteInfoGetter : Singleton<PanelCharacterCompleteInfoGetter>
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x0000BF55 File Offset: 0x0000A155
		public bool isShowing
		{
			get
			{
				return this.m_Panel.isShowing;
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000BF62 File Offset: 0x0000A162
		protected override void Awaking()
		{
			base.Awaking();
			this.m_Panel = base.GetComponent<PanelCharacterCompleteInfoLoader>();
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0000BF76 File Offset: 0x0000A176
		public void CrearYDibujar(FemaleChar target)
		{
			this.m_Panel.SetTarget(target);
			this.m_Panel.CrearYDibujar(null);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000BF90 File Offset: 0x0000A190
		public void CrearYDibujar(MaleChar target)
		{
			this.m_Panel.SetTarget(target);
			this.m_Panel.CrearYDibujar(null);
		}

		// Token: 0x04000158 RID: 344
		private PanelCharacterCompleteInfoLoader m_Panel;
	}
}
