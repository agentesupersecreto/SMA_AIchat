using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Productos.Juegos.Reception.Scripts.Dependientes.Controlladores;
using Assets.TValle.BeachGirl;
using Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Modelos;
using Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Paneles;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.UI
{
	// Token: 0x020000B8 RID: 184
	[RequireComponent(typeof(CurriculumVitaePanel))]
	public class SMACurriculumVitaePanelDataLoader : CustomMonobehaviour
	{
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060006B8 RID: 1720 RVA: 0x00026DD2 File Offset: 0x00024FD2
		public CurriculumVitaePanel panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00026DDC File Offset: 0x00024FDC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_panel = base.GetComponent<CurriculumVitaePanel>();
			this.m_panel.loading += this.M_panel_loading;
			this.m_panel.load += this.M_panel_load;
			this.m_panel.clearing += this.M_panel_clearing1;
			this.m_panel.onAction += this.M_panel_onAction;
			this.m_panel.clearing += this.M_panel_clearing;
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00026E6E File Offset: 0x0002506E
		private void M_panel_loading(ref CurriculumVitaeModelo modelo, CurriculumVitaePanel sender)
		{
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x00026E70 File Offset: 0x00025070
		private void M_panel_load(ref CurriculumVitaeModelo modelo, CurriculumVitaePanel sender)
		{
			CurriculumVitaePanel panel = this.panel;
			bool flag;
			SMACurriculumVitaePanelDataLoader.LoadInfoToPanel(((panel != null) ? panel.target : null) as FemaleChar, modelo, true, out flag);
			if (flag)
			{
				base.StartCoroutine(this.WaitForMeshCorutineV2(modelo));
			}
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x00026EB0 File Offset: 0x000250B0
		public static void LoadInfoToPanel(FemaleChar character, CurriculumVitaeModelo modelo, bool puedeUpdatePortrait, out bool modelAsNoPortrait)
		{
			modelAsNoPortrait = false;
			if (character == null)
			{
				throw new ArgumentNullException("character", "character null reference.");
			}
			IFemaleCharInfo componentInChildren = character.GetComponentInChildren<IFemaleCharInfo>();
			Personalidad componentInChildren2 = character.GetComponentInChildren<Personalidad>(true);
			if (componentInChildren == null)
			{
				throw new ArgumentNullException("IFemaleCharInfo", "IFemaleCharInfo null reference.");
			}
			componentInChildren.ActualizarInfo();
			List<int> list = typeof(Personalidad.Tipo).GetEnumValoresInt().ToList<int>();
			Personalidad.Tipo tipo = componentInChildren2.ObtenerTipoMayorDeCurrentFrame(true, list, false, true);
			list.Remove((int)tipo);
			Personalidad.Tipo tipo2 = componentInChildren2.ObtenerTipoMayorDeCurrentFrame(true, list, false, true);
			float num;
			TraitHumano? traitHumano;
			float num2;
			float num3;
			if (componentInChildren2.InterestedInEroticModeling(out num))
			{
				traitHumano = new TraitHumano?(TraitHumano.gustoPorModelajeHerotico);
			}
			else if (componentInChildren2.InterestedInLingerieModeling(out num2))
			{
				traitHumano = new TraitHumano?(TraitHumano.gustoPorModelajeUnderwear);
			}
			else if (componentInChildren2.InterestedInModeling(out num3))
			{
				traitHumano = new TraitHumano?(TraitHumano.gustoPorModelaje);
			}
			else
			{
				traitHumano = null;
			}
			float num4;
			float num5;
			float num6;
			componentInChildren2.GetPreferredTreatmentForClientsWeights(out num4, out num5, out num6);
			TraitHumano? traitHumano2;
			if (num6 > 0f)
			{
				traitHumano2 = new TraitHumano?(TraitHumano.gustoPorTratoExplicitoDeClientes);
			}
			else if (num5 > 0f)
			{
				traitHumano2 = new TraitHumano?(TraitHumano.gustoPorTratoEspecialDeClientes);
			}
			else if (num4 > 0f)
			{
				traitHumano2 = new TraitHumano?(TraitHumano.gustoPorTratoDeClientes);
			}
			else
			{
				traitHumano2 = null;
			}
			int num7 = Mathf.RoundToInt((componentInChildren.vaginalExperienceWeight + componentInChildren.analExperienceWeight) / 2f * 4f);
			float num8;
			Personalidad.TipoSexual tipoSexual = componentInChildren2.ObtenerMayorSexual(out num8);
			if (modelo.portrait.imagen == null)
			{
				modelo.portrait.imagen = MemoriaDeSMAModelosFemeninas.GetPortrait(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				if (modelo.portrait.imagen == null)
				{
					modelAsNoPortrait = true;
				}
			}
			if (puedeUpdatePortrait)
			{
				modelo.accion1Label = "Update Portrait";
			}
			else
			{
				modelo.accion1Label = string.Empty;
			}
			modelo.accion1ConfirmacionPregunta = null;
			modelo.info.name = character.nombre;
			modelo.info.lastName = character.apellido;
			modelo.info.age = componentInChildren.age.ToString();
			modelo.info.sex = "Female";
			modelo.info.fatigue = (MemoriaDeNpc.GetFatigue(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString, 0f) / 100f).ToString("P0");
			modelo.info.overallExp = MemoriaDeSMAModelosFemeninas.TryGetModelingExp(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString, 0f).ToString("0.00");
			if (traitHumano == null && traitHumano2 == null)
			{
				modelo.info.interests = "None";
			}
			else
			{
				if (traitHumano != null)
				{
					modelo.info.interests = TextoLocalizadoAttribute.Localizado<TraitHumano>(traitHumano.Value, "US").FirstLetterOrDefaultToUpperCaseOthersToLower();
				}
				if (traitHumano2 != null)
				{
					if (traitHumano != null)
					{
						CurriculumVitaeModeloInfo info = modelo.info;
						info.interests += ", ";
					}
					CurriculumVitaeModeloInfo info2 = modelo.info;
					info2.interests += TextoLocalizadoAttribute.Localizado<TraitHumano>(traitHumano2.Value, "US").FirstLetterOrDefaultToUpperCaseOthersToLower();
				}
			}
			modelo.info.height = Mathf.RoundToInt(character.estatura * 100f).ToString() + " cm";
			modelo.info.chest = componentInChildren.chest.ToString() + "(" + componentInChildren.cup + " Cup) cm";
			modelo.info.waist = componentInChildren.waist.ToString() + " cm";
			modelo.info.hips = componentInChildren.hips.ToString() + " cm";
			modelo.info.mostNotablePersonalityTrait = TextoLocalizadoAttribute.Localizado<Personalidad.Tipo>(tipo, "US");
			modelo.info.secondMostNotablePersonalityTrait = TextoLocalizadoAttribute.Localizado<Personalidad.Tipo>(tipo2, "US");
			switch (num7)
			{
			case 0:
				modelo.info.sexualExperience = "Very Low";
				break;
			case 1:
				modelo.info.sexualExperience = "Low";
				break;
			case 2:
				modelo.info.sexualExperience = "Avarage";
				break;
			case 3:
				modelo.info.sexualExperience = "High";
				break;
			case 4:
				modelo.info.sexualExperience = "Very High";
				break;
			default:
				throw new ArgumentOutOfRangeException(num7.ToString());
			}
			modelo.info.sexualDerivation = TextoLocalizadoAttribute.Localizado<Personalidad.TipoSexual>(tipoSexual, "US") + "(Under Development)";
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0002732C File Offset: 0x0002552C
		private void M_panel_onAction(int actionIndex, CurriculumVitaeModelo modelo, CurriculumVitaePanel sender)
		{
			if (actionIndex == 0)
			{
				base.StartCoroutine(this.WaitForMeshCorutineV2(modelo));
			}
			if (actionIndex == 1)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00027349 File Offset: 0x00025549
		private void M_panel_clearing1(ref CurriculumVitaeModelo modelo, CurriculumVitaePanel sender)
		{
			if (modelo.portrait.imagen != null)
			{
				Object.Destroy(modelo.portrait.imagen);
			}
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00027370 File Offset: 0x00025570
		private void UpdatPortrait(CurriculumVitaeModelo modelo)
		{
			CurriculumVitaePanel panel = this.panel;
			SelfPortraitCamera componentInChildren = (((panel != null) ? panel.target : null) as FemaleChar).GetComponentInChildren<SelfPortraitCamera>();
			modelo.portrait.imagen = ((componentInChildren != null) ? componentInChildren.TakeFemalePortrait() : null);
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x000273B1 File Offset: 0x000255B1
		private IEnumerator WaitForMeshCorutineV2(CurriculumVitaeModelo modelo)
		{
			yield return new WaitForEndOfFrame();
			this.UpdatPortrait(modelo);
			this.m_panel.UpdatePortraitPanel();
			yield break;
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x000273C7 File Offset: 0x000255C7
		private void M_panel_clearing(ref CurriculumVitaeModelo modelo, CurriculumVitaePanel sender)
		{
		}

		// Token: 0x04000409 RID: 1033
		private CurriculumVitaePanel m_panel;
	}
}
