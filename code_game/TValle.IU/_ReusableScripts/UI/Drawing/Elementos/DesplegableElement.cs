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
	// Token: 0x0200008E RID: 142
	public class DesplegableElement : UIElemento, IUIElementoConValor, IUIElementoConValorMutable, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura, IUIElementoConLabel, IUIElementoConDescripcion, IUIElementoConExtraData, IUIElementoRefreshable, IUIElementoConInvertLinkedElements
	{
		// Token: 0x06000455 RID: 1109 RVA: 0x00011C4E File Offset: 0x0000FE4E
		void IUIElementoRefreshable.Refresh()
		{
			this.RefresItems();
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x00011C56 File Offset: 0x0000FE56
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x00011C5E File Offset: 0x0000FE5E
		TextMeshProUGUI IUIElementoConDescripcion.descripcion
		{
			get
			{
				return this.descripcion;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x00011C66 File Offset: 0x0000FE66
		// (set) Token: 0x06000459 RID: 1113 RVA: 0x00011C6E File Offset: 0x0000FE6E
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

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x00011C7C File Offset: 0x0000FE7C
		// (set) Token: 0x0600045B RID: 1115 RVA: 0x00011C84 File Offset: 0x0000FE84
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

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x0600045C RID: 1116 RVA: 0x00011C92 File Offset: 0x0000FE92
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00011C9C File Offset: 0x0000FE9C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.label == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
			if (this.descripcion == null)
			{
				throw new ArgumentNullException("descripcion", "descripcion null reference.");
			}
			if (this.dropdown == null)
			{
				throw new ArgumentNullException("dropdown", "dropdown null reference.");
			}
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00011D09 File Offset: 0x0000FF09
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			this.RefresItems();
			if (base.isBinded)
			{
				this.dropdown.onValueChanged.AddListener(new UnityAction<int>(this.OnDropValueChanged));
			}
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00011D3E File Offset: 0x0000FF3E
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

		// Token: 0x06000460 RID: 1120 RVA: 0x00011D7C File Offset: 0x0000FF7C
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

		// Token: 0x06000461 RID: 1121 RVA: 0x00011FB4 File Offset: 0x000101B4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.dropdown != null)
			{
				this.dropdown.onValueChanged.RemoveListener(new UnityAction<int>(this.OnDropValueChanged));
			}
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00011FE8 File Offset: 0x000101E8
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

		// Token: 0x06000463 RID: 1123 RVA: 0x000120B8 File Offset: 0x000102B8
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

		// Token: 0x06000464 RID: 1124 RVA: 0x00012254 File Offset: 0x00010454
		private void OnDropValueChanged(int value)
		{
			OnValueChanged onValueChanged = this.m_onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.Invoke(this);
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0001227A File Offset: 0x0001047A
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00012282 File Offset: 0x00010482
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400016A RID: 362
		public TextMeshProUGUI label;

		// Token: 0x0400016B RID: 363
		public TextMeshProUGUI descripcion;

		// Token: 0x0400016C RID: 364
		public TMP_Dropdown dropdown;

		// Token: 0x0400016D RID: 365
		private List<IUIElemento> m_InvertLinked;

		// Token: 0x0400016E RID: 366
		private List<Func<object>> m_extradata;

		// Token: 0x0400016F RID: 367
		private IList m_Items;

		// Token: 0x04000170 RID: 368
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();
	}
}
