using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.UI.Drawing.Elementos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine.Events;

namespace Assets._ReusableScripts.UI.Interacciones.Donas
{
	// Token: 0x02000025 RID: 37
	[Obsolete("usar la version para THS")]
	public class GenericOpcionDeDona : CustomUpdatedMonobehaviourBase, IOpcionesDeDonaProductor
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x00004BD0 File Offset: 0x00002DD0
		public IEnumerable<DonaDeInteraccionBase.Item> ObtenerItems(LoaderOpcionesDeDonaBase caller)
		{
			string text = this.defaultText;
			GenericOpcionDeDona.TextDeLocal textDeLocal = this.textos.FirstOrDefault((GenericOpcionDeDona.TextDeLocal t) => t.local == Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id);
			if (textDeLocal != null)
			{
				text = textDeLocal.text;
			}
			this.m_EsGreyOutEventArgs.esGreyOut = false;
			this.m_EsGreyOutEventArgs.greyedOutEsInvisible = false;
			OnCheckGreyOutEvent onCheckGreyOutEvent = this.onCheckGreyOutEvent;
			if (onCheckGreyOutEvent != null)
			{
				onCheckGreyOutEvent.Invoke(this.m_EsGreyOutEventArgs, this);
			}
			List<DonaDeInteraccionBase.Item> list = new List<DonaDeInteraccionBase.Item>();
			list.Add(new DonaDeInteraccionBase.Item
			{
				clickedCallback = new UnityAction(this.Clicked),
				clickedCallbackCompleto = new UnityAction<IUIElementoConValor, DonaDeInteraccionBase>(this.ClickedCompleto),
				grayOut = (this.forzeGreyOut || this.m_EsGreyOutEventArgs.esGreyOut),
				hidden = ((this.forzeGreyOut || this.m_EsGreyOutEventArgs.esGreyOut) && this.m_EsGreyOutEventArgs.greyedOutEsInvisible),
				text = text
			});
			this.m_EsGreyOutEventArgs.esGreyOut = false;
			return list;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00004CD7 File Offset: 0x00002ED7
		protected virtual void ClickedCompleto(IUIElementoConValor sender, DonaDeInteraccionBase dona)
		{
			OnClickOpcionDeDonaEvent onClickOpcionDeDonaEvent = this.onOpcionClickedCompleto;
			if (onClickOpcionDeDonaEvent != null)
			{
				onClickOpcionDeDonaEvent.Invoke(sender as BotonElementConValor, dona as DonaDeInteraccion);
			}
			if (this.clearOnClicked)
			{
				dona.StopDrawing();
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004D04 File Offset: 0x00002F04
		protected virtual void Clicked()
		{
			OnClickEvent onClickEvent = this.onOpcionClicked;
			if (onClickEvent == null)
			{
				return;
			}
			onClickEvent.Invoke();
		}

		// Token: 0x0400007D RID: 125
		public bool forzeGreyOut;

		// Token: 0x0400007E RID: 126
		public bool clearOnClicked;

		// Token: 0x0400007F RID: 127
		public string defaultText;

		// Token: 0x04000080 RID: 128
		[CoolArrayItem]
		public List<GenericOpcionDeDona.TextDeLocal> textos = new List<GenericOpcionDeDona.TextDeLocal>();

		// Token: 0x04000081 RID: 129
		public OnCheckGreyOutEvent onCheckGreyOutEvent = new OnCheckGreyOutEvent();

		// Token: 0x04000082 RID: 130
		public OnClickEvent onOpcionClicked = new OnClickEvent();

		// Token: 0x04000083 RID: 131
		public OnClickOpcionDeDonaEvent onOpcionClickedCompleto = new OnClickOpcionDeDonaEvent();

		// Token: 0x04000084 RID: 132
		[NonSerialized]
		private EsGreyOutEventArgs m_EsGreyOutEventArgs = new EsGreyOutEventArgs();

		// Token: 0x02000166 RID: 358
		[Serializable]
		public class TextDeLocal
		{
			// Token: 0x04000466 RID: 1126
			public Localizacion local;

			// Token: 0x04000467 RID: 1127
			public string text;
		}
	}
}
