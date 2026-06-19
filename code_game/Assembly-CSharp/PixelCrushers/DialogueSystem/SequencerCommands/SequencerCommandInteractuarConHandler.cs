using System;
using Assets;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000026 RID: 38
	public class SequencerCommandInteractuarConHandler : SequencerCommand
	{
		// Token: 0x060000C2 RID: 194 RVA: 0x00008700 File Offset: 0x00006900
		public void Start()
		{
			try
			{
				InteraccionesBasicasDeFemale componentEnCharacter = base.Sequencer.Speaker.GetComponentEnCharacter(false);
				if (componentEnCharacter == null)
				{
					Debug.LogWarning("no se encontro InteraccionesBasicasDeFemale");
				}
				else
				{
					int num = base.GetParameterAsInt(0, 0);
					if (num == 0)
					{
						InteraccionSegundariaName interaccionSegundariaName = base.GetParameter(0, "None").ToEnum(InteraccionSegundariaName.None);
						if (interaccionSegundariaName != InteraccionSegundariaName.None)
						{
							num = (int)interaccionSegundariaName;
						}
						else
						{
							InteraccionPrimariaName interaccionPrimariaName = base.GetParameter(0, "None").ToEnum(InteraccionPrimariaName.None);
							if (interaccionPrimariaName != InteraccionPrimariaName.None)
							{
								num = (int)interaccionPrimariaName;
							}
						}
					}
					if (num == 0)
					{
						Debug.LogWarning("no se reconoce interaccion con id: " + base.GetParameterAsInt(0, 0).ToString());
					}
					if (!this.Interactuar(componentEnCharacter, num))
					{
						Debug.LogWarning("no se pudo interactuar con Id: " + base.GetParameterAsInt(0, 0).ToString());
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000087DC File Offset: 0x000069DC
		private bool Interactuar(InteraccionesBasicasDeFemale interacciones, int id)
		{
			Interaccion interaccion;
			return interacciones.TryObtenerSiEsValida(id, out interaccion) && interaccion.EjecutarConHandler();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000087FC File Offset: 0x000069FC
		public void Update()
		{
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000087FE File Offset: 0x000069FE
		public void OnDestroy()
		{
		}
	}
}
