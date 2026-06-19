using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Base.Plugins.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Modelos;
using Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Modelos;
using Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Paneles;
using Assets.TValle.Pro.Entrevista.Runtime.General.UI;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos;
using Assets.TValle.Tools.Runtime;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets.TValle.Tools.Runtime.UI;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas
{
	// Token: 0x02000040 RID: 64
	[RequireComponent(typeof(PanelLateralTabsWithCustomInfo))]
	public class PanelCharacterCompleteInfoLoader : AplicableBehaviour, IPanelOfModel
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060001EC RID: 492 RVA: 0x0000BFB2 File Offset: 0x0000A1B2
		public PanelLateralTabsWithCustomInfo panel
		{
			get
			{
				return this.m_PanelToDraw;
			}
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0000BFBA File Offset: 0x0000A1BA
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PanelToDraw = base.GetComponent<PanelLateralTabsWithCustomInfo>();
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0000BFCE File Offset: 0x0000A1CE
		public void SetTarget(FemaleChar target)
		{
			this.m_maleTaget = null;
			this.m_femaleTaget = target;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000BFDE File Offset: 0x0000A1DE
		public void SetTarget(MaleChar target)
		{
			this.m_femaleTaget = null;
			this.m_maleTaget = target;
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000BFF0 File Offset: 0x0000A1F0
		private void SetFollower(AnimatorCharacter m_target)
		{
			DatosDeHumanBone head = m_target.bones.head;
			base.transform.SetPositionAndRotation(head.posicionFinal, head.rotacionFinal * head.offSetToForward);
			this.m_follower = base.gameObject.AddComponent<TrasnformCopier>();
			this.m_follower.Init(false, base.transform, m_target.bones.head.transform, new Vector3?(head.offSetToForward.eulerAngles), null, null);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0000C080 File Offset: 0x0000A280
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_PanelToDraw.loading += this.m_PanelToDraw_loading;
			this.m_PanelToDraw.loadingItems += this.m_PanelToDraw_loadingItems;
			this.m_PanelToDraw.loadingInformacionGenera += this.m_PanelToDraw_loadingInformacionGenera;
			this.m_PanelToDraw.onCleared += this.m_PanelToDraw_onCleared;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0000C0F0 File Offset: 0x0000A2F0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_PanelToDraw != null)
			{
				this.m_PanelToDraw.loading -= this.m_PanelToDraw_loading;
				this.m_PanelToDraw.loadingItems -= this.m_PanelToDraw_loadingItems;
				this.m_PanelToDraw.loadingInformacionGenera -= this.m_PanelToDraw_loadingInformacionGenera;
				this.m_PanelToDraw.onCleared -= this.m_PanelToDraw_onCleared;
			}
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000C170 File Offset: 0x0000A370
		private void m_PanelToDraw_loading(ref TabsWithCustomInfoModelo modelo, PanelLateralTabsWithCustomInfo sender)
		{
			PanelAttribute panelAttribute = new PanelAttribute();
			modelo.layout = panelAttribute;
			panelAttribute.tipo = TipoDePanel.panel1by3;
			panelAttribute.width = 1100;
			panelAttribute.height = 810;
			panelAttribute.childForceExpandHeight = (panelAttribute.controlChildHeight = true);
			panelAttribute.childForceExpandWidth = (panelAttribute.controlChildWidth = true);
			panelAttribute.flexibleHeight = (panelAttribute.flexibleWidth = 1f);
			panelAttribute.unlockFlexibleIfWidthWasSet = (panelAttribute.unlockParentFlexibleIfWidthWasSet = true);
			PanelAttribute panelAttribute2 = new PanelAttribute();
			modelo.tabsList.layout = panelAttribute2;
			panelAttribute2.tipo = TipoDePanel.scrollableFlotante;
			panelAttribute2.width = 400;
			panelAttribute2.childForceExpandWidth = (panelAttribute2.controlChildWidth = true);
			panelAttribute2.unlockFlexibleIfWidthWasSet = (panelAttribute2.unlockParentFlexibleIfWidthWasSet = true);
			if (this.m_femaleTaget != null)
			{
				this.SetFollower(this.m_femaleTaget);
				modelo.informacionGeneral = this.m_FemaleCurriculum;
				this.LoadFemaleCurriculum();
				modelo.title = "Talent Development";
				return;
			}
			if (this.m_maleTaget != null)
			{
				this.SetFollower(this.m_maleTaget);
				modelo.informacionGeneral = this.m_MaleCurriculum;
				this.LoadMaleCurriculum();
				modelo.title = "Playable Character Info";
				return;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0000C2AC File Offset: 0x0000A4AC
		private void m_PanelToDraw_loadingItems(ref TabsWithCustomInfoModelo modelo, PanelLateralTabsWithCustomInfo sender)
		{
			List<LabelData> list = new List<LabelData>();
			LabelData labelData = new LabelData("Curriculum", "Basic Details", null);
			list.Add(labelData);
			LabelData labelData2 = new LabelData("Favorability", TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<DisplayableBuffCategory>(DisplayableBuffCategory.favorability, Language.en), null);
			list.Add(labelData2);
			LabelData labelData3 = new LabelData("Pleasure Buff", TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<DisplayableBuffCategory>(DisplayableBuffCategory.pleasure, Language.en), null);
			list.Add(labelData3);
			LabelData labelData4 = new LabelData("Desires Buff", TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<DisplayableBuffCategory>(DisplayableBuffCategory.desires, Language.en), null);
			list.Add(labelData4);
			LabelData labelData5 = new LabelData("Rage Buff", TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<DisplayableBuffCategory>(DisplayableBuffCategory.rage, Language.en), null);
			list.Add(labelData5);
			LabelData labelData6 = new LabelData("Pain Buff", TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<DisplayableBuffCategory>(DisplayableBuffCategory.pain, Language.en), null);
			list.Add(labelData6);
			LabelData labelData7 = new LabelData("Fear Buff", TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<DisplayableBuffCategory>(DisplayableBuffCategory.fear, Language.en), null);
			list.Add(labelData7);
			LabelData labelData8 = new LabelData("Decep Buff", TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<DisplayableBuffCategory>(DisplayableBuffCategory.decep, Language.en), null);
			list.Add(labelData8);
			LabelData labelData9 = new LabelData("Other Buff", TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<DisplayableBuffCategory>(DisplayableBuffCategory.other, Language.en), null);
			list.Add(labelData9);
			modelo.tabsList.items.Clear();
			modelo.tabsList.items.AddRange(list);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0000C420 File Offset: 0x0000A620
		private void m_PanelToDraw_loadingInformacionGenera(LabelData itemData, int index, ref object subModeloInformacionGeneral, PanelLateralTabsWithCustomInfo sender)
		{
			Character character = this.m_femaleTaget ?? this.m_maleTaget;
			string id = itemData.ID;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(id);
			if (num <= 1194623194U)
			{
				if (num <= 278447795U)
				{
					if (num != 211359291U)
					{
						if (num == 278447795U)
						{
							if (id == "Pleasure Buff")
							{
								PanelCharacterCompleteInfoLoader.LoadBuff(character, this.PleasureModelo, DisplayableBuffCategory.pleasure, ref subModeloInformacionGeneral);
								this.PleasureModelo.title = itemData.label;
								return;
							}
						}
					}
					else if (id == "Favorability")
					{
						PanelCharacterCompleteInfoLoader.LoadBuff(character, this.FavorabilityModelo, DisplayableBuffCategory.favorability, ref subModeloInformacionGeneral);
						this.FavorabilityModelo.title = itemData.label;
						return;
					}
				}
				else if (num != 1082959250U)
				{
					if (num == 1194623194U)
					{
						if (id == "Curriculum")
						{
							if (character is FemaleChar)
							{
								this.LoadFemaleCurriculum();
								subModeloInformacionGeneral = this.m_FemaleCurriculum;
								return;
							}
							if (character is MaleChar)
							{
								this.LoadMaleCurriculum();
								subModeloInformacionGeneral = this.m_MaleCurriculum;
								return;
							}
							throw new ArgumentOutOfRangeException();
						}
					}
				}
				else if (id == "Pain Buff")
				{
					PanelCharacterCompleteInfoLoader.LoadBuff(character, this.PainModelo, DisplayableBuffCategory.pain, ref subModeloInformacionGeneral);
					this.PainModelo.title = itemData.label;
					return;
				}
			}
			else if (num <= 2200125484U)
			{
				if (num != 1739068471U)
				{
					if (num == 2200125484U)
					{
						if (id == "Fear Buff")
						{
							PanelCharacterCompleteInfoLoader.LoadBuff(character, this.FearModelo, DisplayableBuffCategory.fear, ref subModeloInformacionGeneral);
							this.FearModelo.title = itemData.label;
							return;
						}
					}
				}
				else if (id == "Decep Buff")
				{
					PanelCharacterCompleteInfoLoader.LoadBuff(character, this.DecepModelo, DisplayableBuffCategory.decep, ref subModeloInformacionGeneral);
					this.DecepModelo.title = itemData.label;
					return;
				}
			}
			else if (num != 2663301281U)
			{
				if (num != 2783152653U)
				{
					if (num == 3810319794U)
					{
						if (id == "Other Buff")
						{
							PanelCharacterCompleteInfoLoader.LoadBuff(character, this.OtherModelo, DisplayableBuffCategory.other, ref subModeloInformacionGeneral);
							this.OtherModelo.title = itemData.label;
							return;
						}
					}
				}
				else if (id == "Rage Buff")
				{
					PanelCharacterCompleteInfoLoader.LoadBuff(character, this.RageModelo, DisplayableBuffCategory.rage, ref subModeloInformacionGeneral);
					this.RageModelo.title = itemData.label;
					return;
				}
			}
			else if (id == "Desires Buff")
			{
				PanelCharacterCompleteInfoLoader.LoadBuff(character, this.DesiresModelo, DisplayableBuffCategory.desires, ref subModeloInformacionGeneral);
				this.DesiresModelo.title = itemData.label;
				return;
			}
			throw new ArgumentOutOfRangeException(itemData.ID.ToString());
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000C6D4 File Offset: 0x0000A8D4
		private void LoadFemaleCurriculum()
		{
			bool flag;
			SMACurriculumVitaePanelDataLoader.LoadInfoToPanel(this.m_femaleTaget, this.m_FemaleCurriculum, false, out flag);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000C6F5 File Offset: 0x0000A8F5
		private void LoadMaleCurriculum()
		{
			SMAMaleInfoPanelDataLoader.LoadInfoToPanel(this.m_maleTaget, this.m_MaleCurriculum);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000C708 File Offset: 0x0000A908
		private static void LoadBuff(Character target, BuffAndDebuffModelo buffModelo, DisplayableBuffCategory type, ref object subModeloInformacionGeneral)
		{
			string modelName = target.nombreCompleto;
			BuffDeCharacter componentEnRoot = target.GetComponentEnRoot<BuffDeCharacter>();
			buffModelo.items.Clear();
			buffModelo.items = (from e in componentEnRoot.acontiecionedo.eventos
				where e is IDisplayableBuffCategorable
				select e into b
				select b as DisplayableBuff into buff
				where !buff.hideFromUI && buff.displayableBuffType == type
				select buff into e
				orderby e.displayFirst descending, Mathf.Abs(e.quality - Assets.Base.Plugins.Runtime.ItemQuality.Common) descending, e.priority descending
				select e into buff
				select new LabelData2(buff.id, buff.LocalizedText().Replace("\n", " ").Replace(modelName, "")
					.Trim(), ((buff.EndDateTime.Year >= DateTime.MaxValue.Year) ? TextoLocalizadoAttribute.Localizado<PanelCharacterCompleteInfoLoader.TiempoRestanteLabel>(PanelCharacterCompleteInfoLoader.TiempoRestanteLabel.permanent, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura) : PanelCharacterCompleteInfoLoader.ObtenerTiepoRestanteLocalizado(buff.EndDateTime)) + ((buff != null && !string.IsNullOrWhiteSpace(((IDisplayableCustomToolTip)buff).tooltip)) ? ("\n" + ((IDisplayableCustomToolTip)buff).tooltip) : string.Empty), new Color?(buff.quality.GetColor()))).ToList<LabelData2>();
			subModeloInformacionGeneral = buffModelo;
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000C830 File Offset: 0x0000AA30
		private static string ObtenerTiepoRestanteLocalizado(DateTime endDate)
		{
			DateTime now = Singleton<TiempoDeJuego>.instance.now;
			endDate - now;
			int num = endDate.Year - now.Year;
			if (endDate < now.AddYears(num))
			{
				num--;
			}
			DateTime dateTime = now.AddYears(num);
			TimeSpan timeSpan = endDate - dateTime;
			int num2 = timeSpan.Days / 7;
			int num3 = timeSpan.Days % 7;
			int hours = timeSpan.Hours;
			StringBuilder stringBuilder = new StringBuilder();
			if (num == 0 && num2 == 0 && num3 == 0 && hours == 0)
			{
				stringBuilder.Append(TextoLocalizadoAttribute.Localizado<PanelCharacterCompleteInfoLoader.TiempoRestanteLabel>(PanelCharacterCompleteInfoLoader.TiempoRestanteLabel.expiring, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura));
			}
			else
			{
				stringBuilder.Append(TextoLocalizadoAttribute.Localizado<PanelCharacterCompleteInfoLoader.TiempoRestanteLabel>(PanelCharacterCompleteInfoLoader.TiempoRestanteLabel.timeRemaining, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura));
				stringBuilder.Append(' ');
				if (num > 0)
				{
					stringBuilder.Append(num);
					stringBuilder.Append(' ');
					if (num > 1)
					{
						stringBuilder.Append(TextoLocalizadoAttribute.Localizado<PanelCharacterCompleteInfoLoader.TiempoRestantePrural>(PanelCharacterCompleteInfoLoader.TiempoRestantePrural.years, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura));
					}
					else
					{
						stringBuilder.Append(TextoLocalizadoAttribute.Localizado<PanelCharacterCompleteInfoLoader.TiempoRestanteSingular>(PanelCharacterCompleteInfoLoader.TiempoRestanteSingular.year, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura));
					}
					stringBuilder.Append(',');
					stringBuilder.Append(' ');
				}
				if (num2 > 0)
				{
					stringBuilder.Append(num2);
					stringBuilder.Append(' ');
					if (num2 > 1)
					{
						stringBuilder.Append(TextoLocalizadoAttribute.Localizado<PanelCharacterCompleteInfoLoader.TiempoRestantePrural>(PanelCharacterCompleteInfoLoader.TiempoRestantePrural.semanas, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura));
					}
					else
					{
						stringBuilder.Append(TextoLocalizadoAttribute.Localizado<PanelCharacterCompleteInfoLoader.TiempoRestanteSingular>(PanelCharacterCompleteInfoLoader.TiempoRestanteSingular.semana, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura));
					}
					stringBuilder.Append(',');
					stringBuilder.Append(' ');
				}
				if (num3 > 0)
				{
					stringBuilder.Append(num3);
					stringBuilder.Append(' ');
					if (num3 > 1)
					{
						stringBuilder.Append(TextoLocalizadoAttribute.Localizado<PanelCharacterCompleteInfoLoader.TiempoRestantePrural>(PanelCharacterCompleteInfoLoader.TiempoRestantePrural.dias, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura));
					}
					else
					{
						stringBuilder.Append(TextoLocalizadoAttribute.Localizado<PanelCharacterCompleteInfoLoader.TiempoRestanteSingular>(PanelCharacterCompleteInfoLoader.TiempoRestanteSingular.dia, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura));
					}
					stringBuilder.Append(',');
					stringBuilder.Append(' ');
				}
				if (hours > 0)
				{
					stringBuilder.Append(hours);
					stringBuilder.Append(' ');
					if (hours > 1)
					{
						stringBuilder.Append(TextoLocalizadoAttribute.Localizado<PanelCharacterCompleteInfoLoader.TiempoRestantePrural>(PanelCharacterCompleteInfoLoader.TiempoRestantePrural.horas, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura));
					}
					else
					{
						stringBuilder.Append(TextoLocalizadoAttribute.Localizado<PanelCharacterCompleteInfoLoader.TiempoRestanteSingular>(PanelCharacterCompleteInfoLoader.TiempoRestanteSingular.hora, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura));
					}
					stringBuilder.Append(',');
					stringBuilder.Append(' ');
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000CAC0 File Offset: 0x0000ACC0
		private void m_PanelToDraw_onCleared()
		{
			if (this.m_FemaleCurriculum.portrait.imagen != null)
			{
				Object.Destroy(this.m_FemaleCurriculum.portrait.imagen);
				this.m_FemaleCurriculum.portrait.imagen = null;
			}
			this.m_femaleTaget = null;
			this.m_maleTaget = null;
			if (this.m_follower != null)
			{
				Object.Destroy(this.m_follower);
			}
			this.m_follower = null;
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060001FB RID: 507 RVA: 0x0000CB39 File Offset: 0x0000AD39
		public bool isShowing
		{
			get
			{
				return ((IPanelOfModel)this.m_PanelToDraw).isShowing;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060001FC RID: 508 RVA: 0x0000CB46 File Offset: 0x0000AD46
		public bool isBinded
		{
			get
			{
				return ((IPanelOfModel)this.m_PanelToDraw).isBinded;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060001FD RID: 509 RVA: 0x0000CB53 File Offset: 0x0000AD53
		[Obsolete("Mal hecho", true)]
		public GenericUserPanelBase genericUserPanel
		{
			get
			{
				return ((IPanelOfModel)this.m_PanelToDraw).genericUserPanel;
			}
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000CB60 File Offset: 0x0000AD60
		public void ActualizarValoresDeModelo()
		{
			((IPanelOfModel)this.m_PanelToDraw).ActualizarValoresDeModelo();
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000CB6D File Offset: 0x0000AD6D
		public bool CanShow()
		{
			return ((IPanelOfModel)this.m_PanelToDraw).CanShow();
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000CB7A File Offset: 0x0000AD7A
		public void Clear()
		{
			((IPanelOfModel)this.m_PanelToDraw).Clear();
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000CB87 File Offset: 0x0000AD87
		public void CrearYDibujar(DibujadorDynamico.ExtraData extraData = null)
		{
			((IPanelOfModel)this.m_PanelToDraw).CrearYDibujar(extraData);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000CB95 File Offset: 0x0000AD95
		public object CurrentModelObjectAndState(out bool changed)
		{
			return ((IPanelOfModel)this.m_PanelToDraw).CurrentModelObjectAndState(out changed);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000CBA3 File Offset: 0x0000ADA3
		public void Hide()
		{
			((IPanelOfModel)this.m_PanelToDraw).Hide();
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000CBB0 File Offset: 0x0000ADB0
		public void Show()
		{
			((IPanelOfModel)this.m_PanelToDraw).Show();
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0000CBBD File Offset: 0x0000ADBD
		public object GetLastDrawModel()
		{
			return ((IPanelOfModel)this.m_PanelToDraw).GetLastDrawModel();
		}

		// Token: 0x04000159 RID: 345
		private PanelLateralTabsWithCustomInfo m_PanelToDraw;

		// Token: 0x0400015A RID: 346
		[SerializeField]
		[ReadOnlyUI]
		private FemaleChar m_femaleTaget;

		// Token: 0x0400015B RID: 347
		[SerializeField]
		[ReadOnlyUI]
		private MaleChar m_maleTaget;

		// Token: 0x0400015C RID: 348
		private CurriculumVitaeModelo m_FemaleCurriculum = new CurriculumVitaeModelo();

		// Token: 0x0400015D RID: 349
		private MaleInfoModelo m_MaleCurriculum = new MaleInfoModelo();

		// Token: 0x0400015E RID: 350
		private BuffAndDebuffModelo FavorabilityModelo = new BuffAndDebuffModelo();

		// Token: 0x0400015F RID: 351
		private BuffAndDebuffModelo PleasureModelo = new BuffAndDebuffModelo();

		// Token: 0x04000160 RID: 352
		private BuffAndDebuffModelo DesiresModelo = new BuffAndDebuffModelo();

		// Token: 0x04000161 RID: 353
		private BuffAndDebuffModelo RageModelo = new BuffAndDebuffModelo();

		// Token: 0x04000162 RID: 354
		private BuffAndDebuffModelo PainModelo = new BuffAndDebuffModelo();

		// Token: 0x04000163 RID: 355
		private BuffAndDebuffModelo FearModelo = new BuffAndDebuffModelo();

		// Token: 0x04000164 RID: 356
		private BuffAndDebuffModelo DecepModelo = new BuffAndDebuffModelo();

		// Token: 0x04000165 RID: 357
		private BuffAndDebuffModelo OtherModelo = new BuffAndDebuffModelo();

		// Token: 0x04000166 RID: 358
		private TrasnformCopier m_follower;

		// Token: 0x02000162 RID: 354
		private enum TiempoRestanteLabel
		{
			// Token: 0x040005E6 RID: 1510
			[LabelLocalizado("Permanent", "US")]
			permanent,
			// Token: 0x040005E7 RID: 1511
			[LabelLocalizado("Time remaining", "US")]
			timeRemaining,
			// Token: 0x040005E8 RID: 1512
			[LabelLocalizado("Expiring", "US")]
			expiring
		}

		// Token: 0x02000163 RID: 355
		private enum TiempoRestantePrural
		{
			// Token: 0x040005EA RID: 1514
			None,
			// Token: 0x040005EB RID: 1515
			[LabelLocalizado("Minutes", "US")]
			minutos,
			// Token: 0x040005EC RID: 1516
			[LabelLocalizado("Hours", "US")]
			horas,
			// Token: 0x040005ED RID: 1517
			[LabelLocalizado("Days", "US")]
			dias,
			// Token: 0x040005EE RID: 1518
			[LabelLocalizado("Weeks", "US")]
			semanas,
			// Token: 0x040005EF RID: 1519
			[LabelLocalizado("Years", "US")]
			years
		}

		// Token: 0x02000164 RID: 356
		private enum TiempoRestanteSingular
		{
			// Token: 0x040005F1 RID: 1521
			None,
			// Token: 0x040005F2 RID: 1522
			[LabelLocalizado("Minute", "US")]
			minuto,
			// Token: 0x040005F3 RID: 1523
			[LabelLocalizado("Hour", "US")]
			hora,
			// Token: 0x040005F4 RID: 1524
			[LabelLocalizado("Day", "US")]
			dia,
			// Token: 0x040005F5 RID: 1525
			[LabelLocalizado("Week", "US")]
			semana,
			// Token: 0x040005F6 RID: 1526
			[LabelLocalizado("Year", "US")]
			year
		}
	}
}
