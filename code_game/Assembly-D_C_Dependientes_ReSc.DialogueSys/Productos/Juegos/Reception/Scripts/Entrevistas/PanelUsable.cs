using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Assets._ReusableScripts.UI.Drawing;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x02000004 RID: 4
	[RequireComponent(typeof(IPanelOfModel))]
	public class PanelUsable : CustomUpdatedMonobehaviourBase, IUsable, IActivableModificable, IActivable
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002237 File Offset: 0x00000437
		public int prioridad
		{
			get
			{
				return this.m_prioridad;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000223F File Offset: 0x0000043F
		public ModificableDeBool activadoModificable
		{
			get
			{
				return this.m_activadoModificable;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002247 File Offset: 0x00000447
		// (set) Token: 0x0600000B RID: 11 RVA: 0x0000225A File Offset: 0x0000045A
		public bool activado
		{
			get
			{
				return this.m_activadoModificable.And(this.m_puedeUsarse);
			}
			set
			{
				this.m_puedeUsarse = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002263 File Offset: 0x00000463
		public IPanelOfModel PanelOfModel
		{
			get
			{
				return this.m_PanelOfModel;
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000226B File Offset: 0x0000046B
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PanelOfModel = base.GetComponent<IPanelOfModel>();
			this.UpdateName();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002285 File Offset: 0x00000485
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.changed += this.Idioma_changed;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000022A8 File Offset: 0x000004A8
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (Singleton<ConfiguracionGeneralDeIdioma>.IsInScene)
			{
				Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.changed -= this.Idioma_changed;
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000022D3 File Offset: 0x000004D3
		private void Idioma_changed(ConfiguracionGeneralDeIdioma.Config.Idioma config, string last, string current)
		{
			this.UpdateName();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000022DC File Offset: 0x000004DC
		public void UpdateName()
		{
			if (string.IsNullOrEmpty(this.m_panelName))
			{
				this.m_name = base.name;
			}
			else
			{
				this.m_name = this.m_panelName;
			}
			DisplaySettings displaySettings = DialogueManager.DisplaySettings;
			LocalizedTextTable localizedTextTable;
			if (displaySettings == null)
			{
				localizedTextTable = null;
			}
			else
			{
				DisplaySettings.LocalizationSettings localizationSettings = displaySettings.localizationSettings;
				localizedTextTable = ((localizationSettings != null) ? localizationSettings.localizedText : null);
			}
			LocalizedTextTable localizedTextTable2 = localizedTextTable;
			if (localizedTextTable2 != null && localizedTextTable2.ContainsField(this.m_name))
			{
				this.m_name = localizedTextTable2[this.m_name];
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002357 File Offset: 0x00000557
		public float maxUseDistance
		{
			get
			{
				return this.m_maxUseDistance;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000013 RID: 19 RVA: 0x0000235F File Offset: 0x0000055F
		public string overrideUseMessage
		{
			get
			{
				return this.m_overrideUseMessage;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002367 File Offset: 0x00000567
		// (set) Token: 0x06000015 RID: 21 RVA: 0x0000238B File Offset: 0x0000058B
		public bool puedeUsarse
		{
			get
			{
				return this.activado && !this.m_PanelOfModel.isShowing && this.m_PanelOfModel.CanShow();
			}
			set
			{
				this.activado = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002394 File Offset: 0x00000594
		public bool UseMessages
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002397 File Offset: 0x00000597
		public string GetName()
		{
			return this.m_name;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000018 RID: 24 RVA: 0x000023A0 File Offset: 0x000005A0
		// (remove) Token: 0x06000019 RID: 25 RVA: 0x000023D8 File Offset: 0x000005D8
		public event Action<Transform> onUsado;

		// Token: 0x0600001A RID: 26 RVA: 0x00002410 File Offset: 0x00000610
		public void OnUsado(Transform actor)
		{
			bool flag;
			if (this.m_PanelOfModel.CurrentModelObjectAndState(out flag) == null)
			{
				return;
			}
			if (flag)
			{
				this.m_PanelOfModel.Clear();
			}
			if (!this.m_PanelOfModel.isBinded)
			{
				this.m_PanelOfModel.CrearYDibujar(null);
			}
			else
			{
				this.m_PanelOfModel.Show();
			}
			Action<Transform> action = this.onUsado;
			if (action == null)
			{
				return;
			}
			action(actor);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002498 File Offset: 0x00000698
		GameObject IUsable.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000024A0 File Offset: 0x000006A0
		void IUsable.SendMessage(string methodName)
		{
			base.SendMessage(methodName);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000024A9 File Offset: 0x000006A9
		void IUsable.SendMessage(string methodName, object value)
		{
			base.SendMessage(methodName, value);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000024B3 File Offset: 0x000006B3
		void IUsable.SendMessage(string methodName, SendMessageOptions options)
		{
			base.SendMessage(methodName, options);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000024BD File Offset: 0x000006BD
		void IUsable.SendMessage(string methodName, object value, SendMessageOptions options)
		{
			base.SendMessage(methodName, value, options);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000024C8 File Offset: 0x000006C8
		void IUsable.SendMessageUpwards(string methodName)
		{
			base.SendMessageUpwards(methodName);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000024D1 File Offset: 0x000006D1
		void IUsable.SendMessageUpwards(string methodName, object value)
		{
			base.SendMessageUpwards(methodName, value);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000024DB File Offset: 0x000006DB
		void IUsable.SendMessageUpwards(string methodName, SendMessageOptions options)
		{
			base.SendMessageUpwards(methodName, options);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000024E5 File Offset: 0x000006E5
		void IUsable.SendMessageUpwards(string methodName, object value, SendMessageOptions options)
		{
			base.SendMessageUpwards(methodName, value, options);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000024F0 File Offset: 0x000006F0
		void IUsable.BroadcastMessage(string methodName)
		{
			base.BroadcastMessage(methodName);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000024F9 File Offset: 0x000006F9
		void IUsable.BroadcastMessage(string methodName, object parameter)
		{
			base.BroadcastMessage(methodName, parameter);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002503 File Offset: 0x00000703
		void IUsable.BroadcastMessage(string methodName, SendMessageOptions options)
		{
			base.BroadcastMessage(methodName, options);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000250D File Offset: 0x0000070D
		void IUsable.BroadcastMessage(string methodName, object parameter, SendMessageOptions options)
		{
			base.BroadcastMessage(methodName, parameter, options);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002518 File Offset: 0x00000718
		bool IUsable.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x04000002 RID: 2
		[SerializeField]
		private ModificableDeBool m_activadoModificable = new ModificableDeBool(true);

		// Token: 0x04000003 RID: 3
		[SerializeField]
		private bool m_puedeUsarse = true;

		// Token: 0x04000004 RID: 4
		[SerializeField]
		private string m_panelName;

		// Token: 0x04000005 RID: 5
		[SerializeField]
		private string m_overrideUseMessage;

		// Token: 0x04000006 RID: 6
		[SerializeField]
		private float m_maxUseDistance = 2f;

		// Token: 0x04000007 RID: 7
		[ReadOnlyUI]
		[SerializeField]
		private string m_name;

		// Token: 0x04000008 RID: 8
		[SerializeField]
		private int m_prioridad;

		// Token: 0x04000009 RID: 9
		private IPanelOfModel m_PanelOfModel;
	}
}
