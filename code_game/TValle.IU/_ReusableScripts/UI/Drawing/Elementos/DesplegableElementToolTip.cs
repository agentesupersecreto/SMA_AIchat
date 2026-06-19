using System;
using System.Collections;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.UI.Drawing.Elementos
{
	// Token: 0x02000090 RID: 144
	public class DesplegableElementToolTip : UIElemento, IUIElementoActivable, IUIElemento, IUIElementoRefreshable, IUIElementoConDescripcionSimple, IUIElementoConValor, IUIElementoConValorMutable, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura, IUIElementoConLabel, IUIElementoConExtraData, IUIElementoConInvertLinkedElements
	{
		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600047D RID: 1149 RVA: 0x00012950 File Offset: 0x00010B50
		public bool isActivated
		{
			get
			{
				TMP_Dropdown tmp_Dropdown = this.dropdown;
				return ((tmp_Dropdown != null) ? new bool?(tmp_Dropdown.interactable) : null).GetValueOrDefault();
			}
		}

		// Token: 0x17000161 RID: 353
		// (set) Token: 0x0600047E RID: 1150 RVA: 0x00012984 File Offset: 0x00010B84
		public bool activatedInitialState
		{
			set
			{
				if (base.isBinded)
				{
					throw new NotSupportedException();
				}
				if (this.dropdown != null)
				{
					this.dropdown.interactable = value;
				}
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x000129AE File Offset: 0x00010BAE
		// (set) Token: 0x06000480 RID: 1152 RVA: 0x000129B6 File Offset: 0x00010BB6
		public IReadOnlyList<Func<bool>> canBeActivatedDelegates { get; set; }

		// Token: 0x06000481 RID: 1153 RVA: 0x000129C0 File Offset: 0x00010BC0
		void IUIElementoRefreshable.Refresh()
		{
			if (this.canBeActivatedDelegates != null && this.canBeActivatedDelegates.Count > 0)
			{
				bool flag = true;
				for (int i = 0; i < this.canBeActivatedDelegates.Count; i++)
				{
					Func<bool> func = this.canBeActivatedDelegates[i];
					bool? flag2 = ((func != null) ? new bool?(func()) : null);
					if (flag2 != null)
					{
						flag = flag2.Value && flag;
					}
				}
				if (this.dropdown != null)
				{
					this.dropdown.interactable = flag;
				}
			}
			this.RefresItems();
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x00012A54 File Offset: 0x00010C54
		// (set) Token: 0x06000483 RID: 1155 RVA: 0x00012A61 File Offset: 0x00010C61
		string IUIElementoConDescripcionSimple.descripcion
		{
			get
			{
				return this.tooltip.infoLeft;
			}
			set
			{
				this.tooltip.infoLeft = value;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x00012A6F File Offset: 0x00010C6F
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x00012A7C File Offset: 0x00010C7C
		float IUIElementoConDescripcionSimple.widthMod
		{
			get
			{
				return this.tooltip.widthMod;
			}
			set
			{
				this.tooltip.widthMod = value;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x00012A8A File Offset: 0x00010C8A
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x00012A92 File Offset: 0x00010C92
		// (set) Token: 0x06000488 RID: 1160 RVA: 0x00012A9A File Offset: 0x00010C9A
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

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x00012AA8 File Offset: 0x00010CA8
		// (set) Token: 0x0600048A RID: 1162 RVA: 0x00012AB0 File Offset: 0x00010CB0
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

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x00012ABE File Offset: 0x00010CBE
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00012AC8 File Offset: 0x00010CC8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.label == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
			if (this.dropdown == null)
			{
				throw new ArgumentNullException("dropdown", "dropdown null reference.");
			}
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00012B17 File Offset: 0x00010D17
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			this.RefresItems();
			if (base.isBinded)
			{
				this.dropdown.onValueChanged.AddListener(new UnityAction<int>(this.OnDropValueChanged));
			}
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x00012B4C File Offset: 0x00010D4C
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

		// Token: 0x0600048F RID: 1167 RVA: 0x00012B8C File Offset: 0x00010D8C
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
					TextoLocalizadoAttribute attributeOfEnumValue = DibujadorDynamico.GetAttributeOfEnumValue<TextoLocalizadoAttribute>((Enum)obj, out text);
					if (attributeOfEnumValue != null)
					{
						list.Add(attributeOfEnumValue.text.FirstLetterToUpperCaseOthersToLower());
					}
					else
					{
						list.Add(text);
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

		// Token: 0x06000490 RID: 1168 RVA: 0x00012DC4 File Offset: 0x00010FC4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.dropdown != null)
			{
				this.dropdown.onValueChanged.RemoveListener(new UnityAction<int>(this.OnDropValueChanged));
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00012DF8 File Offset: 0x00010FF8
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

		// Token: 0x06000492 RID: 1170 RVA: 0x00012EC8 File Offset: 0x000110C8
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

		// Token: 0x06000493 RID: 1171 RVA: 0x00013064 File Offset: 0x00011264
		private void OnDropValueChanged(int value)
		{
			OnValueChanged onValueChanged = this.m_onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.Invoke(this);
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0001308A File Offset: 0x0001128A
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00013092 File Offset: 0x00011292
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400017B RID: 379
		public TextMeshProUGUI label;

		// Token: 0x0400017C RID: 380
		public TMP_Dropdown dropdown;

		// Token: 0x0400017D RID: 381
		public SimpleTooltip tooltip;

		// Token: 0x0400017E RID: 382
		private List<IUIElemento> m_InvertLinked;

		// Token: 0x0400017F RID: 383
		private List<Func<object>> m_extradata;

		// Token: 0x04000180 RID: 384
		private IList m_Items;

		// Token: 0x04000181 RID: 385
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();
	}
}
