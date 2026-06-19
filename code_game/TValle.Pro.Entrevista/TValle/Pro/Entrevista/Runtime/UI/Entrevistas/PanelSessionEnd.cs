using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Plugins.Runtime;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets.TValle.Tools.Runtime.UI;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas
{
	// Token: 0x02000045 RID: 69
	public class PanelSessionEnd : PanelBaseSingleModel<SessionEndInfoModelo>
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600023C RID: 572 RVA: 0x0000EB38 File Offset: 0x0000CD38
		public SessionEndInfoModelo modelo
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x0600023D RID: 573 RVA: 0x0000EB40 File Offset: 0x0000CD40
		// (remove) Token: 0x0600023E RID: 574 RVA: 0x0000EB78 File Offset: 0x0000CD78
		public event Action onLeaveClicked;

		// Token: 0x0600023F RID: 575 RVA: 0x0000EBAD File Offset: 0x0000CDAD
		protected override void OnBinded()
		{
			base.OnBinded();
			this.m_model.onNextClick += this.M_model_onNextClick;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0000EBCC File Offset: 0x0000CDCC
		protected override void OnClearing()
		{
			base.OnClearing();
			this.m_model.onNextClick -= this.M_model_onNextClick;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000EBEB File Offset: 0x0000CDEB
		private void M_model_onNextClick()
		{
			Action action = this.onLeaveClicked;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000EBFD File Offset: 0x0000CDFD
		public void ClearLeaveCallBack()
		{
			this.onLeaveClicked = null;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000EC08 File Offset: 0x0000CE08
		public static void LoadDataToModel(bool aborted, float income, float activityExpGain, float activityExpTotal, float modelFatigueGain, float modelFatigueTotal, SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnFrom, SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnTo, SessionEndInfoModelo modelo)
		{
			modelo.title = (aborted ? "Session Failed" : " Session Succeeded");
			modelo.income = new LabelData2(string.Empty, "Total Income " + income.ToString("C0"), string.Empty, new Color?(Color.green));
			modelo.activityExpGain = new LabelData2(string.Empty, "Exp Gain " + activityExpGain.ToString("0.000"), string.Empty, new Color?(Color.green));
			modelo.activityExpTotal = new LabelData2(string.Empty, "Total Exp " + activityExpTotal.ToString("0.0"), string.Empty, new Color?(Color.green));
			modelo.fatigueGain = new LabelData2(string.Empty, "Fatigue Gain " + (modelFatigueGain / 100f).ToString("P2"), string.Empty, new Color?(Color.red));
			modelo.fatigueTotal = new LabelData2(string.Empty, "Total Fatigue " + (modelFatigueTotal / 100f).ToString("P1"), string.Empty, new Color?(Color.red));
			if (BuffAndDebuffOnTo != null)
			{
				IEnumerable<IGrouping<DisplayableBuffCategory, IPrintableBuff>> enumerable = from printable in BuffAndDebuffOnTo.GetAllPrintables()
					group printable by printable.category;
				modelo.buff.nonPlayer.title = BuffAndDebuffOnTo.character.fullName;
				modelo.buff.nonPlayer.buffGains = enumerable.Select(delegate(IGrouping<DisplayableBuffCategory, IPrintableBuff> g)
				{
					SessionEndBuffGainCategoria sessionEndBuffGainCategoria = new SessionEndBuffGainCategoria();
					sessionEndBuffGainCategoria.title = TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<DisplayableBuffCategory>(g.Key, ModdingParser.GetLanguage());
					sessionEndBuffGainCategoria.items = (from buff in g
						where ((IFloatValuableBuff)buff).ValueIsDisplayable()
						orderby Mathf.Abs(((IFloatValuableBuff)buff).ValuePriorty()) descending
						select new LabelData2(((IIdentifiableBuff)buff).stringId, buff.RichPrintStandAlone(delegate(string id)
						{
							string text;
							string text2;
							string text3;
							MemoriaDeNpc.GetNombres(GlobalSingletonV2<MemoriaJson>.instance, id, out text, out text2, out text3);
							return text3;
						}, ModdingParser.GetLanguage()), string.Empty, new Color?(((IFloatValuableBuff)buff).ValuePriorty().DesPolarize().GetColorParaFondoNegro()))).ToList<LabelData2>();
					return sessionEndBuffGainCategoria;
				}).ToList<SessionEndBuffGainCategoria>();
				modelo.buff.nonPlayer.buffGains = modelo.buff.nonPlayer.buffGains.Where((SessionEndBuffGainCategoria s) => s.items.Count > 0).ToList<SessionEndBuffGainCategoria>();
			}
			else
			{
				modelo.buff.nonPlayer.title = "---";
				modelo.buff.nonPlayer.buffGains = new List<SessionEndBuffGainCategoria>();
			}
			if (BuffAndDebuffOnFrom != null)
			{
				IEnumerable<IGrouping<DisplayableBuffCategory, IPrintableBuff>> enumerable2 = from printable in BuffAndDebuffOnFrom.GetAllPrintables()
					group printable by printable.category;
				modelo.buff.player.title = BuffAndDebuffOnFrom.character.fullName;
				modelo.buff.player.buffGains = enumerable2.Select(delegate(IGrouping<DisplayableBuffCategory, IPrintableBuff> g)
				{
					SessionEndBuffGainCategoria sessionEndBuffGainCategoria2 = new SessionEndBuffGainCategoria();
					sessionEndBuffGainCategoria2.title = TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<DisplayableBuffCategory>(g.Key, ModdingParser.GetLanguage());
					sessionEndBuffGainCategoria2.items = (from buff in g
						where ((IFloatValuableBuff)buff).ValueIsDisplayable()
						orderby Mathf.Abs(((IFloatValuableBuff)buff).ValuePriorty()) descending
						select new LabelData2(((IIdentifiableBuff)buff).stringId, buff.RichPrintStandAlone(delegate(string id)
						{
							string text4;
							string text5;
							string text6;
							MemoriaDeNpc.GetNombres(GlobalSingletonV2<MemoriaJson>.instance, id, out text4, out text5, out text6);
							return text6;
						}, ModdingParser.GetLanguage()), string.Empty, new Color?(((IFloatValuableBuff)buff).ValuePriorty().DesPolarize().GetColorParaFondoNegro()))).ToList<LabelData2>();
					return sessionEndBuffGainCategoria2;
				}).ToList<SessionEndBuffGainCategoria>();
				modelo.buff.nonPlayer.buffGains = modelo.buff.nonPlayer.buffGains.Where((SessionEndBuffGainCategoria s) => s.items.Count > 0).ToList<SessionEndBuffGainCategoria>();
				return;
			}
			modelo.buff.player.title = "---";
			modelo.buff.player.buffGains = new List<SessionEndBuffGainCategoria>();
		}
	}
}
