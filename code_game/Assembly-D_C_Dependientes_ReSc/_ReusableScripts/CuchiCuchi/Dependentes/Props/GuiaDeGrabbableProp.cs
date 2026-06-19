using System;
using System.Collections;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;
using Assets._ReusableScripts.CuchiCuchi.Interactables;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Props
{
	// Token: 0x02000155 RID: 341
	public sealed class GuiaDeGrabbableProp : GuiaVisualInteractable
	{
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060006ED RID: 1773 RVA: 0x0002573B File Offset: 0x0002393B
		protected override float recorridoWeigthToInteract
		{
			get
			{
				return 0.95f;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060006EE RID: 1774 RVA: 0x00025742 File Offset: 0x00023942
		protected override float agarradoWeigthToInteract
		{
			get
			{
				return 0.35f;
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool agarrarObjetoPhysicoToInteract
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060006F0 RID: 1776 RVA: 0x00025749 File Offset: 0x00023949
		public override bool interactable
		{
			get
			{
				return this.m_handler.interactable;
			}
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x00025756 File Offset: 0x00023956
		public override bool PuedeEfectuarInteraccionPara(AgarranteObjeto agarrante)
		{
			return this.m_handler.PuedeEfectuarInteraccionPara(agarrante);
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060006F2 RID: 1778 RVA: 0x00002BE7 File Offset: 0x00000DE7
		protected override bool interactuarDespuesDeSoltar
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00025764 File Offset: 0x00023964
		public void Init(GuiaDeGrabbableProp.IHandler handler, Renderer guiaVisualPrefab, GuiaVisualInteractable.Config Config, ModificadorDeBool drawGuiaVisualOnTop, params Transform[] ExtraPuntos)
		{
			this.m_handler = handler;
			base.Init(guiaVisualPrefab, Config, drawGuiaVisualOnTop, Vector3.forward * Config.guiaRadius * 0.5f, ExtraPuntos);
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00025793 File Offset: 0x00023993
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00002BEA File Offset: 0x00000DEA
		public override void UpdateInteraction()
		{
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x0002579C File Offset: 0x0002399C
		protected override void ClearAgarrando()
		{
			base.ClearAgarrando();
			this.m_handler.Stop();
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x000257AF File Offset: 0x000239AF
		protected override IEnumerator EfectuarInteraccion(AgarranteObjeto agarrante)
		{
			this.ClearAgarrando();
			yield return this.m_handler.EfectuarInteraccion(agarrante);
			yield break;
		}

		// Token: 0x04000590 RID: 1424
		private GuiaDeGrabbableProp.IHandler m_handler;

		// Token: 0x02000156 RID: 342
		public interface IHandler
		{
			// Token: 0x060006F9 RID: 1785
			IEnumerator EfectuarInteraccion(AgarranteObjeto agarrante);

			// Token: 0x060006FA RID: 1786
			void Stop();

			// Token: 0x17000163 RID: 355
			// (get) Token: 0x060006FB RID: 1787
			bool interactable { get; }

			// Token: 0x060006FC RID: 1788
			bool PuedeEfectuarInteraccionPara(AgarranteObjeto agarrante);
		}
	}
}
