using System;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff.Mapas;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.UI;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000CB RID: 203
	[Serializable]
	public class DisplayableBuff : BuffEvento, IDisplayableBuffCategorable, IDisplayableCustomToolTip
	{
		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x00017774 File Offset: 0x00015974
		public DisplayableBuffCategory displayableBuffType
		{
			get
			{
				IDisplayableArgCategorable displayableArgCategorable = this.efectoArgumento as IDisplayableArgCategorable;
				return ((displayableArgCategorable != null) ? new DisplayableBuffCategory?(displayableArgCategorable.displayableBuffType) : null).GetValueOrDefault();
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x000177B0 File Offset: 0x000159B0
		string IDisplayableCustomToolTip.tooltip
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(this.customLocalizedTooltip))
				{
					return this.customLocalizedTooltip;
				}
				DisplayableBuffMap displayableBuffMap = this.m_buff as DisplayableBuffMap;
				if (displayableBuffMap == null)
				{
					return null;
				}
				Nombrable.Class tooltipLocalizada = displayableBuffMap.tooltipLocalizada;
				if (tooltipLocalizada == null)
				{
					return null;
				}
				Nombrable.Item item = tooltipLocalizada.ObtenerDeCurrentLocalization();
				if (item == null)
				{
					return null;
				}
				return item.original;
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00017800 File Offset: 0x00015A00
		public string LocalizedText()
		{
			if (!string.IsNullOrWhiteSpace(this.localizedText))
			{
				IDisplayableArgumentoDeEfecto displayableArgumentoDeEfecto = this.efectoArgumento as IDisplayableArgumentoDeEfecto;
				if (!((displayableArgumentoDeEfecto != null) ? new bool?(displayableArgumentoDeEfecto.flagUpdateNonLocalizedTextV2) : null).GetValueOrDefault())
				{
					IDisplayableArgumentoDeEfecto displayableArgumentoDeEfecto2 = this.efectoArgumento as IDisplayableArgumentoDeEfecto;
					if (!((displayableArgumentoDeEfecto2 != null) ? new bool?(displayableArgumentoDeEfecto2.AlwaysUpdateNonLocalizedText) : null).GetValueOrDefault())
					{
						goto IL_0075;
					}
				}
			}
			this.localizedText = this.GenerateLocalizedText();
			IL_0075:
			return this.localizedText;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00017888 File Offset: 0x00015A88
		public void ForceUpdateLocalizedText()
		{
			this.localizedText = null;
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00017894 File Offset: 0x00015A94
		protected virtual string GenerateLocalizedText()
		{
			if (this.m_buff == null)
			{
				throw new ArgumentNullException("m_buff", "m_buff null reference.");
			}
			DisplayableBuffMap displayableBuffMap = this.m_buff as DisplayableBuffMap;
			Nombrable.Class @class = ((displayableBuffMap != null) ? displayableBuffMap.nombreLocalizado : null);
			Nombrable.Class class2 = ((displayableBuffMap != null) ? displayableBuffMap.postNombreLocalizado : null);
			if (!string.IsNullOrEmpty(this.nombresPorID))
			{
				DisplayableBuffMap.NombresPorID nombresPorID = ((displayableBuffMap != null) ? displayableBuffMap.nombresPorID.FirstOrDefault((DisplayableBuffMap.NombresPorID it) => it.id == this.nombresPorID) : null);
				if (nombresPorID != null)
				{
					@class = nombresPorID.nombreLocalizado;
					class2 = nombresPorID.postNombreLocalizado;
				}
			}
			Component owner = base.owner;
			string text;
			if (owner == null)
			{
				text = null;
			}
			else
			{
				ICharacter componentEnRoot = owner.GetComponentEnRoot(false);
				text = ((componentEnRoot != null) ? componentEnRoot.nombreCompleto : null);
			}
			string text2 = text;
			string text3 = ((text2 == null) ? string.Empty : (text2 + "\n"));
			Nombrable.Item item = @class.ObtenerDeCurrentLocalization();
			string text4 = ((item != null) ? item.original : null);
			IDisplayableArgumentoDeEfecto displayableArgumentoDeEfecto = this.efectoArgumento as IDisplayableArgumentoDeEfecto;
			string text5 = ((displayableArgumentoDeEfecto != null) ? displayableArgumentoDeEfecto.NonLocalizedText(this) : null);
			Nombrable.Item item2 = class2.ObtenerDeCurrentLocalization();
			string text6 = ((item2 != null) ? item2.original : null);
			return string.Concat(new string[]
			{
				text3,
				text4 ?? string.Empty,
				(text5 != null) ? "\n\n" : string.Empty,
				text5 ?? string.Empty,
				(text6 != null) ? " " : string.Empty,
				text6 ?? string.Empty
			});
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x000179FE File Offset: 0x00015BFE
		protected override void NoVolatilStared()
		{
			base.NoVolatilStared();
			if (this.showSmallMsgOnApplied)
			{
				this.ShowBuffAppliedMsg();
			}
			if (this.showSmallMsgOnStart && !base.wasStarted)
			{
				this.ShowBuffStaredMsg();
			}
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00017A2C File Offset: 0x00015C2C
		public void ShowBuffStaredMsg()
		{
			Singleton<MainCanvas>.instance.MostrartMsg("Buff Added", this.LocalizedText(), this.msgDuration, true, null, new float?((float)16), null);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00017A68 File Offset: 0x00015C68
		public void ShowBuffAppliedMsg()
		{
			Singleton<MainCanvas>.instance.MostrartMsg("Buff Applied", this.LocalizedText(), this.msgDuration, true, null, new float?((float)16), null);
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00017AA4 File Offset: 0x00015CA4
		protected override void NoVolatilEnded()
		{
			base.NoVolatilEnded();
			if (base.wasEnded)
			{
				return;
			}
			if (this.showSmallMsgOnEnd)
			{
				Singleton<MainCanvas>.instance.MostrartMsg("Buff Removed", this.LocalizedText(), 5f, true, null, new float?((float)16), null);
			}
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00017AF8 File Offset: 0x00015CF8
		protected override void GuardarEventoAMemoria(IJsonMemoryNode eventoMem)
		{
			base.GuardarEventoAMemoria(eventoMem);
			eventoMem.AddData("showSmallMsgOnStart", this.showSmallMsgOnStart, true);
			eventoMem.AddData("showSmallMsgOnEnd", this.showSmallMsgOnEnd, true);
			eventoMem.AddData("showSmallMsgOnApplied", this.showSmallMsgOnApplied, true);
			eventoMem.AddData("msgDuration", this.msgDuration, true);
			eventoMem.AddData("localizedText", this.localizedText, true);
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00017B68 File Offset: 0x00015D68
		protected override void CargarEventoDesdeMemoria(IJsonMemoryNode eventoMem, string eventoID)
		{
			base.CargarEventoDesdeMemoria(eventoMem, eventoID);
			this.showSmallMsgOnStart = eventoMem.FindDataBool("showSmallMsgOnStart", false);
			this.showSmallMsgOnEnd = eventoMem.FindDataBool("showSmallMsgOnEnd", false);
			this.showSmallMsgOnApplied = eventoMem.FindDataBool("showSmallMsgOnApplied", false);
			this.msgDuration = eventoMem.FindDataFloat("msgDuration", 5f);
			this.localizedText = eventoMem.FindData("localizedText");
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00017BDC File Offset: 0x00015DDC
		public void UpdateQualityAndVisibility(float min, float med, float max, float value, float outPower, bool notInverted)
		{
			float num;
			base.UpdateQuality(min, med, max, value, outPower, notInverted, out num);
			if (MathfExtension.AlmostEqual(med, 1f, 0.001f))
			{
				this.hideFromUI = value > 0.99f && value < 1.01f;
				return;
			}
			if (MathfExtension.AlmostEqual(med, 0f, 0.001f))
			{
				this.hideFromUI = value > -0.01f && value < 0.01f;
				return;
			}
			this.hideFromUI = (double)Mathf.Abs(num - 0.5f) < 0.000567;
		}

		// Token: 0x0400038C RID: 908
		public bool showSmallMsgOnStart;

		// Token: 0x0400038D RID: 909
		public bool showSmallMsgOnApplied;

		// Token: 0x0400038E RID: 910
		public float msgDuration = 5f;

		// Token: 0x0400038F RID: 911
		public bool showSmallMsgOnEnd;

		// Token: 0x04000390 RID: 912
		[TextArea(4, 6)]
		public string localizedText;

		// Token: 0x04000391 RID: 913
		public string customLocalizedTooltip;

		// Token: 0x04000392 RID: 914
		public bool hideFromUI;

		// Token: 0x04000393 RID: 915
		public string nombresPorID;
	}
}
