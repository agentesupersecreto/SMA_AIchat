using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.UI.Interacciones.Donas.Abstracts
{
	// Token: 0x0200002C RID: 44
	[Obsolete("usar la version para THS")]
	public abstract class GenericOpcionesDeDonaDeKeys<TKey, TCurrentCliked> : GenericOpcionesDeDonaDeColleccion where TKey : IEquatable<TKey> where TCurrentCliked : OpcionesDeDonaCurrentClickedKey<TKey>, new()
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600012C RID: 300 RVA: 0x000058D2 File Offset: 0x00003AD2
		public IReadOnlyList<TCurrentCliked> todosLosSelected
		{
			get
			{
				return this.m_todosLosSelected;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600012D RID: 301 RVA: 0x000058DA File Offset: 0x00003ADA
		public TCurrentCliked lastClicked
		{
			get
			{
				return this.m_lastClicked;
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000058E2 File Offset: 0x00003AE2
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.onOpccionClicked += this.OnOpccionCliked;
		}

		// Token: 0x0600012F RID: 303
		protected abstract void LoadKeys(HashSetList<TKey> resultado);

		// Token: 0x06000130 RID: 304 RVA: 0x000058FD File Offset: 0x00003AFD
		protected sealed override void LoadingItems(LoaderOpcionesDeDonaBase caller)
		{
			base.LoadingItems(caller);
			this.LoadKeys(this.m_dibujando);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00005914 File Offset: 0x00003B14
		protected override void OnDonaStateChanged(bool drawing, DonaDeInteraccionBase sender)
		{
			base.OnDonaStateChanged(drawing, sender);
			this.m_dibujando.Clear();
			if (!drawing)
			{
				return;
			}
			if (Application.isEditor)
			{
				this.m_debugLastClicked = new TCurrentCliked();
			}
			this.m_lastClicked = default(TCurrentCliked);
			this.m_todosLosSelected.Clear();
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00005964 File Offset: 0x00003B64
		protected virtual void OnOpccionCliked(int index, TKey Key, IUIElementoConValor button, DonaDeInteraccionBase dona)
		{
			IUIElementoConLabel iuielementoConLabel = button as IUIElementoConLabel;
			TCurrentCliked tcurrentCliked = new TCurrentCliked();
			tcurrentCliked.text = ((iuielementoConLabel != null) ? iuielementoConLabel.label.text : string.Empty);
			tcurrentCliked.key = Key;
			TCurrentCliked tcurrentCliked2 = tcurrentCliked;
			this.m_lastClicked = tcurrentCliked2;
			if (Application.isEditor)
			{
				this.m_debugLastClicked = this.m_lastClicked;
			}
			for (int i = this.m_todosLosSelected.Count - 1; i >= 0; i--)
			{
				if (this.m_todosLosSelected[i].key.Equals(Key))
				{
					this.m_todosLosSelected.RemoveAt(i);
				}
			}
			if (Convert.ToBoolean(button.GetValor()))
			{
				this.m_todosLosSelected.Add(tcurrentCliked2);
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000133 RID: 307 RVA: 0x00005A28 File Offset: 0x00003C28
		// (remove) Token: 0x06000134 RID: 308 RVA: 0x00005A60 File Offset: 0x00003C60
		public event GenericOpcionesDeDonaDeKeys<TKey, TCurrentCliked>.ClickEventHandler onOpccionClicked;

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00005A95 File Offset: 0x00003C95
		public override int count
		{
			get
			{
				return this.m_dibujando.Count;
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00005AA2 File Offset: 0x00003CA2
		[Obsolete("", true)]
		public override string ModelDeIndex(int index)
		{
			return GenericOpcionesDeDonaDeKeys<TKey, TCurrentCliked>.serializedKeyTypeName;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00005AA9 File Offset: 0x00003CA9
		[Obsolete("", true)]
		public override object DataModelDeIndex(int index)
		{
			return this.m_dibujando[index];
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00005ABC File Offset: 0x00003CBC
		public override string ObtenerModeloDeIndex(int index)
		{
			return JsonUtility.ToJson(new GenericOpcionesDeDonaDeKeys<TKey, TCurrentCliked>.IndexValorPar
			{
				index = index,
				key = this.m_dibujando[index]
			});
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00005AF7 File Offset: 0x00003CF7
		public override Type ObtenerModeloInstanceTypeDeIndex(int index)
		{
			return typeof(TKey);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00005B03 File Offset: 0x00003D03
		public override bool DibujarIndex(int index)
		{
			return true;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00005B06 File Offset: 0x00003D06
		public override bool IndexEsGreyOut(int index)
		{
			return false;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00005B09 File Offset: 0x00003D09
		public sealed override string TextDeIndex(int index)
		{
			return this.TextDeKey(this.m_dibujando[index]);
		}

		// Token: 0x0600013D RID: 317
		public abstract string TextDeKey(TKey key);

		// Token: 0x0600013E RID: 318 RVA: 0x00005B1D File Offset: 0x00003D1D
		public override UnityAction OnClickDeIndex(int index)
		{
			return null;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00005B20 File Offset: 0x00003D20
		public override UnityAction<IUIElementoConValor, DonaDeInteraccionBase> OnClickCompletoDeIndex(int index)
		{
			return new UnityAction<IUIElementoConValor, DonaDeInteraccionBase>(this.OnBotonClick);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00005B30 File Offset: 0x00003D30
		private void OnBotonClick(IUIElementoConValor but, DonaDeInteraccionBase dona)
		{
			GenericOpcionesDeDonaDeKeys<TKey, TCurrentCliked>.IndexValorPar indexValorPar = JsonUtility.FromJson<GenericOpcionesDeDonaDeKeys<TKey, TCurrentCliked>.IndexValorPar>(but.modelName);
			GenericOpcionesDeDonaDeKeys<TKey, TCurrentCliked>.ClickEventHandler clickEventHandler = this.onOpccionClicked;
			if (clickEventHandler == null)
			{
				return;
			}
			clickEventHandler(indexValorPar.index, indexValorPar.key, but, dona);
		}

		// Token: 0x0400009E RID: 158
		private static string serializedKeyTypeName = GenericOpcionesDeDonaDeKeys<TKey, TCurrentCliked>.serializedKeyType.ToString();

		// Token: 0x0400009F RID: 159
		private static SerializableType serializedKeyType = new SerializableType(typeof(TKey));

		// Token: 0x040000A0 RID: 160
		[ReadOnlyUI]
		[SerializeField]
		private TCurrentCliked m_debugLastClicked;

		// Token: 0x040000A1 RID: 161
		[ReadOnlyUI]
		[SerializeField]
		private List<TCurrentCliked> m_todosLosSelected = new List<TCurrentCliked>();

		// Token: 0x040000A2 RID: 162
		[NonSerialized]
		private TCurrentCliked m_lastClicked;

		// Token: 0x040000A3 RID: 163
		private HashSetList<TKey> m_dibujando = new HashSetList<TKey>();

		// Token: 0x0200016A RID: 362
		// (Invoke) Token: 0x06000A8C RID: 2700
		public delegate void ClickEventHandler(int index, TKey key, IUIElementoConValor button, DonaDeInteraccionBase dona);

		// Token: 0x0200016B RID: 363
		private struct IndexValorPar
		{
			// Token: 0x0400046B RID: 1131
			public int index;

			// Token: 0x0400046C RID: 1132
			public TKey key;
		}
	}
}
