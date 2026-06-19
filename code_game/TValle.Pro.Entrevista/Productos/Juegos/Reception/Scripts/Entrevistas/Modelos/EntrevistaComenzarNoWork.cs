using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x0200000D RID: 13
	[Obsolete("", true)]
	[Panel(height = 650)]
	[Label("Agency Hub", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.TopLeft)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Modelo]
	[Serializable]
	public class EntrevistaComenzarNoWork
	{
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000078 RID: 120 RVA: 0x000041FC File Offset: 0x000023FC
		// (remove) Token: 0x06000079 RID: 121 RVA: 0x00004234 File Offset: 0x00002434
		public event Action<EntrevistaComenzarNoWork> onResting;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600007A RID: 122 RVA: 0x0000426C File Offset: 0x0000246C
		// (remove) Token: 0x0600007B RID: 123 RVA: 0x000042A4 File Offset: 0x000024A4
		public event Action<EntrevistaComenzarNoWork> onSaving;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600007C RID: 124 RVA: 0x000042DC File Offset: 0x000024DC
		// (remove) Token: 0x0600007D RID: 125 RVA: 0x00004314 File Offset: 0x00002514
		public event Action onCheckAgencyInfo;

		// Token: 0x0600007E RID: 126 RVA: 0x00004349 File Offset: 0x00002549
		[Label("Save", "US")]
		[Descripcion("-Save your game progress.", "US")]
		[AccionName("AccionSave")]
		[ClickableLabelDescriptable(confirmar = false)]
		[ConfirmablePregunta("Do you really want to Save?", "US")]
		public void Save()
		{
			Action<EntrevistaComenzarNoWork> action = this.onSaving;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000435C File Offset: 0x0000255C
		[Label("Rest for a while", "US")]
		[Descripcion("-There is no work at the moment.", "US")]
		[Descripcion("-Rest till next appointment.", "US")]
		[AccionName("StartRestingTillNextDate")]
		[ClickableLabelDescriptable(confirmar = false)]
		[ConfirmablePregunta("Do you really want to rest?", "US")]
		public void OnRest()
		{
			Action<EntrevistaComenzarNoWork> action = this.onResting;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000436F File Offset: 0x0000256F
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

		// Token: 0x06000081 RID: 129 RVA: 0x00004381 File Offset: 0x00002581
		[Separador]
		[Label("Auto Rating", "US")]
		[Descripcion("-Assign your profiles to groups. There are a total of ten groups available, which will be unlocked as you progress through the game.", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void OpenProfilesDeGrupos()
		{
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00004383 File Offset: 0x00002583
		[Label("Profile Editor", "US")]
		[Descripcion("-After you've created your interpretation profiles, you'll be able to assign them to groups. You can enable automated ratings for models in that group by doing so.", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void OpenProfileEditor()
		{
		}
	}
}
