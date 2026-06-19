using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias
{
	// Token: 0x020000CC RID: 204
	public class ModificadorDeIngresosDeAgenciasDeCharacter : CustomMonobehaviour
	{
		// Token: 0x060007A3 RID: 1955 RVA: 0x0002C0C8 File Offset: 0x0002A2C8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_modificaciones.Clear();
			this.m_modificacionesDeAgencias.Clear();
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0002C0E8 File Offset: 0x0002A2E8
		public ModificadorDeFloat GetModificadorGeneralNotNullDeAgencia(string agenciaID)
		{
			ModificadorDeIngresosDeAgenciasDeCharacter.Modificacion modificacion;
			if (!this.m_modificacionesDeAgencias.TryGetValue(agenciaID, out modificacion))
			{
				if (Singleton<OtrasAgencias>.instance.ObtenerAgencia(agenciaID) == null)
				{
					Debug.LogError("No existe agencia de id: " + agenciaID, this);
					return null;
				}
				modificacion = new ModificadorDeIngresosDeAgenciasDeCharacter.Modificacion();
				modificacion.agenciaID = agenciaID;
				this.m_modificacionesDeAgencias.Add(agenciaID, modificacion);
				this.m_modificaciones.Add(modificacion);
			}
			return modificacion.modificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0002C160 File Offset: 0x0002A360
		public ModificadorDeFloat GetModificadorNotNullDeAgencia(string agenciaID, string modId)
		{
			ModificadorDeIngresosDeAgenciasDeCharacter.Modificacion modificacion;
			if (!this.m_modificacionesDeAgencias.TryGetValue(agenciaID, out modificacion))
			{
				if (Singleton<OtrasAgencias>.instance.ObtenerAgencia(agenciaID) == null)
				{
					Debug.LogError("No existe agencia de id: " + agenciaID, this);
					return null;
				}
				modificacion = new ModificadorDeIngresosDeAgenciasDeCharacter.Modificacion();
				modificacion.agenciaID = agenciaID;
				this.m_modificacionesDeAgencias.Add(agenciaID, modificacion);
				this.m_modificaciones.Add(modificacion);
			}
			return modificacion.modificable.ObtenerModificadorNotNull(modId);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0002C1D8 File Offset: 0x0002A3D8
		public ModificableDeFloat GetModifiacableDeAgencia(string agenciaID)
		{
			ModificadorDeIngresosDeAgenciasDeCharacter.Modificacion modificacion;
			if (this.m_modificacionesDeAgencias.TryGetValue(agenciaID, out modificacion))
			{
				return modificacion.modificable;
			}
			return null;
		}

		// Token: 0x0400045D RID: 1117
		[SerializeReference]
		private List<ModificadorDeIngresosDeAgenciasDeCharacter.Modificacion> m_modificaciones = new List<ModificadorDeIngresosDeAgenciasDeCharacter.Modificacion>();

		// Token: 0x0400045E RID: 1118
		private Dictionary<string, ModificadorDeIngresosDeAgenciasDeCharacter.Modificacion> m_modificacionesDeAgencias = new Dictionary<string, ModificadorDeIngresosDeAgenciasDeCharacter.Modificacion>();

		// Token: 0x02000261 RID: 609
		[Serializable]
		public class Modificacion
		{
			// Token: 0x04000B4D RID: 2893
			public string agenciaID;

			// Token: 0x04000B4E RID: 2894
			public ModificableDeFloat modificable = new ModificableDeFloat(1f);
		}
	}
}
