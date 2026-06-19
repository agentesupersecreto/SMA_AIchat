using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos.AutoRatingProfilesDeGrupos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x020000B4 RID: 180
	[Panel(width = 400, height = 550, childForceExpandWidth = false)]
	[Modelo]
	[UnTittle]
	[Serializable]
	public class EntrevistaInfoCampaingProfile
	{
		// Token: 0x1400002E RID: 46
		// (add) Token: 0x06000413 RID: 1043 RVA: 0x000149D4 File Offset: 0x00012BD4
		// (remove) Token: 0x06000414 RID: 1044 RVA: 0x00014A0C File Offset: 0x00012C0C
		public event EntrevistaInfoCampaingProfile.LoaderHandler onPortraitLoad;

		// Token: 0x06000415 RID: 1045 RVA: 0x00014A44 File Offset: 0x00012C44
		protected IUIElemento ProductorDeGrupoUI(IUIPanel panel)
		{
			if (this.grupo != null)
			{
				Object.Destroy(this.grupo);
			}
			this.grupo = Object.Instantiate<GrupoProfileIndependiente>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.profileIndependiente);
			this.grupo.Init(0);
			this.grupo.DoLoad(this.profile.item1, GrupoProfile.LoadingMode.displayOnly, new PortraitDeGrupo.CustomLoaderHandler(this.CustomLoaderHandler));
			return this.grupo;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00014AB4 File Offset: 0x00012CB4
		public void Cleared()
		{
			if (this.grupo != null)
			{
				Object.Destroy(this.grupo);
			}
			this.grupo = null;
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00014AD6 File Offset: 0x00012CD6
		private void CustomLoaderHandler(string archivoNombre, ref Texture2D image)
		{
			EntrevistaInfoCampaingProfile.LoaderHandler loaderHandler = this.onPortraitLoad;
			if (loaderHandler == null)
			{
				return;
			}
			loaderHandler(archivoNombre, ref image);
		}

		// Token: 0x040001CA RID: 458
		[IgnoreValue]
		[LayoutConfigUI(width = 270, height = 453)]
		[SelfDrawing(metodo = "ProductorDeGrupoUI", setConfig = true)]
		public MultipleValorElemento<string, bool> profile;

		// Token: 0x040001CB RID: 459
		public GrupoProfileIndependiente grupo;

		// Token: 0x02000118 RID: 280
		// (Invoke) Token: 0x0600062E RID: 1582
		public delegate void LoaderHandler(string profileName, ref Texture2D image);
	}
}
