using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Characters.Controladores.ControlladoresDeColoDePrioridad;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000014 RID: 20
	public class SequencerCommandSorprenderCara : SequencerCommand
	{
		// Token: 0x06000067 RID: 103 RVA: 0x00006910 File Offset: 0x00004B10
		public void Start()
		{
			try
			{
				FemaleChar componentInParent = base.Sequencer.Speaker.GetComponentInParent<FemaleChar>();
				if (!(componentInParent == null))
				{
					ControlladorDeGestosFacialesEmocionales componentInChildren = componentInParent.GetComponentInChildren<ControlladorDeGestosFacialesEmocionales>();
					if (!(componentInChildren == null))
					{
						ControladorDeGestosDeBoca componentInChildren2 = componentInParent.GetComponentInChildren<ControladorDeGestosDeBoca>();
						if (!(componentInChildren2 == null))
						{
							OjosExpresionController componentInChildren3 = componentInParent.GetComponentInChildren<OjosExpresionController>();
							if (!(componentInChildren3 == null))
							{
								float parameterAsFloat = base.GetParameterAsFloat(1, 1f);
								float parameterAsFloat2 = base.GetParameterAsFloat(0, 1f);
								float num = base.Sequencer.SubtitleEndTime * parameterAsFloat2;
								SequencerCommandSorprenderCara.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, num, base.GetParameterAsFloat(2, 1f), base.GetParameterAsFloat(3, 1f));
							}
						}
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000069DC File Offset: 0x00004BDC
		public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosDeBoca jawController, OjosExpresionController ojosController, float weight, float duracion, float ojosW = 1f, float jawW = 1f)
		{
			RegistroDeFuncionesDeGestos.Cara.Sorprender.Gestuar(fController, jawController, ojosController, weight, duracion, ojosW, jawW);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000069ED File Offset: 0x00004BED
		public void Update()
		{
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000069EF File Offset: 0x00004BEF
		public void OnDestroy()
		{
		}
	}
}
