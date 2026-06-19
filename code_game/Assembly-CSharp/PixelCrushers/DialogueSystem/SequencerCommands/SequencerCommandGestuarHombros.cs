using System;
using Assets;
using Assets.Base.BeachGirl.Runtime;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200000E RID: 14
	public class SequencerCommandGestuarHombros : SequencerCommand
	{
		// Token: 0x06000049 RID: 73 RVA: 0x0000652C File Offset: 0x0000472C
		public void Start()
		{
			try
			{
				FemaleChar componentInParent = base.Sequencer.Speaker.GetComponentInParent<FemaleChar>();
				if (!(componentInParent == null))
				{
					ControladorDeGestosConHombros componentInChildren = componentInParent.GetComponentInChildren<ControladorDeGestosConHombros>();
					if (!(componentInChildren == null))
					{
						TipoDeGestoDeHombro tipoDeGestoDeHombro = base.GetParameter(0, "0").ToEnum(TipoDeGestoDeHombro.roll);
						float parameterAsFloat = base.GetParameterAsFloat(1, 1f);
						float parameterAsFloat2 = base.GetParameterAsFloat(2, 1f);
						SequencerCommandGestuarHombros.Gestuar(componentInChildren, tipoDeGestoDeHombro, parameterAsFloat, parameterAsFloat2, true);
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000065BC File Offset: 0x000047BC
		public static void Gestuar(ControladorDeGestosConHombros fController, TipoDeGestoDeHombro tipo, float duracion, float amplitudMod, bool duracionEsMod = true)
		{
			RegistroDeFuncionesDeGestos.Hombros.Gestuar(fController, tipo, duracion, amplitudMod, duracionEsMod);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000065C9 File Offset: 0x000047C9
		public void Update()
		{
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000065CB File Offset: 0x000047CB
		public void OnDestroy()
		{
		}
	}
}
