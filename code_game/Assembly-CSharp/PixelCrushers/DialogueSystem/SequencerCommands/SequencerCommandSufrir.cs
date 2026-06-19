using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200001F RID: 31
	public class SequencerCommandSufrir : SequencerCommand
	{
		// Token: 0x0600009F RID: 159 RVA: 0x00007728 File Offset: 0x00005928
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
								SequencerCommandSufrir.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, parameterAsFloat2, parameterAsFloat3, num);
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

		// Token: 0x060000A0 RID: 160 RVA: 0x00007810 File Offset: 0x00005A10
		public static void Gestuar(Character female, float weightFace, float weightHead, float weightHombros, float duracionFace)
		{
			RegistroDeFuncionesDeGestos.Sufrir.Gestuar(female, weightFace, weightHead, weightHombros, duracionFace);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000781D File Offset: 0x00005A1D
		public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosConCabeza headController, ControladorDeGestosConHombros hombrosController, float weightFace, float weightHead, float weightHombros, float duracionFace)
		{
			RegistroDeFuncionesDeGestos.Sufrir.Gestuar(fController, headController, hombrosController, weightFace, weightHead, weightHombros, duracionFace);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000782E File Offset: 0x00005A2E
		public void Update()
		{
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00007830 File Offset: 0x00005A30
		public void OnDestroy()
		{
		}
	}
}
