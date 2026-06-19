using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Modales;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets.TValle.Tools.Runtime.SMA.Moddding.Jobs.Maps;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.UI
{
	// Token: 0x020000B2 RID: 178
	public class CurrentAvailableJobsPortraitsGetter : CustomMonobehaviour, ICustomDePortraitsDisponibles<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>
	{
		// Token: 0x06000682 RID: 1666 RVA: 0x00025BAC File Offset: 0x00023DAC
		List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> ICustomDePortraitsDisponibles<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>.ObtenerDisponibles()
		{
			this.m_availables.Clear();
			foreach (KeyValuePair<string, SMAJobMap> keyValuePair in AsyncSingleton<JobsGetter>.instance.jobsDisponibles)
			{
				string key = keyValuePair.Key;
				SMAJobMap value = keyValuePair.Value;
				if (this.IsUnlocked(value))
				{
					bool flag;
					MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool> multipleValorElemento = new MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>(key, value.GetIngameName(AsyncSingleton<JobsManager>.instance.gameLanguage, out flag), new SelectablePortraitCargarThumbnailHandler(CurrentAvailableJobsPortraitsGetter.CargarThumbnail), false);
					this.m_availables.Add(multipleValorElemento);
				}
			}
			return this.m_availables;
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x00025C54 File Offset: 0x00023E54
		private bool IsUnlocked(SMAJobMap jobMap)
		{
			if (string.IsNullOrWhiteSpace(jobMap.IsUnlockedLogic))
			{
				return true;
			}
			Type type = Type.GetType(jobMap.IsUnlockedLogic);
			if (type == null)
			{
				Singleton<ModalWindow>.instance.AcumularErrores("Could not load custom modding script of type " + jobMap.IsUnlockedLogic, null);
				Debug.LogError("No se pudo cargar script de tipo: " + jobMap.IsUnlockedLogic, this);
				Debug.LogException(new InvalidOperationException("Could not load custom modding script of type " + jobMap.IsUnlockedLogic), this);
				return false;
			}
			if (!typeof(ISMAUnlockableJob).IsAssignableFrom(type))
			{
				Debug.LogError("Type : " + type.Name + " no implementa " + typeof(ISMAUnlockableJob).Name, this);
				Debug.LogException(new InvalidOperationException("Type : " + type.Name + " does not implement " + typeof(ISMAUnlockableJob).Name), this);
				return false;
			}
			ISMAUnlockableJob ismaunlockableJob = Activator.CreateInstance(type) as ISMAUnlockableJob;
			if (ismaunlockableJob == null)
			{
				throw new ArgumentNullException("instantiatedLogic", "instantiatedLogic null reference.");
			}
			return ismaunlockableJob.IsUnlocked(AsyncSingleton<JobsManager>.instance, jobMap);
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x00025D69 File Offset: 0x00023F69
		private static void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			loadedTexture = AsyncSingleton<JobsGetter>.instance.portraitDeJobs[idDeProtrait] as Texture2D;
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x00025D82 File Offset: 0x00023F82
		public string GetToolTipOf(int index)
		{
			return string.Empty;
		}

		// Token: 0x040003FC RID: 1020
		private List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> m_availables = new List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>();
	}
}
