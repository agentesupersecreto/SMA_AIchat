using System;
using System.Collections;
using Assets.Productos.Juegos.Reception.Scripts.TimepoEventosDeJuego;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Tiempo;
using Assets._ReusableScripts;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders.Abstracts
{
	// Token: 0x0200013D RID: 317
	public abstract class TValleActividadEnNuevoHorarioLoader<T_Actividad> : TValleActividadEnOfficeLoader<T_Actividad>, ITValleActividadEnNuevoHorarioLoader, IActividadLoader where T_Actividad : TValleActividadSavedWithinTheScene
	{
		// Token: 0x1700018D RID: 397
		// (set) Token: 0x06000B2E RID: 2862 RVA: 0x0003A779 File Offset: 0x00038979
		bool ITValleActividadEnNuevoHorarioLoader.flagDontChangeTime
		{
			set
			{
				this.flagDontChangeTime = value;
			}
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0003A782 File Offset: 0x00038982
		protected override IEnumerator LoadingInitialScences()
		{
			if (!this.flagDontChangeTime)
			{
				Singleton<HorariosNormalesDeEntrevistas>.instance.AvanzarTiempoHastaSiguienteEntrevista();
				while (Singleton<TiempoDeJuego>.instance.navegandoEnElTiempo)
				{
					yield return null;
				}
				this.m_dateChanged = true;
			}
			this.flagDontChangeTime = false;
			yield return base.LoadingInitialScences();
			yield break;
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x0003A794 File Offset: 0x00038994
		protected override ScenaTiempoDelDia GetActividadTiempoDelDia()
		{
			if (this.m_dateChanged)
			{
				return base.GetActividadTiempoDelDia();
			}
			DateTime dateTime;
			Singleton<HorariosNormalesDeEntrevistas>.instance.SiguienteEntrevista(out dateTime);
			return SMAGameController.GetTiempoDelDia(dateTime);
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0003A7CB File Offset: 0x000389CB
		GameObject IActividadLoader.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x04000575 RID: 1397
		public bool flagDontChangeTime;

		// Token: 0x04000576 RID: 1398
		[ReadOnlyUI]
		[SerializeField]
		private bool m_dateChanged;
	}
}
