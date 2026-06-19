using System;
using System.Collections;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Drawing.Elementos
{
	// Token: 0x02000094 RID: 148
	public class ScrollablePanelConBuscadorYFavoritos : ScrollablePanel, IUIPanelConEventos, IUIPanel, IUIElemento, IUIPanelConExtraData
	{
		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x00013E10 File Offset: 0x00012010
		public UIPanelEvent onEvent
		{
			get
			{
				return this.m_onEvent;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x00013E18 File Offset: 0x00012018
		public IReadOnlyDictionary<string, Func<object>> extradata
		{
			get
			{
				return this.m_extradata;
			}
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00013E20 File Offset: 0x00012020
		public void SetExtraData(Dictionary<string, Func<object>> Extradata)
		{
			this.m_extradata = Extradata;
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00013E2C File Offset: 0x0001202C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.buscadorInput == null)
			{
				throw new ArgumentNullException("buscadorInput", "buscadorInput null reference.");
			}
			if (this.soloFavoritosToggle == null)
			{
				throw new ArgumentNullException("soloFavoritosToggle", "soloFavoritosToggle null reference.");
			}
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x00013E7C File Offset: 0x0001207C
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			Func<object> func;
			if (this.m_extradata.TryGetValue("SOLO_FAVORITOS", out func))
			{
				this.soloFavoritosToggle.isOn = Convert.ToBoolean((func != null) ? func() : null);
			}
			Func<object> func2;
			if (this.m_extradata.TryGetValue("BUSCANDO", out func2))
			{
				this.buscadorInput.text = Convert.ToString((func2 != null) ? func2() : null);
			}
			this.buscadorInput.onValueChanged.AddListener(new UnityAction<string>(this.OnBuscadorChanged));
			this.soloFavoritosToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnSoloFavoritosChanged));
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00013F2A File Offset: 0x0001212A
		private void OnBuscadorChanged(string value)
		{
			UIPanelEvent onEvent = this.m_onEvent;
			if (onEvent == null)
			{
				return;
			}
			onEvent.Invoke("BUSCANDO", value, this);
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00013F43 File Offset: 0x00012143
		private void OnSoloFavoritosChanged(bool value)
		{
			UIPanelEvent onEvent = this.m_onEvent;
			if (onEvent == null)
			{
				return;
			}
			onEvent.Invoke("SOLO_FAVORITOS", value, this);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00013F64 File Offset: 0x00012164
		public override void AddElementos(IEnumerable<KeyValuePair<string, IUIElemento>> pares)
		{
			base.AddElementos(pares);
			foreach (KeyValuePair<string, IUIElemento> keyValuePair in pares)
			{
				SelectablePortraitBase selectablePortraitBase = keyValuePair.Value as SelectablePortraitBase;
				if (!(selectablePortraitBase == null))
				{
					this.m_toLoadPortraits.Enqueue(selectablePortraitBase);
				}
			}
			base.StartCoroutine(this.RoutineLoadImages());
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00013FDC File Offset: 0x000121DC
		private IEnumerator RoutineLoadImages()
		{
			yield return null;
			while (this.m_toLoadPortraits.Count > 0)
			{
				this.m_toLoadPortraits.Dequeue().DoLoad();
				yield return null;
			}
			yield break;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00014014 File Offset: 0x00012214
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0001401C File Offset: 0x0001221C
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040001D5 RID: 469
		public const string buscandoKey = "BUSCANDO";

		// Token: 0x040001D6 RID: 470
		public const string soloFavoritosKey = "SOLO_FAVORITOS";

		// Token: 0x040001D7 RID: 471
		public TMP_InputField buscadorInput;

		// Token: 0x040001D8 RID: 472
		public Toggle soloFavoritosToggle;

		// Token: 0x040001D9 RID: 473
		private Dictionary<string, Func<object>> m_extradata = new Dictionary<string, Func<object>>();

		// Token: 0x040001DA RID: 474
		private Queue<SelectablePortraitBase> m_toLoadPortraits = new Queue<SelectablePortraitBase>();

		// Token: 0x040001DB RID: 475
		private UIPanelEvent m_onEvent = new UIPanelEvent();
	}
}
