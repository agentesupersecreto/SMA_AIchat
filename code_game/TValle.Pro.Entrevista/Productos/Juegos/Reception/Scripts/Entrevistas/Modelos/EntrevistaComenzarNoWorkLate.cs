using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x0200000E RID: 14
	[Obsolete("", true)]
	[Panel(height = 650)]
	[Label("Agency Hub", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.TopLeft)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Modelo]
	[Serializable]
	public class EntrevistaComenzarNoWorkLate
	{
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000084 RID: 132 RVA: 0x00004390 File Offset: 0x00002590
		// (remove) Token: 0x06000085 RID: 133 RVA: 0x000043C8 File Offset: 0x000025C8
		public event Action<EntrevistaComenzarNoWorkLate> onGoingHome;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000086 RID: 134 RVA: 0x00004400 File Offset: 0x00002600
		// (remove) Token: 0x06000087 RID: 135 RVA: 0x00004438 File Offset: 0x00002638
		public event Action<EntrevistaComenzarNoWorkLate> onSaving;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000088 RID: 136 RVA: 0x00004470 File Offset: 0x00002670
		// (remove) Token: 0x06000089 RID: 137 RVA: 0x000044A8 File Offset: 0x000026A8
		public event Action onCheckAgencyInfo;

		// Token: 0x0600008A RID: 138 RVA: 0x000044DD File Offset: 0x000026DD
		[Label("Save", "US")]
		[Descripcion("-Save your game progress.", "US")]
		[AccionName("AccionSave")]
		[ClickableLabelDescriptable(confirmar = false)]
		[ConfirmablePregunta("Do you really want to Save?", "US")]
		public void Save()
		{
			Action<EntrevistaComenzarNoWorkLate> action = this.onSaving;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000044F0 File Offset: 0x000026F0
		[Label("Go Home", "US")]
		[Descripcion("-There is no work at the moment.", "US")]
		[Descripcion("-Rest at home till next appointment.", "US")]
		[AccionName("AccionGoHome")]
		[ClickableLabelDescriptable(confirmar = false)]
		[ConfirmablePregunta("Do you really want to go Home?", "US")]
		public void GoHome()
		{
			Action<EntrevistaComenzarNoWorkLate> action = this.onGoingHome;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00004503 File Offset: 0x00002703
		[Separador]
		[Label("Agency Info", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		[Descripcion("Check out the responses from other agencies to the models you sent them.", "US")]
		[Descripcion("See if any other agencies are interested in collaborating with yours.", "US")]
		public void CheckEmail()
		{
			Action action = this.onCheckAgencyInfo;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00004515 File Offset: 0x00002715
		[Separador]
		[Label("Auto Rating", "US")]
		[Descripcion("-Assign your profiles to groups. There are a total of ten groups available, which will be unlocked as you progress through the game.", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void OpenProfilesDeGrupos()
		{
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004517 File Offset: 0x00002717
		[Label("Profile Editor", "US")]
		[Descripcion("-After you've created your interpretation profiles, you'll be able to assign them to groups. You can enable automated ratings for models in that group by doing so.", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void OpenProfileEditor()
		{
		}
	}
}
