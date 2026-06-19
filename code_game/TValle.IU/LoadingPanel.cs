using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using TMPro;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000005 RID: 5
	public class LoadingPanel : Singleton<LoadingPanel>
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000214A File Offset: 0x0000034A
		public ModificableDeBool hidingModificable
		{
			get
			{
				return this.m_hidingModificable;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002152 File Offset: 0x00000352
		public string defaultText
		{
			get
			{
				return this.m_defaultText;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000215A File Offset: 0x0000035A
		// (set) Token: 0x0600000C RID: 12 RVA: 0x00002162 File Offset: 0x00000362
		public string nextUserText
		{
			get
			{
				return this.m_nextUserText;
			}
			set
			{
				if (this.m_showing)
				{
					this.m_loadingTextField.text = value;
					this.m_nextUserText = string.Empty;
				}
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002184 File Offset: 0x00000384
		protected override void InitData(bool esEditorTime)
		{
			this.m_children = (from t in base.GetComponentsInChildren<Transform>(true)
				where t != base.transform
				select t.gameObject).ToList<GameObject>();
			this.m_children.ForEach(delegate(GameObject x)
			{
				x.SetActive(false);
			});
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002202 File Offset: 0x00000402
		protected override void Awaking()
		{
			base.Awaking();
			this.esGlobal = false;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002211 File Offset: 0x00000411
		protected override void DoAwake()
		{
			base.DoAwake();
			if (!Singleton<ConfiguracionGeneralDeInputs>.IsInScene)
			{
				Singleton<ConfiguracionGeneralDeInputs>.TryIniciar();
			}
			this.m_enabledInputs = Singleton<ConfiguracionGeneralDeInputs>.instance.activoOverallAND.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000223C File Offset: 0x0000043C
		protected override void OnDestroyingThisDuplicated()
		{
			base.OnDestroyingThisDuplicated();
			ModificadorDeBool enabledInputs = this.m_enabledInputs;
			if (enabledInputs == null)
			{
				return;
			}
			enabledInputs.TryRemoverDeOwner(true);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002258 File Offset: 0x00000458
		public void Update()
		{
			if (!this.initiated)
			{
				return;
			}
			bool flag = this.m_hidingModificable.And(true);
			if (!flag != this.m_showing)
			{
				this.m_showing = !flag;
				this.m_children.ForEach(delegate(GameObject x)
				{
					x.SetActive(this.m_showing);
				});
				if (this.m_showing)
				{
					if (!string.IsNullOrWhiteSpace(this.m_nextUserText))
					{
						this.m_loadingTextField.text = this.m_nextUserText;
						this.m_nextUserText = string.Empty;
					}
					else
					{
						this.m_loadingTextField.text = this.m_defaultText;
					}
				}
			}
			this.m_enabledInputs.valor.valor = !this.m_showing;
		}

		// Token: 0x04000005 RID: 5
		[SerializeField]
		[ReadOnlyUI]
		private bool m_showing;

		// Token: 0x04000006 RID: 6
		[SerializeField]
		private ModificableDeBool m_hidingModificable = new ModificableDeBool(true);

		// Token: 0x04000007 RID: 7
		private List<GameObject> m_children = new List<GameObject>();

		// Token: 0x04000008 RID: 8
		[SerializeField]
		[ReadOnlyUI]
		private string m_defaultText = "Loading...";

		// Token: 0x04000009 RID: 9
		[SerializeField]
		[ReadOnlyUI]
		private string m_nextUserText;

		// Token: 0x0400000A RID: 10
		[SerializeField]
		private TextMeshProUGUI m_loadingTextField;

		// Token: 0x0400000B RID: 11
		[SerializeField]
		private ModificadorDeBool m_enabledInputs;
	}
}
