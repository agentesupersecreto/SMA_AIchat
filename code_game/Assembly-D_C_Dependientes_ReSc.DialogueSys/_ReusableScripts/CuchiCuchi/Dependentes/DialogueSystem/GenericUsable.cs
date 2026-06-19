using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000013 RID: 19
	public class GenericUsable : CustomUpdatedMonobehaviourBase, IUsable, INombrable, IActivableModificable, IActivable
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00003CD7 File Offset: 0x00001ED7
		public ModificableDeBool activadoModificable
		{
			get
			{
				return this.m_activadoModificable;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00003CDF File Offset: 0x00001EDF
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00003CF2 File Offset: 0x00001EF2
		public bool activado
		{
			get
			{
				return this.m_activadoModificable.And(this.puedeUsarse);
			}
			set
			{
				this.puedeUsarse = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00003CFB File Offset: 0x00001EFB
		int IUsable.prioridad
		{
			get
			{
				return this.prioridad;
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000092 RID: 146 RVA: 0x00003D04 File Offset: 0x00001F04
		// (remove) Token: 0x06000093 RID: 147 RVA: 0x00003D3C File Offset: 0x00001F3C
		public event Action<Transform> onUsado;

		// Token: 0x06000094 RID: 148 RVA: 0x00003D71 File Offset: 0x00001F71
		void IUsable.OnUsado(Transform actor)
		{
			Action<Transform> action = this.onUsado;
			if (action != null)
			{
				action(actor);
			}
			this.m_onUsadoUnity.Invoke();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003D90 File Offset: 0x00001F90
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.UpdateName();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003D9E File Offset: 0x00001F9E
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.changed += this.Idioma_changed;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003DC1 File Offset: 0x00001FC1
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (Singleton<ConfiguracionGeneralDeIdioma>.IsInScene)
			{
				Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.changed -= this.Idioma_changed;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003DEC File Offset: 0x00001FEC
		private void Idioma_changed(ConfiguracionGeneralDeIdioma.Config.Idioma config, string last, string current)
		{
			this.UpdateName();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003DF4 File Offset: 0x00001FF4
		public void UpdateName()
		{
			if (this.useAnimatorName)
			{
				Character componentEnRoot = this.GetComponentEnRoot(false);
				this.m_Animator = ((componentEnRoot != null) ? componentEnRoot.bodyAnimator : null);
				if (this.m_Animator)
				{
					this.m_name = this.m_Animator.name;
					if (!string.IsNullOrEmpty(this.m_name))
					{
						return;
					}
				}
			}
			if (string.IsNullOrEmpty(this.usableName))
			{
				this.m_name = base.name;
			}
			else
			{
				this.m_name = this.usableName;
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

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00003EBC File Offset: 0x000020BC
		float IUsable.maxUseDistance
		{
			get
			{
				return this.maxUseDistance;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00003EC4 File Offset: 0x000020C4
		string IUsable.overrideUseMessage
		{
			get
			{
				return this.overrideUseMessage;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00003ECC File Offset: 0x000020CC
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00003EDF File Offset: 0x000020DF
		bool IUsable.puedeUsarse
		{
			get
			{
				return this.m_activadoModificable.And(this.puedeUsarse);
			}
			set
			{
				this.puedeUsarse = value;
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003EE8 File Offset: 0x000020E8
		public string GetName()
		{
			return this.m_name;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00003EF0 File Offset: 0x000020F0
		public bool UseMessages
		{
			get
			{
				return this.usarUnityMessages;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00003EF8 File Offset: 0x000020F8
		public string nombre
		{
			get
			{
				return this.GetName();
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003F26 File Offset: 0x00002126
		GameObject IUsable.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003F2E File Offset: 0x0000212E
		void IUsable.SendMessage(string methodName)
		{
			base.SendMessage(methodName);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003F37 File Offset: 0x00002137
		void IUsable.SendMessage(string methodName, object value)
		{
			base.SendMessage(methodName, value);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003F41 File Offset: 0x00002141
		void IUsable.SendMessage(string methodName, SendMessageOptions options)
		{
			base.SendMessage(methodName, options);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003F4B File Offset: 0x0000214B
		void IUsable.SendMessage(string methodName, object value, SendMessageOptions options)
		{
			base.SendMessage(methodName, value, options);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003F56 File Offset: 0x00002156
		void IUsable.SendMessageUpwards(string methodName)
		{
			base.SendMessageUpwards(methodName);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003F5F File Offset: 0x0000215F
		void IUsable.SendMessageUpwards(string methodName, object value)
		{
			base.SendMessageUpwards(methodName, value);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003F69 File Offset: 0x00002169
		void IUsable.SendMessageUpwards(string methodName, SendMessageOptions options)
		{
			base.SendMessageUpwards(methodName, options);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003F73 File Offset: 0x00002173
		void IUsable.SendMessageUpwards(string methodName, object value, SendMessageOptions options)
		{
			base.SendMessageUpwards(methodName, value, options);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003F7E File Offset: 0x0000217E
		void IUsable.BroadcastMessage(string methodName)
		{
			base.BroadcastMessage(methodName);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003F87 File Offset: 0x00002187
		void IUsable.BroadcastMessage(string methodName, object parameter)
		{
			base.BroadcastMessage(methodName, parameter);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00003F91 File Offset: 0x00002191
		void IUsable.BroadcastMessage(string methodName, SendMessageOptions options)
		{
			base.BroadcastMessage(methodName, options);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003F9B File Offset: 0x0000219B
		void IUsable.BroadcastMessage(string methodName, object parameter, SendMessageOptions options)
		{
			base.BroadcastMessage(methodName, parameter, options);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003FA6 File Offset: 0x000021A6
		bool IUsable.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x0400002D RID: 45
		public bool usarUnityMessages = true;

		// Token: 0x0400002E RID: 46
		public float maxUseDistance;

		// Token: 0x0400002F RID: 47
		public string overrideUseMessage;

		// Token: 0x04000030 RID: 48
		public bool puedeUsarse;

		// Token: 0x04000031 RID: 49
		public string usableName;

		// Token: 0x04000032 RID: 50
		public bool useAnimatorName;

		// Token: 0x04000033 RID: 51
		public int prioridad;

		// Token: 0x04000034 RID: 52
		[ReadOnlyUI]
		[SerializeField]
		private Animator m_Animator;

		// Token: 0x04000035 RID: 53
		[ReadOnlyUI]
		[SerializeField]
		private string m_name;

		// Token: 0x04000036 RID: 54
		[SerializeField]
		private UnityEvent m_onUsadoUnity = new UnityEvent();

		// Token: 0x04000037 RID: 55
		[SerializeField]
		private ModificableDeBool m_activadoModificable = new ModificableDeBool(true);
	}
}
