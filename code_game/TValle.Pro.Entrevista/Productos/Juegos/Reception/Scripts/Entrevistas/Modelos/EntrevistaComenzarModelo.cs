using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x0200000C RID: 12
	[Obsolete("", true)]
	[Panel(height = 650)]
	[Modelo]
	[Label("Agency Hub", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.TopLeft)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Serializable]
	public class EntrevistaComenzarModelo
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600006C RID: 108 RVA: 0x00004068 File Offset: 0x00002268
		// (remove) Token: 0x0600006D RID: 109 RVA: 0x000040A0 File Offset: 0x000022A0
		public event Action<EntrevistaComenzarModelo> clicked;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600006E RID: 110 RVA: 0x000040D8 File Offset: 0x000022D8
		// (remove) Token: 0x0600006F RID: 111 RVA: 0x00004110 File Offset: 0x00002310
		public event Action<EntrevistaComenzarModelo> onSaving;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000070 RID: 112 RVA: 0x00004148 File Offset: 0x00002348
		// (remove) Token: 0x06000071 RID: 113 RVA: 0x00004180 File Offset: 0x00002380
		public event Action onCheckAgencyInfo;

		// Token: 0x06000072 RID: 114 RVA: 0x000041B5 File Offset: 0x000023B5
		[Label("Start interviewing now", "US")]
		[Descripcion("-Bring a female into office.", "US")]
		[Descripcion("-Rate her qualities to improve upcoming females.", "US")]
		[Descripcion("-Earns commissions by contacting her with some other \"modeling\" agency.", "US")]
		[AccionName("StartInterviewing")]
		[ClickableLabelDescriptable(confirmar = false)]
		[ConfirmablePregunta("Do you really want to start interviewing?", "US")]
		public void StartWorking()
		{
			Action<EntrevistaComenzarModelo> action = this.clicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000041C8 File Offset: 0x000023C8
		[Label("Save", "US")]
		[Descripcion("-Save your game progress.", "US")]
		[AccionName("AccionSave")]
		[ClickableLabelDescriptable(confirmar = false)]
		[ConfirmablePregunta("Do you really want to Save?", "US")]
		public void Save()
		{
			Action<EntrevistaComenzarModelo> action = this.onSaving;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000041DB File Offset: 0x000023DB
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

		// Token: 0x06000075 RID: 117 RVA: 0x000041ED File Offset: 0x000023ED
		[Separador]
		[Label("Auto Rating", "US")]
		[Descripcion("-Assign your profiles to groups. There are a total of ten groups available, which will be unlocked as you progress through the game.", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void OpenProfilesDeGrupos()
		{
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000041EF File Offset: 0x000023EF
		[Label("Profile Editor", "US")]
		[Descripcion("-After you've created your interpretation profiles, you'll be able to assign them to groups. You can enable automated ratings for models in that group by doing so.", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void OpenProfileEditor()
		{
		}
	}
}
