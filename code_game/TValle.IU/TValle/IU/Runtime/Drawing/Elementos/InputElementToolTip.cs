using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x0200011F RID: 287
	public class InputElementToolTip : UIElemento, IUIElementoConValor, IUIElementoConValorMutable, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura, IUIElementoConLabel, IUIElementoConDescripcionSimple
	{
		// Token: 0x1700026A RID: 618
		// (get) Token: 0x0600089B RID: 2203 RVA: 0x0001D91A File Offset: 0x0001BB1A
		// (set) Token: 0x0600089C RID: 2204 RVA: 0x0001D927 File Offset: 0x0001BB27
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

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x0600089D RID: 2205 RVA: 0x0001D935 File Offset: 0x0001BB35
		// (set) Token: 0x0600089E RID: 2206 RVA: 0x0001D942 File Offset: 0x0001BB42
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

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x0001D950 File Offset: 0x0001BB50
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x060008A0 RID: 2208 RVA: 0x0001D958 File Offset: 0x0001BB58
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x0001D960 File Offset: 0x0001BB60
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.label == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
			if (this.tooltip == null)
			{
				throw new ArgumentNullException("tooltip", "tooltip null reference.");
			}
			if (this.inputField == null)
			{
				throw new ArgumentNullException("inputField", "inputField null reference.");
			}
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x0001D9CD File Offset: 0x0001BBCD
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.inputField.onEndEdit.AddListener(new UnityAction<string>(this.OnEndEdit));
			}
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x0001D9FC File Offset: 0x0001BBFC
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.inputField.onEndEdit.AddListener(new UnityAction<string>(this.OnEndEdit));
				this.SetValor(initialValue, true);
			}
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x0001DA34 File Offset: 0x0001BC34
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.inputField != null)
			{
				this.inputField.onEndEdit.RemoveListener(new UnityAction<string>(this.OnEndEdit));
			}
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x0001DA67 File Offset: 0x0001BC67
		public object GetValor()
		{
			return this.inputField.text;
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x0001DA74 File Offset: 0x0001BC74
		public void SetValor(object valor, bool silenced)
		{
			if (silenced)
			{
				this.inputField.onEndEdit.RemoveListener(new UnityAction<string>(this.OnEndEdit));
			}
			try
			{
				IMultipleValorElemento<string, string> multipleValorElemento = valor as IMultipleValorElemento<string, string>;
				if (multipleValorElemento != null)
				{
					this.inputField.text = multipleValorElemento.item2;
					this.label.text = multipleValorElemento.item1;
					IMultipleValorElemento<string, string, string> multipleValorElemento2 = valor as IMultipleValorElemento<string, string, string>;
					if (multipleValorElemento2 != null)
					{
						((IUIElementoConDescripcionSimple)this).descripcion = multipleValorElemento2.item3;
					}
				}
				else
				{
					string text = Convert.ToString(valor);
					this.inputField.text = text;
				}
			}
			finally
			{
				if (silenced)
				{
					this.inputField.onEndEdit.AddListener(new UnityAction<string>(this.OnEndEdit));
				}
			}
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x0001DB2C File Offset: 0x0001BD2C
		private void OnEndEdit(string value)
		{
			OnValueChanged onValueChanged = this.m_onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.Invoke(this);
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x0001DB52 File Offset: 0x0001BD52
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x0001DB5A File Offset: 0x0001BD5A
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400036E RID: 878
		public TextMeshProUGUI label;

		// Token: 0x0400036F RID: 879
		public TMP_InputField inputField;

		// Token: 0x04000370 RID: 880
		public SimpleTooltip tooltip;

		// Token: 0x04000371 RID: 881
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();
	}
}
