using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Holders.CondicionesMedicas;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.BuffAndDebuff
{
	// Token: 0x0200010D RID: 269
	public class InitialMedicalConditionsBuff : CustomMonobehaviour
	{
		// Token: 0x06000917 RID: 2327 RVA: 0x000368C8 File Offset: 0x00034AC8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_BuffDeCharacter = this.GetComponentEnRoot(false);
			if (this.m_BuffDeCharacter == null)
			{
				throw new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference.");
			}
			this.m_alteradores = this.GetComponentEnRoot(false);
			if (this.m_alteradores == null)
			{
				throw new ArgumentNullException("m_alteradores", "m_alteradores null reference.");
			}
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
			base.SetYieldStart();
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x00036962 File Offset: 0x00034B62
		protected override IEnumerator YieldStartUnityEvent()
		{
			InitialMedicalConditionsBuff.<>c__DisplayClass6_0 CS$<>8__locals1 = new InitialMedicalConditionsBuff.<>c__DisplayClass6_0();
			while (!this.m_BuffDeCharacter.isStared || !this.m_alteradores.instanciado || !this.m_personalidad.isStared)
			{
				yield return null;
			}
			float num = this.m_personalidad.GetTraitScore(TraitHumano.estadoFisico).GetWeigthDeScore() + this.m_personalidad.GetTraitScore(TraitHumano.vagEndurance).GetWeigthDeScore() + this.m_personalidad.GetTraitScore(TraitHumano.anusEndurance).GetWeigthDeScore() + this.m_personalidad.GetTraitScore(TraitHumano.bocaEndurance).GetWeigthDeScore();
			num /= 4f;
			num = 1f - num;
			CS$<>8__locals1.rate = MathfExtension.LerpConMedio(0.5f, 1f, 2f, num);
			CS$<>8__locals1.isModel = MemoriaDeSMAModelosFemeninas.IsNPCHired(GlobalSingletonV2<MemoriaJson>.instance, this.m_personalidad.character.ID_UnicoString);
			List<Alterador> list = new List<Alterador>();
			this.m_alteradores.ObtenerAlteradores(list);
			for (int i = 0; i < list.Count; i++)
			{
				InitialMedicalConditionsBuff.<>c__DisplayClass6_1 CS$<>8__locals2 = new InitialMedicalConditionsBuff.<>c__DisplayClass6_1();
				CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
				CS$<>8__locals2.alterador = list[i];
				BuffAndDebuffGeneratorHelper.AddOrUpdateBuff<DisplayableBuff, BuffOfMedicalConditionArg>(this.m_BuffDeCharacter, "Tvalle.Buff.MedicalCondition", this, new BuffAndDebuffGeneratorHelper.UpdateArgumentDataHandler<BuffOfMedicalConditionArg>(CS$<>8__locals2.<YieldStartUnityEvent>g__UpdateArgumentDataHandler|0), new BuffAndDebuffGeneratorHelper.UpdateBuffConfigHandler<DisplayableBuff>(InitialMedicalConditionsBuff.<YieldStartUnityEvent>g__UpdateBuffConfigHandler|6_1), CS$<>8__locals2.alterador.nombre, null);
			}
			yield break;
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x00036974 File Offset: 0x00034B74
		private static GenericDataOfInteractionMultArg[] LoadData(string nombre, out float painGainT, out float painIncreaseT, out float painExpandT)
		{
			List<GenericDataOfInteractionMultArg> list = new List<GenericDataOfInteractionMultArg>();
			uint num = <PrivateImplementationDetails>.ComputeStringHash(nombre);
			if (num <= 2345099119U)
			{
				if (num <= 536786912U)
				{
					if (num != 250150580U)
					{
						if (num == 536786912U)
						{
							if (nombre == "Sick_MucosalVascularProminence_")
							{
								list.Add(new GenericDataOfInteractionMultArg
								{
									interationReceivedTypes = new InterationReceivedType[] { InterationReceivedType.penetration },
									fromParts = TriggeringBodyPartHelper.canPenetrateParts.ToArray<TriggeringBodyPart>(),
									toParts = new SensitiveBodyPart[]
									{
										SensitiveBodyPart.anus,
										SensitiveBodyPart.anusWalls
									}
								});
								painGainT = 0.3f;
								painIncreaseT = (painExpandT = 0.5f);
								goto IL_06B5;
							}
						}
					}
					else if (nombre == "Sick_ColonIrritable_")
					{
						list.Add(new GenericDataOfInteractionMultArg
						{
							interationReceivedTypes = new InterationReceivedType[] { InterationReceivedType.caress },
							fromParts = TriggeringBodyPartHelper.canTouchParts.ToArray<TriggeringBodyPart>(),
							toParts = new SensitiveBodyPart[]
							{
								ParteDelCuerpoHumano.vientre.GetPart(),
								ParteDelCuerpoHumano.hombligo.GetPart(),
								ParteDelCuerpoHumano.abdomen.GetPart()
							}
						});
						list.Add(new GenericDataOfInteractionMultArg
						{
							interationReceivedTypes = new InterationReceivedType[] { InterationReceivedType.penetration },
							fromParts = TriggeringBodyPartHelper.canPenetrateParts.ToArray<TriggeringBodyPart>(),
							toParts = new SensitiveBodyPart[] { SensitiveBodyPart.anusBottom }
						});
						painGainT = 0.6f;
						painIncreaseT = (painExpandT = 1f);
						goto IL_06B5;
					}
				}
				else if (num != 710740112U)
				{
					if (num != 2061893184U)
					{
						if (num == 2345099119U)
						{
							if (nombre == "Sick_NabothianCysts_")
							{
								list.Add(new GenericDataOfInteractionMultArg
								{
									interationReceivedTypes = new InterationReceivedType[] { InterationReceivedType.penetration },
									fromParts = TriggeringBodyPartHelper.canPenetrateParts.ToArray<TriggeringBodyPart>(),
									toParts = new SensitiveBodyPart[] { SensitiveBodyPart.vagBottom }
								});
								painGainT = 0.5f;
								painIncreaseT = (painExpandT = 0.5f);
								goto IL_06B5;
							}
						}
					}
					else if (nombre == "Sick_VaginalCyst_")
					{
						list.Add(new GenericDataOfInteractionMultArg
						{
							interationReceivedTypes = new InterationReceivedType[] { InterationReceivedType.penetration },
							fromParts = TriggeringBodyPartHelper.canPenetrateParts.ToArray<TriggeringBodyPart>(),
							toParts = new SensitiveBodyPart[]
							{
								SensitiveBodyPart.vag,
								SensitiveBodyPart.vagWalls
							}
						});
						painGainT = 0.5f;
						painIncreaseT = (painExpandT = 0.5f);
						goto IL_06B5;
					}
				}
				else if (nombre == "Sick_Fiebre_")
				{
					painGainT = 0f;
					painIncreaseT = (painExpandT = 0f);
					goto IL_06B5;
				}
			}
			else if (num <= 2784187069U)
			{
				if (num != 2541638720U)
				{
					if (num != 2732316013U)
					{
						if (num == 2784187069U)
						{
							if (nombre == "Sick_FibrocysticBreast_")
							{
								list.Add(new GenericDataOfInteractionMultArg
								{
									interationReceivedTypes = new InterationReceivedType[] { InterationReceivedType.caress },
									fromParts = TriggeringBodyPartHelper.canTouchParts.ToArray<TriggeringBodyPart>(),
									toParts = new SensitiveBodyPart[]
									{
										ParteDelCuerpoHumano.senos.GetPart(),
										ParteDelCuerpoHumano.pezones.GetPart()
									}
								});
								painGainT = 0.333f;
								painIncreaseT = (painExpandT = 1f);
								goto IL_06B5;
							}
						}
					}
					else if (nombre == "Sick_Constripacion_")
					{
						list.Add(new GenericDataOfInteractionMultArg
						{
							interationReceivedTypes = new InterationReceivedType[] { InterationReceivedType.caress },
							fromParts = TriggeringBodyPartHelper.canTouchParts.ToArray<TriggeringBodyPart>(),
							toParts = new SensitiveBodyPart[]
							{
								ParteDelCuerpoHumano.vientre.GetPart(),
								ParteDelCuerpoHumano.hombligo.GetPart(),
								ParteDelCuerpoHumano.abdomen.GetPart()
							}
						});
						list.Add(new GenericDataOfInteractionMultArg
						{
							interationReceivedTypes = new InterationReceivedType[] { InterationReceivedType.penetration },
							fromParts = TriggeringBodyPartHelper.canPenetrateParts.ToArray<TriggeringBodyPart>(),
							toParts = new SensitiveBodyPart[] { SensitiveBodyPart.anusBottom }
						});
						painGainT = 0.6f;
						painIncreaseT = (painExpandT = 1f);
						goto IL_06B5;
					}
				}
				else if (nombre == "Sick_MucosalIrregularity_")
				{
					list.Add(new GenericDataOfInteractionMultArg
					{
						interationReceivedTypes = new InterationReceivedType[] { InterationReceivedType.penetration },
						fromParts = TriggeringBodyPartHelper.canPenetrateParts.ToArray<TriggeringBodyPart>(),
						toParts = new SensitiveBodyPart[]
						{
							SensitiveBodyPart.anusWalls,
							SensitiveBodyPart.anusBottom
						}
					});
					painGainT = 0.5f;
					painIncreaseT = (painExpandT = 0.5f);
					goto IL_06B5;
				}
			}
			else if (num != 2836391334U)
			{
				if (num != 2861057067U)
				{
					if (num == 3112692206U)
					{
						if (nombre == "Sick_FornixSwelling_")
						{
							list.Add(new GenericDataOfInteractionMultArg
							{
								interationReceivedTypes = new InterationReceivedType[] { InterationReceivedType.penetration },
								fromParts = TriggeringBodyPartHelper.canPenetrateParts.ToArray<TriggeringBodyPart>(),
								toParts = new SensitiveBodyPart[] { SensitiveBodyPart.vagBottom }
							});
							painGainT = 0.5f;
							painIncreaseT = (painExpandT = 0.5f);
							goto IL_06B5;
						}
					}
				}
				else if (nombre == "Sick_Amigdalitis_")
				{
					list.Add(new GenericDataOfInteractionMultArg
					{
						interationReceivedTypes = new InterationReceivedType[]
						{
							InterationReceivedType.caress,
							InterationReceivedType.manipulateBody
						},
						fromParts = TriggeringBodyPartHelper.canTouchParts.ToArray<TriggeringBodyPart>(),
						toParts = new SensitiveBodyPart[] { SensitiveBodyPart.neck }
					});
					list.Add(new GenericDataOfInteractionMultArg
					{
						interationReceivedTypes = new InterationReceivedType[] { InterationReceivedType.penetration },
						fromParts = TriggeringBodyPartHelper.canPenetrateParts.ToArray<TriggeringBodyPart>(),
						toParts = new SensitiveBodyPart[] { SensitiveBodyPart.throatBottom }
					});
					painGainT = 0.5f;
					painIncreaseT = (painExpandT = 1f);
					goto IL_06B5;
				}
			}
			else if (nombre == "Sick_Hemorroides_")
			{
				list.Add(new GenericDataOfInteractionMultArg
				{
					interationReceivedTypes = new InterationReceivedType[] { InterationReceivedType.caress },
					fromParts = TriggeringBodyPartHelper.canTouchParts.ToArray<TriggeringBodyPart>(),
					toParts = new SensitiveBodyPart[] { SensitiveBodyPart.anus }
				});
				list.Add(new GenericDataOfInteractionMultArg
				{
					interationReceivedTypes = new InterationReceivedType[] { InterationReceivedType.penetration },
					fromParts = TriggeringBodyPartHelper.canPenetrateParts.ToArray<TriggeringBodyPart>(),
					toParts = new SensitiveBodyPart[]
					{
						SensitiveBodyPart.anus,
						SensitiveBodyPart.anusWalls
					}
				});
				painGainT = 1f;
				painIncreaseT = (painExpandT = 1f);
				goto IL_06B5;
			}
			throw new ArgumentOutOfRangeException(nombre.ToString());
			IL_06B5:
			return list.ToArray();
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x0003704F File Offset: 0x0003524F
		[CompilerGenerated]
		internal static void <YieldStartUnityEvent>g__UpdateBuffConfigHandler|6_1(DisplayableBuff buff, bool justInstantiated)
		{
		}

		// Token: 0x04000511 RID: 1297
		public const string condicionMedicaBuffMapID = "Tvalle.Buff.MedicalCondition";

		// Token: 0x04000512 RID: 1298
		private BuffDeCharacter m_BuffDeCharacter;

		// Token: 0x04000513 RID: 1299
		private AlteracionesDeCondicionesMedicas m_alteradores;

		// Token: 0x04000514 RID: 1300
		private Personalidad m_personalidad;

		// Token: 0x04000515 RID: 1301
		[SerializeField]
		private List<DisplayableBuff> m_buffs = new List<DisplayableBuff>();
	}
}
