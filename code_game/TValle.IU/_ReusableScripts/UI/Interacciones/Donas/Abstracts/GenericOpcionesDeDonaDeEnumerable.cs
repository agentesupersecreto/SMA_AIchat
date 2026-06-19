using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.UI.Interacciones.Donas.Abstracts
{
	// Token: 0x0200002A RID: 42
	[Obsolete("usar la version para THS")]
	public class GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked> : GenericOpcionesDeDonaDeColleccion where TEnum : struct where TCurrentCliked : OpcionesDeDonaCurrentClicked<TEnum>, new()
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00005558 File Offset: 0x00003758
		public static IReadOnlyList<TEnum> valores
		{
			get
			{
				return GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.m_Valores;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000116 RID: 278 RVA: 0x0000555F File Offset: 0x0000375F
		public static IReadOnlyList<int> intValores
		{
			get
			{
				return GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.m_IntValores;
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00005568 File Offset: 0x00003768
		static GenericOpcionesDeDonaDeEnumerable()
		{
			if (!typeof(TEnum).IsEnum)
			{
				throw new InvalidOperationException(typeof(TEnum).Name + " no es Enum");
			}
			GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.m_IntValores = new List<int>();
			GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.m_Valores = new List<TEnum>();
			GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.m_Nombres = new List<string>();
			foreach (object obj in typeof(TEnum).GetEnumValoresObject())
			{
				TEnum tenum = (TEnum)((object)obj);
				GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.m_Valores.Add(tenum);
			}
			foreach (int num in typeof(TEnum).GetEnumValoresInt())
			{
				GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.m_IntValores.Add(num);
			}
			foreach (string text in typeof(TEnum).GetEnumValoresNombres())
			{
				GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.m_Nombres.Add(text);
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000118 RID: 280 RVA: 0x000056B8 File Offset: 0x000038B8
		public TCurrentCliked currentClicked
		{
			get
			{
				return this.m_CurrentClicked;
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000056C0 File Offset: 0x000038C0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.onOpccionClicked += this.OnOpccionCliked;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000056DB File Offset: 0x000038DB
		protected override void OnDonaStateChanged(bool drawing, DonaDeInteraccionBase sender)
		{
			base.OnDonaStateChanged(drawing, sender);
			if (!drawing)
			{
				return;
			}
			if (Application.isEditor)
			{
				this.m_debugCurrentClicked = new TCurrentCliked();
			}
			this.m_CurrentClicked = default(TCurrentCliked);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00005708 File Offset: 0x00003908
		protected virtual void OnOpccionCliked(int index, TEnum enumerable, IUIElementoConValor button, DonaDeInteraccionBase dona)
		{
			IUIElementoConLabel iuielementoConLabel = button as IUIElementoConLabel;
			TCurrentCliked tcurrentCliked = new TCurrentCliked();
			tcurrentCliked.enumerable = enumerable;
			tcurrentCliked.index = index;
			tcurrentCliked.text = ((iuielementoConLabel != null) ? iuielementoConLabel.label.text : string.Empty);
			TCurrentCliked tcurrentCliked2 = tcurrentCliked;
			this.m_CurrentClicked = tcurrentCliked2;
			if (Application.isEditor)
			{
				this.m_debugCurrentClicked = this.m_CurrentClicked;
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600011C RID: 284 RVA: 0x00005774 File Offset: 0x00003974
		// (remove) Token: 0x0600011D RID: 285 RVA: 0x000057AC File Offset: 0x000039AC
		public event GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.ClickEventHandler onOpccionClicked;

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600011E RID: 286 RVA: 0x000057E1 File Offset: 0x000039E1
		public override int count
		{
			get
			{
				return GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.m_Valores.Count;
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000057ED File Offset: 0x000039ED
		[Obsolete("", true)]
		public override string ModelDeIndex(int index)
		{
			return index.ToString();
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000057F6 File Offset: 0x000039F6
		[Obsolete("", true)]
		public override object DataModelDeIndex(int index)
		{
			return GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.m_Valores[index];
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00005808 File Offset: 0x00003A08
		public override string ObtenerModeloDeIndex(int index)
		{
			return GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.m_Nombres[index];
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00005815 File Offset: 0x00003A15
		public override Type ObtenerModeloInstanceTypeDeIndex(int index)
		{
			return typeof(TEnum);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00005821 File Offset: 0x00003A21
		public override bool DibujarIndex(int index)
		{
			return true;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00005824 File Offset: 0x00003A24
		public override bool IndexEsGreyOut(int index)
		{
			return false;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00005828 File Offset: 0x00003A28
		public override string TextDeIndex(int index)
		{
			TEnum tenum = GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.m_Valores[index];
			return tenum.ToString();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000584E File Offset: 0x00003A4E
		public override UnityAction OnClickDeIndex(int index)
		{
			return null;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00005851 File Offset: 0x00003A51
		public override UnityAction<IUIElementoConValor, DonaDeInteraccionBase> OnClickCompletoDeIndex(int index)
		{
			return new UnityAction<IUIElementoConValor, DonaDeInteraccionBase>(this.OnBotonClick);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00005860 File Offset: 0x00003A60
		private void OnBotonClick(IUIElementoConValor but, DonaDeInteraccionBase dona)
		{
			int num = -1;
			int.TryParse(but.modelName, out num);
			TEnum tenum = (TEnum)((object)but.GetValor());
			GenericOpcionesDeDonaDeEnumerable<TEnum, TCurrentCliked>.ClickEventHandler clickEventHandler = this.onOpccionClicked;
			if (clickEventHandler == null)
			{
				return;
			}
			clickEventHandler(num, tenum, but, dona);
		}

		// Token: 0x04000095 RID: 149
		private static List<int> m_IntValores;

		// Token: 0x04000096 RID: 150
		private static List<string> m_Nombres;

		// Token: 0x04000097 RID: 151
		private static List<TEnum> m_Valores;

		// Token: 0x04000098 RID: 152
		[ReadOnlyUI]
		[SerializeField]
		private TCurrentCliked m_debugCurrentClicked;

		// Token: 0x04000099 RID: 153
		[NonSerialized]
		private TCurrentCliked m_CurrentClicked;

		// Token: 0x02000169 RID: 361
		// (Invoke) Token: 0x06000A88 RID: 2696
		public delegate void ClickEventHandler(int index, TEnum enumerable, IUIElementoConValor button, DonaDeInteraccionBase dona);
	}
}
