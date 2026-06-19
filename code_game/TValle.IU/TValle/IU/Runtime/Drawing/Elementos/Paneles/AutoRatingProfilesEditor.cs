using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles
{
	// Token: 0x02000135 RID: 309
	public class AutoRatingProfilesEditor : UIElemento, IUIPanel, IUIElemento, IUIPanelConControles, IUIPanelConTitulo
	{
		// Token: 0x1400003E RID: 62
		// (add) Token: 0x06000907 RID: 2311 RVA: 0x0001E670 File Offset: 0x0001C870
		// (remove) Token: 0x06000908 RID: 2312 RVA: 0x0001E6A8 File Offset: 0x0001C8A8
		public event Action<int, AutoRatingProfilesEditor> onModeChanged;

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x06000909 RID: 2313 RVA: 0x0001E6E0 File Offset: 0x0001C8E0
		// (remove) Token: 0x0600090A RID: 2314 RVA: 0x0001E718 File Offset: 0x0001C918
		public event Action<string, AutoRatingProfilesEditor> onReset;

		// Token: 0x14000040 RID: 64
		// (add) Token: 0x0600090B RID: 2315 RVA: 0x0001E750 File Offset: 0x0001C950
		// (remove) Token: 0x0600090C RID: 2316 RVA: 0x0001E788 File Offset: 0x0001C988
		public event Action<string, AutoRatingProfilesEditor> onLoad;

		// Token: 0x14000041 RID: 65
		// (add) Token: 0x0600090D RID: 2317 RVA: 0x0001E7C0 File Offset: 0x0001C9C0
		// (remove) Token: 0x0600090E RID: 2318 RVA: 0x0001E7F8 File Offset: 0x0001C9F8
		public event Action<string, AutoRatingProfilesEditor> onSave;

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x0600090F RID: 2319 RVA: 0x0001E82D File Offset: 0x0001CA2D
		public Scrollbar scrollbar
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x0001E830 File Offset: 0x0001CA30
		public RawImage portrait
		{
			get
			{
				return this.m_portrait;
			}
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x0001E838 File Offset: 0x0001CA38
		// (set) Token: 0x06000912 RID: 2322 RVA: 0x0001E83B File Offset: 0x0001CA3B
		public int currentMode
		{
			get
			{
				return 0;
			}
			set
			{
				this.m_modeSelector.value = value;
			}
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x0001E849 File Offset: 0x0001CA49
		public void SetFileName(string n)
		{
			this.m_fileName.text = n;
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0001E858 File Offset: 0x0001CA58
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_panel = base.GetComponent<Image>();
			if (this.m_panelParaTitulos == null)
			{
				throw new ArgumentNullException("m_panelParaTitulos", "m_panelParaTitulos null reference.");
			}
			if (this.m_panelParaControles == null)
			{
				throw new ArgumentNullException("m_panelParaControles", "m_panelParaControles null reference.");
			}
			if (this.m_panelParaFields == null)
			{
				throw new ArgumentNullException("m_panelParaFields", "m_panelParaFields null reference.");
			}
			if (this.m_fileName == null)
			{
				throw new ArgumentNullException("m_fileName", "m_fileName null reference.");
			}
			if (this.m_save == null)
			{
				throw new ArgumentNullException("m_save", "m_save null reference.");
			}
			if (this.m_load == null)
			{
				throw new ArgumentNullException("m_load", "m_load null reference.");
			}
			if (this.m_reset == null)
			{
				throw new ArgumentNullException("m_reset", "m_reset null reference.");
			}
			if (this.m_portrait == null)
			{
				throw new ArgumentNullException("m_portrait", "m_portrait null reference.");
			}
			if (this.m_modeSelector == null)
			{
				throw new ArgumentNullException("m_modeSelector", "m_modeSelector null reference.");
			}
			this.m_modeSelector.onValueChanged.AddListener(new UnityAction<int>(this.OnModeChanged));
			this.m_save.onClick.AddListener(new UnityAction(this.OnSave));
			this.m_load.onClick.AddListener(new UnityAction(this.OnLoad));
			this.m_reset.onClick.AddListener(new UnityAction(this.OnReset));
			this.m_modeSelector.interactable = false;
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x0001EA01 File Offset: 0x0001CC01
		private void OnModeChanged(int valor)
		{
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0001EA03 File Offset: 0x0001CC03
		private void OnReset()
		{
			Action<string, AutoRatingProfilesEditor> action = this.onReset;
			if (action == null)
			{
				return;
			}
			action(this.m_fileName.text, this);
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x0001EA21 File Offset: 0x0001CC21
		private void OnLoad()
		{
			Action<string, AutoRatingProfilesEditor> action = this.onLoad;
			if (action == null)
			{
				return;
			}
			action(this.m_fileName.text, this);
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x0001EA3F File Offset: 0x0001CC3F
		private void OnSave()
		{
			Action<string, AutoRatingProfilesEditor> action = this.onSave;
			if (action == null)
			{
				return;
			}
			action(this.m_fileName.text, this);
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000919 RID: 2329 RVA: 0x0001EA5D File Offset: 0x0001CC5D
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				return this.m_elementos;
			}
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x0600091A RID: 2330 RVA: 0x0001EA65 File Offset: 0x0001CC65
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x0600091B RID: 2331 RVA: 0x0001EA6D File Offset: 0x0001CC6D
		public Transform padreParaTitulos
		{
			get
			{
				return this.m_panelParaTitulos;
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x0600091C RID: 2332 RVA: 0x0001EA75 File Offset: 0x0001CC75
		public Transform padreParaControles
		{
			get
			{
				return this.m_panelParaControles;
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x0001EA7D File Offset: 0x0001CC7D
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x0001EA80 File Offset: 0x0001CC80
		public void AddElementos(IEnumerable<KeyValuePair<string, IUIElemento>> pares)
		{
			if (base.isBinded)
			{
				throw new NotSupportedException();
			}
			foreach (KeyValuePair<string, IUIElemento> keyValuePair in pares)
			{
				if (this.elementoPorModelo.ContainsKey(keyValuePair.Key))
				{
					Debug.LogError("Panel: " + base.name + ", ya contiene elemento: " + keyValuePair.Key, this);
				}
				else
				{
					this.m_elementos.Add(keyValuePair.Key, keyValuePair.Value);
				}
			}
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x0001EB20 File Offset: 0x0001CD20
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x0001EB74 File Offset: 0x0001CD74
		public Transform GetParentPara(int index)
		{
			if (index == 0)
			{
				return this.m_panelParaFields;
			}
			throw new ArgumentOutOfRangeException(index.ToString());
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x0001EB8C File Offset: 0x0001CD8C
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0001EBA6 File Offset: 0x0001CDA6
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x0001EBAE File Offset: 0x0001CDAE
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000394 RID: 916
		[SerializeField]
		private Transform m_panelParaTitulos;

		// Token: 0x04000395 RID: 917
		[SerializeField]
		private Transform m_panelParaControles;

		// Token: 0x04000396 RID: 918
		[SerializeField]
		private Transform m_panelParaFields;

		// Token: 0x04000397 RID: 919
		[SerializeField]
		private TMP_InputField m_fileName;

		// Token: 0x04000398 RID: 920
		[SerializeField]
		private Button m_save;

		// Token: 0x04000399 RID: 921
		[SerializeField]
		private Button m_load;

		// Token: 0x0400039A RID: 922
		[SerializeField]
		private Button m_reset;

		// Token: 0x0400039B RID: 923
		[SerializeField]
		private RawImage m_portrait;

		// Token: 0x0400039C RID: 924
		[SerializeField]
		private TMP_Dropdown m_modeSelector;

		// Token: 0x040003A1 RID: 929
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();

		// Token: 0x040003A2 RID: 930
		private Image m_panel;
	}
}
