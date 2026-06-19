using System;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics.AnimCollection;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.AnimCollection.Idles
{
	// Token: 0x02000565 RID: 1381
	[CreateAssetMenu(fileName = "EvaluadorDeAnimacionFemaleIdle", menuName = "Objetos/Anims/Evaluador De Animacion Female Idle")]
	[Obsolete("", true)]
	public class EvaluadorDeAnimacionFemaleIdle : EvaluadorDeAnimacionBase
	{
		// Token: 0x06002186 RID: 8582 RVA: 0x0007D298 File Offset: 0x0007B498
		[Obsolete("", true)]
		public override float Score(AnimacionEvaluableItemBase item, Character character)
		{
			AnimacionesFemaleIdlesSegunPersonalidad.Item item2 = item as AnimacionesFemaleIdlesSegunPersonalidad.Item;
			if (item2 == null)
			{
				return 0f;
			}
			Personalidad componentEnRoot = character.GetComponentEnRoot<Personalidad>();
			if (componentEnRoot == null)
			{
				return 0f;
			}
			PersonalidadDinamica para = item2.para;
			PersonalidadDinamica rasgos = componentEnRoot.currentPersonalidad.personalidad.rasgos;
			float num = 0f;
			for (int i = 0; i < rasgos.Count; i++)
			{
				PersonalidadDinamica.Par par = para[i];
				float num2 = Mathf.Abs(par.puntage - 50f);
				num2 = Mathf.InverseLerp(0f, 50f, num2).InPow(2f);
				if (num2 > 0f)
				{
					PersonalidadDinamica.Par par2 = rasgos[i];
					float num3 = Mathf.Abs(par2.puntage - 50f);
					num3 = Mathf.InverseLerp(0f, 50f, num3).InPow(2f);
					if (num3 > 0f)
					{
						if (par.rasgo != par2.rasgo)
						{
							throw new InvalidOperationException();
						}
						float num4 = Mathf.Abs(par.puntage - par2.puntage);
						num4 /= 100f;
						num4 = 1f - num4;
						num += num4 * num2 * num3;
					}
				}
			}
			return num / (float)rasgos.Count;
		}
	}
}
