using System;
using Assets;
using Assets.Base.BeachGirl.Runtime;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200001A RID: 26
	public class SequencerCommandGestuarAuto : SequencerCommand
	{
		// Token: 0x06000087 RID: 135 RVA: 0x00006E18 File Offset: 0x00005018
		public void Start()
		{
			try
			{
				Personalidad.Tipo tipo = DialogueLua.GetVariable("MAYOR_PERSONALIDAD").AsString.ToEnum(Personalidad.Tipo.None);
				if (tipo == Personalidad.Tipo.All)
				{
					Debug.LogError("Cant gestuar a All personality", this);
				}
				else
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
									float num = base.GetParameterAsFloat(2, 0f);
									float parameterAsFloat2 = base.GetParameterAsFloat(3, 0f);
									bool parameterAsBool = base.GetParameterAsBool(4, false);
									float parameterAsFloat3 = base.GetParameterAsFloat(0, 1f);
									float num2 = (parameterAsBool ? parameterAsFloat3 : (base.Sequencer.SubtitleEndTime * parameterAsFloat3));
									SequencerCommandGestuarAuto.TipoDeRespuesta tipoDeRespuesta = base.GetParameter(5, string.Empty).ToEnum(SequencerCommandGestuarAuto.TipoDeRespuesta.Default);
									switch (tipoDeRespuesta)
									{
									case SequencerCommandGestuarAuto.TipoDeRespuesta.Default:
										break;
									case SequencerCommandGestuarAuto.TipoDeRespuesta.No:
										num = 1f;
										RegistroDeFuncionesDeGestos.Cabeza.overrrideNext = new TipoDeGestoDeCabeza?(TipoDeGestoDeCabeza.no);
										break;
									case SequencerCommandGestuarAuto.TipoDeRespuesta.Yes:
										num = 1f;
										RegistroDeFuncionesDeGestos.Cabeza.overrrideNext = new TipoDeGestoDeCabeza?(TipoDeGestoDeCabeza.si);
										break;
									default:
										throw new ArgumentOutOfRangeException(tipoDeRespuesta.ToString());
									}
									if (tipo <= Personalidad.Tipo.exhibicionista)
									{
										switch (tipo)
										{
										case Personalidad.Tipo.None:
										case Personalidad.Tipo.neutral:
											SequencerCommandSonrreir.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat * 0.75f, num * 0.75f, parameterAsFloat2 * 0.75f, num2);
											return;
										case Personalidad.Tipo.timido:
											SequencerCommandAsustar.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, num, parameterAsFloat2, num2);
											return;
										case Personalidad.Tipo.neutral | Personalidad.Tipo.timido:
										case Personalidad.Tipo.neutral | Personalidad.Tipo.extrovertido:
										case Personalidad.Tipo.timido | Personalidad.Tipo.extrovertido:
										case Personalidad.Tipo.neutral | Personalidad.Tipo.timido | Personalidad.Tipo.extrovertido:
											break;
										case Personalidad.Tipo.extrovertido:
											SequencerCommandSonrreir.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, num, parameterAsFloat2, num2);
											return;
										case Personalidad.Tipo.sumiso:
											SequencerCommandLamentar.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, num, parameterAsFloat2, num2);
											return;
										default:
											if (tipo == Personalidad.Tipo.pervertido)
											{
												RegistroDeFuncionesDeGestos.SufrirAlegrar.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, num, parameterAsFloat2, num2);
												return;
											}
											if (tipo == Personalidad.Tipo.exhibicionista)
											{
												SequencerCommandSonrreir.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, num, parameterAsFloat2, num2);
												return;
											}
											break;
										}
									}
									else
									{
										if (tipo == Personalidad.Tipo.respetuoso)
										{
											SequencerCommandSonrreir.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat * 0.25f, num * 0.25f, parameterAsFloat2 * 0.25f, num2);
											return;
										}
										if (tipo == Personalidad.Tipo.grosero)
										{
											SequencerCommandEnojar.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, num, parameterAsFloat2, num2);
											return;
										}
										if (tipo == Personalidad.Tipo.honesto)
										{
											SequencerCommandSonrreir.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat * 0.5f, num * 0.5f, parameterAsFloat2 * 0.5f, num2);
											return;
										}
									}
									throw new ArgumentOutOfRangeException(tipo.ToString());
								}
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

		// Token: 0x06000088 RID: 136 RVA: 0x000070FC File Offset: 0x000052FC
		public void Update()
		{
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000070FE File Offset: 0x000052FE
		public void OnDestroy()
		{
		}

		// Token: 0x020000D4 RID: 212
		public enum TipoDeRespuesta
		{
			// Token: 0x040002A7 RID: 679
			Default,
			// Token: 0x040002A8 RID: 680
			No,
			// Token: 0x040002A9 RID: 681
			Yes
		}
	}
}
