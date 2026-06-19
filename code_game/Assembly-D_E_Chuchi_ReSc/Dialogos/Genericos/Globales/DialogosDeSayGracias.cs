using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Globales
{
	// Token: 0x02000211 RID: 529
	public class DialogosDeSayGracias : Singleton<DialogosDeSayGracias>
	{
		// Token: 0x06000C1F RID: 3103 RVA: 0x00035EEC File Offset: 0x000340EC
		public void RandomLoadParaTipo(Localizacion localization, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipo, List<DialogoInfoGenericoConTipoDeRespuesta> result)
		{
			for (int i = 0; i < this.m_dialogos.Length; i++)
			{
				DialogosLocalizadosGenericosConTipoDeRespuesta dialogosLocalizadosGenericosConTipoDeRespuesta = this.m_dialogos[i];
				if (dialogosLocalizadosGenericosConTipoDeRespuesta.IsValid() && dialogosLocalizadosGenericosConTipoDeRespuesta.ParaCultura(localization) && dialogosLocalizadosGenericosConTipoDeRespuesta.ParaTipo(tipo))
				{
					DialogoInfoGenericoConTipoDeRespuesta dialogoInfoGenericoConTipoDeRespuesta = dialogosLocalizadosGenericosConTipoDeRespuesta.Obtener(null);
					result.Add(dialogoInfoGenericoConTipoDeRespuesta);
				}
			}
		}

		// Token: 0x040009CA RID: 2506
		[SerializeField]
		private DialogosLocalizadosGenericosConTipoDeRespuesta[] m_dialogos;
	}
}
