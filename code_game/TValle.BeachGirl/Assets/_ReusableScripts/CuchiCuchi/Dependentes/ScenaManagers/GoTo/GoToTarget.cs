using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers.GoTo
{
	// Token: 0x02000120 RID: 288
	public class GoToTarget : AplicableCustomMonobehaviour
	{
		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06000C78 RID: 3192 RVA: 0x0002A867 File Offset: 0x00028A67
		public GoToScenaManager.GoTo data
		{
			get
			{
				return this.m_data;
			}
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x0002A86F File Offset: 0x00028A6F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.registrarEnAwake)
			{
				this.Registrar();
			}
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x0002A885 File Offset: 0x00028A85
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				this.Registrar();
			}
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x0002A89B File Offset: 0x00028A9B
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.Registrar();
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x0002A8A9 File Offset: 0x00028AA9
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Unregistrar();
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x0002A8B8 File Offset: 0x00028AB8
		protected virtual void OnUsing(ICharacterNavegable navegable, ICharacterTeleportable teleportable, ICharacter character)
		{
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x0002A8BA File Offset: 0x00028ABA
		private void OnUsingCallBack(ICharacterNavegable navegable, ICharacterTeleportable teleportable, ICharacter character, GoToScenaManager.GoTo sender)
		{
			this.OnUsing(navegable, teleportable, character);
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x0002A8C8 File Offset: 0x00028AC8
		public virtual void Registrar()
		{
			if (!this.m_data.isValid)
			{
				throw new InvalidOperationException();
			}
			this.m_data.onUsing -= this.OnUsingCallBack;
			this.m_data.onUsing += this.OnUsingCallBack;
			Singleton<GoToScenaManager>.TryIniciar();
			GoToScenaManager instance = Singleton<GoToScenaManager>.instance;
			if (instance == null)
			{
				Debug.LogError("No se pudo registrar GoTo target, no existe GoTo ScenaManager en scena " + base.gameObject.scene.name, this);
				return;
			}
			if (!instance.TryAdd(this.m_data))
			{
				Debug.LogError("No se pudo registrar GoTo target.", this);
			}
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x0002A968 File Offset: 0x00028B68
		public void Unregistrar()
		{
			this.m_data.onUsing -= this.OnUsingCallBack;
			if (!Singleton<GoToScenaManager>.IsInScene)
			{
				return;
			}
			GoToScenaManager instance = Singleton<GoToScenaManager>.instance;
			if (instance == null)
			{
				return;
			}
			instance.Remove(this.m_data);
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x0002A9B1 File Offset: 0x00028BB1
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Go To Main Heroina",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x0002A9CC File Offset: 0x00028BCC
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			GoToScenaManager instance = Singleton<GoToScenaManager>.instance;
			TargetChar current = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current;
			ICharacterNavegable characterNavegable;
			if (current == null)
			{
				characterNavegable = null;
			}
			else
			{
				Character character = current.character;
				characterNavegable = ((character != null) ? character.GetComponentEnRoot<ICharacterNavegable>() : null);
			}
			instance.NavTo(characterNavegable, false, this.m_data, 1f, 1f, false);
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x0002AA18 File Offset: 0x00028C18
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Go To Main Heroina Precise",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x0002AA34 File Offset: 0x00028C34
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			GoToScenaManager instance = Singleton<GoToScenaManager>.instance;
			TargetChar current = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current;
			ICharacterNavegable characterNavegable;
			if (current == null)
			{
				characterNavegable = null;
			}
			else
			{
				Character character = current.character;
				characterNavegable = ((character != null) ? character.GetComponentEnRoot<ICharacterNavegable>() : null);
			}
			instance.NavTo(characterNavegable, false, this.m_data, 1f, 0.25f, false);
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x0002AA80 File Offset: 0x00028C80
		protected override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Go To Main Heroina Teleport",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x0002AA99 File Offset: 0x00028C99
		protected override void OnAplicar4()
		{
			base.OnAplicar4();
			Singleton<GoToScenaManager>.instance.Apply(CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character, false, this.m_data);
		}

		// Token: 0x040006B1 RID: 1713
		public bool registrarEnAwake;

		// Token: 0x040006B2 RID: 1714
		[SerializeField]
		private GoToScenaManager.GoTo m_data;
	}
}
