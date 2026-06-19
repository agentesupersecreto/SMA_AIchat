using System;
using Assets;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000011 RID: 17
	public class SequencerCommandExagerarTipoDeExpresion : SequencerCommand
	{
		// Token: 0x06000058 RID: 88 RVA: 0x00006708 File Offset: 0x00004908
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
						ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoDeExpresion = base.GetParameter(0, "0").ToEnum(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia);
						float parameterAsFloat = base.GetParameterAsFloat(1, 1f);
						float num = base.Sequencer.SubtitleEndTime * parameterAsFloat;
						float parameterAsFloat2 = base.GetParameterAsFloat(2, 1f);
						float parameterAsFloat3 = base.GetParameterAsFloat(3, 0f);
						SequencerCommandExagerarTipoDeExpresion.Exagerar(componentInChildren, tipoDeExpresion, num, parameterAsFloat2, parameterAsFloat3);
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000067B4 File Offset: 0x000049B4
		public static void Exagerar(ControlladorDeGestosFacialesEmocionales fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo, float duracion, float weight, float minExpresionValue)
		{
			RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, tipo, duracion, weight, minExpresionValue);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000067C1 File Offset: 0x000049C1
		public void Update()
		{
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000067C3 File Offset: 0x000049C3
		public void OnDestroy()
		{
		}
	}
}
