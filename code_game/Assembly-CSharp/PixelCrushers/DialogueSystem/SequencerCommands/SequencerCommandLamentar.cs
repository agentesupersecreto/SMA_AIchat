using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200001C RID: 28
	public class SequencerCommandLamentar : SequencerCommand
	{
		// Token: 0x0600008F RID: 143 RVA: 0x00007440 File Offset: 0x00005640
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
						ControladorDeGestosConCabeza componentInChildren2 = componentInParent.GetComponentInChildren<ControladorDeGestosConCabeza>();
						if (!(componentInChildren2 == null))
						{
							ControladorDeGestosConHombros componentInChildren3 = componentInParent.GetComponentInChildren<ControladorDeGestosConHombros>();
							if (!(componentInChildren3 == null))
							{
								float parameterAsFloat = base.GetParameterAsFloat(1, 1f);
								float parameterAsFloat2 = base.GetParameterAsFloat(2, 0f);
								float parameterAsFloat3 = base.GetParameterAsFloat(3, 0f);
								bool parameterAsBool = base.GetParameterAsBool(4, false);
								float parameterAsFloat4 = base.GetParameterAsFloat(0, 1f);
								float num = (parameterAsBool ? parameterAsFloat4 : (base.Sequencer.SubtitleEndTime * parameterAsFloat4));
								SequencerCommandLamentar.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, parameterAsFloat2, parameterAsFloat3, num);
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

		// Token: 0x06000090 RID: 144 RVA: 0x00007528 File Offset: 0x00005728
		public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosConCabeza headController, ControladorDeGestosConHombros hombrosController, float weightFace, float weightHead, float weightHombros, float duracionFace)
		{
			RegistroDeFuncionesDeGestos.Lamentar.Gestuar(fController, headController, hombrosController, weightFace, weightHead, weightHombros, duracionFace);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00007539 File Offset: 0x00005739
		public void Update()
		{
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000753B File Offset: 0x0000573B
		public void OnDestroy()
		{
		}
	}
}
