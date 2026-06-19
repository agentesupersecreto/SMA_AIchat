using System;
using System.Collections;
using Assets.Base.CustomMonoBehaviours.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Camaras;
using Assets.TValle.BeachGirl.Runtime.XRays.Globales;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.XRays
{
	// Token: 0x0200005E RID: 94
	public class XRaysParaFemaleCharacter : AplicableCustomMonobehaviour
	{
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000197 RID: 407 RVA: 0x000033EF File Offset: 0x000015EF
		public ModificableDeBool canShowPelvisAND
		{
			get
			{
				return this.m_canShowPelvisAND;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000198 RID: 408 RVA: 0x000033F7 File Offset: 0x000015F7
		public ModificableDeBool canShowBocaAND
		{
			get
			{
				return this.m_canShowBocaAND;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000199 RID: 409 RVA: 0x000033FF File Offset: 0x000015FF
		[Obsolete("", true)]
		public ModificableDeBool pelvisIsBlockedOR
		{
			get
			{
				return this.m_pelvisIsBlockedOR;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600019A RID: 410 RVA: 0x00003407 File Offset: 0x00001607
		[Obsolete("", true)]
		public ModificableDeBool bocaIsBlockedOR
		{
			get
			{
				return this.m_bocaIsBlockedOR;
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00003410 File Offset: 0x00001610
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_checkBlockeo = new CoroutineCapsule(this.CheckBlokeoRutine(), this, new CoroutineCapsuleConfig
			{
				autoStart = true,
				autoRestart = true
			});
			this.m_ICharacter = this.GetComponentEnRoot(false);
			if (this.m_ICharacter == null)
			{
				throw new ArgumentNullException("m_AnimatorCharacter", "m_AnimatorCharacter null reference.");
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00003470 File Offset: 0x00001670
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_pelvis = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerHueso(MapaSingleton<MapaSingletonDeFemaleBones>.instance.Pelvis, this.m_ICharacter.bodyAnimator);
			this.m_facialBone = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerHueso(MapaSingleton<MapaSingletonDeFemaleBones>.instance.FacialBone, this.m_ICharacter.bodyAnimator);
			this.m_bocaEntrada = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerHueso(MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabiosEntrada, this.m_ICharacter.bodyAnimator);
			if (this.m_pelvis == null)
			{
				throw new ArgumentNullException("m_pelvis", "m_pelvis null reference.");
			}
			if (this.m_facialBone == null)
			{
				throw new ArgumentNullException("m_facialBone", "m_facialBone null reference.");
			}
			if (this.m_bocaEntrada == null)
			{
				throw new ArgumentNullException("m_bocaEntrada", "m_bocaEntrada null reference.");
			}
			this.UpdatePelvis();
			this.UpdateBoca();
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00003558 File Offset: 0x00001758
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_XRayPelvisCamera != null)
			{
				Object.Destroy(this.m_XRayPelvisCamera.gameObject);
			}
			if (this.m_XRayBocaCamera != null)
			{
				Object.Destroy(this.m_XRayBocaCamera.gameObject);
			}
		}

		// Token: 0x0600019E RID: 414 RVA: 0x000035A8 File Offset: 0x000017A8
		private IEnumerator CheckBlokeoRutine()
		{
			yield return new WaitForSeconds(Random.value);
			WaitForSeconds w = new WaitForSeconds(1f);
			for (;;)
			{
				if (this.m_pelvisEstado != XRaysParaFemaleCharacter.EstadoPelvis.noPudoOff && this.m_pelvisEstado != XRaysParaFemaleCharacter.EstadoPelvis.off && (!this.m_canShowPelvisAND.And(this.canShowPelvis) || this.forceHidePelvis))
				{
					this.m_pelvisEstado = XRaysParaFemaleCharacter.EstadoPelvis.noPudoOff;
					this.UpdatePelvis();
				}
				if (this.m_bocaEstado != XRaysParaFemaleCharacter.Estado.noPudoOff && this.m_bocaEstado != XRaysParaFemaleCharacter.Estado.off && (!this.m_canShowBocaAND.And(this.canShowBoca) || this.forceHideBoca))
				{
					this.m_bocaEstado = XRaysParaFemaleCharacter.Estado.noPudoOff;
					this.UpdateBoca();
				}
				yield return w;
			}
			yield break;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x000035B8 File Offset: 0x000017B8
		public void UpdatePelvis()
		{
			if (!InstantiatedSingleton<MainInternalsXRayCamera>.IsInScene)
			{
				return;
			}
			XRayPelvisUI xRayPelvisUI = Singleton<XRaysReferences>.instance.xRayPelvisUI;
			MainInternalsXRayCamera instance = InstantiatedSingleton<MainInternalsXRayCamera>.instance;
			switch (this.m_pelvisEstado)
			{
			case XRaysParaFemaleCharacter.EstadoPelvis.off:
			case XRaysParaFemaleCharacter.EstadoPelvis.noPudoOff:
				instance.gameObject.SetActive(false);
				if (this.m_XRayPelvisCamera != null)
				{
					this.m_XRayPelvisCamera.enabled = false;
				}
				if (xRayPelvisUI.blockedImage.enabled)
				{
					xRayPelvisUI.blockedImage.enabled = false;
				}
				if (xRayPelvisUI.xRayImage.enabled)
				{
					xRayPelvisUI.xRayImage.enabled = false;
					return;
				}
				break;
			case XRaysParaFemaleCharacter.EstadoPelvis.vagina:
				instance.gameObject.SetActive(true);
				instance.OnlyVag();
				if (this.m_XRayPelvisCamera == null)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(Singleton<XRaysReferences>.instance.pelvisCameraPrefab, base.transform);
					this.m_XRayPelvisCamera = gameObject.GetComponentNotNull<XRayPelvisCamera>();
					this.m_XRayPelvisCamera.gameObject.SetActive(true);
					this.m_XRayPelvisCamera.target = this.m_pelvis;
				}
				if (!this.m_XRayPelvisCamera.enabled)
				{
					this.m_XRayPelvisCamera.enabled = true;
				}
				if (xRayPelvisUI.blockedImage.enabled)
				{
					xRayPelvisUI.blockedImage.enabled = false;
				}
				if (!xRayPelvisUI.xRayImage.enabled)
				{
					xRayPelvisUI.xRayImage.enabled = true;
					return;
				}
				break;
			case XRaysParaFemaleCharacter.EstadoPelvis.anus:
				instance.gameObject.SetActive(true);
				instance.OnlyAnus();
				if (this.m_XRayPelvisCamera == null)
				{
					GameObject gameObject2 = Object.Instantiate<GameObject>(Singleton<XRaysReferences>.instance.pelvisCameraPrefab, base.transform);
					this.m_XRayPelvisCamera = gameObject2.GetComponentNotNull<XRayPelvisCamera>();
					this.m_XRayPelvisCamera.gameObject.SetActive(true);
					this.m_XRayPelvisCamera.target = this.m_pelvis;
				}
				if (!this.m_XRayPelvisCamera.enabled)
				{
					this.m_XRayPelvisCamera.enabled = true;
				}
				if (xRayPelvisUI.blockedImage.enabled)
				{
					xRayPelvisUI.blockedImage.enabled = false;
				}
				if (!xRayPelvisUI.xRayImage.enabled)
				{
					xRayPelvisUI.xRayImage.enabled = true;
					return;
				}
				break;
			case XRaysParaFemaleCharacter.EstadoPelvis.vaginaAndAnus:
				instance.gameObject.SetActive(true);
				instance.All();
				if (this.m_XRayPelvisCamera == null)
				{
					GameObject gameObject3 = Object.Instantiate<GameObject>(Singleton<XRaysReferences>.instance.pelvisCameraPrefab, base.transform);
					this.m_XRayPelvisCamera = gameObject3.GetComponentNotNull<XRayPelvisCamera>();
					this.m_XRayPelvisCamera.gameObject.SetActive(true);
					this.m_XRayPelvisCamera.target = this.m_pelvis;
				}
				if (!this.m_XRayPelvisCamera.enabled)
				{
					this.m_XRayPelvisCamera.enabled = true;
				}
				if (xRayPelvisUI.blockedImage.enabled)
				{
					xRayPelvisUI.blockedImage.enabled = false;
				}
				if (!xRayPelvisUI.xRayImage.enabled)
				{
					xRayPelvisUI.xRayImage.enabled = true;
					return;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(this.m_pelvisEstado.ToString());
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00003894 File Offset: 0x00001A94
		public void UpdateBoca()
		{
			XRayBocaUI xRayBocaUI = Singleton<XRaysReferences>.instance.xRayBocaUI;
			XRaysParaFemaleCharacter.Estado bocaEstado = this.m_bocaEstado;
			if (bocaEstado > XRaysParaFemaleCharacter.Estado.noPudoOff)
			{
				if (bocaEstado != XRaysParaFemaleCharacter.Estado.on)
				{
					throw new ArgumentOutOfRangeException(this.m_bocaEstado.ToString());
				}
				if (this.m_XRayBocaCamera == null)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(Singleton<XRaysReferences>.instance.bocaCameraPrefab, base.transform);
					this.m_XRayBocaCamera = gameObject.GetComponentNotNull<XRayBocaCamera>();
					this.m_XRayBocaCamera.gameObject.SetActive(true);
					this.m_XRayBocaCamera.target = this.m_facialBone;
					this.m_XRayBocaCamera.bocaEntrada = this.m_bocaEntrada;
				}
				if (!this.m_XRayBocaCamera.enabled)
				{
					this.m_XRayBocaCamera.enabled = true;
				}
				if (xRayBocaUI.blockedImage.enabled)
				{
					xRayBocaUI.blockedImage.enabled = false;
				}
				if (!xRayBocaUI.xRayImage.enabled)
				{
					xRayBocaUI.xRayImage.enabled = true;
					return;
				}
			}
			else
			{
				if (this.m_XRayBocaCamera != null)
				{
					this.m_XRayBocaCamera.enabled = false;
				}
				if (xRayBocaUI.blockedImage.enabled)
				{
					xRayBocaUI.blockedImage.enabled = false;
				}
				if (xRayBocaUI.xRayImage.enabled)
				{
					xRayBocaUI.xRayImage.enabled = false;
					return;
				}
			}
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x000039D8 File Offset: 0x00001BD8
		public void ChangePelvis(bool show, int hole)
		{
			if (!base.isStared)
			{
				throw new InvalidOperationException();
			}
			try
			{
				if (!show)
				{
					this.m_pelvisEstado = XRaysParaFemaleCharacter.EstadoPelvis.off;
				}
				else if (!show || !this.m_canShowPelvisAND.And(this.canShowPelvis) || this.forceHidePelvis)
				{
					this.m_pelvisEstado = XRaysParaFemaleCharacter.EstadoPelvis.noPudoOff;
				}
				else
				{
					switch (hole)
					{
					case 0:
						this.m_pelvisEstado = XRaysParaFemaleCharacter.EstadoPelvis.vagina;
						break;
					case 1:
						this.m_pelvisEstado = XRaysParaFemaleCharacter.EstadoPelvis.anus;
						break;
					case 2:
						this.m_pelvisEstado = XRaysParaFemaleCharacter.EstadoPelvis.vaginaAndAnus;
						break;
					default:
						throw new ArgumentOutOfRangeException(hole.ToString());
					}
				}
			}
			finally
			{
				this.UpdatePelvis();
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00003A80 File Offset: 0x00001C80
		public void ChangeBoca(bool show)
		{
			if (!base.isStared)
			{
				throw new InvalidOperationException();
			}
			if (!base.isStared)
			{
				throw new InvalidOperationException();
			}
			try
			{
				if (!show)
				{
					this.m_bocaEstado = XRaysParaFemaleCharacter.Estado.off;
				}
				else if (!show || !this.m_canShowBocaAND.And(this.canShowBoca) || this.forceHideBoca)
				{
					this.m_bocaEstado = XRaysParaFemaleCharacter.Estado.noPudoOff;
				}
				else
				{
					this.m_bocaEstado = XRaysParaFemaleCharacter.Estado.on;
				}
			}
			finally
			{
				this.UpdateBoca();
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00003B04 File Offset: 0x00001D04
		public void TogglePelvis()
		{
			bool flag;
			int num;
			switch (this.m_pelvisEstado)
			{
			case XRaysParaFemaleCharacter.EstadoPelvis.off:
			case XRaysParaFemaleCharacter.EstadoPelvis.noPudoOff:
				flag = true;
				num = 0;
				break;
			case XRaysParaFemaleCharacter.EstadoPelvis.vagina:
				flag = true;
				num = 1;
				break;
			case XRaysParaFemaleCharacter.EstadoPelvis.anus:
				flag = true;
				num = 2;
				break;
			case XRaysParaFemaleCharacter.EstadoPelvis.vaginaAndAnus:
				flag = false;
				num = -1;
				break;
			default:
				throw new ArgumentOutOfRangeException(this.m_pelvisEstado.ToString());
			}
			this.ChangePelvis(flag, num);
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00003B6C File Offset: 0x00001D6C
		public void ToggleBoca()
		{
			XRaysParaFemaleCharacter.Estado bocaEstado = this.m_bocaEstado;
			bool flag;
			if (bocaEstado > XRaysParaFemaleCharacter.Estado.noPudoOff)
			{
				if (bocaEstado != XRaysParaFemaleCharacter.Estado.on)
				{
					throw new ArgumentOutOfRangeException(this.m_bocaEstado.ToString());
				}
				flag = true;
			}
			else
			{
				flag = false;
			}
			this.ChangeBoca(!flag);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00003BB3 File Offset: 0x00001DB3
		protected override void OnAplicar2()
		{
			this.TogglePelvis();
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00003BBB File Offset: 0x00001DBB
		protected override void OnAplicar3()
		{
			this.ToggleBoca();
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00003BC3 File Offset: 0x00001DC3
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Toggle Pelvis"
			};
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00003BDC File Offset: 0x00001DDC
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Toggle Boca"
			};
		}

		// Token: 0x040000FE RID: 254
		public bool forceHidePelvis;

		// Token: 0x040000FF RID: 255
		public bool forceHideBoca;

		// Token: 0x04000100 RID: 256
		public bool canShowPelvis = true;

		// Token: 0x04000101 RID: 257
		public bool canShowBoca = true;

		// Token: 0x04000102 RID: 258
		public bool pelvisIsBlocked;

		// Token: 0x04000103 RID: 259
		public bool bocaIsBlocked;

		// Token: 0x04000104 RID: 260
		[SerializeField]
		private ModificableDeBool m_canShowPelvisAND = new ModificableDeBool(false);

		// Token: 0x04000105 RID: 261
		[SerializeField]
		private ModificableDeBool m_canShowBocaAND = new ModificableDeBool(false);

		// Token: 0x04000106 RID: 262
		[Obsolete("", true)]
		[SerializeField]
		private ModificableDeBool m_pelvisIsBlockedOR = new ModificableDeBool(true);

		// Token: 0x04000107 RID: 263
		[Obsolete("", true)]
		[SerializeField]
		private ModificableDeBool m_bocaIsBlockedOR = new ModificableDeBool(true);

		// Token: 0x04000108 RID: 264
		private ICharacter m_ICharacter;

		// Token: 0x04000109 RID: 265
		private XRayPelvisCamera m_XRayPelvisCamera;

		// Token: 0x0400010A RID: 266
		private XRayBocaCamera m_XRayBocaCamera;

		// Token: 0x0400010B RID: 267
		private Transform m_pelvis;

		// Token: 0x0400010C RID: 268
		private Transform m_facialBone;

		// Token: 0x0400010D RID: 269
		private Transform m_bocaEntrada;

		// Token: 0x0400010E RID: 270
		[ReadOnlyUI]
		[SerializeField]
		private XRaysParaFemaleCharacter.EstadoPelvis m_pelvisEstado;

		// Token: 0x0400010F RID: 271
		[ReadOnlyUI]
		[SerializeField]
		private XRaysParaFemaleCharacter.Estado m_bocaEstado;

		// Token: 0x04000110 RID: 272
		private CoroutineCapsule m_checkBlockeo;

		// Token: 0x02000142 RID: 322
		public enum Estado
		{
			// Token: 0x040007B3 RID: 1971
			off,
			// Token: 0x040007B4 RID: 1972
			noPudoOff,
			// Token: 0x040007B5 RID: 1973
			[Obsolete("", true)]
			blokeadoOn,
			// Token: 0x040007B6 RID: 1974
			on
		}

		// Token: 0x02000143 RID: 323
		public enum EstadoPelvis
		{
			// Token: 0x040007B8 RID: 1976
			off,
			// Token: 0x040007B9 RID: 1977
			noPudoOff,
			// Token: 0x040007BA RID: 1978
			vagina,
			// Token: 0x040007BB RID: 1979
			anus,
			// Token: 0x040007BC RID: 1980
			vaginaAndAnus
		}
	}
}
