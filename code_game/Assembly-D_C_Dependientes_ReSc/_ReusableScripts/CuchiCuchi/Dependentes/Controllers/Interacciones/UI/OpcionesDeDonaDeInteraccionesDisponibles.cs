using System;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Interacciones.Donas.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.UI
{
	// Token: 0x020001B8 RID: 440
	[Obsolete("usar la version para THS")]
	public class OpcionesDeDonaDeInteraccionesDisponibles : GenericOpcionesDeDonaDeKeys<int, OpcionesDeDonaDeInteraccionesDisponibles.CurrentClicked>
	{
		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000A8E RID: 2702 RVA: 0x000346BE File Offset: 0x000328BE
		public IInteraccionesDeCharacter interacciones
		{
			get
			{
				return this.m_interacciones;
			}
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x000346C6 File Offset: 0x000328C6
		public Personalidad personalidad
		{
			get
			{
				return this.m_personalidad;
			}
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x000346D0 File Offset: 0x000328D0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_interacciones = this.GetComponentEnRoot(false);
			if (this.m_interacciones == null)
			{
				throw new ArgumentNullException("m_interacciones", "m_interacciones null reference.");
			}
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x0003473C File Offset: 0x0003293C
		protected override void LoadKeys(HashSetList<int> resultado)
		{
			for (int i = 0; i < this.m_interacciones.interaccionesPrimarias.Count; i++)
			{
				InteraccionDeCharacterFemenino interaccionDeCharacterFemenino = this.m_interacciones.interaccionesPrimarias[i];
				Interaccion instancia = interaccionDeCharacterFemenino.instancia;
				if (!(((instancia != null) ? instancia.GetComponent<InteraccionStrings>() : null) == null))
				{
					InteraccionPersonalidadData interaccionPersonalidadData = ((instancia != null) ? instancia.GetComponent<InteraccionPersonalidadData>() : null);
					if (!(interaccionPersonalidadData == null) && interaccionPersonalidadData.expone.Count != 0)
					{
						if (instancia.algunaEstaEjecutandose)
						{
							resultado.Clear();
							resultado.Add(interaccionDeCharacterFemenino.id);
							return;
						}
						if (instancia.PuedeEjecutarse() && this.m_interacciones.ContieneAndIsValido(interaccionDeCharacterFemenino.id))
						{
							resultado.Add(interaccionDeCharacterFemenino.id);
						}
					}
				}
			}
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x00034800 File Offset: 0x00032A00
		public override string TextDeKey(int key)
		{
			string text;
			try
			{
				text = this.m_interacciones.interaccionPrimariaDeID[key].instancia.GetComponent<InteraccionStrings>().segunda.currentTextFormal;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = key.ToString();
			}
			return text;
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x00034858 File Offset: 0x00032A58
		protected override void OnOpccionCliked(int index, int Key, IUIElementoConValor button, DonaDeInteraccionBase dona)
		{
			base.OnOpccionCliked(index, Key, button, dona);
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino = this.m_interacciones.Obtener(Key);
			bool? flag;
			if (interaccionDeCharacterFemenino == null)
			{
				flag = null;
			}
			else
			{
				Interaccion instancia = interaccionDeCharacterFemenino.instancia;
				flag = ((instancia != null) ? new bool?(instancia.algunaEstaEjecutandose) : null);
			}
			bool? flag2 = flag;
			base.lastClicked.esDetener = flag2.GetValueOrDefault(false);
		}

		// Token: 0x040007F7 RID: 2039
		private InteraccionesBasicasDeFemale m_interacciones;

		// Token: 0x040007F8 RID: 2040
		private Personalidad m_personalidad;

		// Token: 0x020001B9 RID: 441
		[Serializable]
		public class CurrentClicked : OpcionesDeDonaCurrentClickedKey<int>
		{
			// Token: 0x040007F9 RID: 2041
			public bool esDetener;

			// Token: 0x040007FA RID: 2042
			public bool ejecutarForzando;

			// Token: 0x040007FB RID: 2043
			public bool puedeEjecutarse;
		}
	}
}
