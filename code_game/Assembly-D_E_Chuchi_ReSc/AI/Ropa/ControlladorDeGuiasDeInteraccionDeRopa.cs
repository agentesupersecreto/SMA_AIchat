using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl.Runtime.Guias;
using Assets._ReusableScripts.CuchiCuchi.Interactables;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Ropa
{
	// Token: 0x0200037E RID: 894
	public sealed class ControlladorDeGuiasDeInteraccionDeRopa : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06001362 RID: 4962 RVA: 0x00014087 File Offset: 0x00012287
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06001363 RID: 4963 RVA: 0x00053B82 File Offset: 0x00051D82
		public IReadOnlyList<GuiaDeRopaInteractable> guias
		{
			get
			{
				return this.m_guias;
			}
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x00053B8C File Offset: 0x00051D8C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_DrawOnTopVolumes == null)
			{
				throw new ArgumentNullException("m_DrawOnTopVolumes", "m_DrawOnTopVolumes null reference.");
			}
			this.m_GuiasParaInteracionesDeRopaHelper = this.GetComponentEnRoot(false);
			if (this.m_GuiasParaInteracionesDeRopaHelper == null)
			{
				throw new ArgumentNullException("m_GuiasParaInteracionesDeRopaHelper", "m_GuiasParaInteracionesDeRopaHelper null reference.");
			}
			if (this.guiaPrefab == null)
			{
				throw new ArgumentNullException("guiaPrefab", "guiaPrefab null reference.");
			}
			this.ExposeVagAnus_R = base.transform.FindChildNotNull("ExposeVagAnus_R").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeVagAnus_L = base.transform.FindChildNotNull("ExposeVagAnus_L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeLegs_R = base.transform.FindChildNotNull("ExposeLegs_R").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeLegs_L = base.transform.FindChildNotNull("ExposeLegs_L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeAss_R = base.transform.FindChildNotNull("ExposeAss_R").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeAss_L = base.transform.FindChildNotNull("ExposeAss_L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeAssSide_R = base.transform.FindChildNotNull("ExposeAssSide_R").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeAssSide_L = base.transform.FindChildNotNull("ExposeAssSide_L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeNipples_R = base.transform.FindChildNotNull("ExposeNipples_R").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeNipples_L = base.transform.FindChildNotNull("ExposeNipples_L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeShoulders_R = base.transform.FindChildNotNull("ExposeShoulders_R").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeShoulders_L = base.transform.FindChildNotNull("ExposeShoulders_L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeAssHalf1L = base.transform.FindChildNotNull("ExposeAssHalf1L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeAssHalf1R = base.transform.FindChildNotNull("ExposeAssHalf1R").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeAssHalf2L = base.transform.FindChildNotNull("ExposeAssHalf2L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeAssHalf2R = base.transform.FindChildNotNull("ExposeAssHalf2R").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.PullDownAssHalf1L = base.transform.FindChildNotNull("PullDownAssHalf1L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.PullDownAssHalf1R = base.transform.FindChildNotNull("PullDownAssHalf1R").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.PullDownAssHalf2L = base.transform.FindChildNotNull("PullDownAssHalf2L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.PullDownAssHalf2R = base.transform.FindChildNotNull("PullDownAssHalf2R").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeCrotchF = base.transform.FindChildNotNull("ExposeCrotchF").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.PullDownAssL = base.transform.FindChildNotNull("PullDownAssL").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.PullDownAssR = base.transform.FindChildNotNull("PullDownAssR").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeTorzoHalf1F = base.transform.FindChildNotNull("ExposeTorzoHalf1F").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeTorzoHalf2F = base.transform.FindChildNotNull("ExposeTorzoHalf2F").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeTorzoHalf1B = base.transform.FindChildNotNull("ExposeTorzoHalf1B").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeTorzoHalf2B = base.transform.FindChildNotNull("ExposeTorzoHalf2B").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeChestHalf1L = base.transform.FindChildNotNull("ExposeChestHalf1L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeChestHalf1R = base.transform.FindChildNotNull("ExposeChestHalf1R").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeChestHalf2L = base.transform.FindChildNotNull("ExposeChestHalf2L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeChestHalf2R = base.transform.FindChildNotNull("ExposeChestHalf2R").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeHipsHalf1L = base.transform.FindChildNotNull("ExposeHipsHalf1L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeHipsHalf1R = base.transform.FindChildNotNull("ExposeHipsHalf1R").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeHipsHalf2L = base.transform.FindChildNotNull("ExposeHipsHalf2L").GetComponentNotNull<GuiaDeRopaInteractable>();
			this.ExposeHipsHalf2R = base.transform.FindChildNotNull("ExposeHipsHalf2R").GetComponentNotNull<GuiaDeRopaInteractable>();
			Renderer component = this.guiaPrefab.GetComponent<Renderer>();
			this.ExposeVagAnus_R.Init(MapaDeRopa.Interaciones.exposeVagAnusR, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeVagAnus_R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeVagAnus_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeVagAnus_001_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeVagAnus_001_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeVagAnus_R
			});
			this.ExposeVagAnus_L.Init(MapaDeRopa.Interaciones.exposeVagAnusL, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeVagAnus_L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeVagAnus_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeVagAnus_001_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeVagAnus_001_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeVagAnus_L
			});
			this.ExposeLegs_R.Init(MapaDeRopa.Interaciones.exposeLegR, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeLegs_R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeLegs_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeLegs_001_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_R
			});
			this.ExposeLegs_L.Init(MapaDeRopa.Interaciones.exposeLegL, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeLegs_L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeLegs_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeLegs_001_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_L
			});
			this.ExposeAss_R.Init(MapaDeRopa.Interaciones.exposeAssR, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeAss_R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_001_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_002_R
			});
			this.ExposeAss_L.Init(MapaDeRopa.Interaciones.exposeAssL, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeAss_L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_001_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_002_L
			});
			this.ExposeAssSide_R.Init(MapaDeRopa.Interaciones.exposeAssSideR, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeAssSide_R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAssSide_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAssSide_001_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAssSide_002_R
			});
			this.ExposeAssSide_L.Init(MapaDeRopa.Interaciones.exposeAssSideL, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeAssSide_L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAssSide_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAssSide_001_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAssSide_002_L
			});
			this.ExposeNipples_R.Init(MapaDeRopa.Interaciones.exposeNipplesR, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeNipples_R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeNipples_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeNipples_001_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeNipples_002_R
			});
			this.ExposeNipples_L.Init(MapaDeRopa.Interaciones.exposeNipplesL, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeNipples_L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeNipples_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeNipples_001_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeNipples_002_L
			});
			this.ExposeShoulders_R.Init(MapaDeRopa.Interaciones.exposeShouldersR, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeShoulders_R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeShoulders_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeShoulders_001_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeShoulders_002_R
			});
			this.ExposeShoulders_L.Init(MapaDeRopa.Interaciones.exposeShouldersL, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeShoulders_L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeShoulders_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeShoulders_001_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeShoulders_002_L
			});
			this.ExposeAssHalf1L.Init(MapaDeRopa.Interaciones.exposeAssHalf1L, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeAssHalf1L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_001_L
			});
			this.ExposeAssHalf1R.Init(MapaDeRopa.Interaciones.exposeAssHalf1R, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeAssHalf1R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_001_R
			});
			this.ExposeAssHalf2L.Init(MapaDeRopa.Interaciones.exposeAssHalf2L, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeAssHalf2L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_001_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_002_L
			});
			this.ExposeAssHalf2R.Init(MapaDeRopa.Interaciones.exposeAssHalf2R, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeAssHalf2R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_001_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_002_R
			});
			this.PullDownAssHalf1L.Init(MapaDeRopa.Interaciones.pullDownAssHalf1L, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.PullDownAssHalf1L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_002_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_001_L
			});
			this.PullDownAssHalf1R.Init(MapaDeRopa.Interaciones.pullDownAssHalf1R, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.PullDownAssHalf1R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_002_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_001_R
			});
			this.PullDownAssHalf2L.Init(MapaDeRopa.Interaciones.pullDownAssHalf2L, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.PullDownAssHalf2L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_001_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_L
			});
			this.PullDownAssHalf2R.Init(MapaDeRopa.Interaciones.pullDownAssHalf2R, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.PullDownAssHalf2R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_001_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_R
			});
			this.ExposeCrotchF.Init(MapaDeRopa.Interaciones.exposeCrotchF, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeCrotchF), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeCrotch_F,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeCrotch_001_F
			});
			this.PullDownAssL.Init(MapaDeRopa.Interaciones.pullDownAssL, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.PullDownAssL), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_002_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_001_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_L
			});
			this.PullDownAssR.Init(MapaDeRopa.Interaciones.pullDownAssR, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.PullDownAssR), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_002_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_001_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeAss_R
			});
			this.ExposeTorzoHalf1F.Init(MapaDeRopa.Interaciones.exposeTorzoHalf1F, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeTorzoHalf1F), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeTorzo_F,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeTorzo_001_F
			});
			this.ExposeTorzoHalf2F.Init(MapaDeRopa.Interaciones.exposeTorzoHalf2F, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeTorzoHalf2F), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeTorzo_001_F,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeTorzo_002_F
			});
			this.ExposeTorzoHalf1B.Init(MapaDeRopa.Interaciones.exposeTorzoHalf1B, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeTorzoHalf1B), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeTorzo_B,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeTorzo_001_B
			});
			this.ExposeTorzoHalf2B.Init(MapaDeRopa.Interaciones.exposeTorzoHalf2B, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeTorzoHalf2B), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeTorzo_001_B,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeTorzo_002_B
			});
			this.ExposeChestHalf1L.Init(MapaDeRopa.Interaciones.exposeChestLateralHalf1L, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeChestHalf1L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeChestLateral_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeChestLateral_001_L
			});
			this.ExposeChestHalf2L.Init(MapaDeRopa.Interaciones.exposeChestLateralHalf2L, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeChestHalf2L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeChestLateral_001_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeChestLateral_002_L
			});
			this.ExposeChestHalf1R.Init(MapaDeRopa.Interaciones.exposeChestLateralHalf1R, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeChestHalf1R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeChestLateral_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeChestLateral_001_R
			});
			this.ExposeChestHalf2R.Init(MapaDeRopa.Interaciones.exposeChestLateralHalf2R, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeChestHalf2R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeChestLateral_001_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeChestLateral_002_R
			});
			this.ExposeHipsHalf1L.Init(MapaDeRopa.Interaciones.exposeHipsHalf1L, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeHipsHalf1L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeHips_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeHips_001_L
			});
			this.ExposeHipsHalf2L.Init(MapaDeRopa.Interaciones.exposeHipsHalf2L, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeHipsHalf2L), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeHips_001_L,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeHips_002_L
			});
			this.ExposeHipsHalf1R.Init(MapaDeRopa.Interaciones.exposeHipsHalf1R, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeHipsHalf1R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeHips_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeHips_001_R
			});
			this.ExposeHipsHalf2R.Init(MapaDeRopa.Interaciones.exposeHipsHalf2R, component, this.config, this.m_DrawOnTopOR.ObtenerModificadorNotNull(this.ExposeHipsHalf2R), new Transform[]
			{
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeHips_001_R,
				this.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeHips_002_R
			});
			List<GuiaDeRopaInteractable> list = new List<GuiaDeRopaInteractable>
			{
				this.ExposeVagAnus_R, this.ExposeVagAnus_L, this.ExposeLegs_R, this.ExposeLegs_L, this.ExposeAss_R, this.ExposeAss_L, this.ExposeAssSide_R, this.ExposeAssSide_L, this.ExposeNipples_R, this.ExposeNipples_L,
				this.ExposeShoulders_R, this.ExposeShoulders_L, this.ExposeAssHalf1L, this.ExposeAssHalf1R, this.ExposeAssHalf2L, this.ExposeAssHalf2R, this.PullDownAssHalf1L, this.PullDownAssHalf1R, this.PullDownAssHalf2L, this.PullDownAssHalf2R,
				this.ExposeCrotchF, this.PullDownAssL, this.PullDownAssR, this.ExposeTorzoHalf1F, this.ExposeTorzoHalf2F, this.ExposeTorzoHalf1B, this.ExposeTorzoHalf2B, this.ExposeChestHalf1L, this.ExposeChestHalf1R, this.ExposeChestHalf2L,
				this.ExposeChestHalf2R, this.ExposeHipsHalf1L, this.ExposeHipsHalf1R, this.ExposeHipsHalf2L, this.ExposeHipsHalf2R
			};
			this.m_guias = list.Distinct<GuiaDeRopaInteractable>().ToArray<GuiaDeRopaInteractable>();
			this.m_guias.ForEach(delegate(GuiaDeRopaInteractable g)
			{
				g.gameObject.AddComponent<EstimulosDeGuiaDeRopaInteractable>();
			});
			this.m_dic = this.m_guias.ToDictionary((GuiaDeRopaInteractable guia) => (int)guia.interaccion);
		}

		// Token: 0x06001365 RID: 4965 RVA: 0x00054E14 File Offset: 0x00053014
		public GuiaDeRopaInteractable ObtenerGuia(MapaDeRopa.Interaciones interaccion)
		{
			GuiaDeRopaInteractable guiaDeRopaInteractable;
			if (!this.m_dic.TryGetValue((int)interaccion, out guiaDeRopaInteractable))
			{
				return null;
			}
			return guiaDeRopaInteractable;
		}

		// Token: 0x06001366 RID: 4966 RVA: 0x00054E34 File Offset: 0x00053034
		public override void OnUpdateEvent1()
		{
			bool activeSelf = this.m_DrawOnTopVolumes.activeSelf;
			bool flag = this.m_DrawOnTopOR.Or(false);
			if (activeSelf != flag)
			{
				this.m_DrawOnTopVolumes.SetActive(flag);
			}
		}

		// Token: 0x0400101F RID: 4127
		[SerializeField]
		private GameObject m_DrawOnTopVolumes;

		// Token: 0x04001020 RID: 4128
		[SerializeField]
		private ModificableDeBool m_DrawOnTopOR = new ModificableDeBool(false);

		// Token: 0x04001021 RID: 4129
		private GuiasParaInteracionesDeRopaHelper m_GuiasParaInteracionesDeRopaHelper;

		// Token: 0x04001022 RID: 4130
		public GuiaVisualInteractable.Config config = new GuiaVisualInteractable.Config();

		// Token: 0x04001023 RID: 4131
		public GameObject guiaPrefab;

		// Token: 0x04001024 RID: 4132
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeVagAnus_R;

		// Token: 0x04001025 RID: 4133
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeVagAnus_L;

		// Token: 0x04001026 RID: 4134
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeLegs_R;

		// Token: 0x04001027 RID: 4135
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeLegs_L;

		// Token: 0x04001028 RID: 4136
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeAss_R;

		// Token: 0x04001029 RID: 4137
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeAss_L;

		// Token: 0x0400102A RID: 4138
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeAssSide_R;

		// Token: 0x0400102B RID: 4139
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeAssSide_L;

		// Token: 0x0400102C RID: 4140
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeNipples_R;

		// Token: 0x0400102D RID: 4141
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeNipples_L;

		// Token: 0x0400102E RID: 4142
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeShoulders_R;

		// Token: 0x0400102F RID: 4143
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeShoulders_L;

		// Token: 0x04001030 RID: 4144
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeAssHalf1L;

		// Token: 0x04001031 RID: 4145
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeAssHalf1R;

		// Token: 0x04001032 RID: 4146
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeAssHalf2L;

		// Token: 0x04001033 RID: 4147
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeAssHalf2R;

		// Token: 0x04001034 RID: 4148
		[ReadOnlyUI]
		public GuiaDeRopaInteractable PullDownAssHalf1L;

		// Token: 0x04001035 RID: 4149
		[ReadOnlyUI]
		public GuiaDeRopaInteractable PullDownAssHalf1R;

		// Token: 0x04001036 RID: 4150
		[ReadOnlyUI]
		public GuiaDeRopaInteractable PullDownAssHalf2L;

		// Token: 0x04001037 RID: 4151
		[ReadOnlyUI]
		public GuiaDeRopaInteractable PullDownAssHalf2R;

		// Token: 0x04001038 RID: 4152
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeCrotchF;

		// Token: 0x04001039 RID: 4153
		[ReadOnlyUI]
		public GuiaDeRopaInteractable PullDownAssL;

		// Token: 0x0400103A RID: 4154
		[ReadOnlyUI]
		public GuiaDeRopaInteractable PullDownAssR;

		// Token: 0x0400103B RID: 4155
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeTorzoHalf1F;

		// Token: 0x0400103C RID: 4156
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeTorzoHalf2F;

		// Token: 0x0400103D RID: 4157
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeTorzoHalf1B;

		// Token: 0x0400103E RID: 4158
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeTorzoHalf2B;

		// Token: 0x0400103F RID: 4159
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeChestHalf1L;

		// Token: 0x04001040 RID: 4160
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeChestHalf1R;

		// Token: 0x04001041 RID: 4161
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeChestHalf2L;

		// Token: 0x04001042 RID: 4162
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeChestHalf2R;

		// Token: 0x04001043 RID: 4163
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeHipsHalf1L;

		// Token: 0x04001044 RID: 4164
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeHipsHalf1R;

		// Token: 0x04001045 RID: 4165
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeHipsHalf2L;

		// Token: 0x04001046 RID: 4166
		[ReadOnlyUI]
		public GuiaDeRopaInteractable ExposeHipsHalf2R;

		// Token: 0x04001047 RID: 4167
		private GuiaDeRopaInteractable[] m_guias;

		// Token: 0x04001048 RID: 4168
		private Dictionary<int, GuiaDeRopaInteractable> m_dic;
	}
}
