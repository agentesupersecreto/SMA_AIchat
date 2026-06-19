using System;
using System.Collections;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Drawing.Elementos
{
	// Token: 0x0200008F RID: 143
	public class DesplegableElementHelpButton : UIElemento, IUIElementoConValor, IUIElementoConValorMutable, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura, IUIElementoConLabel, IUIBoton, IUIElementoConExtraData, IUIElementoRefreshable, IUIElementoConInvertLinkedElements
	{
		// Token: 0x06000468 RID: 1128 RVA: 0x0001228A File Offset: 0x0001048A
		void IUIElementoRefreshable.Refresh()
		{
			this.RefresItems();
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x00012292 File Offset: 0x00010492
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x0001229A File Offset: 0x0001049A
		// (set) Token: 0x0600046B RID: 1131 RVA: 0x000122A2 File Offset: 0x000104A2
		public IReadOnlyList<Func<object>> extradata
		{
			get
			{
				return this.m_extradata;
			}
			set
			{
				this.m_extradata = (List<Func<object>>)value;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x000122B0 File Offset: 0x000104B0
		// (set) Token: 0x0600046D RID: 1133 RVA: 0x000122B8 File Offset: 0x000104B8
		public IReadOnlyList<IUIElemento> InvertLinked
		{
			get
			{
				return this.m_InvertLinked;
			}
			set
			{
				this.m_InvertLinked = (List<IUIElemento>)value;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x000122C6 File Offset: 0x000104C6
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x0600046F RID: 1135 RVA: 0x000122CE File Offset: 0x000104CE
		OnClickedEvent IUIBoton.onClicked
		{
			get
			{
				return this.onClicked;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x000122D6 File Offset: 0x000104D6
		OnClickedBotonEvent IUIBoton.onClickedElement
		{
			get
			{
				return this.onClickedElement;
			}
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x000122E0 File Offset: 0x000104E0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.label == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
			if (this.boton == null)
			{
				throw new ArgumentNullException("boton", "boton null reference.");
			}
			if (this.dropdown == null)
			{
				throw new ArgumentNullException("dropdown", "dropdown null reference.");
			}
			this.boton.onClick.AddListener(new UnityAction(this.CallHelpClickEvents));
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00012369 File Offset: 0x00010569
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			this.RefresItems();
			if (base.isBinded)
			{
				this.dropdown.onValueChanged.AddListener(new UnityAction<int>(this.OnDropValueChanged));
			}
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0001239E File Offset: 0x0001059E
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			this.RefresItems();
			if (base.isBinded)
			{
				this.dropdown.onValueChanged.AddListener(new UnityAction<int>(this.OnDropValueChanged));
				this.SetValor(initialValue, true);
			}
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x000123DC File Offset: 0x000105DC
		protected void CallHelpClickEvents()
		{
			OnClickedEvent onClickedEvent = this.onClicked;
			if (onClickedEvent != null)
			{
				onClickedEvent.Invoke();
			}
			OnClickedBotonEvent onClickedBotonEvent = this.onClickedElement;
			if (onClickedBotonEvent == null)
			{
				return;
			}
			onClickedBotonEvent.Invoke(this);
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00012400 File Offset: 0x00010600
		public void RefresItems()
		{
			this.dropdown.onValueChanged.RemoveListener(new UnityAction<int>(this.OnDropValueChanged));
			int value = this.dropdown.value;
			this.dropdown.ClearOptions();
			if (base.modelType.IsEnum)
			{
				ICollection enumValoresObject = base.modelType.GetEnumValoresObject();
				List<string> list = new List<string>(enumValoresObject.Count);
				foreach (object obj in enumValoresObject)
				{
					string text;
					LabelAttribute attributeOfEnumValue = DibujadorDynamico.GetAttributeOfEnumValue<LabelAttribute>((Enum)obj, out text);
					if (attributeOfEnumValue == null)
					{
						list.Add(text);
					}
					else
					{
						list.Add(attributeOfEnumValue.text);
					}
				}
				this.dropdown.AddOptions(list);
			}
			else
			{
				if (this.m_extradata == null || this.m_extradata.Count <= 0)
				{
					Debug.LogError("No existe data para crear opciones en " + base.GetType().Name + " " + base.name, this);
					throw new NotSupportedException();
				}
				for (int i = 0; i < this.m_extradata.Count; i++)
				{
					Func<object> func = this.m_extradata[i];
					this.m_Items = ((func != null) ? func() : null) as IList;
					if (this.m_Items != null)
					{
						break;
					}
				}
				if (this.m_Items == null)
				{
					throw new NotSupportedException();
				}
				List<string> list2 = new List<string>(this.m_Items.Count);
				foreach (object obj2 in this.m_Items)
				{
					list2.Add(obj2.ToString());
				}
				this.dropdown.AddOptions(list2);
			}
			if (!this.dropdown.options.ContieneIndex(value))
			{
				this.dropdown.value = 0;
			}
			else
			{
				this.dropdown.value = value;
			}
			this.dropdown.onValueChanged.AddListener(new UnityAction<int>(this.OnDropValueChanged));
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00012630 File Offset: 0x00010830
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.dropdown != null)
			{
				this.dropdown.onValueChanged.RemoveListener(new UnityAction<int>(this.OnDropValueChanged));
			}
			if (this.boton != null)
			{
				this.boton.onClick.RemoveListener(new UnityAction(this.CallHelpClickEvents));
			}
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00012698 File Offset: 0x00010898
		public object GetValor()
		{
			if (!base.isBinded)
			{
				throw new InvalidOperationException();
			}
			int value = this.dropdown.value;
			if (base.modelType == typeof(int))
			{
				return value;
			}
			if (base.modelType.IsEnum)
			{
				return base.modelType.GetEnumValoresInt()[value];
			}
			if (this.m_Items == null)
			{
				Debug.LogError("No existe data obtener valor en opciones de " + base.GetType().Name + " " + base.name, this);
				throw new NotSupportedException();
			}
			if (!this.m_Items.ContieneIndexBase(value))
			{
				Debug.LogError("Items no con tiene index: " + value.ToString(), this);
				return null;
			}
			return this.m_Items[value];
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00012768 File Offset: 0x00010968
		public void SetValor(object valor, bool silenced)
		{
			if (!base.isBinded)
			{
				throw new InvalidOperationException();
			}
			if (silenced)
			{
				this.dropdown.onValueChanged.RemoveListener(new UnityAction<int>(this.OnDropValueChanged));
			}
			int num = 0;
			try
			{
				if (base.modelType.IsEnum)
				{
					IEnumerable enumValoresObject = base.modelType.GetEnumValoresObject();
					int num2 = -1;
					foreach (object obj in enumValoresObject)
					{
						object obj2 = (Enum)obj;
						num2++;
						if (obj2.Equals(valor))
						{
							num = num2;
							break;
						}
					}
					this.dropdown.value = num;
				}
				else
				{
					if (this.m_Items == null)
					{
						Debug.LogError("No existe data definir valor en opciones de " + base.GetType().Name + " " + base.name, this);
						throw new NotSupportedException();
					}
					int num3;
					if (base.modelType == typeof(int))
					{
						num3 = Convert.ToInt32(valor);
					}
					else
					{
						num3 = this.m_Items.IndexOf(valor);
					}
					if (num3 < 0)
					{
						Debug.LogError("No se encontro index para valor " + valor.ToString() + " se usara el primer index ", this);
						this.dropdown.value = 0;
					}
					else
					{
						this.dropdown.value = num3;
					}
				}
			}
			finally
			{
				if (silenced)
				{
					this.dropdown.onValueChanged.AddListener(new UnityAction<int>(this.OnDropValueChanged));
				}
			}
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00012904 File Offset: 0x00010B04
		private void OnDropValueChanged(int value)
		{
			OnValueChanged onValueChanged = this.m_onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.Invoke(this);
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00012940 File Offset: 0x00010B40
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00012948 File Offset: 0x00010B48
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000171 RID: 369
		public TextMeshProUGUI label;

		// Token: 0x04000172 RID: 370
		public Button boton;

		// Token: 0x04000173 RID: 371
		public TMP_Dropdown dropdown;

		// Token: 0x04000174 RID: 372
		private List<IUIElemento> m_InvertLinked;

		// Token: 0x04000175 RID: 373
		private List<Func<object>> m_extradata;

		// Token: 0x04000176 RID: 374
		private IList m_Items;

		// Token: 0x04000177 RID: 375
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();

		// Token: 0x04000178 RID: 376
		public OnClickedEvent onClicked = new OnClickedEvent();

		// Token: 0x04000179 RID: 377
		public OnClickedBotonEvent onClickedElement = new OnClickedBotonEvent();
	}
}
