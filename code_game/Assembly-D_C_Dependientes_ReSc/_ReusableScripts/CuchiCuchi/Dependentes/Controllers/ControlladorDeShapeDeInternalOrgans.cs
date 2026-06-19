using System;
using System.Collections.Generic;
using Assets.Base.Controllers;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers
{
	// Token: 0x020001A4 RID: 420
	public class ControlladorDeShapeDeInternalOrgans : ControllerGenericoDeShapesKey
	{
		// Token: 0x060009EA RID: 2538 RVA: 0x00031818 File Offset: 0x0002FA18
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_femSkins = this.GetComponentEnRoot(false);
			if (this.m_femSkins == null)
			{
				throw new ArgumentNullException("femSkins", "femSkins null reference.");
			}
			this.m_femSkins.skinAdded += this.FemSkins_skinAdded;
			this.m_femSkins.skinRemoved += this.FemSkins_skinRemoved;
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x0003187E File Offset: 0x0002FA7E
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_femSkins != null)
			{
				this.m_femSkins.skinAdded -= this.FemSkins_skinAdded;
				this.m_femSkins.skinRemoved -= this.FemSkins_skinRemoved;
			}
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x000318BD File Offset: 0x0002FABD
		private void FemSkins_skinAdded(ArmatureSkins arg1, Skin arg2)
		{
			if (arg2 is InternalOrgansSkin)
			{
				this.m_internalOrgnas = arg2.skinnedMeshRenderer;
			}
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x000318D3 File Offset: 0x0002FAD3
		private void FemSkins_skinRemoved(ArmatureSkins arg1, Skin arg2)
		{
			if (arg2 is InternalOrgansSkin)
			{
				this.m_internalOrgnas = null;
			}
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x000318E4 File Offset: 0x0002FAE4
		protected override bool CanUpdate()
		{
			return this.m_internalOrgnas != null;
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x000318F2 File Offset: 0x0002FAF2
		protected override SkinnedMeshRenderer GetRenderer()
		{
			return this.m_internalOrgnas;
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x000318FC File Offset: 0x0002FAFC
		protected override void InstantiateShapeKeys(List<IShapeKey> resultado)
		{
			resultado.Add(new ShapeKey("BODY_BreastQuisteA"));
			resultado.Add(new ShapeKey("BODY_BreastQuisteB"));
			resultado.Add(new ShapeKey("BODY_BreastQuisteC"));
			resultado.Add(new ShapeKey("BODY_BreastQuisteD"));
			resultado.Add(new ShapeKey("BODY_ConstipationA"));
			resultado.Add(new ShapeKey("BODY_ConstipationB"));
			resultado.Add(new ShapeKey("BODY_ConstipationC"));
			resultado.Add(new ShapeKey("BODY_ColonIrritadoA"));
			resultado.Add(new ShapeKey("BODY_ColonIrritadoB"));
			resultado.Add(new ShapeKey("BODY_ColonIrritadoC"));
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x000319AC File Offset: 0x0002FBAC
		protected override void ProducirGrupos()
		{
			base.ProducirGrupos();
			base.AgruparNormalizandoExagerado(1.1f, new string[] { "BODY_BreastQuisteA", "BODY_BreastQuisteB", "BODY_BreastQuisteC", "BODY_BreastQuisteD" });
			base.AgruparNormalizandoExagerado(1.5f, new string[] { "BODY_ConstipationA", "BODY_ConstipationB", "BODY_ConstipationC" });
			base.AgruparNormalizandoExagerado(1.5f, new string[] { "BODY_ColonIrritadoA", "BODY_ColonIrritadoB", "BODY_ColonIrritadoC" });
		}

		// Token: 0x04000774 RID: 1908
		private SkinnedMeshRenderer m_internalOrgnas;

		// Token: 0x04000775 RID: 1909
		private IFemaleSkins m_femSkins;

		// Token: 0x04000776 RID: 1910
		public const string senoQuiste1 = "BODY_BreastQuisteA";

		// Token: 0x04000777 RID: 1911
		public const string senoQuiste2 = "BODY_BreastQuisteB";

		// Token: 0x04000778 RID: 1912
		public const string senoQuiste3 = "BODY_BreastQuisteC";

		// Token: 0x04000779 RID: 1913
		public const string senoQuiste4 = "BODY_BreastQuisteD";

		// Token: 0x0400077A RID: 1914
		public const string constripacion1 = "BODY_ConstipationA";

		// Token: 0x0400077B RID: 1915
		public const string constripacion2 = "BODY_ConstipationB";

		// Token: 0x0400077C RID: 1916
		public const string constripacion3 = "BODY_ConstipationC";

		// Token: 0x0400077D RID: 1917
		public const string colonIrritable1 = "BODY_ColonIrritadoA";

		// Token: 0x0400077E RID: 1918
		public const string colonIrritable2 = "BODY_ColonIrritadoB";

		// Token: 0x0400077F RID: 1919
		public const string colonIrritable3 = "BODY_ColonIrritadoC";
	}
}
