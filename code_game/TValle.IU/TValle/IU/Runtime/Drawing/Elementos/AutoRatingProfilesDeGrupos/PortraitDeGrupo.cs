using System;
using Assets._ReusableScripts.Memorias.Archivos;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.AutoRatingProfilesDeGrupos
{
	// Token: 0x0200014E RID: 334
	public class PortraitDeGrupo : CustomMonobehaviour
	{
		// Token: 0x170002BE RID: 702
		// (get) Token: 0x060009C6 RID: 2502 RVA: 0x000207F5 File Offset: 0x0001E9F5
		public PortraitDeGrupo.Modo modo
		{
			get
			{
				return this.m_Modo;
			}
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x00020800 File Offset: 0x0001EA00
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.portrait == null)
			{
				throw new ArgumentNullException("portrait", "portrait null reference.");
			}
			if (this.notFound == null)
			{
				throw new ArgumentNullException("notFound", "notFound null reference.");
			}
			if (this.manualMode == null)
			{
				throw new ArgumentNullException("manualMode", "manualMode null reference.");
			}
			if (this.lockedMode == null)
			{
				throw new ArgumentNullException("lockedMode", "lockedMode null reference.");
			}
			if (this.loading == null)
			{
				throw new ArgumentNullException("loading", "loading null reference.");
			}
			if (this.nombre == null)
			{
				throw new ArgumentNullException("nombre", "nombre null reference.");
			}
			this.portrait.texture = null;
			this.nombre.text = string.Empty;
			this.portrait.enabled = false;
			this.notFound.gameObject.SetActive(false);
			this.manualMode.gameObject.SetActive(false);
			this.lockedMode.gameObject.SetActive(false);
			this.loading.enabled = true;
			this.m_Modo = PortraitDeGrupo.Modo.loading;
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x00020935 File Offset: 0x0001EB35
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_loadedTexture != null)
			{
				Object.Destroy(this.m_loadedTexture);
			}
			this.m_loadedTexture = null;
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x0002095E File Offset: 0x0001EB5E
		public void Lock()
		{
			this.nombreDeProtrait = null;
			this.DoLoad(null);
			this.manualMode.gameObject.SetActive(false);
			this.lockedMode.gameObject.SetActive(true);
			this.m_Modo = PortraitDeGrupo.Modo.locked;
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x00020998 File Offset: 0x0001EB98
		public void DoLoadAsDisplayOnly(PortraitDeGrupo.CustomLoaderHandler customLoader = null)
		{
			this.DoLoad(customLoader);
			if (this.m_loadedTexture == null || string.IsNullOrWhiteSpace(this.nombreDeProtrait))
			{
				throw new NotSupportedException("solo se puede usar display only mode si existe portrait");
			}
			this.lockedMode.gameObject.SetActive(false);
			this.m_Modo = PortraitDeGrupo.Modo.displayOnly;
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x000209EC File Offset: 0x0001EBEC
		public void DoLoad(PortraitDeGrupo.CustomLoaderHandler customLoader = null)
		{
			this.m_Modo = PortraitDeGrupo.Modo.loading;
			if (this.m_loadedTexture != null)
			{
				Object.Destroy(this.m_loadedTexture);
			}
			this.m_loadedTexture = null;
			bool flag = !string.IsNullOrWhiteSpace(this.nombreDeProtrait);
			if (flag)
			{
				if (customLoader == null)
				{
					SaveLoadProfilePortraits.CargarThumbnail(this.nombreDeProtrait, ref this.m_loadedTexture);
				}
				else
				{
					customLoader(this.nombreDeProtrait, ref this.m_loadedTexture);
				}
			}
			if (this.m_loadedTexture != null)
			{
				this.portrait.texture = this.m_loadedTexture;
				this.portrait.enabled = true;
				this.nombre.text = this.nombreDeProtrait;
				this.notFound.gameObject.SetActive(false);
				this.manualMode.gameObject.SetActive(false);
				this.loading.enabled = false;
				this.m_Modo = PortraitDeGrupo.Modo.applyed;
				return;
			}
			this.portrait.enabled = false;
			this.portrait.texture = null;
			this.loading.enabled = false;
			if (!flag)
			{
				this.nombre.text = string.Empty;
				this.notFound.gameObject.SetActive(false);
				this.manualMode.gameObject.SetActive(true);
				this.m_Modo = PortraitDeGrupo.Modo.manual;
				return;
			}
			this.nombre.text = this.nombreDeProtrait;
			this.notFound.gameObject.SetActive(true);
			this.manualMode.gameObject.SetActive(false);
			this.m_Modo = PortraitDeGrupo.Modo.notFound;
		}

		// Token: 0x040003E2 RID: 994
		public RawImage portrait;

		// Token: 0x040003E3 RID: 995
		public Transform notFound;

		// Token: 0x040003E4 RID: 996
		public Transform manualMode;

		// Token: 0x040003E5 RID: 997
		public Transform lockedMode;

		// Token: 0x040003E6 RID: 998
		public RawImage loading;

		// Token: 0x040003E7 RID: 999
		public TextMeshProUGUI nombre;

		// Token: 0x040003E8 RID: 1000
		public string nombreDeProtrait;

		// Token: 0x040003E9 RID: 1001
		private Texture2D m_loadedTexture;

		// Token: 0x040003EA RID: 1002
		[SerializeField]
		private PortraitDeGrupo.Modo m_Modo;

		// Token: 0x020001D1 RID: 465
		// (Invoke) Token: 0x06000C5A RID: 3162
		public delegate void CustomLoaderHandler(string archivoNombre, ref Texture2D image);

		// Token: 0x020001D2 RID: 466
		public enum Modo
		{
			// Token: 0x040005C8 RID: 1480
			loading,
			// Token: 0x040005C9 RID: 1481
			applyed,
			// Token: 0x040005CA RID: 1482
			notFound,
			// Token: 0x040005CB RID: 1483
			locked,
			// Token: 0x040005CC RID: 1484
			manual,
			// Token: 0x040005CD RID: 1485
			displayOnly
		}
	}
}
