using System;
using System.Collections;
using Assets.Base.Behaviours.Runtime.Cameras;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Miscellaneous;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes.Controlladores
{
	// Token: 0x02000017 RID: 23
	[RequireComponent(typeof(CameraRendingTextureTakeAPhoto))]
	[RequireComponent(typeof(Camera))]
	public class SelfPortraitCamera : AplicableCustomMonobehaviour
	{
		// Token: 0x060000F7 RID: 247 RVA: 0x0000590C File Offset: 0x00003B0C
		protected override void AwakeUnityEvent()
		{
			this.m_TurnOffFlashDelegate = new Action(this.TurnOffFlash);
			base.AwakeUnityEvent();
			this.m_CameraRendingTextureTakeAPhoto = base.GetComponent<CameraRendingTextureTakeAPhoto>();
			this.m_Camera = base.GetComponent<Camera>();
			this.m_defaultSize = this.m_Camera.orthographicSize;
			this.m_defaultFar = this.m_Camera.farClipPlane;
			this.m_updateRutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.onAI4, this, this.UpdateRutine(), null);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00005988 File Offset: 0x00003B88
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.m_mainVolume == null)
			{
				throw new ArgumentNullException("m_mainVolume", "m_mainVolume null reference.");
			}
			this.m_Camera.enabled = false;
			if (this.m_flash != null)
			{
				this.m_flash.enabled = false;
			}
			if (this.m_BaseFolowTransform != null)
			{
				if (!this.m_BaseFolowTransform.isAwaken)
				{
					this.m_BaseFolowTransform.ManualAwake();
				}
				if (!this.m_BaseFolowTransform.isStared)
				{
					this.m_BaseFolowTransform.ManualStart();
				}
				this.m_BaseFolowTransform.enabled = false;
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00005A29 File Offset: 0x00003C29
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_lastTaken)
			{
				Object.Destroy(this.m_lastTaken);
			}
			this.m_lastTaken = null;
			GlobalUpdater.instancia.StopCorrutina(this.m_updateRutina);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00005A61 File Offset: 0x00003C61
		private IEnumerator UpdateRutine()
		{
			ManualCorrutina.TValleWaitForSeconds w = new ManualCorrutina.TValleWaitForSeconds(10f);
			for (;;)
			{
				yield return w;
				this.UpdateCameraSizes();
			}
			yield break;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00005A70 File Offset: 0x00003C70
		public void UpdateCameraSizes()
		{
			BaseFolowTransform baseFolowTransform = this.m_BaseFolowTransform;
			if (baseFolowTransform != null)
			{
				baseFolowTransform.Follow();
			}
			float num = base.transform.lossyScale.Escala();
			this.m_Camera.orthographicSize = this.m_defaultSize * num;
			this.m_Camera.farClipPlane = this.m_defaultFar * num;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00005AC8 File Offset: 0x00003CC8
		public void UpdateTexture()
		{
			GlobalUpdater.instancia.CancelarInvocacionPorDelegado(this.m_TurnOffFlashDelegate);
			Camera main = Camera.main;
			VolumeProfile volumeProfile;
			if (main == null)
			{
				volumeProfile = null;
			}
			else
			{
				Volume componentInChildren = main.GetComponentInChildren<Volume>();
				volumeProfile = ((componentInChildren != null) ? componentInChildren.profile : null);
			}
			VolumeProfile volumeProfile2 = volumeProfile;
			if (volumeProfile2 != null)
			{
				this.m_mainVolume.profile = volumeProfile2;
			}
			if (this.m_flash != null)
			{
				this.m_flash.enabled = true;
			}
			this.UpdateCameraSizes();
			this.m_Camera.Render();
			if (this.m_flash != null)
			{
				GlobalUpdater.instancia.Invokar(this.m_TurnOffFlashDelegate, 0.1f);
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00005B68 File Offset: 0x00003D68
		public void TurnOnFlash()
		{
			this.m_CameraRendingTextureTakeAPhoto.TurnOnFlash();
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00005B75 File Offset: 0x00003D75
		public void OverrideNextPortrait(Texture2D overriding)
		{
			this.m_overriding = overriding;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00005B80 File Offset: 0x00003D80
		public Texture2D TakeFemalePortrait()
		{
			if (this.m_lastTaken)
			{
				Object.Destroy(this.m_lastTaken);
			}
			this.m_lastTaken = null;
			if (this.m_overriding != null)
			{
				Texture2D overriding = this.m_overriding;
				this.m_overriding = null;
				return overriding;
			}
			this.UpdateTexture();
			this.m_CameraRendingTextureTakeAPhoto.TryTakeAPhoto(ref this.m_lastTaken, false);
			return this.m_lastTaken;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00005BE7 File Offset: 0x00003DE7
		private void TurnOffFlash()
		{
			if (this.m_flash != null)
			{
				this.m_flash.enabled = false;
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00005C03 File Offset: 0x00003E03
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.UpdateTexture();
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00005C11 File Offset: 0x00003E11
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Update Texture",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00005C2A File Offset: 0x00003E2A
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			this.TakeFemalePortrait();
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00005C39 File Offset: 0x00003E39
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Take Female Portrait",
				editorTimeVisible = false
			};
		}

		// Token: 0x0400008D RID: 141
		private GlobalUpdater.Corrutina m_updateRutina;

		// Token: 0x0400008E RID: 142
		private Camera m_Camera;

		// Token: 0x0400008F RID: 143
		[SerializeField]
		private BaseFolowTransform m_BaseFolowTransform;

		// Token: 0x04000090 RID: 144
		[SerializeField]
		private Light m_flash;

		// Token: 0x04000091 RID: 145
		private float m_defaultSize;

		// Token: 0x04000092 RID: 146
		private float m_defaultFar;

		// Token: 0x04000093 RID: 147
		[SerializeField]
		private Texture2D m_overriding;

		// Token: 0x04000094 RID: 148
		[SerializeField]
		private Texture2D m_lastTaken;

		// Token: 0x04000095 RID: 149
		[SerializeField]
		private Volume m_mainVolume;

		// Token: 0x04000096 RID: 150
		private CameraRendingTextureTakeAPhoto m_CameraRendingTextureTakeAPhoto;

		// Token: 0x04000097 RID: 151
		private Action m_TurnOffFlashDelegate;
	}
}
