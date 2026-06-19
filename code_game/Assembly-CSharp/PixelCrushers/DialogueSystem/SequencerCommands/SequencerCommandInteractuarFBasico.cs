using System;
using Assets;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000027 RID: 39
	public class SequencerCommandInteractuarFBasico : SequencerCommand
	{
		// Token: 0x060000C7 RID: 199 RVA: 0x00008808 File Offset: 0x00006A08
		public void Start()
		{
			try
			{
				InteraccionesBasicasDeFemale componentEnCharacter = base.Sequencer.Speaker.GetComponentEnCharacter(false);
				if (componentEnCharacter == null)
				{
					base.Sequencer.Listener.GetComponentEnCharacter(false);
				}
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
							num = interaccionSegundariaName.GetInteractionID();
						}
						else
						{
							InteraccionPrimariaName interaccionPrimariaName = base.GetParameter(0, "None").ToEnum(InteraccionPrimariaName.None);
							if (interaccionPrimariaName != InteraccionPrimariaName.None)
							{
								num = interaccionPrimariaName.GetInteractionID();
							}
						}
					}
					bool parameterAsBool = base.GetParameterAsBool(1, true);
					if (num == 0)
					{
						Debug.LogWarning("no se reconoce interaccion con id: " + base.GetParameter(0, "None"));
					}
					if (!this.Interactuar(componentEnCharacter, num, parameterAsBool))
					{
						Debug.LogWarning("no se pudo interactuar con Id: " + base.GetParameter(0, "None"));
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000890C File Offset: 0x00006B0C
		private bool Interactuar(InteraccionesBasicasDeFemale interacciones, int id, bool start)
		{
			Interaccion interaccion;
			if (!interacciones.TryObtenerSiEsValida(id, out interaccion))
			{
				return false;
			}
			if (start)
			{
				float parameterAsFloat = base.GetParameterAsFloat(2, 10f);
				return interaccion.Ejecutar(int.MaxValue, parameterAsFloat, ControllerPrioridadConfig.interrumpir, 1f, 1f, false);
			}
			interaccion.Detener(false);
			return true;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00008957 File Offset: 0x00006B57
		public void Update()
		{
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00008959 File Offset: 0x00006B59
		public void OnDestroy()
		{
		}
	}
}
