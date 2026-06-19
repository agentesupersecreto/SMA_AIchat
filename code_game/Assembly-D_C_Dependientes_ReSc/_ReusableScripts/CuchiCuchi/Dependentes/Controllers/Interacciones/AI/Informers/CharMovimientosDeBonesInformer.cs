using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Informers
{
	// Token: 0x020001DE RID: 478
	public class CharMovimientosDeBonesInformer : CustomUpdatedMonobehaviourBase, ICharGuiadoDeBonesInformer, ICharManipulacionDeBonesInformer
	{
		// Token: 0x06000B69 RID: 2921 RVA: 0x00037ED9 File Offset: 0x000360D9
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_guiables = this.GetComponentsEnRoot(false);
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x00037EEE File Offset: 0x000360EE
		void ICharGuiadoDeBonesInformer.EstimulosRecibidosDe(Character productor, ICharMovimientoDeBonesInformerInstanceGetter<EstimuloPorManipulacionDeBone> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> result)
		{
			if (productor == null)
			{
				return;
			}
			if (result == null)
			{
				throw new ArgumentNullException("result", "result null reference.");
			}
			if (instanciasGetter == null)
			{
				throw new ArgumentNullException("instanciasGetter", "instanciasGetter null reference.");
			}
			CharMovimientosDeBonesInformer.LoadGuiadasDe(this.m_guiables, productor, instanciasGetter, result);
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x00037F2E File Offset: 0x0003612E
		void ICharManipulacionDeBonesInformer.EstimulosRecibidosDe(Character productor, ICharMovimientoDeBonesInformerInstanceGetter<EstimuloPorManipulacionDeBone> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> result)
		{
			if (productor == null)
			{
				return;
			}
			if (result == null)
			{
				throw new ArgumentNullException("result", "result null reference.");
			}
			if (instanciasGetter == null)
			{
				throw new ArgumentNullException("instanciasGetter", "instanciasGetter null reference.");
			}
			CharMovimientosDeBonesInformer.LoadManipuladasDe(this.m_guiables, productor, instanciasGetter, result);
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x00037F70 File Offset: 0x00036170
		private static void LoadGuiadasDe(BoneGuiable[] guiables, Character productor, ICharMovimientoDeBonesInformerInstanceGetter<EstimuloPorManipulacionDeBone> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> result)
		{
			for (int i = 0; i < guiables.Length; i++)
			{
				EstimuloPorManipulacionDeBone estimuloPorManipulacionDeBone;
				if (guiables[i].siendoGuiadoEnBonesPorCharacter.ContieneEstimuloV3<EstimuloPorManipulacionDeBone>(productor, out estimuloPorManipulacionDeBone))
				{
					ParteQuePuedeEstimular parteQuePuedeEstimular = productor.ParteQuePuedeEstimularDeTransform(estimuloPorManipulacionDeBone.transformEstimulante);
					EstimuloPorManipulacionDeBone estimuloPorManipulacionDeBone2;
					if (result.TryGetValue(parteQuePuedeEstimular, out estimuloPorManipulacionDeBone2))
					{
						estimuloPorManipulacionDeBone2.AddPartesEstimuladas(estimuloPorManipulacionDeBone.partesDelCuerpoHumanoEstimuladas);
					}
					else
					{
						EstimuloPorManipulacionDeBone estimuloPorManipulacionDeBone3 = instanciasGetter();
						estimuloPorManipulacionDeBone.CopiarA(estimuloPorManipulacionDeBone3, false);
						result.Add(parteQuePuedeEstimular, estimuloPorManipulacionDeBone3);
					}
				}
			}
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x00037FE0 File Offset: 0x000361E0
		private static void LoadManipuladasDe(BoneGuiable[] guiables, Character productor, ICharMovimientoDeBonesInformerInstanceGetter<EstimuloPorManipulacionDeBone> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> result)
		{
			for (int i = 0; i < guiables.Length; i++)
			{
				EstimuloPorManipulacionDeBone estimuloPorManipulacionDeBone;
				if (guiables[i].siendoManipuladoEnBonesPorCharacter.ContieneEstimuloV3<EstimuloPorManipulacionDeBone>(productor, out estimuloPorManipulacionDeBone))
				{
					ParteQuePuedeEstimular parteQuePuedeEstimular = productor.ParteQuePuedeEstimularDeTransform(estimuloPorManipulacionDeBone.transformEstimulante);
					EstimuloPorManipulacionDeBone estimuloPorManipulacionDeBone2;
					if (result.TryGetValue(parteQuePuedeEstimular, out estimuloPorManipulacionDeBone2))
					{
						estimuloPorManipulacionDeBone2.AddPartesEstimuladas(estimuloPorManipulacionDeBone.partesDelCuerpoHumanoEstimuladas);
					}
					else
					{
						EstimuloPorManipulacionDeBone estimuloPorManipulacionDeBone3 = instanciasGetter();
						estimuloPorManipulacionDeBone.CopiarA(estimuloPorManipulacionDeBone3, false);
						result.Add(parteQuePuedeEstimular, estimuloPorManipulacionDeBone3);
					}
				}
			}
		}

		// Token: 0x0400088C RID: 2188
		private BoneGuiable[] m_guiables;
	}
}
