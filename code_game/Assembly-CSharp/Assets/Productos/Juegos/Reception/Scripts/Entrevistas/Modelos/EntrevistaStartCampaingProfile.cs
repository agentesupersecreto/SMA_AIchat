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
	// Token: 0x020000B1 RID: 177
	[Panel(width = 480, height = 550, childForceExpandWidth = false)]
	[Modelo]
	[UnTittle]
	[Serializable]
	public class EntrevistaStartCampaingProfile
	{
		// Token: 0x1400002A RID: 42
		// (add) Token: 0x060003FD RID: 1021 RVA: 0x0001463C File Offset: 0x0001283C
		// (remove) Token: 0x060003FE RID: 1022 RVA: 0x00014674 File Offset: 0x00012874
		public event Action<GrupoProfileIndependiente> onNew;

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x060003FF RID: 1023 RVA: 0x000146AC File Offset: 0x000128AC
		// (remove) Token: 0x06000400 RID: 1024 RVA: 0x000146E4 File Offset: 0x000128E4
		public event Action<GrupoProfileIndependiente> onCambiar;

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06000401 RID: 1025 RVA: 0x0001471C File Offset: 0x0001291C
		// (remove) Token: 0x06000402 RID: 1026 RVA: 0x00014754 File Offset: 0x00012954
		public event Action<GrupoProfileIndependiente> onEditar;

		// Token: 0x06000403 RID: 1027 RVA: 0x0001478C File Offset: 0x0001298C
		protected IUIElemento ProductorDeGrupoUI(IUIPanel panel)
		{
			if (this.grupo != null)
			{
				Object.Destroy(this.grupo);
			}
			this.grupo = Object.Instantiate<GrupoProfileIndependiente>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.profileIndependiente);
			this.grupo.Init(0);
			this.SubscribeToGroups(this.grupo);
			this.grupo.DoLoad(string.Empty, GrupoProfile.LoadingMode.none, null);
			return this.grupo;
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x000147F7 File Offset: 0x000129F7
		public void Cleared()
		{
			if (this.grupo != null)
			{
				this.UnSubscribeToGroups(this.grupo);
				Object.Destroy(this.grupo);
			}
			this.grupo = null;
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00014825 File Offset: 0x00012A25
		private void SubscribeToGroups(GrupoProfileIndependiente grupo)
		{
			grupo.onCambiar += this.Grupo_onCambiar;
			grupo.onEditar += this.Grupo_onEditar;
			grupo.onNew += this.Grupo_onNew;
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0001485D File Offset: 0x00012A5D
		private void UnSubscribeToGroups(GrupoProfileIndependiente grupo)
		{
			grupo.onCambiar -= this.Grupo_onCambiar;
			grupo.onEditar -= this.Grupo_onEditar;
			grupo.onNew -= this.Grupo_onNew;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00014895 File Offset: 0x00012A95
		private void Grupo_onNew(GrupoProfile obj)
		{
			Action<GrupoProfileIndependiente> action = this.onNew;
			if (action == null)
			{
				return;
			}
			action(this.grupo);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x000148AD File Offset: 0x00012AAD
		private void Grupo_onEditar(GrupoProfile obj)
		{
			Action<GrupoProfileIndependiente> action = this.onEditar;
			if (action == null)
			{
				return;
			}
			action(this.grupo);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x000148C5 File Offset: 0x00012AC5
		private void Grupo_onCambiar(GrupoProfile obj)
		{
			Action<GrupoProfileIndependiente> action = this.onCambiar;
			if (action == null)
			{
				return;
			}
			action(this.grupo);
		}

		// Token: 0x040001BE RID: 446
		[Texto(height = 90)]
		public string GuiaProf = "*For this new campaign, what kind of model are you looking for?";

		// Token: 0x040001BF RID: 447
		[LayoutConfigUI(width = 270, height = 453)]
		[SelfDrawing(metodo = "ProductorDeGrupoUI", setConfig = true)]
		public MultipleValorElemento<string, bool> profile;

		// Token: 0x040001C0 RID: 448
		public GrupoProfileIndependiente grupo;
	}
}
